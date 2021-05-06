using System.Collections.Generic;
using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using HitBtc.Net.Objects.MarginTrading;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Socket

{
    public class HitBtcSocketMarginAccountReportEvent: HitBtcSocketResponseBase<HitBtcSocketMarginAccountResponse>
    {
    }
    public class HitBtcSocketMarginAccountsEvent : HitBtcSocketResponseBase<IEnumerable<HitBtcSocketMarginAccountResponse>>
    {
    }

    public class HitBtcSocketMarginAccountResponse : HitBtcIsolatedMarginAccount
    {
        [JsonProperty("reportType"), JsonConverter(typeof(HitBtcSocketAccountReportTypeConverter))]
        public HitBtcSocketAccountReportType ReportType { get; set; }

        [JsonProperty("reportReason"), JsonConverter(typeof(HitBtcSocketAccountReportReasonConverter))]
        public HitBtcSocketAccountReportReason ReportReason { get; set; }

    }
}