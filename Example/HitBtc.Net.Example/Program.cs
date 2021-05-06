using CryptoExchange.Net.Authentication;
using HitBtc.Net.Objects.MarketData;
using HitBtc.Net.Objects.Socket;
using HitBtc.Net.Extensions;
using Microsoft.VisualStudio.Threading;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HitBtc.Net.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // var client = new HitBtcClient("key", "secret");

            // var pairs = await client.GetSymbolsAsync();
            // var order = await client.PlaceOrderAsync(new HitbtcPlaceOrderRequest()
            // {
            //     Side = Enums.HitBtcTradeSide.Sell,
            //     PostOnly=true,
            //     Quantity=0.042m,
            //     Price=142000,
            //     Symbol="BTCUSD",
            //     Type=Enums.HitBtcOrderType.Limit,

            // });

            var socketClient = new HitBtcSocketClient("key", "secret");
            socketClient.OnTickerUpdate += Ticker_OnUpdate;
            socketClient.OnActiveOrdersSnapshot += Orders_OnSnapshot;
            socketClient.OnOrderUpdate += Orders_OnUpdate;
            socketClient.OnTradesSnapshot += PublicTrades_OnUpdate;
            socketClient.OnTradesUpdate += PublicTrades_OnUpdate;
            socketClient.OnCandlesSnapshot += Candles_OnUpdate;
            socketClient.OnCandlesUpdate += Candles_OnUpdate;
            var requestTic = new HitBtcSubscribeToTickerRequest("LTCUSD");
            var request = new HitBtcSubscribeToTradesRequest(new HitBtcSubscribeToTradesParam("LTCUSD"));
            var requestC = new HitBtcSubscribeToCandlesRequest(new HitBtcSubscribeToCandlesParam("LTCUSD", "M1", 10));
            var ordersReq = new HitBtcSubscribeToReportsRequest();
            var json = JsonConvert.SerializeObject(request);
            Console.WriteLine(JsonConvert.SerializeObject(requestTic));
            Console.WriteLine(json);

            // var responsetic = await socketClient.SubscribeAsync(requestTic);
            // var response = await socketClient.SubscribeAsync(ordersReq);
            // var responseTr = await socketClient.SubscribeAsync(request);
            var responseC = await socketClient.SubscribeAsync(requestC);
            //  var book = new HitBtcSymbolOrderBook("BTCUSD");
            // book.OnBestOffersChanged += Book_OnBestOffersChanged;
            // await book.StartAsync();


            Console.ReadLine();
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

