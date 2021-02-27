using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Enums
{
    public enum HitBtcSocketRequest
    {
        SubscribeToOrderbook,
        UnsubscribeFromOrderbook,

    }
    public enum HitBtcSocketEvent
    {
        /// <summary>
        /// Message contains incremental changes.
        ///size = 0 means that level has been deleted.
        ///sequence is monotonically increased for each update, each symbol has its own sequence.
        ///Notification method: updateOrderbook
        /// </summary>
        OrderBookUpdated,
        /// <summary>
        /// Message contains a full snapshot of the Order Book. snapshotOrderbook
        /// </summary>
        OrderbookFullSnapshot
    }
}
