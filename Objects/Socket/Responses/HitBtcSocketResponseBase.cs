using HitBtc.Net.Enums;
using HitBtc.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Socket
{
    public abstract class HitBtcSocketResponseBase<TData>
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("method"), JsonConverter(typeof(HitBtcSocketEventConverter))]
        public HitBtcSocketEvent Method { get; set; }

        [JsonProperty("params")]
        public TData Data { get; set; }
    }
}
