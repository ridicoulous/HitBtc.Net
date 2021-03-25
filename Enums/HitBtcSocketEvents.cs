using System.ComponentModel;

namespace HitBtc.Net.Enums
{
    public enum HitBtcSocketRequest
    {
        /// <summary>
        ///  You should authenticate session once before request requires authorisation. 
        /// </summary>
        [Description("login")]
        Login,

        [Description("subscribeOrderbook")]
        SubscribeToOrderbook,

        [Description("unsubscribeOrderbook")]
        UnsubscribeFromOrderbook,

        [Description("subscribeTicker")]
        SubscribeToTicker,

        [Description("unsubscribeTicker")]
        UnsubscribeFromTicker,

        [Description("subscribeTrades")]
        SubscribeToTrades,

        [Description("unsubscribeTrades")]
        UnsubscribeFromTrades,

        [Description("subscribeCandles")]
        SubscribeToCandles,

        [Description("unsubscribeCandles")]
        UnsubscribeFromCandles,

        //subscribe to orders changes
        [Description("subscribeReports")]
        SubscribeToOrdersReports,

        //subscribe to Margin Accounts, Margin orders
        [Description("marginSubscribe")]
        SubscribeToMarginReports,

        [Description("getCurrencies")]
        GetCurrencies,

        [Description("getCurrency")]
        GetCurrency,

        [Description("getSymbols")]
        GetSymbols,

        [Description("getSymbol")]
        GetSymbol,

        [Description("getTrades")]
        GetTrades,
        /// <summary>
        /// Place new order
        ///  A `report` notification will arrive before request result. 
        /// </summary>
        [Description("newOrder")]
        PlaceOrder,

        /// <summary>
        /// Cancel order
        /// </summary>
        [Description("cancelOrder")]
        CancelOrder,

        /// <summary>
        /// The Cancel/Replace request is used to change the parameters of an existing order and to change the quantity or price attribute of an open order.
        /// Do not use this request to cancel the quantity remaining in an outstanding order. Use the Cancel request message for this purpose.
        /// It is stipulated that a newly entered order cancels a prior order that has been entered, but not yet executed.
        /// </summary>
        [Description("cancelReplaceOrder")]
        ReplaceOrder,

        /// <summary>
        /// Get active orders 
        /// </summary>
        [Description("getOrders")]
        GetOrders,

        [Description("getTradingBalance")]
        GetTradingBalance,

        /// <summary>
        /// Returns a list of Isolated Margin Accounts with details about open positions.
        /// </summary>
        [Description("marginAccountsGet")]
        GetMarginAccounts,

        /// <summary>
        /// Setup Isolated Margin Account.
        /// Adds a margin for the specified symbol. Creates or updates Isolated Margin Account.
        /// Setting margin balance to zero will lead to closing Isolated Margin Account and retrieval all formerly reserved funds to the trading account.
        /// </summary>
        [Description("marginAccountSet")]
        SetMarginAccount,

        /// <summary>
        /// Closes a position for the specified symbol. This will result in cancelling all open orders within the position.
        /// </summary>
        [Description("marginPositionClose")]
        CloseMarginPosition,

        /// <summary>
        /// Returns all active margin orders. 
        /// </summary>
        [Description("marginOrdersGet")]
        GetMarginOrders,

        /// <summary>
        /// Cancel all active margin orders.
        /// </summary>
        [Description("marginOrdersCancel")]
        CancelMarginOrders,

        /// <summary>
        /// Places a new margin order. 
        /// </summary>
        [Description("marginOrderNew")]
        PlaceMarginOrder,

        /// <summary>
        ///Cancels an active margin order.
        /// </summary>
        [Description("marginOrderCancel")]
        CancelMarginOrder,

        /// <summary>
        /// Changes the parameters of an existing margin order.
        /// </summary>
        [Description("marginOrderCancelReplace")]
        ReplaceMarginOrder,

    }
    public enum HitBtcSocketEvent
    {
        /// <summary>
        /// Message contains incremental changes.
        ///size = 0 means that level has been deleted.
        ///sequence is monotonically increased for each update, each symbol has its own sequence.
        ///Notification method: updateOrderbook
        /// </summary>
        [Description("updateOrderbook")]
        OrderBookUpdated,
        /// <summary>
        /// Message contains a full snapshot of the Order Book. snapshotOrderbook
        /// </summary>
        [Description("snapshotOrderbook")]
        OrderbookFullSnapshot,


        [Description("ticker")]
        TickerUpdated,
        
        [Description("snapshotTrades")]
        TradesSnapshot,

        [Description("updateTrades")]
        TradesUpdated,

        [Description("snapshotCandles")]
        CandlesSnapshot,
       
        [Description("updateCandles")]
        CandlesUpdated,

        /// <summary>
        /// A notification with active orders is sent after subscription or on any service maintainance. 
        /// </summary>
        [Description("activeOrders")]
        ActiveOrdersSnapshot,

        // orders changes
        [Description("report")]
        OrderUpdated,

        [Description("marginOrders")]
        MarginOrdersSnapshot,

        [Description("marginAccounts")]
        MarginAccountsSnapshot,

        [Description("marginAccountReport")]
        MarginAccountUpdated,

        [Description("marginOrderReport")]
        MarginOrderUpdated
    }
}
