using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcRequestBoolResult
    {

        [JsonProperty("result")]
        public bool Result { get; set; }

    }


}
