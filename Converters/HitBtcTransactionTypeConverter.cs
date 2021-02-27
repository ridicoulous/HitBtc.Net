using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcTransactionTypeConverter : BaseConverter<HitBtcTransactionType>
    {
        public HitBtcTransactionTypeConverter() : this(false) { }
        public HitBtcTransactionTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcTransactionType, string>> Mapping => new List<KeyValuePair<HitBtcTransactionType, string>>
        {
            new KeyValuePair<HitBtcTransactionType, string>(HitBtcTransactionType.BankToExchange, "bankToExchange"),
            new KeyValuePair<HitBtcTransactionType, string>(HitBtcTransactionType.ExchangeToBank, "exchangeToBank"),
            new KeyValuePair<HitBtcTransactionType, string>(HitBtcTransactionType.Deposit, "deposit"),
            new KeyValuePair<HitBtcTransactionType, string>(HitBtcTransactionType.Payout, "payout"),
            new KeyValuePair<HitBtcTransactionType, string>(HitBtcTransactionType.Withdraw, "withdraw"),
            new KeyValuePair<HitBtcTransactionType, string>(HitBtcTransactionType.Payin, "payin")
        };
    }
}
