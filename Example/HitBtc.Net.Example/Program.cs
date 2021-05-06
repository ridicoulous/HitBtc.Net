﻿using HitBtc.Net.Objects.Trading;
using System;
using System.Threading.Tasks;

namespace HitBtc.Net.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ob = new HitBtcSymbolOrderBook("ETHBTC");
            ob.OnBestOffersChanged += Ob_OnBestOffersChanged;
            await ob.StartAsync();
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

        private static void Ob_OnBestOffersChanged((CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestBid, CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestAsk) obj)
        {
            Console.WriteLine($"Bid:{obj.BestBid.Price} Ask:{obj.BestAsk.Price}= {obj.BestAsk.Price- obj.BestBid.Price}");
        }

        private static void Book_OnBestOffersChanged((CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestBid, CryptoExchange.Net.Interfaces.ISymbolOrderBookEntry BestAsk) obj)
        {
            Console.WriteLine($"{obj.BestBid.Price}:{obj.BestAsk.Price}");
        }
    }
}

