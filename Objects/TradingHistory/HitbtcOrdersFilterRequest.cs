using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.TradingHistory
{
    public class HitBtcOrdersFilterRequest
    {

        int limit;
        int offset;

        /// <summary>
        /// Create filter with default parameters
        /// </summary>
        public HitBtcOrdersFilterRequest() : this(null, null, null, 100, 0)
        {
        }

        /// <summary>
        /// use this to filter by client order Id
        /// </summary>
        /// <param name="clientOrderId"></param>
        public HitBtcOrdersFilterRequest(string clientOrderId)
        {
            ClientOrderId = clientOrderId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol">Optional parameter to filter orders by symbol.</param>
        /// <param name="from"></param>
        /// <param name="till"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        public HitBtcOrdersFilterRequest(string symbol, DateTime? from, DateTime? till, int limit, int offset)
        {
            Symbol = symbol;
            From = from;
            Till = till;
            Limit = limit;
            Offset = offset;
        }


        /// <summary>
        /// Optional parameter to filter orders by symbol.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }


        /// <summary>
        /// If set, other parameters will be ignored, including limit and offset.
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; private set; }


        /// <summary>
        /// Interval initial value (optional parameter) 
        /// </summary>
        [JsonProperty("from")]
        public DateTime? From { get; private set; }

        /// <summary>
        /// Interval end value (optional parameter)
        /// </summary>
        [JsonProperty("till")]
        public DateTime? Till { get; private set; }


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
                    throw new NotSupportedException("Accepted range: 0 - 1000");
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
                    throw new NotSupportedException("Accepted range: 0 - 100000");
                offset = value;
            }
        }

        public static HitBtcOrdersFilterRequest CreateFilterBySymbolRequest(string symbol)
        {
            return new HitBtcOrdersFilterRequest(symbol, null, null, 100, 0);
        }
        public static HitBtcOrdersFilterRequest CreateFilterByClOrderIdRequest(string clientOrderId)
        {
            return new HitBtcOrdersFilterRequest(clientOrderId);
        }
    }
}
