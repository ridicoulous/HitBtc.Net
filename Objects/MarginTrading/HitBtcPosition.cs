using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarginTrading
{
    public class HitBtcPosition
    {
        /// <summary>
        /// Position identifier.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Trading symbol.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Position quantity.
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Unrealized profit and loss valued in currency.
        /// </summary>
        [JsonProperty("pnl")]
        public decimal Pnl { get; set; }

        /// <summary>
        /// The price of the first transaction that opened a position.
        /// </summary>
        [JsonProperty("priceEntry")]
        public decimal PriceEntry { get; set; }

        /// <summary>
        /// The market price of the margin call.
        /// </summary>
        [JsonProperty("priceMarginCall")]
        public decimal PriceMarginCall { get; set; }

        /// <summary>
        /// The market price of force close.
        /// </summary>
        [JsonProperty("priceLiquidation")]
        public decimal PriceLiquidation { get; set; }

        /// <summary>
        /// Position creation date and time.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Position last update date and time.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
