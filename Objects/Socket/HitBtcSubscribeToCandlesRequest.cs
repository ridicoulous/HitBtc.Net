using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    internal class HitBtcSubscribeToCandlesRequest : HitBtcSocketSubscribeBaseRequest<HitBtcSubscribeToCandlesParam>
    {
        public HitBtcSubscribeToCandlesRequest(HitBtcSubscribeToCandlesParam requestParams) : base("subscribeCandles", requestParams)
        {
        }
    }

    public class HitBtcSubscribeToCandlesParam
    {
        public HitBtcSubscribeToCandlesParam(string symbol, string period = "M30", int limit = 100)
        {
            Symbol = symbol;
            Period = period;
            Limit = limit;
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("period")]
        public string Period { get; private set; }

        [JsonProperty("limit")]
        public int Limit { get; private set; }
    }
}
