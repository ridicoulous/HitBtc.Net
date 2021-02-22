using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcTransaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
            
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("status"), JsonConverter(typeof(HitBtcTransactionStatusConverter))]
        public HitBtcTransactionStatus Status { get; set; }

        [JsonProperty("type"), JsonConverter(typeof(HitBtcTransactionTypeConverter))]
        public HitBtcTransactionType Type { get; set; }

        [JsonProperty("subType")]
        public string SubType { get; set; }
                
        [JsonProperty("offchainId")]
        public string OffchainId { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("publicComment")]
        public string PublicComment { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
