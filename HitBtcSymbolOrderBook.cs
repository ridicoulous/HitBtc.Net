using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.Sockets;
using HitBtc.Net.Objects.Socket;
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

        protected override async Task<CallResult<bool>> DoResyncAsync()
        {
            return await Task.Run(() => new CallResult<bool>(true,null));
        }

        protected override async Task<CallResult<UpdateSubscription>> DoStartAsync()
        {
            hitBtcSocketClient.OnOrderBookUpdate += book => UpdateOrderBook(book.Data.Sequence, book.Data.Bids, book.Data.Asks);
            hitBtcSocketClient.OnOrderBookSnapshot += book => SetInitialOrderBook(book.Data.Sequence, book.Data.Bids, book.Data.Asks);
            return await hitBtcSocketClient.SubscribeAsync(new HitBtcSubscribeToOrderBookRequest(Symbol));
        }
    }
}
