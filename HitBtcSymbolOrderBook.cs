using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.Sockets;
using HitBtc.Net.Enums;
using HitBtc.Net.Objects.Socket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HitBtc.Net
{
    public class HitBtcSymbolOrderBook : SymbolOrderBook
    {
        private static HitBtcSymbolOrderBookOptions defaultoptions = new HitBtcSymbolOrderBookOptions(nameof(HitBtcSymbolOrderBookOptions), true, false);
        private readonly HitBtcSocketClient hitBtcSocketClient;
        public HitBtcSymbolOrderBook(string symbol):this(symbol, defaultoptions)
        {

        }
        public HitBtcSymbolOrderBook(string symbol, HitBtcSymbolOrderBookOptions options) : base(symbol, options)
        {
            hitBtcSocketClient = new HitBtcSocketClient();
        }

        public override void Dispose()
        {
            asks.Clear();
            bids.Clear();
        }

        protected override async Task<CallResult<bool>> DoResync()
        {
            return new CallResult<bool>(true,null);
        }

        protected override async Task<CallResult<UpdateSubscription>> DoStart()
        {
            return await hitBtcSocketClient.SubscribeToOrderBookAsync(Symbol, OnObUpdate);
        }
        private void OnObUpdate(DataEvent<HitBtcSocketOrderBookEvent> book)
        {
            if (book.Data == null)
            {
                return;
            }
            if(book.Data.Method== HitBtcSocketEvent.OrderbookFullSnapshot)
            {
                SetInitialOrderBook(book.Data.Data.Sequence, book.Data.Data.Bids, book.Data.Data.Asks);
            }
            else
            {
                UpdateOrderBook(book.Data.Data.Sequence, book.Data.Data.Bids, book.Data.Data.Asks);
            }
        }
        internal Task<CallResult<UpdateSubscription>> SubscribeInternal<T>(string url, IEnumerable<string> topics, Action<DataEvent<T>> onData)
        {
            var request = new HitBtcSocketSubscribeBaseRequest<TParams>
            {
                Method = "SUBSCRIBE",
                Params = topics.ToArray(),
                Id = NextId()
            };

            return SubscribeAsync(url, request, null, false, onData);
        }

    }
}
