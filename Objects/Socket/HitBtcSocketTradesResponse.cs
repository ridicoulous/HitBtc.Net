using HitBtc.Net.Objects.MarketData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSocketTradesEvent : HitBtcSocketResponseBase<HitBtcSocketTradesResponse>
    {
    }
    public class HitBtcSocketTradesResponse
    {
        [JsonProperty("data")]
        public List<HitBtcPublicTrade> Trades { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

    }
}
