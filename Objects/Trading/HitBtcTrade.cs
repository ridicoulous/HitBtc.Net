using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using HitBtc.Net.Objects.MarketData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Trading
{
        public class HitBtcTrade : HitBtcPublicTrade
    {
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

    }
}
