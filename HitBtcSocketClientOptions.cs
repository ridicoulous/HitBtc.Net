﻿using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net
{
    public class HitBtcSocketClientOptions : SocketClientOptions
    {
        public HitBtcSocketClientOptions() : this("wss://api.hitbtc.com/api/2/ws/")
        {

        }
        public HitBtcSocketClientOptions(string baseAddress) : base(baseAddress)
        {
                        
        }
    }
}
