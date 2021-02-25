using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HitBtc.Net
{
    public class HitBtcClientOptions : RestClientOptions
    {
        public HitBtcClientOptions(string baseAddress) : base(baseAddress)
        {
        }

        public HitBtcClientOptions(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress)
        {
        }
    }
}
