using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsInstant {
    /// <summary>
    /// Gets or Sets EpochSecond
    /// </summary>
    [DataMember(Name="epoch_second", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "epoch_second")]
    public long? EpochSecond { get; set; }

    /// <summary>
    /// Gets or Sets Nano
    /// </summary>
    [DataMember(Name="nano", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nano")]
    public int? Nano { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsInstant {\n");
      sb.Append("  EpochSecond: ").Append(EpochSecond).Append("\n");
      sb.Append("  Nano: ").Append(Nano).Append("\n");
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
