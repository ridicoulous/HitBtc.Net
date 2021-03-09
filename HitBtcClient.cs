using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using HitBtc.Net.Interfaces;
using HitBtc.Net.Objects.AccountManagement;
using HitBtc.Net.Objects.AccountManagement.SubAccount;
using HitBtc.Net.Objects.MarginTrading;
using HitBtc.Net.Objects.MarketData;
using HitBtc.Net.Objects.Trading;
using HitBtc.Net.Objects.TradingHistory;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HitBtc.Net.Extensions;
using Microsoft.VisualStudio.Threading;

namespace HitBtc.Net
{
    public class HitBtcClient : RestClient, IHitBtcClient
    {
        #region Endpoints
        private const string SymbolsUrl = "public/symbol";
        private const string SymbolWithSymbolUrl = "public/symbol/{}";
        private const string CurrencyUrl = "public/currency";
        private const string CurrencyWithCurrencyUrl = "public/currency/{}";
        private const string TickerUrl = "public/ticker";
        private const string TickerWithSymbolUrl = "public/ticker/{}";
        private const string TradesUrl = "public/trades";
        private const string TradesWithSymbolUrl = "public/trades/{}";
        private const string OrderBookUrl = "public/orderbook";
        private const string OrderBookWithSymbolUrl = "public/orderbook/{}";
        private const string CandlesUrl = "public/candles";
        private const string CandlesWithSymbolUrl = "public/candles/{}";
        
        private const string SubAccountsUrl = "sub-acc";
        private const string ActivateSubAccountsUrl = "sub-acc/activate";
        private const string SubAccFreezeUrl = "sub-acc/freeze";
        private const string SubAccTransferUrl = "sub-acc/transfer";
        private const string SubAccWithdrawSettingUrl = "sub-acc/acl";
        private const string SubAccWithdrawSettingWithUserIdUrl = "sub-acc/acl/{}";
        private const string SubAccBalanceWithUserIdUrl = "sub-acc/balance/{}";
        private const string SubAccDepositAddressWithUserIdCurrencyUrl = "sub-acc/deposit-address/{}/{}";

        private const string OrderWithClientOrderIdUrl = "order/{}";
        private const string OrderUrl = "order";
        private const string TradingBalanceUrl = "trading/balance";
        private const string TradingFeeWithSymbolUrl = "trading/fee/{}";

        private const string MarginOrderWithClientOrderIdUrl = "margin/order/{}";
        private const string MarginOrderUrl = "margin/order";
        private const string MarginAccountUrl = "margin/account";
        private const string MarginAccountWithSymbolUrl = "margin/account/{}";
        private const string MarginPositionUrl = "margin/position";
        private const string MarginPositionWithSymbolUrl = "margin/position/{}";

        private const string AccountBalanceUrl = "account/balance";
        private const string AccountCryptoWithdrawUrl = "account/crypto/withdraw";
        private const string AccountCryptoCheckOffchainUrl = "account/crypto/check-offchain-available";
        private const string AccountCryptoWithdrawWithIdUrl = "account/crypto/withdraw/{}";
        private const string AccountCryptoTransferConvertUrl = "account/crypto/transfer-convert";
        private const string AccountCryptoEstimateWithrdawFeesUrl = "account/crypto/estimate-withdraw";
        private const string AccountCryptoEstimateWithrdawFeesLevelsUrl = "account/crypto/estimate-withdraw-levels";
        private const string AccountCryptoAddressWithCurrencyUrl = "account/crypto/address/{}";
        private const string AccountCryptoAddressesWithCurrencyUrl = "account/crypto/addresses/{}";
        private const string AccountCryptoIsMineAddressUrl = "account/crypto/is-mine/{}";
        private const string AccountCryptoUsedAddressesWithCurrencyUrl = "account/crypto/used-addresses/{}";
        private const string AccountTransferUrl = "account/transfer";
        private const string AccountTransferInternalUrl = "account/transfer/internal";
        private const string AccountTransactionsUrl = "account/transactions";
        private const string AccountTransactionWithIdUrl = "account/transactions/{}";

        private const string HistoryTradesUrl = "history/trades";
        private const string HistoryOrderUrl = "history/order";
        private const string HistoryOrderWithOrderIdUrl = "/history/order/{}/trades";

        #endregion
        static HitBtcClientOptions defaultOptions = new HitBtcClientOptions();
        public HitBtcClient() : this("HitBtcClient", defaultOptions, null) { }
        public HitBtcClient(string key, string secret, string clientName = "HitBtcClient", bool sandBox = false) : this(clientName, new HitBtcClientOptions(sandBox), new HitBtcAuthenticationProvider(new ApiCredentials(key, secret)))
        {

        }
        public HitBtcClient(string clientName, HitBtcClientOptions exchangeOptions, HitBtcAuthenticationProvider authenticationProvider) : base(clientName, exchangeOptions, authenticationProvider)
        {
            postParametersPosition = PostParameters.InBody;
            requestBodyFormat = RequestBodyFormat.FormData;
        }
        private Uri GetUrl(string path)
        {
            return new Uri(BaseAddress + path);
        }
        public WebCallResult<HitBtcRequestsBoolResult> ActivateSubAccounts(List<long> ids) => ActivateSubAccountsAsync(ids, default).Result;

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> ActivateSubAccountsAsync(List<long> ids, CancellationToken ct = default)
        {   
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("ids", ids.AsStringParameterOrNull());
            return await SendRequest<HitBtcRequestsBoolResult>(GetUrl(ActivateSubAccountsUrl), HttpMethod.Post, ct, null, true, true);
        }

        public WebCallResult<HitBtcOrder> CancelMarginOrderByClientOrderId(string clientOrderId) => CancelMarginOrderByClientOrderIdAsync(clientOrderId).Result;

        public async Task<WebCallResult<HitBtcOrder>> CancelMarginOrderByClientOrderIdAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcOrder>(GetUrl(FillPathParameter(MarginOrderWithClientOrderIdUrl, clientOrderId)), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> CancelMarginOrders(string symbol = null) => CancelMarginOrdersAsync(symbol).Result;
        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> CancelMarginOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcOrder>>(GetUrl(MarginOrderUrl), HttpMethod.Delete, ct, symbol == null ? null : new Dictionary<string, object> {{ "symbol", symbol }},  true, true);
        }

        public WebCallResult<HitBtcOrder> CancelOrderByClientOrderId(string clientOrderId) => CancelOrderByClientOrderIdAsync(clientOrderId).Result;

        public async Task<WebCallResult<HitBtcOrder>> CancelOrderByClientOrderIdAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcOrder>(GetUrl(FillPathParameter(OrderWithClientOrderIdUrl, clientOrderId)), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> CancelOrders(string symbol = null) => CancelOrdersAsync(symbol).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> CancelOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcOrder>>(GetUrl(OrderUrl), HttpMethod.Delete, ct, symbol == null ? null : new Dictionary<string, object> { { "symbol", symbol } }, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>> CloseAllIsolatedMarginAccounts() => CloseAllIsolatedMarginAccountsAsync().Result;

        public async Task<WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>>> CloseAllIsolatedMarginAccountsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcIsolatedMarginAccount>>(GetUrl(MarginAccountUrl), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<HitBtcIsolatedMarginAccount> CloseIsolatedMarginAccount(string symbol) => CloseIsolatedMarginAccountAsync(symbol).Result;

        public async Task<WebCallResult<HitBtcIsolatedMarginAccount>> CloseIsolatedMarginAccountAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcIsolatedMarginAccount>(GetUrl(FillPathParameter(MarginAccountWithSymbolUrl, symbol)), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<HitBtcPosition> CloseMarginPosition(string symbol, decimal? price = null, bool strictValidate = false) => CloseMarginPositionAsync(symbol, price, strictValidate).Result;
        public async Task<WebCallResult<HitBtcPosition>> CloseMarginPositionAsync(string symbol, decimal? price = null, bool strictValidate = false, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("price", price);
            parameters.AddOptionalParameter("strictValidate", strictValidate);
            return await SendRequest<HitBtcPosition>(GetUrl(FillPathParameter(MarginPositionWithSymbolUrl, symbol)), HttpMethod.Delete, ct, parameters, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcPosition>> CloseMarginPositions() => CloseMarginPositionsAsync().Result;
        public async Task<WebCallResult<IEnumerable<HitBtcPosition>>> CloseMarginPositionsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcPosition>>(GetUrl(MarginPositionUrl), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<HitBtcRequestsBoolResult> CommitWithdrawCrypto(string id) => CommitWithdrawCryptoAsync(id).Result;

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> CommitWithdrawCryptoAsync(string id, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcRequestsBoolResult>(GetUrl(FillPathParameter(AccountCryptoWithdrawWithIdUrl, id)), HttpMethod.Put, ct, null, true, true);
        }

        public WebCallResult<HitBtcRequestsBoolResult> FreezeSubAccounts(List<long> ids) => FreezeSubAccountsAsync(ids).Result;

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> FreezeSubAccountsAsync(List<long> ids, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("ids", ids.AsStringParameterOrNull());
            return await SendRequest<HitBtcRequestsBoolResult>(GetUrl(SubAccFreezeUrl), HttpMethod.Post, ct, parameters, true, true);

        }

        public WebCallResult<HitBtcDepositAddress> GenerateNewDepositAddress(string currency) => GenerateNewDepositAddressAsync(currency).Result;


        public async Task<WebCallResult<HitBtcDepositAddress>> GenerateNewDepositAddressAsync(string currency, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcDepositAddress>(GetUrl(FillPathParameter(AccountCryptoAddressWithCurrencyUrl, currency)), HttpMethod.Post, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcAccountBalance>> GetAccountBalance() => GetAccountBalanceAsync().Result;
 
        public async Task<WebCallResult<IEnumerable<HitBtcAccountBalance>>> GetAccountBalanceAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcAccountBalance>>(GetUrl(AccountBalanceUrl), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcOrder> GetActiveOrderByClientOrderId(string clientOrderId, long? wait = null) => GetActiveOrderByClientOrderIdAsync(clientOrderId, wait).Result;


        public async Task<WebCallResult<HitBtcOrder>> GetActiveOrderByClientOrderIdAsync(string clientOrderId, long? wait = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("wait", wait);
            return await SendRequest<HitBtcOrder>(GetUrl(FillPathParameter(OrderWithClientOrderIdUrl, clientOrderId)), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> GetActiveOrders(string symbol = null) => GetActiveOrdersAsync(symbol).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetActiveOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            return await SendRequest<IEnumerable<HitBtcOrder>>(GetUrl(OrderUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcRequestsBoolResult> GetAddressIsMine(string address) => GetAddressIsMineAsync(address).Result;

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> GetAddressIsMineAsync(string address, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcRequestsBoolResult>(GetUrl(FillPathParameter(AccountCryptoIsMineAddressUrl, address)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcCandle>> GetCandlesForSymbol(string symbol, HitBtcCandlesFilterRequest filter) => GetCandlesForSymbolAsync(symbol, filter).Result;
        public async Task<WebCallResult<IEnumerable<HitBtcCandle>>> GetCandlesForSymbolAsync(string symbol, HitBtcCandlesFilterRequest filter, CancellationToken ct = default)
        {
            var parameters = filter.AsDictionary();
            return await SendRequest<IEnumerable<HitBtcCandle>>(GetUrl(FillPathParameter(CandlesWithSymbolUrl, symbol)), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<HitBtcCandlesResponse> GetCandles(HitBtcCandlesFilterRequest filter, params string[] symbols) => GetCandlesAsync(filter, symbols: symbols).Result;
        public async Task<WebCallResult<HitBtcCandlesResponse>> GetCandlesAsync(HitBtcCandlesFilterRequest filter, CancellationToken ct = default, params string[] symbols)
        {
            var parameters = filter.AsDictionary();
            return await SendRequest<HitBtcCandlesResponse>(GetUrl(CandlesUrl), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<IEnumerable<HitBtcCurrency>> GetCurrencies(params string[] currencies) => GetCurrenciesAsync().Result;

        public async Task<WebCallResult<IEnumerable<HitBtcCurrency>>> GetCurrenciesAsync(CancellationToken ct = default, params string[] currencies)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("currencies", currencies.AsStringParameterOrNull());
            return await SendRequest<IEnumerable<HitBtcCurrency>>(GetUrl(CurrencyUrl), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<HitBtcCurrency> GetCurrency(string currency) => GetCurrencyAsync(currency).Result;

        public async Task<WebCallResult<HitBtcCurrency>> GetCurrencyAsync(string currency, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcCurrency>(GetUrl(FillPathParameter(CurrencyWithCurrencyUrl, currency)), HttpMethod.Get, ct, null, false);
        }

        public WebCallResult<HitBtcDepositAddress> GetDepositAddress(string currency) => GetDepositAddressAsync(currency).Result;

        public async Task<WebCallResult<HitBtcDepositAddress>> GetDepositAddressAsync(string currency, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcDepositAddress>(GetUrl(FillPathParameter(AccountCryptoAddressWithCurrencyUrl, currency)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcFee> GetEstimateWithdrawFee(string currency, decimal amount) => GetEstimateWithdrawFeeAsync(currency, amount).Result;

        public async Task<WebCallResult<HitBtcFee>> GetEstimateWithdrawFeeAsync(string currency, decimal amount, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("currency", currency);
            parameters.Add("amount", amount);
            return await SendRequest<HitBtcFee>(GetUrl(AccountCryptoEstimateWithrdawFeesUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcFeeLevel>> GetEstimateWithdrawFeeLevels(string currency, decimal amount) => GetEstimateWithdrawFeeLevelsAsync(currency, amount).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcFeeLevel>>> GetEstimateWithdrawFeeLevelsAsync(string currency, decimal amount, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("currency", currency);
            parameters.Add("amount", amount);
            return await SendRequest<IEnumerable<HitBtcFeeLevel>>(GetUrl(AccountCryptoEstimateWithrdawFeesLevelsUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcIsolatedMarginAccount> GetIsolatedMarginAccount(string symbol) => GetIsolatedMarginAccountAsync(symbol).Result;

        public async Task<WebCallResult<HitBtcIsolatedMarginAccount>> GetIsolatedMarginAccountAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcIsolatedMarginAccount>(GetUrl(FillPathParameter(MarginAccountWithSymbolUrl, symbol)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>> GetIsolatedMarginAccounts() => GetIsolatedMarginAccountsAsync().Result;

        public async Task<WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>>> GetIsolatedMarginAccountsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcIsolatedMarginAccount>>(GetUrl(MarginAccountUrl), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcDepositAddress>> GetLastDepositAddresses(string currency) => GetLastDepositAddressesAsync(currency).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcDepositAddress>>> GetLastDepositAddressesAsync(string currency, CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcDepositAddress>>(GetUrl(FillPathParameter(AccountCryptoAddressesWithCurrencyUrl, currency)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcDepositAddress>> GetLastUsedDepositAddresses(string currency) => GetLastUsedDepositAddressesAsync(currency).Result;
        public async Task<WebCallResult<IEnumerable<HitBtcDepositAddress>>> GetLastUsedDepositAddressesAsync(string currency, CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcDepositAddress>>(GetUrl(FillPathParameter(AccountCryptoUsedAddressesWithCurrencyUrl, currency)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcOrder> GetMarginOrder(string clientOrderId) => GetMarginOrderAsync(clientOrderId).Result;


        public async Task<WebCallResult<HitBtcOrder>> GetMarginOrderAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcOrder>(GetUrl(FillPathParameter(MarginOrderWithClientOrderIdUrl, clientOrderId)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> GetMarginOrders(string symbol = null) => GetMarginOrdersAsync(symbol).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetMarginOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            return await SendRequest<IEnumerable<HitBtcOrder>>(GetUrl(MarginOrderUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcPosition> GetMarginPosition(string symbol) => GetMarginPositionAsync(symbol).Result;
        public async Task<WebCallResult<HitBtcPosition>> GetMarginPositionAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcPosition>(GetUrl(FillPathParameter(MarginPositionWithSymbolUrl, symbol)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcPosition>> GetMarginPositions() => GetMarginPositionsAsync().Result;

        public async Task<WebCallResult<IEnumerable<HitBtcPosition>>> GetMarginPositionsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcPosition>>(GetUrl(MarginPositionUrl), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcOrderBook> GetOrderBook(string symbol, int limit = 100, decimal? volume = null) => GetOrderBookAsync(symbol, limit, volume).Result;

        public async Task<WebCallResult<HitBtcOrderBook>> GetOrderBookAsync(string symbol, int limit = 100, decimal? volume = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("limit", limit);
            parameters.AddOptionalParameter("volume", volume);
            return await SendRequest<HitBtcOrderBook>(GetUrl(FillPathParameter(OrderBookWithSymbolUrl, symbol)), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<HitBtcOrderBooksResponse> GetOrderBooks(int limit = 100, params string[] symbols) => GetOrderBooksAsync(limit, symbols: symbols).Result;
        public async Task<WebCallResult<HitBtcOrderBooksResponse>> GetOrderBooksAsync(int limit = 100, CancellationToken ct = default, params string[] symbols)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("symbols", symbols.AsStringParameterOrNull());
            return await SendRequest<HitBtcOrderBooksResponse>(GetUrl(OrderBookUrl), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> GetOrdersHistory(HitBtcOrdersFilterRequest filter) => GetOrdersHistoryAsync(filter).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetOrdersHistoryAsync(HitBtcOrdersFilterRequest filter, CancellationToken ct = default)
        {
            var parameters = filter.AsDictionary();
            return await SendRequest<IEnumerable<HitBtcOrder>>(GetUrl(HistoryOrderUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcSubAccAddressResponse> GetSubAccAddress(long subAccountUserId, string currency) => GetSubAccAddressAsync(subAccountUserId, currency).Result;

        public async Task<WebCallResult<HitBtcSubAccAddressResponse>> GetSubAccAddressAsync(long subAccountUserId, string currency, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcSubAccAddressResponse>(GetUrl(FillPathParameter(SubAccDepositAddressWithUserIdCurrencyUrl, subAccountUserId.ToString(), currency)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcSubAccBalanceResponse> GetSubAccBalance(long subAccountUserID) => GetSubAccBalanceAsync(subAccountUserID).Result;


        public async Task<WebCallResult<HitBtcSubAccBalanceResponse>> GetSubAccBalanceAsync(long subAccountUserID, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcSubAccBalanceResponse>(GetUrl(FillPathParameter(SubAccBalanceWithUserIdUrl, subAccountUserID.ToString())), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcSubAccountResponse> GetSubAccounts() => GetSubAccountsAsync().Result;

        public async Task<WebCallResult<HitBtcSubAccountResponse>> GetSubAccountsAsync(CancellationToken ct = default)
        {
            return await SendRequest<HitBtcSubAccountResponse>(GetUrl(SubAccountsUrl), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcSubAccSettingResponse> GetSubAccWithdrawalSettings(List<long> subAccountIds) => GetSubAccWithdrawalSettingsAsync(subAccountIds).Result;

        public async Task<WebCallResult<HitBtcSubAccSettingResponse>> GetSubAccWithdrawalSettingsAsync(List<long> subAccountIds, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("subAccountIds", subAccountIds.AsStringParameterOrNull());
            return await SendRequest<HitBtcSubAccSettingResponse>(GetUrl(SubAccWithdrawSettingUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcSymbol> GetSymbol(string symbol) => GetSymbolAsync(symbol).Result;
        public async Task<WebCallResult<HitBtcSymbol>> GetSymbolAsync(string symbol, CancellationToken ct = default)
        {

            return await SendRequest<HitBtcSymbol>(GetUrl(FillPathParameter(SymbolWithSymbolUrl, symbol)), HttpMethod.Get, ct, null, false);
        }

        public WebCallResult<IEnumerable<HitBtcSymbol>> GetSymbols(params string[] symbols) => GetSymbolsAsync(default, symbols).Result; //JoinableTaskFactory.Run(async delegate { await GetSymbolsAsync(default, symbols); });

        public async Task<WebCallResult<IEnumerable<HitBtcSymbol>>> GetSymbolsAsync(CancellationToken ct = default, params string[] symbols)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbols", symbols.AsStringParameterOrNull());
            return await SendRequest<IEnumerable<HitBtcSymbol>>(GetUrl(SymbolsUrl), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<HitBtcTicker> GetTicker(string symbol) => GetTickerAsync(symbol).Result;
        public async Task<WebCallResult<HitBtcTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcTicker>(GetUrl(FillPathParameter(TickerWithSymbolUrl, symbol)), HttpMethod.Get, ct, null, false);
        }

        public WebCallResult<IEnumerable<HitBtcTicker>> GetTickers(params string[] symbols) => GetTickersAsync(symbols: symbols).Result;
        public async Task<WebCallResult<IEnumerable<HitBtcTicker>>> GetTickersAsync(CancellationToken ct = default, params string[] symbols)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbols", symbols.AsStringParameterOrNull());
            return await SendRequest<IEnumerable<HitBtcTicker>>(GetUrl(TickerUrl), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<IEnumerable<HitBtcPublicTrade>> GetTradesForSymbol(string symbol, HitbtcPublicTradesFilterRequest filter) => GetTradesForSymbolAsync(symbol, filter).Result;
        public async Task<WebCallResult<IEnumerable<HitBtcPublicTrade>>> GetTradesForSymbolAsync(string symbol, HitbtcPublicTradesFilterRequest filter, CancellationToken ct = default)
        {
            var parameters = filter.AsDictionary();
            return await SendRequest<IEnumerable<HitBtcPublicTrade>>(GetUrl(FillPathParameter(TradesWithSymbolUrl, symbol)), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<HitBtcTradeResponse> GetTrades(HitbtcPublicTradesFilterRequest filter, params string[] symbols) => GetTradesAsync(filter: filter, symbols: symbols).Result;
        public async Task<WebCallResult<HitBtcTradeResponse>> GetTradesAsync(HitbtcPublicTradesFilterRequest filter, CancellationToken ct = default, params string[] symbols)
        {
            var parameters = filter.AsDictionary();
            parameters.AddOptionalParameter("symbols", symbols.AsStringParameterOrNull());
            return await SendRequest<HitBtcTradeResponse>(GetUrl(TradesUrl), HttpMethod.Get, ct, parameters, false);
        }

        public WebCallResult<IEnumerable<HitBtcTrade>> GetTradesByOrderId(long orderId) => GetTradesByOrderIdAsync(orderId).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcTrade>>> GetTradesByOrderIdAsync(long orderId, CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBtcTrade>>(GetUrl(FillPathParameter(HistoryOrderWithOrderIdUrl, orderId.ToString())), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcTrade>> GetTradesHistory(HitBtcTradesFilterRequest filter) => GetTradesHistoryAsync(filter).Result;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<HitBtcTrade>>> GetTradesHistoryAsync(HitBtcTradesFilterRequest filter, CancellationToken ct = default)
        {
            var parameters = filter.AsDictionary();
            return await SendRequest<IEnumerable<HitBtcTrade>>(GetUrl(HistoryTradesUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<List<HitBtcTradingBalance>> GetTradingBalance() => GetTradingBalanceAsync().Result;

        public async Task<WebCallResult<List<HitBtcTradingBalance>>> GetTradingBalanceAsync(CancellationToken ct = default)
        {
            return await SendRequest<List<HitBtcTradingBalance>>(GetUrl(TradingBalanceUrl), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcTradingCommission> GetTradingCommission(string symbol) => GetTradingCommissionAsync(symbol).Result;
        public async Task<WebCallResult<HitBtcTradingCommission>> GetTradingCommissionAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcTradingCommission>(GetUrl(FillPathParameter(TradingFeeWithSymbolUrl, symbol)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<HitBtcTransaction> GetTransactionById(string transactionId) => GetTransactionByIdAsync(transactionId).Result;
        public async Task<WebCallResult<HitBtcTransaction>> GetTransactionByIdAsync(string transactionId, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcTransaction>(GetUrl(FillPathParameter(AccountTransactionWithIdUrl, transactionId)), HttpMethod.Get, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcTransaction>> GetTransactions(HitBtcTransactionsHistoryRequest request) => GetTransactionsAsync(request).Result;
        public async Task<WebCallResult<IEnumerable<HitBtcTransaction>>> GetTransactionsAsync(HitBtcTransactionsHistoryRequest request, CancellationToken ct = default)
        {
            var parameters = request.AsDictionary();
            return await SendRequest<IEnumerable<HitBtcTransaction>>(GetUrl(AccountTransactionsUrl), HttpMethod.Get, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcOrder> PlaceMarginOrder(HitbtcPlaceOrderRequest order) => PlaceMarginOrderAsync(order).Result;
        public async Task<WebCallResult<HitBtcOrder>> PlaceMarginOrderAsync(HitbtcPlaceOrderRequest order, CancellationToken ct = default)
        {
            var parameters = order.AsDictionary();
            return await SendRequest<HitBtcOrder>(GetUrl(MarginOrderUrl), HttpMethod.Post, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcOrder> PlaceOrder(HitbtcPlaceOrderRequest order) => PlaceOrderAsync(order).Result;

        public async Task<WebCallResult<HitBtcOrder>> PlaceOrderAsync(HitbtcPlaceOrderRequest order, CancellationToken ct = default)
        {
            var parameters = order.AsDictionary();
            return await SendRequest<HitBtcOrder>(GetUrl(OrderUrl), HttpMethod.Post, ct, parameters, true, false);
        }

        public WebCallResult<HitBtcRequestsBoolResult> RollbackWithdrawCrypto(string id) => RollbackWithdrawCryptoAsync(id).Result;
        public async Task<WebCallResult<HitBtcRequestsBoolResult>> RollbackWithdrawCryptoAsync(string id, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcRequestsBoolResult>(GetUrl(FillPathParameter(AccountCryptoWithdrawWithIdUrl, id)), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<HitBtcIsolatedMarginAccount> SetIsolatedMarginAccount(string symbol, decimal marginBalance, bool strictValidate) => SetIsolatedMarginAccountAsync(symbol, marginBalance, strictValidate).Result;

        public async Task<WebCallResult<HitBtcIsolatedMarginAccount>> SetIsolatedMarginAccountAsync(string symbol, decimal marginBalance, bool strictValidate, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("marginBalance", marginBalance);
            parameters.Add("strictValidate", strictValidate);
            return await SendRequest<HitBtcIsolatedMarginAccount>(GetUrl(FillPathParameter(MarginAccountWithSymbolUrl, symbol)), HttpMethod.Put, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcSubAccSettingResponse> SetSubAccWithdrawalSettings(HitBtcSubAccWithdrawalSetting request) => SetSubAccWithdrawalSettingsAsync(request).Result;
        public async Task<WebCallResult<HitBtcSubAccSettingResponse>> SetSubAccWithdrawalSettingsAsync(HitBtcSubAccWithdrawalSetting request, CancellationToken ct = default)
        {
            var parameters = request.AsDictionary();
            return await SendRequest<HitBtcSubAccSettingResponse>(GetUrl(FillPathParameter(SubAccWithdrawSettingWithUserIdUrl, request.SubAccountId.ToString())), HttpMethod.Put, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcTransactionIdResponse> TransferBetweenAcc(HitBtcTransferRequest request) => TransferBetweenAccAsync(request).Result;
        public async Task<WebCallResult<HitBtcTransactionIdResponse>> TransferBetweenAccAsync(HitBtcTransferRequest transferRequest, CancellationToken ct = default)
        {
            var parameters = transferRequest.AsDictionary();
            return await SendRequest<HitBtcTransactionIdResponse>(GetUrl(AccountTransferUrl), HttpMethod.Post, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcTransferConvertCryptoResponse> TransferConvertCrypto(string fromCurrency, string toCurrency, decimal amount) => TransferConvertCryptoAsync(fromCurrency, toCurrency, amount).Result;
        public async Task<WebCallResult<HitBtcTransferConvertCryptoResponse>> TransferConvertCryptoAsync(string fromCurrency, string toCurrency, decimal amount, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("fromCurrency", fromCurrency);
            parameters.Add("toCurrency", toCurrency);
            parameters.Add("amount", amount);
            return await SendRequest<HitBtcTransferConvertCryptoResponse>(GetUrl(AccountCryptoTransferConvertUrl), HttpMethod.Post, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcTransactionIdResponse> TransferToAnotherUser(HitBtcTransferToAnotherUserRequest request) => TransferToAnotherUserAsync(request).Result;
        public async Task<WebCallResult<HitBtcTransactionIdResponse>> TransferToAnotherUserAsync(HitBtcTransferToAnotherUserRequest request, CancellationToken ct = default)
        {
            var parameters = request.AsDictionary();
            return await SendRequest<HitBtcTransactionIdResponse>(GetUrl(AccountTransferInternalUrl), HttpMethod.Post, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcRequestsBoolResult> TrasferFound(HitBtcSubAccTransferRequest request) => TrasferFoundAsync(request).Result;
        public async Task<WebCallResult<HitBtcRequestsBoolResult>> TrasferFoundAsync(HitBtcSubAccTransferRequest request, CancellationToken ct = default)
        {
            var parameters = request.AsDictionary();
            return await SendRequest<HitBtcRequestsBoolResult>(GetUrl(SubAccTransferUrl), HttpMethod.Post, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcTransactionIdResponse> WithdrawCrypto(HitBtcWithdrawRequest request) => WithdrawCryptoAsync(request).Result;
        public async Task<WebCallResult<HitBtcTransactionIdResponse>> WithdrawCryptoAsync(HitBtcWithdrawRequest request, CancellationToken ct = default)
        {
            var parameters = request.AsDictionary();
            return await SendRequest<HitBtcTransactionIdResponse>(GetUrl(AccountCryptoWithdrawUrl), HttpMethod.Post, ct, parameters, true, true);
        }

        public WebCallResult<HitBtcRequestsBoolResult> IsOffchainTransactionAvialable(string currency, string address, string paymentId = null) => IsOffchainTransactionAvialableAsync(currency, address, paymentId, default).Result;
        public async Task<WebCallResult<HitBtcRequestsBoolResult>> IsOffchainTransactionAvialableAsync(string currency, string address, string paymentId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("currency", currency);
            parameters.Add("address", address);
            parameters.AddOptionalParameter("paymentId", paymentId);
            return await SendRequest<HitBtcRequestsBoolResult>(GetUrl(AccountCryptoCheckOffchainUrl), HttpMethod.Post, ct, parameters, true, true);
        }
    }
}
