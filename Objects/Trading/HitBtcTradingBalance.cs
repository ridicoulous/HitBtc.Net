using CryptoExchange.Net.ExchangeInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.Trading
{
    public class HitBtcTradingBalance:ICommonBalance
    {
        /// <summary>
        /// Currency code
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Amount available for trading or transfer to main account
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }

        /// <summary>
        /// Amount reserved for active orders or incomplete transfers to main account
        /// </summary>
        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }

        public string CommonAsset => Currency;

        public decimal CommonAvailable => Available;

        public decimal CommonTotal => Reserved + Available;
    }
}
