using HitBtc.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSubscribeToOrderBookRequest : HitBtcSocketSubscribeBaseRequest<HitBtcOrderBookParam>
    {
        public HitBtcSubscribeToOrderBookRequest(string symbol) : base(HitBtcSocketRequest.SubscribeToOrderbook, new HitBtcOrderBookParam(symbol))
        {
        }
        public override string EndpointSuffix { get; } = "public";
    }
    public class HitBtcOrderBookParam
    {
        public HitBtcOrderBookParam(string s)
        {
            Symbol = s;
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
