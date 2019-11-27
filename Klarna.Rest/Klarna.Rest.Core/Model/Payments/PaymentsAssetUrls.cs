using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsAssetUrls {
    /// <summary>
    /// Decriptive asset URL
    /// </summary>
    /// <value>Decriptive asset URL</value>
    [DataMember(Name="descriptive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "descriptive")]
    public string Descriptive { get; set; }

    /// <summary>
    /// Standard asset URL
    /// </summary>
    /// <value>Standard asset URL</value>
    [DataMember(Name="standard", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "standard")]
    public string Standard { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsAssetUrls {\n");
      sb.Append("  Descriptive: ").Append(Descriptive).Append("\n");
      sb.Append("  Standard: ").Append(Standard).Append("\n");
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
