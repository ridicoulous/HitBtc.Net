using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcSocketRequestConverter : BaseConverter<HitBtcSocketRequest>
    {
        public HitBtcSocketRequestConverter() : this(false) { }
        public HitBtcSocketRequestConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcSocketRequest, string>> Mapping => new List<KeyValuePair<HitBtcSocketRequest, string>>
        {
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SubscribeToOrderbook, "subscribeOrderbook"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.UnsubscribeFromOrderbook, "unsubscribeOrderbook"),


        };
    }
}
