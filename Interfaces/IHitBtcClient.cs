using CryptoExchange.Net.Objects;
using HitBtc.Net.Objects.MarginTrading;
using HitBtc.Net.Objects.MarketData;
using HitBtc.Net.Objects.Trading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HitBtc.Net.Interfaces
{
    public interface IHitBtcClient
    {
        //TODO: decribe actions according to docs
        #region Market data
        /// <summary>
        /// Get a list of all currencies or specified currencies (GET /api/2/public/currency)
        /// </summary>
        /// <param name="currencies">Comma-separated list of currency codes. Optional parameter</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HitBtcCurrency>>> GetCurrenciesAsync(params string[] currencies);
        /// <summary>
        /// Get a list of all currencies or specified currencies (GET /api/2/public/currency)
        /// </summary>
        /// <param name="currencies">Comma-separated list of currency codes. Optional parameter</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HitBtcCurrency>> GetCurrencies(params string[] currencies);

        /// <summary>
        /// Returns the data for a certain currency. (GET /api/2/public/currency)
        /// </summary>
        /// <param name="currency">currency codes (GET /api/2/public/currency/{currency})</param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcCurrency>> GetCurrencyAsync(string currency);

        /// <summary>
        /// Returns the data for a certain currency. (GET /api/2/public/currency)
        /// </summary>
        /// <param name="currency">currency codes (GET /api/2/public/currency/{currency})</param>
        /// <returns></returns>
        WebCallResult<HitBtcCurrency> GetCurrency(string currency);

        /// <summary>
        /// Return the actual list of currency symbols (currency pairs) traded on exchange.
        /// The first listed currency of a symbol is called the base currency, 
        /// and the second currency is called the quote currency. 
        /// The currency pair indicates how much of the quote currency is needed to purchase one unit of the base currency.
        /// </summary>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HitBtcSymbol>>> GetSymbolsAsync(params string[] symbols);

        /// <summary>
        /// Return the actual list of currency symbols (currency pairs) traded on exchange.
        /// The first listed currency of a symbol is called the base currency, 
        /// and the second currency is called the quote currency. 
        /// The currency pair indicates how much of the quote currency is needed to purchase one unit of the base currency.
        /// </summary>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HitBtcSymbol>> GetSymbols(params string[] symbols);

        /// <summary>
        /// Returns the data for a certain symbol.
        /// </summary>
        /// <param name="symbol">certain symbol</param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcSymbol>> GetSymbolAsync(string symbol);

        /// <summary>
        /// Returns the data for a certain symbol.
        /// </summary>
        /// <param name="symbol">certain symbol</param>
        /// <returns></returns>
        WebCallResult<HitBtcSymbol> GetSymbol(string symbol);

        /// <summary>
        /// Get tickers for all symbols or for specified symbols
        /// </summary>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HitBtcTicker>>> GetTickersAsync(params string[] symbols);

        /// <summary>
        /// Get tickers for all symbols or for specified symbols
        /// </summary>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HitBtcTicker>> GetTickers(params string[] symbols);

        /// <summary>
        /// Get ticker for a certain symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcTicker>> GetTickerAsync(string symbol);

        /// <summary>
        /// Get ticker for a certain symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcTicker>> GetTicker(string symbol);

        #region Trades
        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        WebCallResult<HitBtcTradeResponse> GetTrades(
            string sort = "DESC",
            string by = "timestamp",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0,
            params string[] symbols);

        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcTradeResponse>> GetTradesAsync(
            string sort = "DESC",
            string by = "timestamp",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0,
            params string[] symbols);

        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="symbol">symbol code.</param>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <returns>Returns trades information for a symbol with a symbol Id</returns>
        WebCallResult<IEnumerable<Objects.MarketData.HitBtcTrade>> GetTrade(
            string symbol,
            string sort = "DESC",
            string by = "timestamp",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0);

        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="symbol">symbol code.</param>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <returns>Returns trades information for a symbol with a symbol Id</returns>
        Task<WebCallResult<IEnumerable<Objects.MarketData.HitBtcTrade>>> GetTradeAsync(
            string symbol,
            string sort = "DESC",
            string by = "timestamp",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0);

        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        WebCallResult<HitBtcTradeResponse> GetTrades(
            string sort = "DESC",
            string by = "timestamp",
            long? from = null,
            long? till = null,
            int limit = 100,
            int offset = 0,
            params string[] symbols);

        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <param name="symbols">Comma-separated list of symbol codes. Optional parameter</param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcTradeResponse>> GetTradesAsync(
            string sort = "DESC",
            string by = "timestamp",
            long? from = null,
            long? till = null,
            int limit = 100,
            int offset = 0,
            params string[] symbols);

        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="symbol">symbol code.</param>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <returns>Returns trades information for a symbol with a symbol Id</returns>
        WebCallResult<IEnumerable<Objects.MarketData.HitBtcTrade>> GetTrade(
            string symbol,
            string sort = "DESC",
            string by = "timestamp",
            long? from = null,
            long? till = null,
            int limit = 100,
            int offset = 0);

        /// <summary>
        /// Get trades for all symbols or for specified symbols (GET /api/2/public/trades)
        /// </summary>
        /// <param name="symbol">symbol code.</param>
        /// <param name="sort">Sort direction. Accepted values: ASC, DESC. Default value: DESC</param>
        /// <param name="by">Defines filter type. Accepted values: id, timestamp. Default value: timestamp</param>
        /// <param name="from">Interval initial value (optional parameter) 
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="till">Interval end value (optional parameter)
        /// If sorting by timestamp is used, then Datetime, otherwise Number of index value</param>
        /// <param name="limit">Default value: 100, Max value: 1000</param>
        /// <param name="offset">Default value: 0, Max value: 100000</param>
        /// <returns>Returns trades information for a symbol with a symbol Id</returns>
        Task<WebCallResult<IEnumerable<Objects.MarketData.HitBtcTrade>>> GetTradeAsync(
            string symbol,
            string sort = "DESC",
            string by = "timestamp",
            long? from = null,
            long? till = null,
            int limit = 100,
            int offset = 0);
        #endregion Trades

        /// <summary>
        /// Get Order Book for all symbols or for specified symbols
        /// </summary>
        /// <param name="limit">Limit of Order Book levels
        /// Default value: 100, Set 0 to view full list of Order Book levels.</param>
        /// <param name="symbol">Comma-separated list of symbol codes. Optional parameter. 
        /// If it is not provided, null or empty, the request returns an Order Book for all symbols.</param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcOrderBooksResponse>> GetOrderBooksAsync(int limit = 100, params string[] symbol);

        /// <summary>
        /// Get Order Book for all symbols or for specified symbols
        /// </summary>
        /// <param name="limit">Limit of Order Book levels
        /// Default value: 100, Set 0 to view full list of Order Book levels.</param>
        /// <param name="symbol">Comma-separated list of symbol codes. Optional parameter. 
        /// If it is not provided, null or empty, the request returns an Order Book for all symbols.</param>
        /// <returns></returns>
        WebCallResult<HitBtcOrderBooksResponse> GetOrderBooks(int limit = 100, params string[] symbol);

        /// <summary>
        /// Get Order Book for a certain symbol
        /// </summary>
        /// <param name="symbol">symbol code</param>
        /// <param name="limit">Limit of Order Book levels
        /// Default value: 100, Set 0 to view full list of Order Book levels.</param>
        /// <param name="volume">Desired volume for market depth search. Please note that if the <c>volume</c> is specified, the <c>limit</c> will be ignored, <c>askAveragePrice</c>  and <c>bidAveragePrice<c> are returned in response.</param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcOrderBook>> GetOrderBookAsync(string symbol, int limit = 100, decimal? volume = null);

        /// <summary>
        /// Get Order Book for a certain symbol
        /// </summary>
        /// <param name="symbol">symbol code</param>
        /// <param name="limit">Limit of Order Book levels
        /// Default value: 100, Set 0 to view full list of Order Book levels.</param>
        /// <param name="volume">Desired volume for market depth search. Please note that if the <c>volume</c> is specified, the <c>limit</c> will be ignored, <c>askAveragePrice</c>  and <c>bidAveragePrice<c> are returned in response.</param>
        /// <returns></returns>
        WebCallResult<HitBtcOrderBook> GetOrderBook(string symbol, int limit = 100, decimal? volume = null);

        /// <summary>
        /// Get candles for all symbols or for specified symbols (GET /api/2/public/candles)
        /// You can optionally use comma-separated list of symbols. 
        /// If it is not provided, null or empty, the request returns candles for all symbols.
        /// The result contains candles with non-zero volume only (no trades = no candles). 
        /// </summary>
        /// <param name="period">Accepted values: M1(one minute), M3, M5, M15, M30, H1(one hour), H4, D1(one day), D7, 1M (one month)
        /// Default value: M30(30 minutes)</param>
        /// <param name="sort"> Sort direction
        /// Accepted values: ASC, DESC. Default value: ASC</param>
        /// <param name="from">Datetime Interval initial value(optional parameter)</param>
        /// <param name="till">Interval end value(optional parameter)</param>
        /// <param name="limit">Limit of candles. Default value: 100. Max value: 1000</param>
        /// <param name="offset">Default value: 0. Max value: 100000</param>
        /// <param name="symbols">Comma-separated list of symbol codes.Optional parameter</param>
        /// <returns></returns>
        WebCallResult<HitBtcCandlesResponse> GetCandles(
            string period = "M30",
            string sort = "ASC",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0,
            params string[] symbols);

        /// <summary>
        /// Get candles for all symbols or for specified symbols (GET /api/2/public/candles)
        /// You can optionally use comma-separated list of symbols. 
        /// If it is not provided, null or empty, the request returns candles for all symbols.
        /// The result contains candles with non-zero volume only (no trades = no candles). 
        /// </summary>
        /// <param name="period">Accepted values: M1(one minute), M3, M5, M15, M30, H1(one hour), H4, D1(one day), D7, 1M (one month)
        /// Default value: M30(30 minutes)</param>
        /// <param name="sort"> Sort direction
        /// Accepted values: ASC, DESC. Default value: ASC</param>
        /// <param name="from">Datetime Interval initial value(optional parameter)</param>
        /// <param name="till">Interval end value(optional parameter)</param>
        /// <param name="limit">Limit of candles. Default value: 100. Max value: 1000</param>
        /// <param name="offset">Default value: 0. Max value: 100000</param>
        /// <param name="symbols">Comma-separated list of symbol codes.Optional parameter</param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcCandlesResponse>> GetCandlesAsync(
            string period = "M30",
            string sort = "ASC",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0,
            params string[] symbols);

        /// <summary>
        /// Get candles for a certain symbol. The result contains candles with non-zero volume only (no trades = no candles). 
        /// </summary>
        /// <param name="symbol">The certain symbol</param>
        /// <param name="period">Accepted values: M1(one minute), M3, M5, M15, M30, H1(one hour), H4, D1(one day), D7, 1M (one month)
        /// Default value: M30(30 minutes)</param>
        /// <param name="sort"> Sort direction
        /// Accepted values: ASC, DESC. Default value: ASC</param>
        /// <param name="from">Datetime Interval initial value(optional parameter)</param>
        /// <param name="till">Interval end value(optional parameter)</param>
        /// <param name="limit">Limit of candles. Default value: 100. Max value: 1000</param>
        /// <param name="offset">Default value: 0. Max value: 100000</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HitBtcCandle>> GetCandle(
            string symbol,
            string period = "M30",
            string sort = "ASC",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0);

        /// <summary>
        /// Get candles for a certain symbol.  The result contains candles with non-zero volume only (no trades = no candles). 
        /// </summary>
        /// <param name="symbol">The certain symbol</param>
        /// <param name="period">Accepted values: M1(one minute), M3, M5, M15, M30, H1(one hour), H4, D1(one day), D7, 1M (one month)
        /// Default value: M30(30 minutes)</param>
        /// <param name="sort"> Sort direction
        /// Accepted values: ASC, DESC. Default value: ASC</param>
        /// <param name="from">Datetime Interval initial value(optional parameter)</param>
        /// <param name="till">Interval end value(optional parameter)</param>
        /// <param name="limit">Limit of candles. Default value: 100. Max value: 1000</param>
        /// <param name="offset">Default value: 0. Max value: 100000</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HitBtcCandle>>> GetCandleAsync(
            string symbol,
            string period = "M30",
            string sort = "ASC",
            DateTime? from = null,
            DateTime? till = null,
            int limit = 100,
            int offset = 0);

        #endregion
        #region Trading
        /// <summary>
        /// Returns the user's trading balance. 
        /// Requires the "Orderbook, History, Trading balance" API key Access Right.
        /// </summary>
        /// <returns></returns>
        WebCallResult<HitBtcTradingBalance> GetTradingBalance();

        /// <summary>
        /// Returns the user's trading balance. 
        /// Requires the "Orderbook, History, Trading balance" API key Access Right.
        /// </summary>
        /// <returns></returns>
        Task<WebCallResult<HitBtcTradingBalance>> GetTradingBalanceAsync();

        /// <summary>
        /// Return array of active orders. (GET /api/2/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter to filter active orders by symbol</param>
        /// <returns>Array of orders</returns>
        WebCallResult<IEnumerable<HitBtcOrder>> GetActiveOrders(string symbol = null);

        /// <summary>
        /// Return array of active orders. (GET /api/2/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter to filter active orders by symbol</param>
        /// <returns>Array of orders</returns>
        Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetActiveOrdersAsync(string symbol = null);

        /// <summary>
        /// Get active order by clientOrderId. (GET /api/2/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId"></param>
        /// <param name="wait">Time in milliseconds (optional parameter)
        /// Max value: 60000
        /// Default value: none
        /// While using long polling request: if order is filled, 
        /// cancelled or expired order info will be returned instantly.
        /// For other order statuses, actual order info will be returned after specified wait time.</param>
        /// <returns>Order</returns>
        WebCallResult<HitBtcOrder> GetActiveOrderByClientOrderId(string clientOrderId, long? wait = null);

        /// <summary>
        /// Get active order by clientOrderId. (GET /api/2/order/{clientOrderId}) 
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId"></param>
        /// <param name="wait">Time in milliseconds (optional parameter)
        /// Max value: 60000
        /// Default value: none
        /// While using long polling request: if order is filled, 
        /// cancelled or expired order info will be returned instantly.
        /// For other order statuses, actual order info will be returned after specified wait time.</param>
        /// <returns>Order</returns>
        Task<WebCallResult<HitBtcOrder>> GetActiveOrderByClientOrderIdAsync(string clientOrderId, long? wait = null);

        /// <summary>
        /// Create new order or Update existing order. (POST /api/2/order,  PUT /api/2/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Returns the successfully created or updated order.</returns>
        WebCallResult<HitBtcOrder> PlaceOrder(HitbtcPlaceOrderRequest order);

        /// <summary>
        /// Create new order or Update existing order. (POST /api/2/order,  PUT /api/2/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Returns the successfully created or updated order.</returns>
        Task<WebCallResult<HitBtcOrder>> PlaceOrderAsync(HitbtcPlaceOrderRequest order);


        /// <summary>
        /// Cancel all active orders, or all active orders for a specified symbol. (DELETE /api/2/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter to filter active orders by symbol</param>
        /// <returns>Returns a list of cancelled orders.</returns>
        WebCallResult<IEnumerable<HitBtcOrder>> CancelOrders(string symbol = null);

        /// <summary>
        /// Cancel all active orders, or all active orders for a specified symbol. (DELETE /api/2/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter to filter active orders by symbol</param>
        /// <returns>Returns a list of cancelled orders.</returns>
        Task<WebCallResult<IEnumerable<HitBtcOrder>>> CancelOrdersAsync(string symbol = null);

        /// <summary>
        /// Cancel order by clientOrderId. (DELETE /api/2/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId">Order unique identifier as assigned by trader. </param>
        /// <returns>Returns the cancelled order.</returns>
        WebCallResult<HitBtcOrder> CancelOrderByClientOrderId(string clientOrderId);

        /// <summary>
        /// Cancel order by clientOrderId. (DELETE /api/2/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId">Order unique identifier as assigned by trader. </param>
        /// <returns>Returns the cancelled order.</returns>
        Task<WebCallResult<HitBtcOrder>> CancelOrderByClientOrderIdAsync(string clientOrderId);

        /// <summary>
        /// Get personal trading commission rate.
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        WebCallResult<HitBtcTradingCommission> GetTradingCommission(string symbol);

        /// <summary>
        /// Get personal trading commission rate.
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcTradingCommission>> GetTradingCommissionAsync(string symbol);
        #endregion Trading
        #region MarginTrading
        /// <summary>
        /// Get Isolated Margin Accounts (GET /api/2/margin/account)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns user Isolated Margin Account details.</returns>
        WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>> GetIsolatedMarginAccounts();

        /// <summary>
        /// Get Isolated Margin Accounts (GET /api/2/margin/account)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns user Isolated Margin Account details.</returns>
        Task<WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>>> GetIsolatedMarginAccountsAsync();

        /// <summary>
        /// Closes all positions and then closes all Isolated Margin Accounts. 
        /// This will completely free up any balance reserved for margin purposes.
        /// (DELETE /api/2/margin/account)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns list of the closed Isolated Margin Accounts.</returns>
        WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>> CloseAllIsolatedMarginAccounts();

        /// <summary>
        /// Closes all positions and then closes all Isolated Margin Accounts. 
        /// This will completely free up any balance reserved for margin purposes.
        /// (DELETE /api/2/margin/account)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns list of the closed Isolated Margin Accounts.</returns>
        Task<WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>>> CloseAllIsolatedMarginAccountsAsync();

        /// <summary>
        /// Get Isolated Margin Account by symbol (GET /api/2/margin/account/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">the symbol</param>
        /// <returns>Returns Isolated Margin Account details.</returns>
        WebCallResult<HitBtcIsolatedMarginAccount> GetIsolatedMarginAccount(string symbol);


        /// <summary>
        /// Get Isolated Margin Account by symbol (GET /api/2/margin/account/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">the symbol</param>
        /// <returns>Returns Isolated Margin Account details.</returns>
        Task<WebCallResult<HitBtcIsolatedMarginAccount>> GetIsolatedMarginAccountAsync(string symbol);

        /// <summary>
        /// Creates or updates margin account. 
        /// Setting margin balance to zero will lead to closing margin account
        /// and retrieval all formerly reserved funds to the trading account.
        /// (PUT /api/2/margin/account/{symbol)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Trading symbol.
        /// Where base currency is the currency of funds reserved on the trading account for positions 
        /// and quote currency is the currency of funds reserved on a margin account (e.g. "BTCUSD").</param>
        /// <param name="marginBalance">Amount of currency reserved.</param>
        /// <param name="strictValidate">The value indicating whether the marginBalance going to be checked
        /// for correct non exponential format and currency precision.</param>
        /// <returns>Returns margin account details.</returns>
        WebCallResult<HitBtcIsolatedMarginAccount> SetIsolatedMarginAccount(
            string symbol, 
            decimal marginBalance,
            bool strictValidate);

        /// <summary>
        /// Creates or updates margin account. 
        /// Setting margin balance to zero will lead to closing margin account
        /// and retrieval all formerly reserved funds to the trading account.
        /// (PUT /api/2/margin/account/{symbol)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Trading symbol.
        /// Where base currency is the currency of funds reserved on the trading account for positions 
        /// and quote currency is the currency of funds reserved on a margin account (e.g. "BTCUSD").</param>
        /// <param name="marginBalance">Amount of currency reserved.</param>
        /// <param name="strictValidate">The value indicating whether the marginBalance going to be checked
        /// for correct non exponential format and currency precision.</param>
        /// <returns>Returns margin account details.</returns>
        Task<WebCallResult<HitBtcIsolatedMarginAccount>> SetIsolatedMarginAccountAsync(
            string symbol,
            decimal marginBalance,
            bool strictValidate);

        /// <summary>
        /// Closes Isolated Margin Account by symbol.
        /// This will completely free up any balance reserved for margin purposes.
        /// (DELETE /api/2/margin/account/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">the symbol</param>
        /// <returns>Returns closed Isolated Margin Account.</returns>
        WebCallResult<HitBtcIsolatedMarginAccount> CloseIsolatedMarginAccount(string symbol);

        /// <summary>
        /// Closes Isolated Margin Account by symbol. 
        /// This will completely free up any balance reserved for margin purposes.
        /// (DELETE /api/2/margin/account/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">the symbol</param>
        /// <returns>Returns closed Isolated Margin Account.</returns>
        Task<WebCallResult<HitBtcIsolatedMarginAccount>> CloseIsolatedMarginAccountAsync(string symbol);

        /// <summary>
        /// Get Margin Positions (GET /api/2/margin/position)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns a list of open positions.</returns>
        WebCallResult<IEnumerable<HitBtcPosition>> GetMarginPositions();

        /// <summary>
        /// Get Margin Positions (GET /api/2/margin/position)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns a list of open positions.</returns>
        Task<WebCallResult<IEnumerable<HitBtcPosition>>> GetMarginPositionsAsync();

        /// <summary>
        /// Closes all open positions. (DELETE /api/2/margin/position)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns a list of the successfully closed margin positions.</returns>
        WebCallResult<IEnumerable<HitBtcPosition>> CloseMarginPositions();

        /// <summary>
        /// Closes all open positions. (DELETE /api/2/margin/position)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns>Returns a list of the successfully closed margin positions.</returns>
        Task<WebCallResult<IEnumerable<HitBtcPosition>>> CloseMarginPositionsAsync();

        /// <summary>
        /// Returns opened position for the requested symbol. (GET /api/2/margin/position/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns></returns>
        WebCallResult<HitBtcPosition> GetMarginPosition(string symbol);

        /// <summary>
        /// Returns opened position for the requested symbol. (GET /api/2/margin/position/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <returns></returns>
        Task<WebCallResult<HitBtcPosition>> GetMarginPositionAsync(string symbol);
        #endregion MarginTrading
  
        /// <summary>
        /// Closes open position by symbol. (DELETE /api/2/margin/position/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Trading symbol.</param>
        /// <param name="price">Optional parameter.
        /// if a price is defined, then close order would be an limit order with the specified price,
        /// instead, close order would be a market order with the market price.</param>
        /// <param name="strictValidate">Optional parameter.
        /// The value indicating whether the price going to be checked for incrementation within the symbol’s tick size step.See the symbol's tickSize.</param>
        /// <returns>Returns  the successfully closed margin position.</returns>
        WebCallResult<HitBtcPosition> CloseMarginPosition(
            string symbol,
            decimal? price = null,
            bool strictValidate = false);

        /// <summary>
        /// Closes open position by symbol. (DELETE /api/2/margin/position/{symbol})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Trading symbol.</param>
        /// <param name="price">Optional parameter.
        /// if a price is defined, then close order would be an limit order with the specified price,
        /// instead, close order would be a market order with the market price.</param>
        /// <param name="strictValidate">Optional parameter.
        /// The value indicating whether the price going to be checked for incrementation within the symbol’s tick size step.See the symbol's tickSize.</param>
        /// <returns>Returns  the successfully closed margin position.</returns>
        Task<WebCallResult<HitBtcPosition>> CloseMarginPositionAsync(
            string symbol,
            decimal? price = null,
            bool strictValidate = false);

        /// <summary>
        /// Get Active Margin Orders. (GET /api/2/margin/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter. Parameter to filter active orders by symbol</param>
        /// <returns>Returns an array of the active margin orders.</returns>
        WebCallResult<IEnumerable<HitBtcOrder>> GetMarginOrders(string symbol = null);

        /// <summary>
        /// Get Active Margin Orders. (GET /api/2/margin/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter. Parameter to filter active orders by symbol</param>
        /// <returns>Returns an array of the active margin orders.</returns>
        Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetMarginOrdersAsync(string symbol = null);

        /// <summary>
        /// Returns an active order by clientOrderId. (GET /api/2/margin/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId"></param>
        /// <returns></returns>
        WebCallResult<HitBtcOrder> GetMarginOrder(string clientOrderId);

        /// <summary>
        /// Returns an active order by clientOrderId. (GET /api/2/margin/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId"></param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcOrder>> GetMarginOrderAsync(string clientOrderId);

        /// <summary>
        /// Create/Update Margin Order. (POST /api/2/margin/order, PUT /api/2/margin/order/{clientOrderId})
        /// Requires the Isolated Margin Account for the order symbol.
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        WebCallResult<HitBtcOrder> PlaceMarginOrder(HitbtcPlaceOrderRequest order);

        /// <summary>
        /// Create/Update Margin Order. (POST /api/2/margin/order, PUT /api/2/margin/order/{clientOrderId})
        /// Requires the Isolated Margin Account for the order symbol.
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<WebCallResult<HitBtcOrder>> PlaceMarginOrderAsync(HitbtcPlaceOrderRequest order);

        /// <summary>
        /// Cancels all active margin orders, or all active margin orders for the specified symbol.
        /// (DELETE /api/2/margin/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter to filter active margin orders by symbol</param>
        /// <returns>Returns a list of cancelled margin orders.</returns>
        WebCallResult<IEnumerable<HitBtcOrder>> CancelMarginOrders(string symbol = null);

        /// <summary>
        /// Cancels all active margin orders, or all active margin orders for the specified symbol.
        /// (DELETE /api/2/margin/order)
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="symbol">Optional parameter to filter active margin orders by symbol</param>
        /// <returns>Returns a list of cancelled margin orders.</returns>
        Task<WebCallResult<IEnumerable<HitBtcOrder>>> CancelMarginOrdersAsync(string symbol = null);

        /// <summary>
        /// Cancel margin order by clientOrderId. (DELETE /api/2/margin/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId">Order unique identifier as assigned by trader. </param>
        /// <returns>Returns the successfully cancelled margin order.</returns>
        WebCallResult<HitBtcOrder> CancelMarginOrderByClientOrderId(string clientOrderId);

        /// <summary>
        /// Cancel margin order by clientOrderId. (DELETE /api/2/margin/order/{clientOrderId})
        /// Requires the "Place/cancel orders" API key Access Right.
        /// </summary>
        /// <param name="clientOrderId">Order unique identifier as assigned by trader. </param>
        /// <returns>Returns the successfully cancelled margin order.</returns>
        Task<WebCallResult<HitBtcOrder>> CancelMarginOrderByClientOrderIdAsync(string clientOrderId);

    }

}
