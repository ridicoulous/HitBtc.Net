using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcSocketAccountReportTypeConverter : BaseConverter<HitBtcSocketAccountReportType>
    {
        public HitBtcSocketAccountReportTypeConverter() : this(false) { }
        public HitBtcSocketAccountReportTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcSocketAccountReportType, string>> Mapping => new List<KeyValuePair<HitBtcSocketAccountReportType, string>>
        {
            new KeyValuePair<HitBtcSocketAccountReportType, string>(HitBtcSocketAccountReportType.Created, "created"),
            new KeyValuePair<HitBtcSocketAccountReportType, string>(HitBtcSocketAccountReportType.Status, "status"),
            new KeyValuePair<HitBtcSocketAccountReportType, string>(HitBtcSocketAccountReportType.Updated, "updated"),
            new KeyValuePair<HitBtcSocketAccountReportType, string>(HitBtcSocketAccountReportType.Closed, "closed")
        };
    }
}
