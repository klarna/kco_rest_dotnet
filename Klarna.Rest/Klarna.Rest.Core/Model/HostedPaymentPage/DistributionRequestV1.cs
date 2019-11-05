using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class DistributionRequestV1 {
    /// <summary>
    /// Contact information for the link distribution
    /// </summary>
    /// <value>Contact information for the link distribution</value>
    [DataMember(Name="contact_information", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contact_information")]
    public DistributionContactV1 ContactInformation { get; set; }

    /// <summary>
    /// Method used for distribution
    /// </summary>
    /// <value>Method used for distribution</value>
    [DataMember(Name="method", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "method")]
    public string Method { get; set; }

    /// <summary>
    /// Gets or Sets Template
    /// </summary>
    [DataMember(Name="template", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "template")]
    public string Template { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DistributionRequestV1 {\n");
      sb.Append("  ContactInformation: ").Append(ContactInformation).Append("\n");
      sb.Append("  Method: ").Append(Method).Append("\n");
      sb.Append("  Template: ").Append(Template).Append("\n");
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
