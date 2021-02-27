using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcTradeSideConverter : BaseConverter<HitBtcTradeSide>
    {
        public HitBtcTradeSideConverter() : this(false) { }
        public HitBtcTradeSideConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcTradeSide, string>> Mapping => new List<KeyValuePair<HitBtcTradeSide, string>>
        {
            new KeyValuePair<HitBtcTradeSide, string>(HitBtcTradeSide.Buy, "buy"),
            new KeyValuePair<HitBtcTradeSide, string>(HitBtcTradeSide.Sell, "sell"),
        };
    }
}
