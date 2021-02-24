using Newtonsoft.Json;
using System.Collections.Generic;

namespace HitBtc.Net.Objects.AccountManagement.SubAccount
{
    public class HitBtcSubAccSettingResponse
    {
        [JsonProperty("result")]
        public List<HitBtcSubAccWithdrawalSetting> Result { get; set; }

    }
}