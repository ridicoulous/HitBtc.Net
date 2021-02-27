using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcSocketEventConverter : BaseConverter<HitBtcSocketEvent>
    {
        public HitBtcSocketEventConverter() : this(false) { }
        public HitBtcSocketEventConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcSocketEvent, string>> Mapping => new List<KeyValuePair<HitBtcSocketEvent, string>>
        {
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.OrderbookFullSnapshot, "snapshotOrderbook"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.OrderBookUpdated, "updateOrderbook"),


        };
    }
}
