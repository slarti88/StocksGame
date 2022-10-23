using System.Collections.Generic;
using System.Linq;
using Shapes;
using StocksGame.StockSource.Runtime;
using UnityEngine;
using Draw = Shapes.Draw;

namespace StocksGame.Runtime
{
    // TODO: A way to inject the drawing implementation, could be shapes, could be gameobjects etc
    public class StockView : ImmediateModeShapeDrawer
    {
        private List<float> _normalizedStockData = new List<float>();
        
        public void Show(StockSource.Runtime.StockSource source)
        {
            List<Stock> stocks = new List<Stock>();
            for (int i = 0; i < source.Count; ++i)
            {
                Stock stock        = source.GetStockAt(i);
                stocks.Add(stock);
            }
            _normalizedStockData = GetNormalizedStockValues(stocks);
        }

        public override void DrawShapes(Camera cam)
        {
            
            using (Draw.Command(cam))
            {
                int index = 0;
                foreach (var stockPoint in _normalizedStockData)
                {
                    DrawStockPoint(index,stockPoint);
                    // if (index < _normalizedStockData.Count - 1)
                    // {
                    //     DrawStockLine(_normalizedStockData[index], _normalizedStockData[index + 1], index);
                    // }
                    ++index;
                }
            }
        }

        private void DrawStockLine(float f, float f1,int index)
        {
            // set up static parameters. these are used for all following Draw.Line calls
            Draw.LineGeometry   = LineGeometry.Volumetric3D;
            Draw.ThicknessSpace = ThicknessSpace.Pixels;
            Draw.Thickness      = 4; // 4px wide

            // set static parameter to draw in the local space of this object
            Draw.Matrix = transform.localToWorldMatrix;

            // draw lines
            Draw.Line( GetStockPoint(f,index), GetStockPoint(f1,index+1),   Color.white);
            // Draw.Line( Vector3.zero, Vector3.up,      Color.green );
            // Draw.Line( Vector3.zero, Vector3.forward, Color.blue  );
        }
        
        private void DrawGraph()
        {
            // set up static parameters. these are used for all following Draw.Line calls
            Draw.LineGeometry   = LineGeometry.Volumetric3D;
            Draw.ThicknessSpace = ThicknessSpace.Pixels;
            Draw.Thickness      = 4; // 4px wide

            // set static parameter to draw in the local space of this object
            Draw.Matrix = transform.localToWorldMatrix;

            // draw lines
            Draw.Line( Vector3.zero, Vector3.right,   Color.red   );
            Draw.Line( Vector3.zero, Vector3.up,      Color.green );
            Draw.Line( Vector3.zero, Vector3.forward, Color.blue  );
        }

        private void DrawStockPoint(int index, float stockPoint)
        {
            Draw.DiscGeometry   = DiscGeometry.Flat2D;
            Draw.ThicknessSpace = ThicknessSpace.Pixels;
            Draw.Thickness      = 4;
            
            Draw.Matrix = transform.localToWorldMatrix;

            SDDraw.Circle(new Vector3(index *.1f,stockPoint *2,0),.5f);
            // Draw.Disc(new Vector3(index*.1f,stockPoint*2,0),.025f,Color.white);
        }

        private List<float> GetNormalizedStockValues(List<Stock> stocks)
        {
            float minVal = stocks.Min(stock => stock.Close);
            float maxVal = stocks.Max(stock => stock.Close);
            float range  = maxVal - minVal;
            var normalized = stocks.Select( i => (i.Close - minVal) /range)
                .ToList();
            return normalized;
        }

        Vector3 GetStockPoint(float x, float y)
        {
            return new Vector3(x * .1f, y * 2, 0);
        }
    }
}
