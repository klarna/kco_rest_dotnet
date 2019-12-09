using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ProductV1 {
    /// <summary>
    /// Carrier product name
    /// </summary>
    /// <value>Carrier product name</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Carrier product identifier
    /// </summary>
    /// <value>Carrier product identifier</value>
    [DataMember(Name="identifier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "identifier")]
    public string Identifier { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ProductV1 {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Identifier: ").Append(Identifier).Append("\n");
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
