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
    }
}
