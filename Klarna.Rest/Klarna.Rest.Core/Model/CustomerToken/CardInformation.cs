using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.CustomerToken {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CardInformation {
    /// <summary>
    /// Card brand
    /// </summary>
    /// <value>Card brand</value>
    [DataMember(Name="brand", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "brand")]
    public string Brand { get; set; }

    /// <summary>
    /// Card expiration date
    /// </summary>
    /// <value>Card expiration date</value>
    [DataMember(Name="expiry_date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expiry_date")]
    public string ExpiryDate { get; set; }

    /// <summary>
    /// Masked credit card number
    /// </summary>
    /// <value>Masked credit card number</value>
    [DataMember(Name="masked_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "masked_number")]
    public string MaskedNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CardInformation {\n");
      sb.Append("  Brand: ").Append(Brand).Append("\n");
      sb.Append("  ExpiryDate: ").Append(ExpiryDate).Append("\n");
      sb.Append("  MaskedNumber: ").Append(MaskedNumber).Append("\n");
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
