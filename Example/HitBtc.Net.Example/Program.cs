using HitBtc.Net.Objects.Trading;
using System;
using HitBtc.Net.Extensions;
namespace HitBtc.Net.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderRequest = new HitbtcPlaceOrderRequest()
            {
                ClientOrderId = "42",
                Side = Enums.HitBtcTradeSide.Buy,
                TimeInForce = Enums.HitBtcOrderTimeInForce.GoodTillCancelled,
                Quantity = 9,
                Price = 42,
                Symbol = "asd"
            };
            var dict = orderRequest.AsDictionary();
        }
    }
}
