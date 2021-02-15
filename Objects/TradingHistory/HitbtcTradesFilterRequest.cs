using HitBtc.Net.Objects.MarketData;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.TradingHistory
{
    class HitbtcTradesFilterRequest : HitbtcPublicTradesFilterRequest
    {
        private string margin;

        public HitbtcTradesFilterRequest() : base()
        {
            Margin = "include";

        }
        public HitbtcTradesFilterRequest(string sort, long from, long till, int limit, int offset, string margin) : base(sort, from, till, limit, offset)
        {
            Margin = margin;
        }

        public HitbtcTradesFilterRequest(string sort, DateTime? from, DateTime? till, int limit, int offset, string margin) : base(sort, from, till, limit, offset)
        {
            Margin = margin;

        }
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
