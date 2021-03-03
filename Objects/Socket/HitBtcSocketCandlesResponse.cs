using System.Collections.Generic;
using HitBtc.Net.Objects.MarketData;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSocketCandlesEvent : HitBtcSocketResponseBase<HitBtcSocketCandlesResponse>
    {
    }
    public class HitBtcSocketCandlesResponse
    {
        [JsonProperty("data")]
        public List<HitBtcCandle> Candles { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

    }


}