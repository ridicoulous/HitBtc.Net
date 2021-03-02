using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcWithdrawRequest
    {
        private string publicComment;
        private string useOffchain;

        public HitBtcWithdrawRequest(string currency, decimal amount, string address) : this(currency, amount, address, null, false, true, "never", null ,null)
        {
            
        }

        public HitBtcWithdrawRequest(string currency,
                               decimal amount,
                               string address,
                               string paymentId,
                               bool includeFee,
                               bool autoCommit,
                               string useOffchain,
                               int? feeLevelId,
                               string publicComment)
        {
            Currency = currency;
            Amount = amount;
            Address = address;
            PaymentId = paymentId;
            IncludeFee = includeFee;
            AutoCommit = autoCommit;
            UseOffchain = useOffchain;
            FeeLevelId = feeLevelId;
            PublicComment = publicComment;
        }




        /// <summary>
        /// Currency code
        /// </summary>
        [JsonProperty("currency")]
        public string Currency {get; set; }

        /// <summary>
        /// The amount that will be sent to the specified address
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set;}

        /// <summary>
        ///  Address identifier
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set;}

        /// <summary>
        /// Optional parameter
        /// </summary>
        [JsonProperty("paymentId")]
        public string PaymentId { get; set;}

        /// <summary>
        /// Default value: false. If true is set, then total spent value will include fees.
        /// </summary>
        [JsonProperty("includeFee")]
        public bool IncludeFee { get; set; }

        /// <summary>
        /// Default value: true
        /// If false is set, then you should commit or rollback transaction in an hour.Used in two phase commit schema.
        /// </summary>
        [JsonProperty("autoCommit")]
        public bool AutoCommit { get; set; }

        /// <summary>
        /// Allow create internal offchain transfer (fast, no fees, no hash).
        /// If required selected, then only offchain transaction can be created.
        /// Available values : never, optionally, required
        /// Default value : never
        /// </summary>
        [JsonProperty("useOffchain")]
        public string UseOffchain
        {
            get { return useOffchain; }
            private set 
            {
                if (string.Equals(value, "never", StringComparison.OrdinalIgnoreCase))
                {
                    useOffchain = "never";
                }
                else if (string.Equals(value, "optionally", StringComparison.OrdinalIgnoreCase))
                {
                    useOffchain = "optionally";
                }
                else if (string.Equals(value, "required", StringComparison.OrdinalIgnoreCase))
                {
                    useOffchain = "required";
                }
                else
                    throw new NotSupportedException("Only \"never\", \"optionally\" or \"required\" are allowed");
                ; }
        }

        /// <summary>
        /// Allows you to select the desired commission level. (The level affects the speed of transactions).
        /// </summary>
        [JsonProperty("feeLevelId")]
        public int? FeeLevelId { get; set; }

        /// <summary>
        /// Allows you add comment to transaction.
        /// </summary>
        [JsonProperty("publicComment")]
        public string PublicComment
        {
            get { return publicComment;}
            private set
            {
                if (value == null || value.Length <= 255)
                {
                    publicComment = value;
                }
                else
                    throw new NotSupportedException("Maximum length of publicComment is 255");
            }
        }



    }
}
