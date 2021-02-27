using CryptoExchange.Net.Logging;
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
            LogVerbosity = CryptoExchange.Net.Logging.LogVerbosity.Debug;
            LogWriters = new List<System.IO.TextWriter>() { new DebugTextWriter() };
        }

        public HitBtcClientOptions(HttpClient httpClient, bool sandBox = false) : base(httpClient, sandBox ? "https://api.demo.hitbtc.com/api/2" : "https://api.hitbtc.com/api/2")
        {
            LogVerbosity = CryptoExchange.Net.Logging.LogVerbosity.Debug;
            LogWriters = new List<System.IO.TextWriter>() { new DebugTextWriter() };

        }
    }
}
