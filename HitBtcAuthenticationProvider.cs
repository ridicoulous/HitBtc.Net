using CryptoExchange.Net.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net
{
    public class HitBtcAuthenticationProvider : AuthenticationProvider
    {
        public HitBtcAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
        }
    }
}
