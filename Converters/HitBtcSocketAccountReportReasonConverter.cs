using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcSocketAccountReportReasonConverter : BaseConverter<HitBtcSocketAccountReportReason>
    {
        public HitBtcSocketAccountReportReasonConverter() : this(false) { }
        public HitBtcSocketAccountReportReasonConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcSocketAccountReportReason, string>> Mapping => new List<KeyValuePair<HitBtcSocketAccountReportReason, string>>
        {
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.Created, "created"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.Status, "status"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.Updated, "updated"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.MarginChanged, "marginChanged"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.OpenTrade, "openTrade"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.CloseTrade, "closeTrade"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.FlipTrade, "flipTrade"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.Liquidated, "liquidated"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.InterestTaken, "interestTaken"),
            new KeyValuePair<HitBtcSocketAccountReportReason, string>(HitBtcSocketAccountReportReason.Closed, "closed")
        };
    }
}
