using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcOrderStatusConverter : BaseConverter<HitBtcOrderStatusEnum>
    {
        public HitBtcOrderStatusConverter() : this(true) { }
        public HitBtcOrderStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcOrderStatusEnum, string>> Mapping => new List<KeyValuePair<HitBtcOrderStatusEnum, string>>
        {
            new KeyValuePair<HitBtcOrderStatusEnum, string>(HitBtcOrderStatusEnum.New, "new"),
            new KeyValuePair<HitBtcOrderStatusEnum, string>(HitBtcOrderStatusEnum.Filled, "filled"),
            new KeyValuePair<HitBtcOrderStatusEnum, string>(HitBtcOrderStatusEnum.Canceled, "canceled"),
            new KeyValuePair<HitBtcOrderStatusEnum, string>(HitBtcOrderStatusEnum.Expired, "expired"),
            new KeyValuePair<HitBtcOrderStatusEnum, string>(HitBtcOrderStatusEnum.Suspended, "suspended"),
            new KeyValuePair<HitBtcOrderStatusEnum, string>(HitBtcOrderStatusEnum.PartiallyFilled, "partiallyFilled"),
        };
    }
}
