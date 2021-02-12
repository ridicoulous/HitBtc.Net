using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Trading
{
    public class HitBtcTradingCommission
    {
        /// <summary>
        /// Fee rate
        /// </summary>
        [JsonProperty("takeLiquidityRate")]
        public string TakeLiquidityRate { get; set; }

        /// <summary>
        /// fee rate for market making trades
        /// </summary>
        [JsonProperty("provideLiquidityRate")]
        public string ProvideLiquidityRate { get; set; }
    }
}
