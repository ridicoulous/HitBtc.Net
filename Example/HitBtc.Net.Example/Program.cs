using HitBtc.Net.Objects.Trading;
using System;
using HitBtc.Net.Extensions;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using StreamJsonRpc;
using Microsoft.VisualStudio.Threading;

namespace HitBtc.Net.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var orderRequest = new HitbtcPlaceOrderRequest()
            //{
            //    ClientOrderId = "42",
            //    Side = Enums.HitBtcTradeSide.Buy,
            //    TimeInForce = Enums.HitBtcOrderTimeInForce.GoodTillCancelled,
            //    Quantity = 9,
            //    Price = 42,
            //    Symbol = "asd"
            //};
            //var dict = orderRequest.AsDictionary();
            
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Canceling...");
                cts.Cancel();
                e.Cancel = true;
            };

            try
            {
                Console.WriteLine("Press Ctrl+C to end.");
                await MainAsync(cts.Token);
            }

            catch (OperationCanceledException)
            {
                // This is the normal way we close.
            }
            catch (Exception ex)
            {

            }

        }
        static async Task MainAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Connecting to web socket...");
            using (var socket = new ClientWebSocket())
            {
                await socket.ConnectAsync(new Uri("wss://api.hitbtc.com/api/2/ws/public"), cancellationToken);
                Console.WriteLine("Connected to web socket. Establishing JSON-RPC protocol...");
                using (var jsonRpc = new JsonRpc(new WebSocketMessageHandler(socket)))
                {
                    try
                    {
                        jsonRpc.AddLocalRpcMethod("updateOrderbook", new Action<string>(tick => Console.WriteLine($"Tick {tick}!")));
                        jsonRpc.StartListening();
                        Console.WriteLine("JSON-RPC protocol over web socket established.");
                        var myResult = await jsonRpc.InvokeWithParameterObjectAsync<object>("subscribeOrderbook", new { symbol = "ETHBTC" });
                  
                        await jsonRpc.Completion.WithCancellation(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        // Closing is initiated by Ctrl+C on the client.
                        // Close the web socket gracefully -- before JsonRpc is disposed to avoid the socket going into an aborted state.
                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", CancellationToken.None);
                        throw;
                    }
                }
            }
        }
    }
}

