

using Newtonsoft.Json;
using System;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcTransferToAnotherUserRequest
    {
        readonly string currency;
        readonly decimal amount;
        readonly string by;
        readonly string identifier;

        /// <summary>
        ///
        /// </summary>
        /// <param name="currency">Currency code</param>
        /// <param name="amount">The amount that will be transferred between balances</param>
        /// <param name="by">Accepted values: <c>email</c>,  <c>username</c></param>
        /// <param name="identifier">Identifier value. Either email or username</param>
        /// 
        public HitBtcTransferToAnotherUserRequest(string currency, decimal amount, string by, string identifier)
        {
            this.currency = currency;
            this.amount = amount;
            if (string.Equals(by, "email", StringComparison.OrdinalIgnoreCase))
                this.by = "email";
            else if (string.Equals(by, "username", StringComparison.OrdinalIgnoreCase))
                this.by = "username";
            else
                throw new NotSupportedException("Only \"email\" or \"username\" are allowed");
            this.identifier = identifier;
        }

        [JsonProperty("currency")]
        public string Currency => currency;

        [JsonProperty("amount")]
        public decimal Amount => amount;

        [JsonProperty("by")]
        public string By => by;

        [JsonProperty("identifier")]
        public string Identifier => identifier;
    }


}
