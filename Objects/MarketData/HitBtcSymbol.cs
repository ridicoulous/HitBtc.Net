using Newtonsoft.Json;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcSymbol
    {
        /// <summary>
        /// Symbol (currency pair) identifier, for example, ''ETHBTC''
        /// Note: description will simply use symbol in the future.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name (code) of base currency, for example, ''ETH''
        /// </summary>
        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }

        /// <summary>
        /// Name of quote currency
        /// </summary>
        [JsonProperty("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        /// <summary>
        /// Symbol quantity should be divided by this value with no remainder
        /// </summary>
        [JsonProperty("quantityIncrement")]
        public decimal QuantityIncrement { get; set; }

        /// <summary>
        /// Symbol price should be divided by this value with no remainder
        /// </summary>
        [JsonProperty("tickSize")]
        public decimal TickSize { get; set; }

        /// <summary>
        /// Default fee rate
        /// </summary>
        [JsonProperty("takeLiquidityRate")]
        public decimal TakeLiquidityRate { get; set; }

        /// <summary>
        /// Default fee rate for market making trades
        /// </summary>
        [JsonProperty("provideLiquidityRate")]
        public decimal ProvideLiquidityRate { get; set; }

        /// <summary>
        /// Value of charged fee
        /// </summary>
        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }
    }
}
