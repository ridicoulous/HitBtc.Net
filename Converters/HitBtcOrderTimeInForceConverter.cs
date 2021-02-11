using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcOrderTimeInForceConverter : BaseConverter<HitBtcOrderTimeInForce>
    {
        public HitBtcOrderTimeInForceConverter() : this(true) { }
        public HitBtcOrderTimeInForceConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcOrderTimeInForce, string>> Mapping => new List<KeyValuePair<HitBtcOrderTimeInForce, string>>
        {
            new KeyValuePair<HitBtcOrderTimeInForce, string>(HitBtcOrderTimeInForce.GoodTillCancelled, "GTC"),
            new KeyValuePair<HitBtcOrderTimeInForce, string>(HitBtcOrderTimeInForce.ImmediateOrCancel, "IOC"),
            new KeyValuePair<HitBtcOrderTimeInForce, string>(HitBtcOrderTimeInForce.FillOrKill, "FOK"),
            new KeyValuePair<HitBtcOrderTimeInForce, string>(HitBtcOrderTimeInForce.Day, "Day"),
            new KeyValuePair<HitBtcOrderTimeInForce, string>(HitBtcOrderTimeInForce.GoodTillDate, "GTD"),
        };
    }
}
