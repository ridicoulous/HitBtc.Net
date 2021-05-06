
using System;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSubscribeToAccountTransactionsRequest : HitBtcSocketSubscribeBaseRequest<Object>
    {
        public HitBtcSubscribeToAccountTransactionsRequest() : base(HitBtcSocketRequest.SubscribeToTransactions, new object())
        {
        }

        public override string EndpointSuffix => "account";
    }
}