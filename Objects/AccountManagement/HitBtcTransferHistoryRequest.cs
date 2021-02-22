using HitBtc.Net.Objects.MarketData;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.TradingHistory
{
    public class HitBtcTransferHistoryRequest : HitbtcPublicTradesFilterRequest
    {
        private string showSenders;
        public HitBtcTransferHistoryRequest(string symbol) : base()
        {
            Symbol = symbol;
            ShowSenders = false;

        }
        public HitBtcTransferHistoryRequest(string symbol, string sort, long from, long till, int limit, int offset, bool showSenders) : base(sort, from, till, limit, offset)
        {
            By = "index";
            Symbol = symbol;
            ShowSenders = showSenders;
        }

        public HitBtcTransferHistoryRequest(string symbol, string sort, DateTime? from, DateTime? till, int limit, int offset, bool showSenders) : base(sort, from, till, limit, offset)
        {
            Symbol = symbol;
            ShowSenders = showSenders;

        }

        public string Symbol { get; private set; }

        public bool ShowSenders { get; private set; }

        public new string By { get; private set; }

    }
}
