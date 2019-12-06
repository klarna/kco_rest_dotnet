using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Settlements {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PayoutSummary {
    /// <summary>
    /// The total amount of fee correction, in minor units
    /// </summary>
    /// <value>The total amount of fee correction, in minor units</value>
    [DataMember(Name="summary_total_fee_correction_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_fee_correction_amount")]
    public long? SummaryTotalFeeCorrectionAmount { get; set; }

    /// <summary>
    /// ISO-8601 formatted date-time string
    /// </summary>
    /// <value>ISO-8601 formatted date-time string</value>
    [DataMember(Name="summary_payout_date_start", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_payout_date_start")]
    public DateTime? SummaryPayoutDateStart { get; set; }

    /// <summary>
    /// The total amount of money released from holdback by Klarna, in minor units
    /// </summary>
    /// <value>The total amount of money released from holdback by Klarna, in minor units</value>
    [DataMember(Name="summary_total_release_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_release_amount")]
    public long? SummaryTotalReleaseAmount { get; set; }

    /// <summary>
    /// ISO-3166 Currency Code.
    /// </summary>
    /// <value>ISO-3166 Currency Code.</value>
    [DataMember(Name="summary_settlement_currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_settlement_currency")]
    public string SummarySettlementCurrency { get; set; }

    /// <summary>
    /// ISO-8601 formatted date-time string
    /// </summary>
    /// <value>ISO-8601 formatted date-time string</value>
    [DataMember(Name="summary_payout_date_end", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_payout_date_end")]
    public DateTime? SummaryPayoutDateEnd { get; set; }

    /// <summary>
    /// The total amount of tax, in minor units
    /// </summary>
    /// <value>The total amount of tax, in minor units</value>
    [DataMember(Name="summary_total_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_tax_amount")]
    public long? SummaryTotalTaxAmount { get; set; }

    /// <summary>
    /// The total amount of the settlement in question, in minor units
    /// </summary>
    /// <value>The total amount of the settlement in question, in minor units</value>
    [DataMember(Name="summary_total_settlement_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_settlement_amount")]
    public long? SummaryTotalSettlementAmount { get; set; }

    /// <summary>
    /// The total amount of money withheld by Klarna, in minor units
    /// </summary>
    /// <value>The total amount of money withheld by Klarna, in minor units</value>
    [DataMember(Name="summary_total_holdback_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_holdback_amount")]
    public long? SummaryTotalHoldbackAmount { get; set; }

    /// <summary>
    /// The total amount of reversals, in minor units
    /// </summary>
    /// <value>The total amount of reversals, in minor units</value>
    [DataMember(Name="summary_total_reversal_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_reversal_amount")]
    public long? SummaryTotalReversalAmount { get; set; }

    /// <summary>
    /// The total amount of returns, in minor units
    /// </summary>
    /// <value>The total amount of returns, in minor units</value>
    [DataMember(Name="summary_total_return_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_return_amount")]
    public long? SummaryTotalReturnAmount { get; set; }

    /// <summary>
    /// The total amount of fees, in minor units
    /// </summary>
    /// <value>The total amount of fees, in minor units</value>
    [DataMember(Name="summary_total_fee_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_fee_amount")]
    public long? SummaryTotalFeeAmount { get; set; }

    /// <summary>
    /// The total amount of commissions, in minor units
    /// </summary>
    /// <value>The total amount of commissions, in minor units</value>
    [DataMember(Name="summary_total_commission_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_commission_amount")]
    public long? SummaryTotalCommissionAmount { get; set; }

    /// <summary>
    /// The total amount of sales, in minor units
    /// </summary>
    /// <value>The total amount of sales, in minor units</value>
    [DataMember(Name="summary_total_sale_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_sale_amount")]
    public long? SummaryTotalSaleAmount { get; set; }

    /// <summary>
    /// The total amount of money that has been repaid by the merchant from the debt to Klarna, in minor units
    /// </summary>
    /// <value>The total amount of money that has been repaid by the merchant from the debt to Klarna, in minor units</value>
    [DataMember(Name="summary_total_repay_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_repay_amount")]
    public long? SummaryTotalRepayAmount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PayoutSummary {\n");
      sb.Append("  SummaryTotalFeeCorrectionAmount: ").Append(SummaryTotalFeeCorrectionAmount).Append("\n");
      sb.Append("  SummaryPayoutDateStart: ").Append(SummaryPayoutDateStart).Append("\n");
      sb.Append("  SummaryTotalReleaseAmount: ").Append(SummaryTotalReleaseAmount).Append("\n");
      sb.Append("  SummarySettlementCurrency: ").Append(SummarySettlementCurrency).Append("\n");
      sb.Append("  SummaryPayoutDateEnd: ").Append(SummaryPayoutDateEnd).Append("\n");
      sb.Append("  SummaryTotalTaxAmount: ").Append(SummaryTotalTaxAmount).Append("\n");
      sb.Append("  SummaryTotalSettlementAmount: ").Append(SummaryTotalSettlementAmount).Append("\n");
      sb.Append("  SummaryTotalHoldbackAmount: ").Append(SummaryTotalHoldbackAmount).Append("\n");
      sb.Append("  SummaryTotalReversalAmount: ").Append(SummaryTotalReversalAmount).Append("\n");
      sb.Append("  SummaryTotalReturnAmount: ").Append(SummaryTotalReturnAmount).Append("\n");
      sb.Append("  SummaryTotalFeeAmount: ").Append(SummaryTotalFeeAmount).Append("\n");
      sb.Append("  SummaryTotalCommissionAmount: ").Append(SummaryTotalCommissionAmount).Append("\n");
      sb.Append("  SummaryTotalSaleAmount: ").Append(SummaryTotalSaleAmount).Append("\n");
      sb.Append("  SummaryTotalRepayAmount: ").Append(SummaryTotalRepayAmount).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
