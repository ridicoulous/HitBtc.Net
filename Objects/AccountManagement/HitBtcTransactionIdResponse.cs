using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcTransactionIdResponse
    {
        /// <summary>
        ///  Transaction unique identifier as assigned by exchange
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    
    }
}
