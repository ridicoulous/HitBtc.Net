using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcOrderTypeConverter : BaseConverter<HitBtcOrderTypeEnum>
    {
        public HitBtcOrderTypeConverter() : this(true) { }
        public HitBtcOrderTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcOrderTypeEnum, string>> Mapping => new List<KeyValuePair<HitBtcOrderTypeEnum, string>>
        {
            new KeyValuePair<HitBtcOrderTypeEnum, string>(HitBtcOrderTypeEnum.Limit, "limit"),
            new KeyValuePair<HitBtcOrderTypeEnum, string>(HitBtcOrderTypeEnum.Market, "market"),
            new KeyValuePair<HitBtcOrderTypeEnum, string>(HitBtcOrderTypeEnum.StopLimit, "stopLimit"),
            new KeyValuePair<HitBtcOrderTypeEnum, string>(HitBtcOrderTypeEnum.StopMarket, "stopMarket"),
        };
    }
}
