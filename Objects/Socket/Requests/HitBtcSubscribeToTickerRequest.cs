using HitBtc.Net.Enums;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSubscribeToTickerRequest : HitBtcSocketSubscribeBaseRequest<HitBtcSubscribeToTickerParam>
    {
        public HitBtcSubscribeToTickerRequest(string symbol) : base(HitBtcSocketRequest.SubscribeToTicker, new HitBtcSubscribeToTickerParam(symbol))
        {
        }
        public override string EndpointSuffix { get; } = "public";
    }

    public class HitBtcSubscribeToTickerParam
    {
        public HitBtcSubscribeToTickerParam(string s)
        {
            Symbol = s;
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
