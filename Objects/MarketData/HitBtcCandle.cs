﻿using CryptoExchange.Net.ExchangeInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    /// <summary>
    /// Candles are used for the representation of a specific symbol as an OHLC chart.
    /// </summary>
    public class HitBtcCandle : ICommonKline
    {
        /// <summary>
        /// Candle timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Open price
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; set; }

        /// <summary>
        /// Closing price
        /// </summary>
        [JsonProperty("close")]
        public decimal Close { get; set; }

        /// <summary>
        /// Lowest price for the period
        /// </summary>
        [JsonProperty("min")]
        public decimal Low { get; set; }

        /// <summary>
        /// Highest price for the period
        /// </summary>
        [JsonProperty("max")]
        public decimal High { get; set; }

        /// <summary>
        /// Volume in base currency
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Volume in quote currency
        /// </summary>
        [JsonProperty("volumeQuote")]
        public decimal VolumeQuote { get; set; }

        public decimal CommonHigh => High;

        public decimal CommonLow => Low;

        public decimal CommonOpen => Open;

        public decimal CommonClose => Close;

        public DateTime CommonOpenTime => Timestamp;

        public decimal CommonVolume => Volume;
    }

}
