using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcCurrency
    {
        /// <summary>
        /// Currency identifier (code), for example, ''BTC''    Note: description will simply use currency in the future.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Currency full name, for example, ''Bitcoin''
        /// </summary>
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("crypto")]
        public bool Crypto { get; set; }

        [JsonProperty("payinEnabled")]
        public bool PayinEnabled { get; set; }

        [JsonProperty("payinPaymentId")]
        public bool PayinPaymentId { get; set; }

        [JsonProperty("payinConfirmations")]
        public long PayinConfirmations { get; set; }

        [JsonProperty("payoutEnabled")]
        public bool PayoutEnabled { get; set; }

        [JsonProperty("payoutIsPaymentId")]
        public bool PayoutIsPaymentId { get; set; }

        [JsonProperty("transferEnabled")]
        public bool TransferEnabled { get; set; }

        [JsonProperty("delisted")]
        public bool Delisted { get; set; }

        [JsonProperty("payoutFee")]
        public string PayoutFee { get; set; }

        [JsonProperty("payoutMinimalAmount")]
        public string PayoutMinimalAmount { get; set; }

        [JsonProperty("precisionPayout")]
        public long PrecisionPayout { get; set; }

        [JsonProperty("precisionTransfer")]
        public long PrecisionTransfer { get; set; }
    }
}
