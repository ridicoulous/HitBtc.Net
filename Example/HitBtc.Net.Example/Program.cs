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

namespace HitBtc.Net.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {         
            var s = new HitBtcSocketClient();
            var result = await s.SubscribeToOrderBookAsync("ETHBTC", c => Console.WriteLine(c.Data.Sequence));
            Console.ReadKey();
        }
    }
}

