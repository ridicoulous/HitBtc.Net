using HitBtc.Net.Objects.MarketData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSocketOrderBookEvent : HitBtcSocketResponseBase<HitBtcSocketOrderBook>
    {
    }
    public class HitBtcSocketOrderBook
    {
        [JsonProperty("ask")]
        public List<HitBtcOrderBookEntry> Asks { get; set; }

        [JsonProperty("bid")]
        public List<HitBtcOrderBookEntry> Bid { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
