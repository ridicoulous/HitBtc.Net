using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcOrderTimeInForceConverter : BaseConverter<HitBtcOrderTimeInForceEnum>
    {
        public HitBtcOrderTimeInForceConverter() : this(true) { }
        public HitBtcOrderTimeInForceConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcOrderTimeInForceEnum, string>> Mapping => new List<KeyValuePair<HitBtcOrderTimeInForceEnum, string>>
        {
            new KeyValuePair<HitBtcOrderTimeInForceEnum, string>(HitBtcOrderTimeInForceEnum.GoodTillCancelled, "GTC"),
            new KeyValuePair<HitBtcOrderTimeInForceEnum, string>(HitBtcOrderTimeInForceEnum.ImmediateOrCancel, "IOC"),
            new KeyValuePair<HitBtcOrderTimeInForceEnum, string>(HitBtcOrderTimeInForceEnum.FillOrKill, "FOK"),
            new KeyValuePair<HitBtcOrderTimeInForceEnum, string>(HitBtcOrderTimeInForceEnum.Day, "Day"),
            new KeyValuePair<HitBtcOrderTimeInForceEnum, string>(HitBtcOrderTimeInForceEnum.GoodTillDate, "GTD"),
        };
    }
}
