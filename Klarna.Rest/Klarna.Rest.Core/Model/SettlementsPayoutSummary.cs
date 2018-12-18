using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Payout summary object
    /// </summary>
    public class SettlementsPayoutSummary
    {
        /// <summary>
        /// The total amount of fee correction, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_fee_correction_amount")]
        public int SummaryTotalFeeCorrectionAmount { get; set; }
        /// <summary>
        /// ISO-8601 formatted date-time string
        /// </summary>
        [JsonProperty(PropertyName = "summary_payout_date_start")]
        public string SummaryPayoutDateStart { get; set; }
        /// <summary>
        /// The total amount of money released from holdback by Klarna, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_release_amount")]
        public int SummaryTotalReleaseAmount { get; set; }
        /// <summary>
        /// ISO-3166 Currency Code.
        /// </summary>
        [JsonProperty(PropertyName = "summary_settlement_currency")]
        public string SummarySettlementCurrency { get; set; }
        /// <summary>
        /// ISO-8601 formatted date-time string
        /// </summary>
        [JsonProperty(PropertyName = "summary_payout_date_end")]
        public string SummaryPayoutDateEnd { get; set; }
        /// <summary>
        /// The total amount of tax, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_tax_amount")]
        public int SummaryTotaTaxAmount { get; set; }
        /// <summary>
        /// The total amount of the settlement in question, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_settlement_amount")]
        public int SummaryTotalSettlementAmount { get; set; }
        /// <summary>
        /// The total amount of money withheld by Klarna, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_holdback_amount")]
        public int SummaryTotalHoldbackAmount { get; set; }
        /// <summary>
        /// The total amount of reversals, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_reversal_amount")]
        public int SummaryTotalReversalAmount { get; set; }
        /// <summary>
        /// The total amount of returns, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_return_amount")]
        public int SummaryTotalReturnAmount { get; set; }
        /// <summary>
        /// The total amount of fees, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_fee_amount")]
        public int SummaryTotalFeeAmount { get; set; }
        /// <summary>
        /// The total amount of commissions, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_commission_amount")]
        public int SummaryTotalCommissionAmount { get; set; }
        /// <summary>
        /// The total amount of sales, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_sale_amount")]
        public int SummaryTotaSaleAmount { get; set; }
        /// <summary>
        /// The total amount of money that has been repaid by the merchant from the debt to Klarna, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "summary_total_repay_amount")]
        public int SummaryTotalRepayAmount { get; set; }
    }
}
