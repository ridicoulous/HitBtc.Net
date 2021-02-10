using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcTrade
    {
        /// <summary>
        /// Trade identifier
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Trade side
        /// Accepted values: sell or buy
        /// </summary>
        [JsonProperty("side")]
        public string Side { get; set; }

        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
