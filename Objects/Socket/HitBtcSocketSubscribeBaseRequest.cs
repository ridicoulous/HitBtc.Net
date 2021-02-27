using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    internal abstract class HitBtcSocketSubscribeBaseRequest<TParams>
    {
        public HitBtcSocketSubscribeBaseRequest(string method, TParams @params)
        {
            Parameters = @params;
            Method = method;            
        }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("params")]
        public TParams Parameters { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
