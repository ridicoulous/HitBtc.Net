
using System;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSubscribeToReportsRequest : HitBtcSocketSubscribeBaseRequest<Object>
    {
        public HitBtcSubscribeToReportsRequest() : base(HitBtcSocketRequest.SubscribeToOrdersReports, new object())
        {
        }

        public override string EndpointSuffix => "trading";
    }
}