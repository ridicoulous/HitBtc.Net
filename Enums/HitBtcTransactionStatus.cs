using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Enums
{
    /// <summary>
    /// Transaction state
    /// Accepted values: created, pending, failed, success
    /// </summary>
    public enum HitBtcTransactionStatus
    {
        Created, 
        Pending,
        Failed,
        Success
    }
}
