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
  public class Totals {
    /// <summary>
    /// The total amount of commissions, in minor units
    /// </summary>
    /// <value>The total amount of commissions, in minor units</value>
    [DataMember(Name="commission_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "commission_amount")]
    public long? CommissionAmount { get; set; }

    /// <summary>
    /// The total amount of money that has been repaid by the merchant from the debt to Klarna, in minor units
    /// </summary>
    /// <value>The total amount of money that has been repaid by the merchant from the debt to Klarna, in minor units</value>
    [DataMember(Name="repay_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "repay_amount")]
    public long? RepayAmount { get; set; }

    /// <summary>
    /// The total amount of sales, in minor units
    /// </summary>
    /// <value>The total amount of sales, in minor units</value>
    [DataMember(Name="sale_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sale_amount")]
    public long? SaleAmount { get; set; }

    /// <summary>
    /// The total amount of money withheld by Klarna, in minor units
    /// </summary>
    /// <value>The total amount of money withheld by Klarna, in minor units</value>
    [DataMember(Name="holdback_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "holdback_amount")]
    public long? HoldbackAmount { get; set; }

    /// <summary>
    /// The total amount of tax, in minor units
    /// </summary>
    /// <value>The total amount of tax, in minor units</value>
    [DataMember(Name="tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tax_amount")]
    public long? TaxAmount { get; set; }

    /// <summary>
    /// The total amount of the settlement in question, in minor units
    /// </summary>
    /// <value>The total amount of the settlement in question, in minor units</value>
    [DataMember(Name="settlement_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "settlement_amount")]
    public long? SettlementAmount { get; set; }

    /// <summary>
    /// The total amount of fee correction, in minor units
    /// </summary>
    /// <value>The total amount of fee correction, in minor units</value>
    [DataMember(Name="fee_correction_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fee_correction_amount")]
    public long? FeeCorrectionAmount { get; set; }

    /// <summary>
    /// The total amount of reversals, in minor units
    /// </summary>
    /// <value>The total amount of reversals, in minor units</value>
    [DataMember(Name="reversal_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reversal_amount")]
    public long? ReversalAmount { get; set; }

    /// <summary>
    /// The total amount of money released from holdback by Klarna, in minor units
    /// </summary>
    /// <value>The total amount of money released from holdback by Klarna, in minor units</value>
    [DataMember(Name="release_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "release_amount")]
    public long? ReleaseAmount { get; set; }

    /// <summary>
    /// The total amount of returns, in minor units
    /// </summary>
    /// <value>The total amount of returns, in minor units</value>
    [DataMember(Name="return_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "return_amount")]
    public long? ReturnAmount { get; set; }

    /// <summary>
    /// The total amount of fees, in minor units
    /// </summary>
    /// <value>The total amount of fees, in minor units</value>
    [DataMember(Name="fee_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fee_amount")]
    public long? FeeAmount { get; set; }

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
