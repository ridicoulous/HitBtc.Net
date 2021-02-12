using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarginTrading
{
    public class HitBtcIsolatedMarginAccount
    {
        /// <summary>
        /// Trading symbol. Where base currency is the currency of funds reserved on the trading account
        /// for positions and quote currency is the currency of funds reserved on a Isolated Margin Account 
        /// (e.g. "BTCUSD").
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Margin leverage. The ratio of the trader's own funds to funds borrowed from the platform.
        /// </summary>
        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }

        /// <summary>
        /// Amount of currency, reserved for margin purpose.
        /// </summary>
        [JsonProperty("marginBalance")]
        public decimal MarginBalance { get; set; }

        /// <summary>
        /// Amount of currency, reserved for margin orders.
        /// </summary>
        [JsonProperty("marginBalanceOrders")]
        public string MarginBalanceOrders { get; set; }

        /// <summary>
        /// Amount of currency, reserved for margin position close.
        /// </summary>
        [JsonProperty("marginBalanceRequired")]
        public string MarginBalanceRequired { get; set; }

        /// <summary>
        /// Account creation date and time.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Account last update date and time.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Open position of the Isolated Margin Account.
        /// </summary>
        [JsonProperty("position")]
        public HitBtcPosition Position { get; set; }
    }
}
