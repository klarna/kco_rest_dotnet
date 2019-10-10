using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// The payout totals object
    /// </summary>
    public class SettlementsPayoutTotals
    {
        [Obsolete("ComissionAmount has a typo in the name and marked as deprecated. Use CommissionAmount instead.")]
        public int ComissionAmount
        {
            get => CommissionAmount;
            set => CommissionAmount = value;
        }
        /// <summary>
        /// The total amount of commissions, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "commission_amount")]
        public int CommissionAmount { get; set; }
        /// <summary>
        /// The total amount of money that has been repaid by the merchant from the debt to Klarna, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "repay_amount")]
        public int RepayAmount { get; set; }
        /// <summary>
        /// The total amount of sales, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "sale_amount")]
        public int SaleAmount { get; set; }
        /// <summary>
        /// The total amount of money withheld by Klarna, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "holdback_amount")]
        public int HoldbackAmount { get; set; }
        /// <summary>
        /// The total amount of tax, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "tax_amount")]
        public int TaxAmount { get; set; }
        /// <summary>
        /// The total amount of the settlement in question, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "settlement_amount")]
        public int SettlementAmount { get; set; }
        /// <summary>
        /// The total amount of fee correction, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "fee_correction_amount")]
        public int FeeCorrectionAmount { get; set; }
        /// <summary>
        /// The total amount of reversals, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "reversal_amount")]
        public int ReversalAmount { get; set; }
        /// <summary>
        /// The total amount of money released from holdback by Klarna, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "release_amount")]
        public int ReleaseAmount { get; set; }
        /// <summary>
        /// The total amount of returns, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "return_amount")]
        public int ReturnAmount { get; set; }
        /// <summary>
        /// The total amount of fees, in minor units
        /// </summary>
        [JsonProperty(PropertyName = "fee_amount")]
        public int FeeAmount { get; set; }
    }
}