using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    public abstract class HitBtcSocketSubscribeBaseRequest<TParams>
    {
        public HitBtcSocketSubscribeBaseRequest(HitBtcSocketRequest method, TParams @params)
        {
            Parameters = @params;
            Method = method;            
        }
        [JsonProperty("method"), JsonConverter(typeof(HitBtcSocketRequestConverter))]
        public HitBtcSocketRequest Method { get; set; }
        [JsonProperty("params")]
        public TParams Parameters { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
