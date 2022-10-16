using System.Collections.Generic;
using System.Linq;
using Shapes;
using StocksGame.StockSource.Runtime;
using UnityEngine;
using Draw = Shapes.Draw;

namespace StocksGame.StockView.Runtime
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
            foreach (var stockPoint in _normalizedStockData)
            {
                DrawStockPoint(stockPoint);
            }
            base.DrawShapes(cam);
        }

        private void DrawStockPoint(float stockPoint)
        {
            Draw.DiscGeometry   = DiscGeometry.Flat2D;
            Draw.ThicknessSpace = ThicknessSpace.Pixels;
            Draw.Thickness      = 4;
            
            Draw.Matrix = transform.localToWorldMatrix;

            Draw.Disc(new Vector3(0,stockPoint,0),.2F,Color.white);
        }

        private List<float> GetNormalizedStockValues(List<Stock> stocks)
        {
            float minVal = stocks.Min(stock => stock.Close);
            float maxVal = stocks.Max(stock => stock.Close);
            float range  = maxVal - minVal;
            var normalized = stocks.Select( i => 100 * (i.Close - minVal) /range)
                .ToList();
            return normalized;
        }
    }
}
