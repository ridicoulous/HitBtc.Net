using HitBtc.Net.Objects.MarketData;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.TradingHistory
{
    public class HitBtcTradesFilterRequest : HitbtcPublicTradesFilterRequest
    {
        private string margin;
        public HitBtcTradesFilterRequest() : base()
        {
            Margin = "include";

        }
        public HitBtcTradesFilterRequest(string symbol, string sort, long from, long till, int limit, int offset, string margin = "include") : base(sort, from, till, limit, offset)
        {
            Symbol = symbol;
            Margin = margin;
        }

        public HitBtcTradesFilterRequest(
            string symbol,
            string sort = "DESC",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0,
            string margin = "include") : base(sort, from, till, limit, offset)
        {
            Symbol = symbol;
            Margin = margin;

        }

        public string Symbol { get; private set; }

        public string Margin
        {
            get
            {
                return margin;
            }
            private set
            {
                if (string.Equals(value, "include", StringComparison.OrdinalIgnoreCase))
                {
                    margin = "include";
                }
                else if (string.Equals(value, "only", StringComparison.OrdinalIgnoreCase))
                {
                    margin = "only";
                }
                else if (string.Equals(value, "ignore", StringComparison.OrdinalIgnoreCase))
                {
                    margin = "ignore";
                }
                else
                    throw new NotSupportedException("Only \"include\", \"only\" or \"ignore\" are allowed");
            }
        }

    }
}
