using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcCandlesResponse
    {
        public Dictionary<string, List<HitBtcCandle>> Body { get; set; }

    }
}
