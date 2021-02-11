using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Trading
{
    public class HitBtcTrade
    {
        /// <summary>
        /// Trade unique identifier as assigned by exchange
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Order unique identifier as assigned by exchange
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// Order unique identifier as assigned by trader
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        /// <summary>
        /// Trading symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Trade side. Accepted values: sell or buy
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(HitBtcTradeSideConverter))]
        public HitBtcTradeSide Side { get; set; }

        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Trade commission
        /// Can be negative(''rebate'' - reward paid to a trader).
        /// See fee currency in the symbol config.
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Optional parameter. Liquidation trade flag for margin trades
        /// </summary>
        [JsonProperty("liquidation")]
        public bool Liquidation { get; set; }

        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
