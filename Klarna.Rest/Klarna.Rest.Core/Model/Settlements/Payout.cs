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
  public class Payout {
    /// <summary>
    /// Gets or Sets Totals
    /// </summary>
    [DataMember(Name="totals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totals")]
    public Totals Totals { get; set; }

    /// <summary>
    /// The reference id of the payout
    /// </summary>
    /// <value>The reference id of the payout</value>
    [DataMember(Name="payment_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_reference")]
    public string PaymentReference { get; set; }

    /// <summary>
    /// ISO-8601 formatted date-time string
    /// </summary>
    /// <value>ISO-8601 formatted date-time string</value>
    [DataMember(Name="payout_date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payout_date")]
    public DateTime? PayoutDate { get; set; }

    /// <summary>
    /// ISO-3166 Currency Code.
    /// </summary>
    /// <value>ISO-3166 Currency Code.</value>
    [DataMember(Name="currency_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency_code")]
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Whether the amounts are net or gross
    /// </summary>
    /// <value>Whether the amounts are net or gross</value>
    [DataMember(Name="merchant_settlement_type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_settlement_type")]
    public string MerchantSettlementType { get; set; }

    /// <summary>
    /// The merchant id
    /// </summary>
    /// <value>The merchant id</value>
    [DataMember(Name="merchant_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_id")]
    public string MerchantId { get; set; }

    /// <summary>
    /// Link to the transactions that are part of this payout
    /// </summary>
    /// <value>Link to the transactions that are part of this payout</value>
    [DataMember(Name="transactions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transactions")]
    public string Transactions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Payout {\n");
      sb.Append("  Totals: ").Append(Totals).Append("\n");
      sb.Append("  PaymentReference: ").Append(PaymentReference).Append("\n");
      sb.Append("  PayoutDate: ").Append(PayoutDate).Append("\n");
      sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
      sb.Append("  MerchantSettlementType: ").Append(MerchantSettlementType).Append("\n");
      sb.Append("  MerchantId: ").Append(MerchantId).Append("\n");
      sb.Append("  Transactions: ").Append(Transactions).Append("\n");
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
