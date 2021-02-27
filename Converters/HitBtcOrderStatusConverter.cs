using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcOrderStatusConverter : BaseConverter<HitBtcOrderStatus>
    {
        public HitBtcOrderStatusConverter() : this(false) { }
        public HitBtcOrderStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcOrderStatus, string>> Mapping => new List<KeyValuePair<HitBtcOrderStatus, string>>
        {
            new KeyValuePair<HitBtcOrderStatus, string>(HitBtcOrderStatus.New, "new"),
            new KeyValuePair<HitBtcOrderStatus, string>(HitBtcOrderStatus.Filled, "filled"),
            new KeyValuePair<HitBtcOrderStatus, string>(HitBtcOrderStatus.Canceled, "canceled"),
            new KeyValuePair<HitBtcOrderStatus, string>(HitBtcOrderStatus.Expired, "expired"),
            new KeyValuePair<HitBtcOrderStatus, string>(HitBtcOrderStatus.Suspended, "suspended"),
            new KeyValuePair<HitBtcOrderStatus, string>(HitBtcOrderStatus.PartiallyFilled, "partiallyFilled"),
        };
    }
}
