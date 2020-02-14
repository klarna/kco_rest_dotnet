using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class BackgroundImageV1 {
    /// <summary>
    /// Url for the image
    /// </summary>
    /// <value>Url for the image</value>
    [DataMember(Name="url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; }

    /// <summary>
    /// Width of the image
    /// </summary>
    /// <value>Width of the image</value>
    [DataMember(Name="width", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "width")]
    public long? Width { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BackgroundImageV1 {\n");
      sb.Append("  Url: ").Append(Url).Append("\n");
      sb.Append("  Width: ").Append(Width).Append("\n");
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
