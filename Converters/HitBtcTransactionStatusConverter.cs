using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcTransactionStatusConverter : BaseConverter<HitBtcTransactionStatus>
    {
        public HitBtcTransactionStatusConverter() : this(false) { }
        public HitBtcTransactionStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcTransactionStatus, string>> Mapping => new List<KeyValuePair<HitBtcTransactionStatus, string>>
        {
            new KeyValuePair<HitBtcTransactionStatus, string>(HitBtcTransactionStatus.Created, "created"),
            new KeyValuePair<HitBtcTransactionStatus, string>(HitBtcTransactionStatus.Failed, "failed"),
            new KeyValuePair<HitBtcTransactionStatus, string>(HitBtcTransactionStatus.Pending, "pending"),
            new KeyValuePair<HitBtcTransactionStatus, string>(HitBtcTransactionStatus.Success, "success"),
        };
    }
}
