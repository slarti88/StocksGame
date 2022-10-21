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
                    ++index;
                }
            }
        }

        private void DrawStockPoint(int index, float stockPoint)
        {
            Draw.DiscGeometry   = DiscGeometry.Flat2D;
            Draw.ThicknessSpace = ThicknessSpace.Pixels;
            Draw.Thickness      = 4;
            
            Draw.Matrix = transform.localToWorldMatrix;

            Draw.Disc(new Vector3(index*.1f,stockPoint,0),.05f,Color.white);
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
    }
}
