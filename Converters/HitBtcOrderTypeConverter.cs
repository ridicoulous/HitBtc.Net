using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcOrderTypeConverter : BaseConverter<HitBtcOrderType>
    {
        public HitBtcOrderTypeConverter() : this(true) { }
        public HitBtcOrderTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcOrderType, string>> Mapping => new List<KeyValuePair<HitBtcOrderType, string>>
        {
            new KeyValuePair<HitBtcOrderType, string>(HitBtcOrderType.Limit, "limit"),
            new KeyValuePair<HitBtcOrderType, string>(HitBtcOrderType.Market, "market"),
            new KeyValuePair<HitBtcOrderType, string>(HitBtcOrderType.StopLimit, "stopLimit"),
            new KeyValuePair<HitBtcOrderType, string>(HitBtcOrderType.StopMarket, "stopMarket"),
        };
    }
}
