using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Socket
{
    internal class HitBtcSubscribeToTickerRequest : HitBtcSocketSubscribeBaseRequest<HitBtcSubscribeToTickerParam>
    {
        public HitBtcSubscribeToTickerRequest(string symbol) : base("subscribeTicker", new HitBtcSubscribeToTickerParam(symbol))
        {
        }
    }

    internal class HitBtcSubscribeToTickerParam
    {
        public HitBtcSubscribeToTickerParam(string s)
        {
            Symbol = s;
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
