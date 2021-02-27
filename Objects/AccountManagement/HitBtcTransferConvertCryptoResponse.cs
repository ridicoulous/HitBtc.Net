using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcTransferConvertCryptoResponse
    {
        [JsonProperty("result")]
        public string[] TransactionIds { get; set; }
    }
}
