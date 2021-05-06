using CryptoExchange.Net.ExchangeInterfaces;
using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcPublicTrade: ICommonRecentTrade
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
        [JsonProperty("side"), JsonConverter(typeof(HitBtcTradeSideConverter))]
        public HitBtcTradeSide Side { get; set; }

        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        public decimal CommonPrice => Price;

        public decimal CommonQuantity => Quantity;

        public DateTime CommonTradeTime => Timestamp;
    }
}
