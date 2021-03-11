using Newtonsoft.Json;
using System;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcCandlesFilterRequest
    {
        string period;
        string sort;
        DateTime? from;
        DateTime? till;
        int limit;
        int offset;

        /// <summary>
        /// Filter public trades with default parameters
        /// </summary>
        public HitBtcCandlesFilterRequest() : this("M30","ASC", null, null, 100, 0) { }

        /// <summary>
        /// Filter public trades by date
        /// </summary>
        /// <param name="period"> Accepted values: M1 (one minute), M3, M5, M15, M30, H1 (one hour), H4, D1 (one day), D7, 1M (one month)
        /// Default value: M30(30 minutes)</param>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC.</param>
        /// <param name="from">Interval initial value
        /// <param name="till">Interval end value
        /// <param name="limit">Max value: 1000</param>
        /// <param name="offset">Max value: 100000</param>
        public HitBtcCandlesFilterRequest(string period, string sort, DateTime? from, DateTime? till, int limit, int offset)
        {
            Sort = sort;
            this.from = from;
            this.till = till;
            Limit = limit;
            Offset = offset;
        }

        /// <summary>
        ///  Accepted values: M1 (one minute), M3, M5, M15, M30, H1 (one hour), H4, D1 (one day), D7, 1M (one month)
        ///  Default value: M30(30 minutes)
        /// </summary>
        [JsonProperty("period")]
        public string Period
        {
            get
            {
                return period;
            }
            private set
            {
                value = value ?? "M30";
                switch (value.ToUpper())
                {
                    case "M1":
                    case "M3":
                    case "M5":
                    case "M15":
                    case "M30":
                    case "H1":
                    case "H4":
                    case "D1":
                    case "D7":
                    case "1M":
                        period = value.ToUpper();
                        break;
                    default:
                        throw new NotSupportedException("Only one of \"M1\", \"M3\",\"M5\",\"M15\"," +
                            "\"M30\",\"H1\" \"H4\",\"D1\",\"D7\" or \"1M\" are allowed");
                }
            }
        }

        /// <summary>
        /// Sort direction. Accepted values: ASC, DESC. Default value: ASC
        /// </summary>
        [JsonProperty("sort")]
        public string Sort
        {
            get
            {
                return sort;
            }
            private set
            {
                value = value ?? "ASC";
                if (string.Equals(value, "DESC", StringComparison.OrdinalIgnoreCase))
                {
                    sort = "DESC";
                }
                else if (string.Equals(value, "ASC", StringComparison.OrdinalIgnoreCase))
                {
                    sort = "ASC";
                }
                else
                {
                    throw new NotSupportedException("Only \"ASC\" or \"DESC\" are allowed");
                }
            }
        }

        /// <summary>
        /// Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise long of index value
        /// </summary>
        [JsonProperty("from")]
        public DateTime? From
        {
            get
            {
                return from;
            }
        }

        /// <summary>
        /// Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise long of index value
        /// </summary>
        [JsonProperty("till")]
        public DateTime? Till
        {
            get
            {
                return till;
            }

        }

        /// <summary>
        /// Default value: 100. Max value: 1000
        /// </summary>
        [JsonProperty("limit")]
        public int Limit
        {
            get
            {
                return limit;
            }
            private set
            {
                if (value < 0 || value > 1000)
                {
                    throw new NotSupportedException("Accepted range: 0 - 1000");
                }
                limit = value;
            }
        }

        /// <summary>
        /// Default value: 0. Max value: 100000
        /// </summary>
        [JsonProperty("offset")]
        public int Offset
        {
            get
            {
                return offset;
            }
            private set
            {
                if (value < 0 || value > 100000)
                {
                    throw new NotSupportedException("Accepted range: 0 - 100000");
                }
                offset = value;
            }
        }
    }
}
