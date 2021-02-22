using Newtonsoft.Json;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcFee
    {
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
    }
}
