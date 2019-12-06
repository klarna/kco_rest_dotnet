using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.MerchantCardService {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CardSpecification {
    /// <summary>
    /// The total purchase amount on a card
    /// </summary>
    /// <value>The total purchase amount on a card</value>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public long? Amount { get; set; }

    /// <summary>
    /// The amount currency
    /// </summary>
    /// <value>The amount currency</value>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public string Currency { get; set; }

    /// <summary>
    /// The funded amount that will be on a card
    /// </summary>
    /// <value>The funded amount that will be on a card</value>
    [DataMember(Name="fund_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fund_amount")]
    public long? FundAmount { get; set; }

    /// <summary>
    /// Your reference on the card
    /// </summary>
    /// <value>Your reference on the card</value>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CardSpecification {\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
      sb.Append("  FundAmount: ").Append(FundAmount).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
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
