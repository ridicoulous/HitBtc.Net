using System.Collections.Generic;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Socket

{
    public class HitBtcSocketMarginOrderReportEvent: HitBtcSocketResponseBase<HitBtcSocketMarginOrdersResponse>
    {
    }
    public class HitBtcSocketMarginActiveOrdersReportEvent : HitBtcSocketResponseBase<IEnumerable<HitBtcSocketMarginOrdersResponse>>
    {
    }

    public class HitBtcSocketMarginOrdersResponse : HitBtcSocketOrdersResponse
    {
        /// <summary>
        /// Position identifier of the trade
        /// </summary>
        [JsonProperty("tradePositionId")]
        public long TradePositionId { get; set; }

    }
}