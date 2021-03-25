using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Converters
{
    public class HitBtcSocketRequestConverter : BaseConverter<HitBtcSocketRequest>
    {
        public HitBtcSocketRequestConverter() : this(false) { }
        public HitBtcSocketRequestConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<HitBtcSocketRequest, string>> Mapping => new List<KeyValuePair<HitBtcSocketRequest, string>>
        {
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SubscribeToOrderbook, "subscribeOrderbook"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.UnsubscribeFromOrderbook, "unsubscribeOrderbook"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.Login, "login"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SubscribeToTicker, "subscribeTicker"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.UnsubscribeFromTicker, "unsubscribeTicker"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SubscribeToTrades, "subscribeTrades"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.UnsubscribeFromTrades, "unsubscribeTrades"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SubscribeToCandles, "subscribeCandles"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.UnsubscribeFromCandles, "unsubscribeCandles"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SubscribeToOrdersReports, "subscribeReports"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SubscribeToMarginReports, "marginSubscribe"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetCurrencies, "getCurrencies"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetCurrency, "getCurrency"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetSymbols, "getSymbols"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetSymbol, "getSymbol"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetTrades, "getTrades"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.PlaceOrder, "newOrder"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.CancelOrder, "cancelOrder"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.ReplaceOrder, "cancelReplaceOrder"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetOrders, "getOrders"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetTradingBalance, "getTradingBalance"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetMarginAccounts, "marginAccountsGet"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.SetMarginAccount, "marginAccountSet"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.CloseMarginPosition, "marginPositionClose"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.GetMarginOrders, "marginOrdersGet"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.CancelMarginOrders, "marginOrdersCancel"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.PlaceMarginOrder, "marginOrderNew"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.CancelMarginOrder, "marginOrderCancel"),
            new KeyValuePair<HitBtcSocketRequest, string>(HitBtcSocketRequest.ReplaceMarginOrder, "marginOrderCancelReplace"),
        };
    }
}
