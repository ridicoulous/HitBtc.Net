using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcTradeSideConverter : BaseConverter<HitBtcTradeSideEnum>
    {
        public HitBtcTradeSideConverter() : this(true) { }
        public HitBtcTradeSideConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcTradeSideEnum, string>> Mapping => new List<KeyValuePair<HitBtcTradeSideEnum, string>>
        {
            new KeyValuePair<HitBtcTradeSideEnum, string>(HitBtcTradeSideEnum.Buy, "buy"),
            new KeyValuePair<HitBtcTradeSideEnum, string>(HitBtcTradeSideEnum.Sell, "sell"),
        };
    }
}
