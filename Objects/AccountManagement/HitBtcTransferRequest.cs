

using Newtonsoft.Json;
using System;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcTransferRequest
    {
        readonly string currency;
        readonly decimal amount;
        readonly string type;

        /// <summary>
        ///
        /// </summary>
        /// <param name="currency">Currency code</param>
        /// <param name="amount">The amount that will be transferred between balances</param>
        /// <param name="type">Accepted values: bankToExchange, exchangeToBank</param>
        public HitBtcTransferRequest(string currency, decimal amount, string type)
        {
            this.currency = currency;
            this.amount = amount;
            if (string.Equals(type, "bankToExchange", StringComparison.OrdinalIgnoreCase))
                this.type = "bankToExchange";
            else if (string.Equals(type, "exchangeToBank", StringComparison.OrdinalIgnoreCase))
                this.type = "exchangeToBank";
            else
                throw new NotSupportedException("Only \"exchangeToBank\" or \"bankToExchange\" are allowed");
        }

        [JsonProperty("currency")]
        public string Currency => currency;

        [JsonProperty("amount")]
        public decimal Amount => amount;

        [JsonProperty("type")]
        public string Type => type;
    }


}
