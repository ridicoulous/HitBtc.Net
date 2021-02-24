using Newtonsoft.Json;

namespace HitBtc.Net.Objects.AccountManagement.SubAccount
{
    public class HitBtcSubAccWithdrawalSetting
    {
        /// <summary>
        /// Unique identifier of a sub-account.
        /// </summary>
        [JsonProperty("subAccountId")]
        public long SubAccountId { get; set; }

        /// <summary>
        /// Value indicating, whether withdrawals are enabled (true) or not (false).
        /// </summary>
        [JsonProperty("isPayoutEnabled")]
        public bool IsPayoutEnabled { get; set; }

        /// <summary>
        /// Textual description. Normally left empty.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
