using System;

namespace HitBtc.Net.Objects.AccountManagement.SubAccount
{
    public class HitBtcSubAccTransferRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subAccountId">Identifier of a sub-account to deposit/withdraw funds.</param>
        /// <param name="amount">Amount of funds to transferred.</param>
        /// <param name="currency">Name (code) of base currency, for example, "BTC".</param>
        /// <param name="type">Type of transaction. Accepted values: <c>deposit</c>,<c>withdraw</c>.</param>
        public HitBtcSubAccTransferRequest(long subAccountId, decimal amount, string currency, string type)
        {
            SubAccountId = subAccountId;
            Amount = amount;
            Currency = currency;
            if (string.Equals(type, "deposit", StringComparison.OrdinalIgnoreCase))
            {
                Type = "deposit";
            }
            else if (string.Equals(type, "withdraw", StringComparison.OrdinalIgnoreCase))
            {
                Type = "withdraw";
            }
            else
                throw new NotSupportedException("Only \"deposit\" or \"withdraw\" are allowed");
        }

        public long SubAccountId { get; private set; }
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }
        public string Type { get; private set; }    


    }
}
