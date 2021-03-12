using Newtonsoft.Json;
using System;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcTicker : CryptoExchange.Net.ExchangeInterfaces.ICommonTicker
    {
        /// <summary>
        /// Best ask price. Can return 'null' if no data
        /// </summary>
        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        /// <summary>
        /// Best bid price. Can return 'null' if no data
        /// </summary>
        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        /// <summary>
        /// Last trade price. Can return 'null' if no data
        /// </summary>
        [JsonProperty("last")]
        public decimal Last { get; set; }

        /// <summary>
        /// Last trade price 24 hours ago. Can return 'null' if no data
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; set; }

        /// <summary>
        /// Lowest trade price within 24 hours
        /// </summary>
        [JsonProperty("low")]
        public decimal Low { get; set; }

        /// <summary>
        /// Highest trade price within 24 hours
        /// </summary>
        [JsonProperty("high")]
        public decimal High { get; set; }

        /// <summary>
        /// Total trading amount within 24 hours in base currency
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Total trading amount within 24 hours in quote currency
        /// </summary>
        [JsonProperty("volumeQuote")]
        public decimal VolumeQuote { get; set; }

        /// <summary>
        /// Last update or refresh ticker timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        public string CommonSymbol => Symbol;

        public decimal CommonHigh => High;

        public decimal CommonLow => Low;

        public decimal CommonVolume => Volume;
    }
}
