using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcFeeLevel
    {
        [JsonProperty("feeLevelId")]
        public int FeeLevelId { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }
}
