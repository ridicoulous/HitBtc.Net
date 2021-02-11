using Newtonsoft.Json;
using System;
using HitBtc.Net.Enums;
using HitBtc.Net.Converters;

namespace HitBtc.Net.Objects.Trading
{
    public class HitBtcOrder
    {
        /// <summary>
        /// Order unique identifier as assigned by exchange
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Order unique identifier as assigned by trader. 
        /// Uniqueness must be guaranteed within a single trading day, including all active orders.
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        /// <summary>
        /// Trading symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Trade side. Accepted values: sell or buy
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(HitBtcTradeSideConverter))]
        public HitBtcTradeSideEnum Side { get; set; }

        /// <summary>
        /// Order state
        /// Accepted values: new, suspended, partiallyFilled, filled, canceled, expired
        /// </summary>
        [JsonProperty("status"), JsonConverter(typeof(HitBtcOrderStatusConverter))]
        public HitBtcOrderStatusEnum Status { get; set; }

        /// <summary>
        /// Accepted values: limit, market, stopLimit, stopMarket
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(HitBtcOrderTypeConverter))]
        public HitBtcOrderTypeEnum Type { get; set; }

        /// <summary>
        /// Time in Force is a special instruction used when placing a trade to indicate how long an order will remain active before it is executed or expired.
        /// GTC - ''Good-Till-Cancelled'' order won't be closed until it is filled.
        /// IOC - ''Immediate-Or-Cancel'' order must be executed immediately.Any part of an IOC order that cannot be filled immediately will be cancelled.
        /// FOK - ''Fill-Or-Kill'' is a type of ''Time in Force'' designation used in securities trading that instructs a brokerage to execute a transaction immediately and completely or not execute it at all.
        /// Day - keeps the order active until the end of the trading day (UTC).
        /// GTD - ''Good-Till-Date''. The date is specified in expireTime.
        /// </summary>
        [JsonProperty("timeInForce")]
        public HitBtcOrderTimeInForceEnum TimeInForce { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Average execution price, only for history orders
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal AvgPrice { get; set; }

        /// <summary>
        /// Cumulative executed quantity
        /// </summary>
        [JsonProperty("cumQuantity")]
        public decimal CumQuantity { get; set; }

        /// <summary>
        /// Order creation date
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of order's last update
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Required for stop-limit and stop-market orders
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }

        /// <summary>
        /// A post-only order is an order that does not remove liquidity. 
        /// If your post-only order causes a match with a pre-existing order as a taker, then the order will be cancelled.
        /// </summary>
        [JsonProperty("postOnly")]
        public bool PostOnly { get; set; }

        /// <summary>
        /// Date of order expiration for timeInForce = GTD
        /// </summary>
        [JsonProperty("expireTime")]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// Optional list of trades
        /// </summary>
        [JsonProperty("tradesReport")]
        public HitBtcTrade[] TradesReport { get; set; }
            
    }
}
