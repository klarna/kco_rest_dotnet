using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.CustomerToken {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CustomerTokenV1 : CustomerTokenDetails {
    /// <summary>
    /// Card payment information
    /// </summary>
    /// <value>Card payment information</value>
    [DataMember(Name="card", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "card")]
    public CardInformation Card { get; set; }

    /// <summary>
    /// Direct debit payment information
    /// </summary>
    /// <value>Direct debit payment information</value>
    [DataMember(Name="direct_debit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "direct_debit")]
    public DirectDebitInformation DirectDebit { get; set; }

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CustomerTokenV1 {\n");
      sb.Append("  Card: ").Append(Card).Append("\n");
      sb.Append("  DirectDebit: ").Append(DirectDebit).Append("\n");
      sb.Append("  PaymentMethodType: ").Append(PaymentMethodType).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
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
