using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcTransferConvResponse
    {
        [JsonProperty("result")]
        public string[] Result { get; set; }
    }
}
