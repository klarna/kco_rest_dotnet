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
  public class Totals: SettlementsPayoutTotals {
    /// <summary>
    /// The total amount of charges, in minor units. The additional field detailed_type contains the purpose of the charge
    /// </summary>
    /// <value>The total amount of charges, in minor units. The additional field detailed_type contains the purpose of the charge</value>
    [DataMember(Name="charge_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "charge_amount")]
    public long? ChargeAmount { get; set; }

    /// <summary>
    /// The total amount of credits, in minor units. The additional field detailed_type contains the purpose of the credit
    /// </summary>
    /// <value>The total amount of credits, in minor units. The additional field detailed_type contains the purpose of the credit</value>
    [DataMember(Name="credit_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "credit_amount")]
    public long? CreditAmount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Totals {\n");
      sb.Append("  CommissionAmount: ").Append(CommissionAmount).Append("\n");
      sb.Append("  RepayAmount: ").Append(RepayAmount).Append("\n");
      sb.Append("  SaleAmount: ").Append(SaleAmount).Append("\n");
      sb.Append("  HoldbackAmount: ").Append(HoldbackAmount).Append("\n");
      sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
      sb.Append("  SettlementAmount: ").Append(SettlementAmount).Append("\n");
      sb.Append("  FeeCorrectionAmount: ").Append(FeeCorrectionAmount).Append("\n");
      sb.Append("  ReversalAmount: ").Append(ReversalAmount).Append("\n");
      sb.Append("  ReleaseAmount: ").Append(ReleaseAmount).Append("\n");
      sb.Append("  ReturnAmount: ").Append(ReturnAmount).Append("\n");
      sb.Append("  FeeAmount: ").Append(FeeAmount).Append("\n");
      sb.Append("  ChargeAmount: ").Append(ChargeAmount).Append("\n");
      sb.Append("  CreditAmount: ").Append(CreditAmount).Append("\n");
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