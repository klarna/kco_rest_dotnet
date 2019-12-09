using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.CustomerToken {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class DirectDebitInformation {
    /// <summary>
    /// Bank name
    /// </summary>
    /// <value>Bank name</value>
    [DataMember(Name="brand", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "brand")]
    public string Brand { get; set; }

    /// <summary>
    /// Masked bank account number
    /// </summary>
    /// <value>Masked bank account number</value>
    [DataMember(Name="masked_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "masked_number")]
    public string MaskedNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DirectDebitInformation {\n");
      sb.Append("  Brand: ").Append(Brand).Append("\n");
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
