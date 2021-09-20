using Newtonsoft.Json;
using System;
using HitBtc.Net.Enums;
using HitBtc.Net.Converters;
using CryptoExchange.Net.ExchangeInterfaces;

namespace HitBtc.Net.Objects.Trading
{
    public class HitBtcOrder : ICommonOrderId, ICommonOrder
    {
        /// <summary>
        /// Order unique identifier as assigned by exchange
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Order unique identifier as assigned by trader. 
        /// Uniqueness must be guaranteed within a single trading day, including all active orders.
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        /// <summary>
        /// Trading symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Trade side. Accepted values: sell or buy
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(HitBtcTradeSideConverter))]
        public HitBtcTradeSide Side { get; set; }

        /// <summary>
        /// Order state
        /// Accepted values: new, suspended, partiallyFilled, filled, canceled, expired
        /// </summary>
        [JsonProperty("status"), JsonConverter(typeof(HitBtcOrderStatusConverter))]
        public HitBtcOrderStatus Status { get; set; }

        /// <summary>
        /// Accepted values: limit, market, stopLimit, stopMarket
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(HitBtcOrderTypeConverter))]
        public HitBtcOrderType Type { get; set; }

        /// <summary>
        /// Time in Force is a special instruction used when placing a trade to indicate how long an order will remain active before it is executed or expired.
        /// GTC - ''Good-Till-Cancelled'' order won't be closed until it is filled.
        /// IOC - ''Immediate-Or-Cancel'' order must be executed immediately.Any part of an IOC order that cannot be filled immediately will be cancelled.
        /// FOK - ''Fill-Or-Kill'' is a type of ''Time in Force'' designation used in securities trading that instructs a brokerage to execute a transaction immediately and completely or not execute it at all.
        /// Day - keeps the order active until the end of the trading day (UTC).
        /// GTD - ''Good-Till-Date''. The date is specified in expireTime.
        /// </summary>
        [JsonProperty("timeInForce"),JsonConverter(typeof(HitBtcOrderTimeInForceConverter))]
        public HitBtcOrderTimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Average execution price, only for history orders
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal AvgPrice { get; set; }

        /// <summary>
        /// Cumulative executed quantity
        /// </summary>
        [JsonProperty("cumQuantity")]
        public decimal CumQuantity { get; set; }

        /// <summary>
        /// Order creation date
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of order's last update
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Required for stop-limit and stop-market orders
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }

        /// <summary>
        /// A post-only order is an order that does not remove liquidity. 
        /// If your post-only order causes a match with a pre-existing order as a taker, then the order will be cancelled.
        /// </summary>
        [JsonProperty("postOnly")]
        public bool PostOnly { get; set; }

        /// <summary>
        /// Date of order expiration for timeInForce = GTD
        /// </summary>
        [JsonProperty("expireTime")]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// Margin position Id
        /// </summary>
        [JsonProperty("positionId")]
        public long PositionId { get; set; }

        /// <summary>
        /// Optional list of trades
        /// </summary>
        [JsonProperty("tradesReport")]
        public HitBtcTrade[] TradesReport { get; set; }

        public string CommonId => ClientOrderId;

        public string CommonSymbol => Symbol;

        public decimal CommonPrice => Price;

        public decimal CommonQuantity => Quantity;

        public bool IsActive
        {
            get
            {
                switch (Status)
                {
                    case HitBtcOrderStatus.New:
                    case HitBtcOrderStatus.PartiallyFilled:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public IExchangeClient.OrderSide CommonSide
        {
            get
            {
                switch (Side)
                {
                    case HitBtcTradeSide.Buy:
                        return IExchangeClient.OrderSide.Buy;
                    case HitBtcTradeSide.Sell:
                        return IExchangeClient.OrderSide.Sell;
                    default:
                        throw new NotSupportedException("Unknown trade side");
                }
            }
        }

        public IExchangeClient.OrderType CommonType
        {
            get
            {
                switch (Type)
                {
                    case HitBtcOrderType.Limit:
                        return IExchangeClient.OrderType.Limit;
                    case HitBtcOrderType.Market:
                        return IExchangeClient.OrderType.Market;
                    default:
                        return IExchangeClient.OrderType.Other;
                }
            }
        }

        public DateTime CommonOrderTime => CreatedAt;

        public IExchangeClient.OrderStatus CommonStatus => Status switch
        {
            HitBtcOrderStatus.New => IExchangeClient.OrderStatus.Active,
            HitBtcOrderStatus.PartiallyFilled => IExchangeClient.OrderStatus.Active,
            HitBtcOrderStatus.Canceled => IExchangeClient.OrderStatus.Canceled,
            HitBtcOrderStatus.Expired => IExchangeClient.OrderStatus.Canceled,
            HitBtcOrderStatus.Filled => IExchangeClient.OrderStatus.Filled,
            _ => throw new NotImplementedException("Undefined order status")
        };
    }
}
