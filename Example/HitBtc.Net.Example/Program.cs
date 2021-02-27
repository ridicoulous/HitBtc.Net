using HitBtc.Net.Objects.Trading;
using System;
using HitBtc.Net.Extensions;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using StreamJsonRpc;
using Microsoft.VisualStudio.Threading;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace HitBtc.Net.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var s = new HitBtcSocketClient();
            //var result = await s.SubscribeToOrderBookAsync("ETHBTC", c => Console.WriteLine(c.Data.Sequence));
            //Console.ReadKey();
            var client = new HitBtcClient();
            var pairs = await client.GetSymbolsAsync();
        
            var book = new HitBtcSymbolOrderBook("BTCUSD");
            book.OnBestOffersChanged += Book_OnBestOffersChanged;
            await book.StartAsync();

            
            Console.ReadLine();
        }

        private static void Book_OnBestOffersChanged((CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestBid, CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestAsk) obj)
        {
            Console.WriteLine($"{obj.BestBid.Price}:{obj.BestAsk.Price}");
        }
    }
}

