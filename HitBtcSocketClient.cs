using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using HitBtc.Net.Enums;
using HitBtc.Net.Interfaces;
using HitBtc.Net.Objects.Socket;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HitBtc.Net
{
    public class HitBtcSocketClient : SocketClient, IHitBtcSocketClient
    {
        private const string MarketDataUrlSuffix = "public";
        private static HitBtcSocketClientOptions defaultOptions = new HitBtcSocketClientOptions();
        private Dictionary<string, HitBtcSocketEvent> mappedResponses;
        

        #region Events
        public event Action<HitBtcSocketOrderBookEvent> OnOrderBookUpdate;
        public event Action<HitBtcSocketOrderBookEvent> OnOrderBookSnapshot;
        public event Action<HitBtcSocketTickerEvent> OnTickerUpdate;
        public event Action<HitBtcSocketCandlesEvent> OnCandlesUpdate;
        public event Action<HitBtcSocketCandlesEvent> OnCandlesSnapshot;
        public event Action<HitBtcSocketTradesEvent> OnTradesSnapshot;
        public event Action<HitBtcSocketTradesEvent> OnTradesUpdate;
        public event Action<HitBtcSocketActiveOrdersReportEvent> OnActiveOrdersSnapshot;
        public event Action<HitBtcSocketOrderReportEvent> OnOrderUpdate;
        public event Action<HitBtcSocketMarginActiveOrdersReportEvent> OnMarginActiveOrdersSnapshot;
        public event Action<HitBtcSocketMarginOrderReportEvent> OnMarginOrderUpdate;
        public event Action<HitBtcSocketMarginAccountReportEvent> OnMarginAccountUpdate;
        public event Action<HitBtcSocketMarginAccountsEvent> OnMarginAccountsSnapshot;
        public event Action<HitBtcSocketAccountTransactionEvent> OnAccountTransactionUpdate;
        public event Action<string> OnError;
        #endregion

        public HitBtcSocketClient() : this(nameof(HitBtcSocketClient), defaultOptions, null)
        {
        }
        public HitBtcSocketClient(string key, string secret, string socketClientName = nameof(HitBtcSocketClient))
                                            : this
                                            (
                                                socketClientName,
                                                defaultOptions,
                                                new HitBtcAuthenticationProvider(new ApiCredentials(key, secret))
                                            )
        {
        }
        public HitBtcSocketClient(string clientName, HitBtcSocketClientOptions exchangeOptions, HitBtcAuthenticationProvider authenticationProvider) : base(clientName, exchangeOptions, authenticationProvider)
        {
            mappedResponses = Objects.Socket.Helpers.SocketMapping.HitBtcSocketResponsesAsStringEnumMappedDict();
        }

        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookAsync(string symbol, Action<DataEvent<HitBtcSocketOrderBookEvent>> dataHandler)
        {
            return await SubscribeAsync<HitBtcSocketOrderBookEvent>(BaseAddress+"public", new HitBtcSubscribeToOrderBookRequest(symbol), null, false, dataHandler);
        }
       
        public async Task<CallResult<UpdateSubscription>> SubscribeAsync<TParams>(HitBtcSocketSubscribeBaseRequest<TParams> subscribeRequest)
        {
            var dataHandler = new Action<DataEvent<string>>(data =>
           {
               var token = JToken.Parse(data.Data);
               var method = (string)token["method"];
               if (method is null)
               {
                   ErrorHandler(token["error"].ToString());
                   return;
               }
               HitBtcSocketEvent responseType;

               if (!mappedResponses.TryGetValue(method, out responseType))
               {
                   ErrorHandler($"Unknown response method [{method}] update catched at data {data}");
                   return;
               }

               switch (responseType)
               {
                   case HitBtcSocketEvent.OrderBookUpdated:
                       {
                           var result = Deserialize<HitBtcSocketOrderBookEvent>(token, false);
                           if (result.Success)
                           {
                               OnOrderBookUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.OrderbookFullSnapshot:
                   {
                           var result = Deserialize<HitBtcSocketOrderBookEvent>(token, false);
                           if (result.Success)
                           {
                               OnOrderBookSnapshot?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.TradesSnapshot:
                       {
                           var result = Deserialize<HitBtcSocketTradesEvent>(token, false);
                           if (result.Success)
                           {
                               OnTradesSnapshot?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.TradesUpdated:
                       {
                           var result = Deserialize<HitBtcSocketTradesEvent>(token, false);
                           if (result.Success)
                           {
                               OnTradesUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.TickerUpdated:
                       {
                           var result = Deserialize<HitBtcSocketTickerEvent>(token, false);
                           if (result.Success)
                           {
                               OnTickerUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.CandlesSnapshot:
                       {
                           var result = Deserialize<HitBtcSocketCandlesEvent>(token, false);
                           if (result.Success)
                           {
                               OnCandlesSnapshot?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.CandlesUpdated:
                       {
                           var result = Deserialize<HitBtcSocketCandlesEvent>(token, false);
                           if (result.Success)
                           {
                               OnCandlesUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.ActiveOrdersSnapshot:
                       {
                           var result = Deserialize<HitBtcSocketActiveOrdersReportEvent>(token, false);
                           if (result.Success)
                           {
                               OnActiveOrdersSnapshot?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.OrderUpdated:
                       {
                           var result = Deserialize<HitBtcSocketOrderReportEvent>(token, false);
                           if (result.Success)
                           {
                               OnOrderUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.MarginOrdersSnapshot:
                       {
                           var result = Deserialize<HitBtcSocketMarginActiveOrdersReportEvent>(token, false);
                           if (result.Success)
                           {
                               OnMarginActiveOrdersSnapshot?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.MarginOrderUpdated:
                       {
                           var result = Deserialize<HitBtcSocketMarginOrderReportEvent>(token, false);
                           if (result.Success)
                           {
                               OnMarginOrderUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.MarginAccountsSnapshot:
                       {
                           var result = Deserialize<HitBtcSocketMarginAccountsEvent>(token, false);
                           if (result.Success)
                           {
                               OnMarginAccountsSnapshot?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.MarginAccountUpdated:
                       {
                           var result = Deserialize<HitBtcSocketMarginAccountReportEvent>(token, false);
                           if (result.Success)
                           {
                               OnMarginAccountUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   case HitBtcSocketEvent.TransactionUpdated:
                       {
                           var result = Deserialize<HitBtcSocketAccountTransactionEvent>(token, false);
                           if (result.Success)
                           {
                               OnAccountTransactionUpdate?.Invoke(result.Data);
                           }
                           else
                               log.Write(LogLevel.Warning, "Couldn't deserialize data received from  stream: " + result.Error);
                           break;
                       }
                   default:
                       ErrorHandler($"Catched unknown method update: {data}");
                    break;
               }
           });

            return await SubscribeAsync(BaseAddress + subscribeRequest.EndpointSuffix, subscribeRequest, null, subscribeRequest.EndpointSuffix != MarketDataUrlSuffix, dataHandler);
        }
        protected override async Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection s)
        {
            bool isSuccess = false;
            ServerError serverError = null;
            var authRequest = new HitBtcSocketLogin(
                new LoginParams()
                {
                    Algorithm = "BASIC",
                    Key = authProvider.Credentials.Key?.GetString(),
                    SecretKey = authProvider.Credentials.Secret?.GetString(),
                });
           await s.SendAndWaitAsync(authRequest, TimeSpan.FromSeconds(1), f =>
              {
                  if (String.IsNullOrEmpty(f.ToString()))
                  {
                      isSuccess = false;
                      serverError = new ServerError("Auth request was not succesful");
                  }
                  else
                  {
                      isSuccess = true;
                  }
                  return true;

              });
            return new CallResult<bool>(isSuccess, null);
        }

        protected override bool HandleQueryResponse<T>(SocketConnection s, object request, JToken data, out CallResult<T> callResult)
        {
            throw new NotImplementedException();
        }

        protected override bool HandleSubscriptionResponse(SocketConnection s, SocketSubscription subscription, object request, JToken message, out CallResult<object> callResult)
        {
            var error = message["error"];
            callResult = new CallResult<object>(request,error==null?null:new ServerError(error["message"].ToString(),error));
            return message["result"] != null && (bool)message["result"] == true;
        }

        protected override bool MessageMatchesHandler(JToken message, object request)
        {
            return true;
        }

        protected override bool MessageMatchesHandler(JToken message, string identifier)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription s)
        {
            throw new NotImplementedException();
        }

        private void ErrorHandler(string errorMessage)
        {
            OnError?.Invoke(errorMessage);
            log.Write(LogLevel.Warning, errorMessage);
        }
    }
}
