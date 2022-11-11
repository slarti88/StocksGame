using System.Collections.Generic;
using System.Linq;
using Shapes;
using StocksGame.StockSource.Runtime;
using UnityEngine;

namespace StocksGame.Runtime
{
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
            float dim = 4;
            SDPlot.Frame = Rect.MinMaxRect(-dim, -dim, dim, dim);   
            SDPlot.DrawLineGraph(_normalizedStockData);
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
