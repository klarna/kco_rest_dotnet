using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TimeslotV1 {
    /// <summary>
    /// Id
    /// </summary>
    /// <value>Id</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Start time
    /// </summary>
    /// <value>Start time</value>
    [DataMember(Name="start", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "start")]
    public string Start { get; set; }

    /// <summary>
    /// End time
    /// </summary>
    /// <value>End time</value>
    [DataMember(Name="end", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "end")]
    public string End { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TimeslotV1 {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Start: ").Append(Start).Append("\n");
      sb.Append("  End: ").Append(End).Append("\n");
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
