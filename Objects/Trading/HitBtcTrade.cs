using System;
using CryptoExchange.Net.ExchangeInterfaces;
using HitBtc.Net.Objects.MarketData;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Trading
{
        public class HitBtcTrade : HitBtcPublicTrade, ICommonTrade, ICommonRecentTrade
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

        /// <summary>
        /// this is an undocumented field
        /// </summary>
        [JsonProperty("pnl")]
        public decimal Pnl { get; set; }

        /// <summary>
        /// this is an undocumented field
        /// </summary>
        [JsonProperty("taker")]
        public bool Taker { get; set; }

        public string CommonId => Id.ToString();

        public decimal CommonFee => Fee;

        public string CommonFeeAsset => null;

    }
}
