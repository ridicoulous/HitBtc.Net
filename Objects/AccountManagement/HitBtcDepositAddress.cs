using Newtonsoft.Json;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcDepositAddress
    {
        /// <summary>
        /// Address for deposit
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Optional parameter
        /// If this parameter is set, it is required for deposit.
        ///</summary>
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        /// <summary>
        /// Optional parameter
        /// If this parameter is set, it is required for deposit.
        ///</summary>
        [JsonProperty("publicKey")]
        public string PublicKey { get; set; }
    }
}
