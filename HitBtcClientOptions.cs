using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HitBtc.Net
{
    public class HitBtcClientOptions : RestClientOptions
    {
        public HitBtcClientOptions(bool sandBox = false) : base(sandBox ? "https://api.demo.hitbtc.com/api/2" : "https://api.hitbtc.com/api/2")
        {
        }

        public HitBtcClientOptions(HttpClient httpClient, bool sandBox = false) : base(httpClient, sandBox ? "https://api.demo.hitbtc.com/api/2" : "https://api.hitbtc.com/api/2")
        {
        }
    }
}
