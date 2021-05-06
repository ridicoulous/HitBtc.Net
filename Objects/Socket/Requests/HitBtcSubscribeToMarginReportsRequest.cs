
using System;
using HitBtc.Net.Enums;

namespace HitBtc.Net.Objects.Socket
{
    public class HitBtcSubscribeToMarginReportsRequest : HitBtcSocketSubscribeBaseRequest<Object>
    {
        public HitBtcSubscribeToMarginReportsRequest() : base(HitBtcSocketRequest.SubscribeToMarginReports, new object())
        {
        }

        public override string EndpointSuffix => "trading";
    }
}