using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net
{
    public class HitBtcSymbolOrderBookOptions : OrderBookOptions
    {
        public HitBtcSymbolOrderBookOptions(string name, bool sequencesAreConsecutive, bool strictLevels) : base(name, sequencesAreConsecutive, strictLevels)
        {
        }
    }
}
