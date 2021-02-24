using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.AccountManagement
{
    public class HitBtcRequestsBoolResult
    {

        [JsonProperty("result")]
        public bool Result { get; set; }

    }


}
