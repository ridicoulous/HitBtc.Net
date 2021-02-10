using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcBidAsk
    {
        /// <summary>
        /// Total volume of orders with the specified price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Price level
        /// </summary>
        [JsonProperty("size")]  
        public decimal Size { get; set; }
    }
}
