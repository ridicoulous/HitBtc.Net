using CryptoExchange.Net.Objects;
using HitBtc.Net.Objects.MarketData;
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
        WebCallResult<IEnumerable<HitBtcTrade>> GetTrade(
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
        Task<WebCallResult<IEnumerable<HitBtcTrade>>> GetTradeAsync(
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
        WebCallResult<IEnumerable<HitBtcTrade>> GetTrade(
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
        Task<WebCallResult<IEnumerable<HitBtcTrade>>> GetTradeAsync(
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
        /// Get candles for a certain symbol
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
        /// Get candles for a certain symbol
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
    }
}
