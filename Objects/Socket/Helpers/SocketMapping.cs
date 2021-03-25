using System.Collections.Generic;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Objects.Socket.Helpers
{
    public static class SocketMapping
    {
        private static List<KeyValuePair<HitBtcSocketEvent, string>> responsesAsEnumStringMappedList = new List<KeyValuePair<HitBtcSocketEvent, string>>
        {
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.OrderBookUpdated, "updateOrderbook"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.OrderbookFullSnapshot, "snapshotOrderbook"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.TickerUpdated, "ticker"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.TradesSnapshot, "snapshotTrades"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.TradesUpdated, "updateTrades"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.CandlesSnapshot, "snapshotCandles"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.CandlesUpdated, "updateCandles"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.ActiveOrdersSnapshot, "activeOrders"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.OrderUpdated, "report"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.MarginOrdersSnapshot, "marginOrders"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.MarginAccountsSnapshot, "marginAccounts"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.MarginAccountUpdated, "marginAccountReport"),
            new KeyValuePair<HitBtcSocketEvent, string>(HitBtcSocketEvent.MarginOrderUpdated, "marginOrderReport"),
        };

        public static List<KeyValuePair<HitBtcSocketEvent, string>> HitBtcSocketResponsesAsEnumStringMappedList() => responsesAsEnumStringMappedList;
        
        public static Dictionary<string,HitBtcSocketEvent> HitBtcSocketResponsesAsStringEnumMappedDict() 
        {
            var dict = new Dictionary<string, HitBtcSocketEvent>();
            foreach (var item in responsesAsEnumStringMappedList)
            {
                dict.Add(item.Value, item.Key);
            }
            return dict;
        }


    }
}
