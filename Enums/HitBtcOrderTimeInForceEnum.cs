using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Enums
{
    /// <summary>
    /// Time in Force is a special instruction used when placing a trade to indicate 
    /// how long an order will remain active before it is executed or expired.
    /// </summary>
    public enum HitBtcOrderTimeInForceEnum
    {
        /// <summary>
        ///  GTC - ''Good-Till-Cancelled'' order won't be closed until it is filled.
        /// </summary>
        GoodTillCancelled,
        /// <summary>
        /// IOC - ''Immediate-Or-Cancel'' order must be executed immediately.Any part of an IOC order that cannot be filled immediately will be cancelled.
        /// </summary>
        ImmediateOrCancel,

        /// <summary>
        /// FOK - ''Fill-Or-Kill'' is a type of ''Time in Force'' designation used in securities trading 
        /// that instructs a brokerage to execute a transaction immediately and completely or not execute it at all.
        /// </summary>
        FillOrKill,
        /// <summary>
        /// Day - keeps the order active until the end of the trading day (UTC).
        /// </summary>
        Day,

        /// <summary>
        /// GTD - ''Good-Till-Date''. The date is specified in expireTime.
        /// </summary>
        GoodTillDate

    }
}
