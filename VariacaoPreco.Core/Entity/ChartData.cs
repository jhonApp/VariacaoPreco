using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoPreco.Core.Entity
{
    public class ChartData
    {
        public class Meta
        {
            public string currency { get; set; }
            public string symbol { get; set; }
            public string exchangeName { get; set; }
            public string instrumentType { get; set; }
            public string firstTradeDate { get; set; }
            public string regularMarketTime { get; set; }
            public string gmtoffset { get; set; }
            public string timezone { get; set; }
            public string exchangeTimezoneName { get; set; }
            public string regularMarketPrice { get; set; }
            public string chartPreviousClose { get; set; }
            public string previousClose { get; set; }
            public string scale { get; set; }
            public string priceHint { get; set; }
            public string dataGranularity { get; set; }
            public string range { get; set; }
        }

        public class CurrentTradingPeriod
        {
            public string timezone { get; set; }
            public int start { get; set; }
            public int end { get; set; }
            public int gmtoffset { get; set; }
        }

        public class Indicators
        {
            public List<Quote> quote { get; set; }
        }

        public class Quote
        {
            public List<int?> volume { get; set; }
            public List<double?> low { get; set; }
            public List<double?> close { get; set; }
            public List<double?> high { get; set; }
            public List<double?> open { get; set; }
        }
        public class Result
        {
            public Meta meta { get; set; }
            public List<int> timestamp { get; set; }
            public Indicators indicators { get; set; }
        }

        public class ChartResult
        {
            public List<Result> result { get; set; }
            public object error { get; set; }
        }

        public ChartResult chart { get; set; }
    }

}
