using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;
using HitBtc.Net.Objects.Socket.Helpers;

namespace HitBtc.Net.Converters
{
    public class HitBtcSocketEventConverter : BaseConverter<HitBtcSocketEvent>
    {
        public HitBtcSocketEventConverter() : this(false) { }
        public HitBtcSocketEventConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcSocketEvent, string>> Mapping => HitBtc.Net.Objects.Socket.Helpers.SocketMapping.HitBtcSocketResponsesAsEnumStringMappedList();
    }
}
