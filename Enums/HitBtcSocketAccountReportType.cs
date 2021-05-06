namespace HitBtc.Net.Enums
{
    public enum HitBtcSocketAccountReportType
    {
        /// <summary>
        /// Status of margin account requested e.g. get accounts or subscription report with a list of current margin accounts.
        /// </summary>
        Status,
        /// <summary>
        /// A new margin account created, e.g. new margin account has been created or recreated as a result of flip trade occurs with the position.
        /// </summary>
        Created,
        /// <summary>
        /// Margin account or position has been updated.
        /// </summary>
        Updated,
        /// <summary>
        /// Margin account has been closed.
        /// </summary>
        Closed
    }
}