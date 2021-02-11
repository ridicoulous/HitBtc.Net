using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Enums
{
    /// <summary>
    /// Order state
    /// Accepted values: new, suspended, partiallyFilled, filled, canceled, expired
    /// </summary>
    public enum HitBtcOrderStatus
    {
        New,

        Suspended,

        PartiallyFilled,

        Filled,

        Canceled,

        Expired
    }
}
