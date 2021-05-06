namespace HitBtc.Net.Enums
{
    public enum HitBtcSocketAccountReportReason
    {
        /// <summary>
        /// Response in account information request.
        /// </summary>
        Status,
        /// <summary>
        /// Margin account has been created.
        /// </summary>
        Created,
        /// <summary>
        ///  Margin account has been changed 
        ///  as a result of any order report e.g. new, canceled, filled and so on.
        /// </summary>
        Updated,
        /// <summary>
        /// The position quantity has been set to 0 (zero) as a result of closing trade.
        /// </summary>
        Closed,
        /// <summary>
        /// Margin account has been changed as a result of any requested change of the marginBalance.
        /// </summary>
        MarginChanged,
        /// <summary>
        /// Opening trade has been executed.
        /// </summary>
        OpenTrade,
        /// <summary>
        /// Closing trade has been executed.
        /// </summary>
        CloseTrade,
        /// <summary>
        /// The position has been flipped as a result of opposite order execution 
        /// with a quantity exceeding the position quantity (quantity has been changing sign).
        /// </summary>
        FlipTrade,
        /// <summary>
        /// The position has been liquidated.
        /// </summary>
        Liquidated,
        /// <summary>
        /// The interest rate has been paid.
        /// </summary>
        InterestTaken

    }
}