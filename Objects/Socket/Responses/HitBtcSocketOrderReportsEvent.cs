using System.Collections.Generic;
using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using HitBtc.Net.Objects.Trading;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Socket

{
    public class HitBtcSocketOrderReportEvent: HitBtcSocketResponseBase<HitBtcSocketOrdersResponse>
    {
    }
    public class HitBtcSocketActiveOrdersReportEvent : HitBtcSocketResponseBase<IEnumerable<HitBtcSocketOrdersResponse>>
    {
    }

    public class HitBtcSocketOrdersResponse : HitBtcOrder
    {
        [JsonProperty("reportType"), JsonConverter(typeof(HitBtcSocketOrderReportTypeConverter))]
        public HitBtcSocketOrderReportType ReportType { get; set; }

        /// <summary>
        /// Trade identifier. Required for reportType = trade
        /// </summary>
        [JsonProperty("tradeId")]
        public long TradeId { get; set; }

        /// <summary>
        /// Quantity of trade. Required for reportType = trade
        /// </summary>
        [JsonProperty("tradeQuantity")]
        public decimal TradeQuantity { get; set; }

        /// <summary>
        /// Trade price. Required for reportType = trade
        /// </summary>
        [JsonProperty("tradePrice")]
        public decimal TradePrice { get; set; }

        /// <summary>
        /// Fee paid for trade. Required for reportType = trade
        /// </summary>
        [JsonProperty("tradeFee")]
        public decimal TradeFee { get; set; }

        /// <summary>
        /// Identifier of replaced order
        /// </summary>
        [JsonProperty("originalRequestClientOrderId")]
        public string OriginalRequestClientOrderId { get; set; }
    }
}