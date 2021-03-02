using HitBtc.Net.Objects.MarketData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.TradingHistory
{
    public class HitBtcTransactionsHistoryRequest : HitbtcPublicTradesFilterRequest
    {
        public HitBtcTransactionsHistoryRequest(string currency) : base()
        {
            Currency = currency;
            ShowSenders = false;

        }
        public HitBtcTransactionsHistoryRequest(string currency, string sort, long from, long till, int limit, int offset, bool showSenders) : base(sort, from, till, limit, offset)
        {
            By = "index";
            Currency = currency;
            ShowSenders = showSenders;
        }

        public HitBtcTransactionsHistoryRequest(string currency, string sort, DateTime? from, DateTime? till, int limit, int offset, bool showSenders) : base(sort, from, till, limit, offset)
        {
            Currency = currency;
            ShowSenders = showSenders;

        }
        [JsonProperty("currency")]
        public string Currency { get; private set; }

        [JsonProperty("showSenders")]
        public bool ShowSenders { get; private set; }

        [JsonProperty("by")]
        public new string By { get; private set; }

    }
}
