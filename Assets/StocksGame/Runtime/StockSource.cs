using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace StocksGame.StockSource.Runtime
{
    public class StockSource
    {
        public int Count => _stocks.Count;

        private List<Stock> _stocks;

        public Stock GetStockAt(int index)
        {
            return _stocks[index];
        }
        
        public StockSource()
        {}

        public void Load(string sourceText)
        {
            _stocks = JsonConvert.DeserializeObject<List<Stock>>(sourceText);
        }
        
        public void Load(string sourceText, DateTime from, DateTime to)
        {
            _stocks = JsonConvert.DeserializeObject<List<Stock>>(sourceText);
            _stocks = _stocks.Where(stock =>
            {
                var dateTime = DateTime.Parse(stock.Date);
                return (dateTime > from && dateTime < to);
            }).ToList();
        }
    }

    [Serializable]
    public class Stock
    {
        [JsonProperty("Date")]
        public string Date               { get; set; }
        [JsonProperty("Symbol")]
        public string Symbol             { get; set; }
        [JsonProperty("Series")]
        public string Series             { get; set; }
        [JsonProperty("Prev Close")]
        public float    PrevClose         { get; set; }
        [JsonProperty("Open")]
        public float Open { get; set; }
        [JsonProperty("High")]
        public float    High               { get; set; }
        [JsonProperty("Low")]
        public float Low { get; set; }
        [JsonProperty("Last")]
        public float Last { get; set; }
        [JsonProperty("Close")]
        public float Close { get; set; }
        [JsonProperty("VWAP")]
        public float VWAP { get; set; }
        [JsonProperty("Volume")]
        public int    Volume             { get; set; }
        [JsonProperty("Turnover")]
        public double   Turnover           { get; set; }
        [JsonProperty("Trades")]
        public string Trades             { get; set; }
        [JsonProperty("Deliverable Volume")]
        public int    DeliverableVolume { get; set; }
        [JsonProperty("%Deliverble")]
        public float PercentDeliverble        { get; set; }
    }

}
