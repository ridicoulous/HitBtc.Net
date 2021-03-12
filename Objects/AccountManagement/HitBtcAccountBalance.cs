using CryptoExchange.Net.ExchangeInterfaces;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcAccountBalance : ICommonBalance
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("available")]
        public decimal Available { get; set; }

        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }

        public string CommonAsset => Currency;

        public decimal CommonAvailable => Available;

        public decimal CommonTotal
        {
            get
            {
                return Available + Reserved;
            }
        }
    }
}
