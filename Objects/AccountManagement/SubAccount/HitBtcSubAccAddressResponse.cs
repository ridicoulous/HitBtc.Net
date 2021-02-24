using Newtonsoft.Json;

namespace HitBtc.Net.Objects.AccountManagement.SubAccount
{
    public class HitBtcSubAccAddressResponse
    {
        [JsonProperty("result")]
        public HitBtcDepositAddress Result { get; set; }
    }
}
