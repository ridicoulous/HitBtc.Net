using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using HitBtc.Net.Extensions;
using HitBtc.Net.Objects.Socket;
using Newtonsoft.Json;

namespace HitBtc.Net.Example
{
    class Program
    {
      //  public static EventHandler<(IEnumerable<ISymbolOrderBookEntry> Bids, IEnumerable<ISymbolOrderBookEntry> Asks)> BookUpdate { get; private set; }

        static async Task Main(string[] args)
        {
            var boook = new HitBtcSymbolOrderBook("EEXBTC");
     //       var c = new HitBtcClient();
     //       //var recent = await c.GetRecentTradesAsync("EEXBTC");
     //       //var recent2 = await c.GetRecentTradesAsync("BTCUSD");

     //       Observable.FromEventPattern<(IEnumerable<ISymbolOrderBookEntry> Bids, IEnumerable<ISymbolOrderBookEntry> Asks)>(
     //h => BookUpdate += h,
     //h => BookUpdate -= h)
     //.Sample(TimeSpan.FromMilliseconds(555))
     //.Select(x =>
     //         Observable.FromAsync(async () => await FrontrunBid()))
     //.Switch()
     //.Subscribe();
     //       var ob = new HitBtcSymbolOrderBook("EEXBTC");
     //       ob.OnOrderBookUpdate += Ob_OnOrderBookUpdate; ;
     //       await ob.StartAsync();
            //var client = new HitBtcClient("key", "secret");

            //var pairs = await client.GetSymbolsAsync();
            //var order = await client.PlaceOrderAsync(new HitbtcPlaceOrderRequest()
            //{
            //    Side = Enums.HitBtcTradeSide.Sell,
            //    PostOnly=true,
            //    Quantity=0.042m,
            //    Price=142000,
            //    Symbol="BTCUSD",
            //    Type=Enums.HitBtcOrderType.Limit,
                
            //});
            //var book = new HitBtcSymbolOrderBook("BTCUSD");
            //book.OnBestOffersChanged += Book_OnBestOffersChanged;
            //await book.StartAsync();


            Console.ReadLine();
        }

        private static void Ob_OnOrderBookUpdate((IEnumerable<ISymbolOrderBookEntry> Bids, IEnumerable<ISymbolOrderBookEntry> Asks) obj)
        {
            //BookUpdate?.Invoke(obj,(obj.Bids,obj.Asks));
        }

        private static  DateTime lastUpdate = DateTime.UtcNow;
        private static async Task FrontrunBid()
        {
            await Task.Delay(50);
            Console.WriteLine($"{lastUpdate:HH:mm:ss.ffffff} updated: {DateTime.UtcNow.Subtract(lastUpdate).TotalMilliseconds}");
            lastUpdate = DateTime.UtcNow;
        }

        private static void Ob_OnBestOffersChanged((CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestBid, CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestAsk) obj)
        {
            Console.WriteLine($"Bid:{obj.BestBid.Price} Ask:{obj.BestAsk.Price}= {obj.BestAsk.Price- obj.BestBid.Price}");
        }

        private static void Book_OnBestOffersChanged((CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestBid, CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestAsk) obj)
        {
            Console.WriteLine($"{obj.BestBid.Price}:{obj.BestAsk.Price}");
        }

        private static void Ticker_OnUpdate(HitBtcSocketTickerEvent obj)
        {
            Console.WriteLine($"{obj.Data.Symbol}:{obj.Data.Ask} - {obj.Data.Bid}");
        }
        private static void Orders_OnSnapshot(HitBtcSocketActiveOrdersReportEvent obj)
        {
            foreach (var item in obj.Data)
            {
                var d = item.AsDictionary();
                Console.WriteLine($"{item.Symbol}:{JsonConvert.SerializeObject(d)}");
            }
        }
        private static void Orders_OnUpdate(HitBtcSocketOrderReportEvent obj)
        {

            var d = obj.Data.AsDictionary();
            Console.WriteLine($"{d["symbol"]}:{JsonConvert.SerializeObject(d)}");
        }
        private static void PublicTrades_OnUpdate(HitBtcSocketTradesEvent obj)
        {
            Console.WriteLine("Trades come");
            var d = obj.Data.AsDictionary();
            Console.WriteLine($"{d["symbol"]}:{JsonConvert.SerializeObject(d)}");
        }
        private static void Candles_OnUpdate(HitBtcSocketCandlesEvent obj)
        {
            Console.WriteLine("Candles come");
            var d = obj.Data.AsDictionary();
            Console.WriteLine($"{d["symbol"]}:{JsonConvert.SerializeObject(d)}");
        }
        
    }
}

