using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement.SubAccount
{
    public class HitBtcSubAccBalanceResponse
    {
        [JsonProperty("result")]
        public Dictionary<string, List<HitBtcAccountBalance>> Body { get; set; }

    }
}
