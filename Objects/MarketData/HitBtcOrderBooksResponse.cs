using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcOrderBooksResponse
    {
        public Dictionary<string, HitBtcOrderBook> Body { get; set; }

    }
}
