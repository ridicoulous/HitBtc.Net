using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcSocketOrderReportTypeConverter : BaseConverter<HitBtcSocketOrderReportType>
    {
        public HitBtcSocketOrderReportTypeConverter() : this(false) { }
        public HitBtcSocketOrderReportTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcSocketOrderReportType, string>> Mapping => new List<KeyValuePair<HitBtcSocketOrderReportType, string>>
        {
            new KeyValuePair<HitBtcSocketOrderReportType, string>(HitBtcSocketOrderReportType.New, "new"),
            new KeyValuePair<HitBtcSocketOrderReportType, string>(HitBtcSocketOrderReportType.Status, "status"),
            new KeyValuePair<HitBtcSocketOrderReportType, string>(HitBtcSocketOrderReportType.Canceled, "canceled"),
            new KeyValuePair<HitBtcSocketOrderReportType, string>(HitBtcSocketOrderReportType.Expired, "expired"),
            new KeyValuePair<HitBtcSocketOrderReportType, string>(HitBtcSocketOrderReportType.Suspended, "suspended"),
            new KeyValuePair<HitBtcSocketOrderReportType, string>(HitBtcSocketOrderReportType.Trade, "trade"),
            new KeyValuePair<HitBtcSocketOrderReportType, string>(HitBtcSocketOrderReportType.Replaced, "replaced"),
        };
    }
}
