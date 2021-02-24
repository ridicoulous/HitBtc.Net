using Newtonsoft.Json;
using System.Collections.Generic;

namespace HitBtc.Net.Objects.AccountManagement.SubAccount
{
    public class HitBtcSubAccountResponse
    {
        [JsonProperty("result")]
        public List<HitBtcSubAccount> Result { get; set; }

    }
}
