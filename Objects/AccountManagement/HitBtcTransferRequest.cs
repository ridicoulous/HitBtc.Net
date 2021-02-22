

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

        public string Currency => currency;

        public decimal Amount => amount;

        public string Type => type;
    }


}
