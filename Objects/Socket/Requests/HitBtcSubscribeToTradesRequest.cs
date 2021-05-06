using HitBtc.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSubscribeToTradesRequest : HitBtcSocketSubscribeBaseRequest<HitBtcSubscribeToTradesParam>
    {
        public HitBtcSubscribeToTradesRequest(HitBtcSubscribeToTradesParam requestParams) : base(HitBtcSocketRequest.SubscribeToTrades, requestParams)
        {
        }
        public override string EndpointSuffix { get; } = "public";
    }
    public class HitBtcSubscribeToTradesParam
    {
        public HitBtcSubscribeToTradesParam(string symbol, int limit = 100)
        {
            Symbol = symbol;
            Limit = limit;
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; private set; }
    }
}
