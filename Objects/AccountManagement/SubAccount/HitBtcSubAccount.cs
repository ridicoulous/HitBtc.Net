using Newtonsoft.Json;

namespace HitBtc.Net.Objects.AccountManagement.SubAccount
{
    public class HitBtcSubAccount
    {
        /// <summary>
        /// Unique identifier of a sub-account.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Email address of a sub-account. 
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// User status of a sub-account. Accepted values: new, active, disable.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
