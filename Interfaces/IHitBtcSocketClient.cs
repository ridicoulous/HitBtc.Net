using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using HitBtc.Net.Objects.Socket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HitBtc.Net.Interfaces
{
    public interface IHitBtcSocketClient
    {
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookAsync(string symbol, Action<HitBtcSocketOrderBookEvent> dataHandler);
        Task<CallResult<UpdateSubscription>> SubscribeToTradesAsync(HitBtcSubscribeToTradesParam requestParams, Action<HitBtcSocketTradesEvent> dataHandler);
        Task<CallResult<UpdateSubscription>> SubscribeToCandlesAsync(HitBtcSubscribeToCandlesParam requestParams, Action<HitBtcSocketCandlesEvent> dataHandler);
        Task<CallResult<UpdateSubscription>> SubscribeToTickerAsync(string symbol, Action<HitBtcSocketTickerEvent> dataHandler);
        Task<CallResult<UpdateSubscription>> SubscribeAsync<TParams>(HitBtcSocketSubscribeBaseRequest<TParams> subscribeRequest);

    }
}
