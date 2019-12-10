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
  public class PayoutSummary: SettlementsPayoutSummary {
    /// <summary>
    /// The total amount of tax, in minor units
    /// </summary>
    /// <value>The total amount of tax, in minor units</value>
    [DataMember(Name="summary_total_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_tax_amount")]
    public long? SummaryTotalTaxAmount { get; set; }

    /// <summary>
    /// The total amount of sales, in minor units
    /// </summary>
    /// <value>The total amount of sales, in minor units</value>
    [DataMember(Name="summary_total_sale_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary_total_sale_amount")]
    public long? SummaryTotalSaleAmount { get; set; }

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
