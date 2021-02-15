using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitbtcPublicTradesFilterRequest
    {

        string sort;
        string by;
        Object from;
        Object till;
        int limit;
        int offset;

        /// <summary>
        /// Filter public trades with default parameters
        /// </summary>
        public HitbtcPublicTradesFilterRequest() : this("DESC", null, null, 100, 0) { }

        /// <summary>
        /// Filter public trades by index
        /// </summary>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="from">Interval initial value
        /// <param name="till">Interval end value
        /// <param name="limit">Max value: 1000</param>
        /// <param name="offset">Max value: 100000</param>
        public HitbtcPublicTradesFilterRequest(string sort, long from, long till, int limit, int offset)
        {
            Sort = sort;
            this.by = "id";
            this.from = from;
            this.till = till;
            Limit = limit;
            Offset = offset;
        }

        /// <summary>
        /// Filter public trades by date
        /// </summary>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="from">Interval initial value
        /// <param name="till">Interval end value
        /// <param name="limit">Max value: 1000</param>
        /// <param name="offset">Max value: 100000</param>
        public HitbtcPublicTradesFilterRequest(string sort, DateTime? from, DateTime? till, int limit, int offset)
        {
            Sort = sort;
            this.by = "timestamp";
            this.from = from;
            this.till = till;
            Limit = limit;
            Offset = offset;
        }

        /// <summary>
        /// Sort direction. Accepted values: ASC, DESC. Default value: DESC
        /// </summary>
        public string Sort
        {
            get
            {
                return sort;
            }
            private set
            {
                if (string.Equals(value, "DESC", StringComparison.OrdinalIgnoreCase))
                {
                    sort = "DESC";
                }
                else if (string.Equals(value, "ASC", StringComparison.OrdinalIgnoreCase))
                {
                    sort = "ASC";
                }
                else
                    throw new NotSupportedException("Only \"ASC\" or \"DESC\" are allowed");
            }
        }

        /// <summary>
        /// Defines filter type. Accepted values: id, timestamp. Default value: timestamp
        /// </summary>
        public string By
        {
            get
            {
                return by;
            }
        }

        /// <summary>
        /// Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise long of index value
        /// </summary>
        public Object From
        {
            get
            {
                if ("id".Equals(by))
                {
                    return (long)from;
                }
                else
                {
                    return (DateTime?)from;
                }
            }
        }

        /// <summary>
        /// Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise long of index value
        /// </summary>
        public Object Till
        {
            get
            {
                if ("id".Equals(by))
                {
                    return (long)till;
                }
                else
                {
                    return (DateTime?)till;
                }
            }
            
        }

        /// <summary>
        /// Default value: 100. Max value: 1000
        /// </summary>
        public int Limit {
                get
            {
                    return limit;
                }
                private set
            {
                    if (value < 0 || value > 1000)
                        throw new NotSupportedException("Accepted range: 0 - 1000");
                    limit = value;
                }
            }

        /// <summary>
        /// Default value: 0. Max value: 100000
        /// </summary>
        public int Offset
        {
            get
            {
                return offset;
            }
            private set
            {
                if (value < 0 || value > 100000)
                    throw new NotSupportedException("Accepted range: 0 - 100000");
                offset = value;
            }
        }
    }
}
