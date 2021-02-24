﻿using CryptoExchange.Net;
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

namespace HitBtc.Net
{
    public class HitBtcClient : RestClient, IHitBtcClient
    {
        #region Endpoints
        private const string ActivateSubAccountsUrl = "sub-acc/activate";
        private const string OrderWithClientOrderIdUrl = "order/{}";
        private const string MarginOrderWithClientOrderIdUrl = "margin/order/{}";

        #endregion
        public HitBtcClient(string clientName, HitBtcClientOptions exchangeOptions, AuthenticationProvider authenticationProvider) : base(clientName, exchangeOptions, authenticationProvider)
        {

        }
        private Uri GetUrl(string path)
        {
            return new Uri(BaseAddress + path);
        }
        public WebCallResult<HitBtcRequestsBoolResult> ActivateSubAccounts(params long[] ids) => ActivateSubAccountsAsync(default, ids).Result;

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> ActivateSubAccountsAsync(CancellationToken ct = default, params long[] ids)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrder> CancelMarginOrderByClientOrderId(string clientOrderId) => CancelMarginOrderByClientOrderIdAsync(clientOrderId).Result;

        public async Task<WebCallResult<HitBtcOrder>> CancelMarginOrderByClientOrderIdAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcOrder>(GetUrl(FillPathParameter(MarginOrderWithClientOrderIdUrl, clientOrderId)), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> CancelMarginOrders(string symbol = null) => CancelMarginOrdersAsync(symbol).Result;
        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> CancelMarginOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrder> CancelOrderByClientOrderId(string clientOrderId) => CancelOrderByClientOrderIdAsync(clientOrderId).Result;

        public async Task<WebCallResult<HitBtcOrder>> CancelOrderByClientOrderIdAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBtcOrder>(GetUrl(FillPathParameter(OrderWithClientOrderIdUrl, clientOrderId)), HttpMethod.Delete, ct, null, true, true);
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> CancelOrders(string symbol = null) => CancelOrdersAsync(symbol).Result;

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> CancelOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>> CloseAllIsolatedMarginAccounts() => CloseAllIsolatedMarginAccountsAsync().Result;

        public async Task<WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>>> CloseAllIsolatedMarginAccountsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcIsolatedMarginAccount> CloseIsolatedMarginAccount(string symbol) => CloseIsolatedMarginAccountAsync(symbol).Result;

        public async Task<WebCallResult<HitBtcIsolatedMarginAccount>> CloseIsolatedMarginAccountAsync(string symbol, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcPosition> CloseMarginPosition(string symbol, decimal? price = null, bool strictValidate = false) => CloseMarginPositionAsync(symbol, price, strictValidate).Result;
        public async Task<WebCallResult<HitBtcPosition>> CloseMarginPositionAsync(string symbol, decimal? price = null, bool strictValidate = false, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcPosition>> CloseMarginPositions()
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcPosition>>> CloseMarginPositionsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcRequestsBoolResult> CommitWithdrawCrypto(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> CommitWithdrawCryptoAsync(string id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcRequestsBoolResult> FreezeSubAccounts(params long[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> FreezeSubAccountsAsync(CancellationToken ct = default, params long[] ids)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcDepositAddress> GenerateNewDepositAddress(string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcDepositAddress>> GenerateNewDepositAddressAsync(string currency, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcAccountBalance>> GetAccountBalance()
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcAccountBalance>>> GetAccountBalanceAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrder> GetActiveOrderByClientOrderId(string clientOrderId, long? wait = null)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcOrder>> GetActiveOrderByClientOrderIdAsync(string clientOrderId, long? wait = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> GetActiveOrders(string symbol = null)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetActiveOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcRequestsBoolResult> GetAddressIsMine(string address)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> GetAddressIsMineAsync(string address, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcCandle>> GetCandle(string symbol, string period = "M30", string sort = "ASC", DateTime? from = null, DateTime? till = null, int limit = 100, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcCandle>>> GetCandleAsync(string symbol, string period = "M30", string sort = "ASC", DateTime? from = null, DateTime? till = null, int limit = 100, int offset = 0, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcCandlesResponse> GetCandles(string period = "M30", string sort = "ASC", DateTime? from = null, DateTime? till = null, int limit = 100, int offset = 0, params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcCandlesResponse>> GetCandlesAsync(string period = "M30", string sort = "ASC", DateTime? from = null, DateTime? till = null, int limit = 100, int offset = 0, CancellationToken ct = default, params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcCurrency>> GetCurrencies(params string[] currencies)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcCurrency>>> GetCurrenciesAsync(CancellationToken ct = default, params string[] currencies)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcCurrency> GetCurrency(string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcCurrency>> GetCurrencyAsync(string currency, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcDepositAddress> GetDepositAddress(string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcDepositAddress>> GetDepositAddressAsync(string currency, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcFee> GetEstimateWithdrawFee(string currency, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcFee>> GetEstimateWithdrawFeeAsync(string currency, decimal amount, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcFeeLevel>> GetEstimateWithdrawFeeLevels(string currency, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcFeeLevel>>> GetEstimateWithdrawFeeLevelsAsync(string currency, decimal amount, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcIsolatedMarginAccount> GetIsolatedMarginAccount(string symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcIsolatedMarginAccount>> GetIsolatedMarginAccountAsync(string symbol, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>> GetIsolatedMarginAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcIsolatedMarginAccount>>> GetIsolatedMarginAccountsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcDepositAddress>> GetLastDepositAddresses(string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcDepositAddress>>> GetLastDepositAddressesAsync(string currency, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcDepositAddress>> GetLastUsedDepositAddresses(string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcDepositAddress>>> GetLastUsedDepositAddresses(string currency, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrder> GetMarginOrder(string clientOrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcOrder>> GetMarginOrderAsync(string clientOrderId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> GetMarginOrders(string symbol = null)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetMarginOrdersAsync(string symbol = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcPosition> GetMarginPosition(string symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcPosition>> GetMarginPositionAsync(string symbol, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcPosition>> GetMarginPositions()
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcPosition>>> GetMarginPositionsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrderBook> GetOrderBook(string symbol, int limit = 100, decimal? volume = null)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcOrderBook>> GetOrderBookAsync(string symbol, int limit = 100, decimal? volume = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrderBooksResponse> GetOrderBooks(int limit = 100, params string[] symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcOrderBooksResponse>> GetOrderBooksAsync(int limit = 100, CancellationToken ct = default, params string[] symbol)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcOrder>> GetOrdersHistory(HitBtcOrdersFilterRequest filter)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcOrder>>> GetOrdersHistoryAsync(HitBtcOrdersFilterRequest filter, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcSubAccAddressResponse> GetSubAccAddress(long subAccountUserId, string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcSubAccAddressResponse>> GetSubAccAddressAsync(long subAccountUserId, string currency, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcSubAccBalanceResponse> GetSubAccBalance(long subAccountUserID)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcSubAccBalanceResponse>> GetSubAccBalanceAsync(long subAccountUserID, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcSubAccountResponse> GetSubAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcSubAccountResponse>> GetSubAccountsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcSubAccSettingResponse> GetSubAccWithdrawalSettings(params long[] subAccountIds)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcSubAccSettingResponse>> GetSubAccWithdrawalSettingsAsync(CancellationToken ct = default, params long[] subAccountIds)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcSymbol> GetSymbol(string symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcSymbol>> GetSymbolAsync(string symbol, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcSymbol>> GetSymbols(params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcSymbol>>> GetSymbolsAsync(CancellationToken ct = default, params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTicker> GetTicker(string symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcTicker>> GetTickers(params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcTicker>>> GetTickersAsync(CancellationToken ct = default, params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcPublicTrade>> GetTrade(string symbol, HitbtcPublicTradesFilterRequest filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcPublicTrade>>> GetTradeAsync(string symbol, HitbtcPublicTradesFilterRequest filter = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTradeResponse> GetTrades(HitbtcPublicTradesFilterRequest filter = null, params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTradeResponse>> GetTradesAsync(HitbtcPublicTradesFilterRequest filter = null, CancellationToken ct = default, params string[] symbols)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcTrade>> GetTradesByOrderId(long orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcTrade>>> GetTradesByOrderIdAsync(long orderId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcTrade>> GetTradesHistory(HitBtcTradesFilterRequest filter)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcTrade>>> GetTradesHistoryAsync(HitBtcTradesFilterRequest filter, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTradingBalance> GetTradingBalance()
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTradingBalance>> GetTradingBalanceAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTradingCommission> GetTradingCommission(string symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTradingCommission>> GetTradingCommissionAsync(string symbol)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTransaction> GetTransactionById(string transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTransaction>> GetTransactionByIdAsync(string transactionId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<IEnumerable<HitBtcTransaction>> GetTransactions(HitBtcTransferHistoryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<IEnumerable<HitBtcTransaction>>> GetTransactionsAsync(HitBtcTransferHistoryRequest request, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrder> PlaceMarginOrder(HitbtcPlaceOrderRequest order)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcOrder>> PlaceMarginOrderAsync(HitbtcPlaceOrderRequest order, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcOrder> PlaceOrder(HitbtcPlaceOrderRequest order)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcOrder>> PlaceOrderAsync(HitbtcPlaceOrderRequest order, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcRequestsBoolResult> RollbackWithdrawCrypto(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> RollbackWithdrawCryptoAsync(string id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcIsolatedMarginAccount> SetIsolatedMarginAccount(string symbol, decimal marginBalance, bool strictValidate)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcIsolatedMarginAccount>> SetIsolatedMarginAccountAsync(string symbol, decimal marginBalance, bool strictValidate, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcSubAccSettingResponse> SetSubAccWithdrawalSettings(HitBtcSubAccWithdrawalSetting request)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcSubAccSettingResponse>> SetSubAccWithdrawalSettingsAsync(HitBtcSubAccWithdrawalSetting request, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTransactionIdResponse> TransferBetweenAcc(HitBtcTransferRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTransactionIdResponse>> TransferBetweenAccAsync(HitBtcTransferRequest transferRequest, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTransferConvResponse> TransferConvertCrypto(string fromCurrency, string toCurrency, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTransferConvResponse>> TransferConvertCryptoAsync(string fromCurrency, string toCurrency, decimal amount, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTransactionIdResponse> TransferToAnotherUser(HitBtcTransferToAnotherUserRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTransactionIdResponse>> TransferToAnotherUser(HitBtcTransferToAnotherUserRequest request, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcRequestsBoolResult> TrasferFound(HitBtcSubAccTransferRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcRequestsBoolResult>> TrasferFoundAsync(HitBtcSubAccTransferRequest request, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public WebCallResult<HitBtcTransactionIdResponse> WithdrawCrypto(HitBtcWithdrawRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<WebCallResult<HitBtcTransactionIdResponse>> WithdrawCryptoAsync(HitBtcWithdrawRequest request, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
