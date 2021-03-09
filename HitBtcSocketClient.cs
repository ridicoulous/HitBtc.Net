using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using HitBtc.Net.Interfaces;
using HitBtc.Net.Objects.Socket;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HitBtc.Net
{
    public class HitBtcSocketClient : SocketClient, IHitBtcSocketClient
    {
        private static HitBtcSocketClientOptions defaultOptions = new HitBtcSocketClientOptions();
        public HitBtcSocketClient():this(nameof(HitBtcSocketClient),defaultOptions,null)
        {

        }
        public HitBtcSocketClient(string clientName, HitBtcSocketClientOptions exchangeOptions, HitBtcAuthenticationProvider authenticationProvider) : base(clientName, exchangeOptions, authenticationProvider)
        {
            
        }

        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookAsync(string symbol, Action<HitBtcSocketOrderBookEvent> dataHandler)
        {
            return await Subscribe<HitBtcSocketOrderBookEvent>(BaseAddress+"public", new HitBtcSubscribeToOrderBookRequest(symbol), null, false, dataHandler);
        }
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradesAsync(HitBtcSubscribeToTradesParam requestParams, Action<HitBtcSocketTradesEvent> dataHandler)
        {
            return await Subscribe<HitBtcSocketTradesEvent>(BaseAddress+"public", requestParams, null, false, dataHandler);
        }
        public async Task<CallResult<UpdateSubscription>> SubscribeToCandlesAsync(HitBtcSubscribeToCandlesParam requestParams, Action<HitBtcSocketCandlesEvent> dataHandler)
        {
            return await Subscribe<HitBtcSocketCandlesEvent>(BaseAddress+"public", requestParams, null, false, dataHandler);
        }
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerAsync(string symbol, Action<HitBtcSocketTickerEvent> dataHandler)
        {
            return await Subscribe<HitBtcSocketTickerEvent>(BaseAddress+"public", new HitBtcSubscribeToTickerRequest(symbol), null, false, dataHandler);
        }

        protected override Task<CallResult<bool>> AuthenticateSocket(SocketConnection s)
        {
            throw new NotImplementedException();
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

        protected override Task<bool> Unsubscribe(SocketConnection connection, SocketSubscription s)
        {
            throw new NotImplementedException();
        }
    }
}
