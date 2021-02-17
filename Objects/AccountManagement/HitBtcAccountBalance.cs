using Newtonsoft.Json;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcAccountBalance
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("available")]
        public decimal Available { get; set; }

        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }
    }
}
