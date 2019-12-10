using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Customer {
    /// <summary>
    /// ISO 8601 date. The customer date of birth.
    /// </summary>
    /// <value>ISO 8601 date. The customer date of birth.</value>
    [DataMember(Name="date_of_birth", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date_of_birth")]
    public string DateOfBirth { get; set; }

    /// <summary>
    /// The default supported value is 'person'. If B2B is enabled for the merchant, the value may be \"organization\".
    /// </summary>
    /// <value>The default supported value is 'person'. If B2B is enabled for the merchant, the value may be \"organization\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The organization's official registration id (organization number). Applicable only for B2B orders
    /// </summary>
    /// <value>The organization's official registration id (organization number). Applicable only for B2B orders</value>
    [DataMember(Name="organization_registration_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "organization_registration_id")]
    public string OrganizationRegistrationId { get; set; }

    /// <summary>
    /// The gender of the person. This is not known in all markets 
    /// </summary>
    /// <value>The gender of the person. This is not known in all markets </value>
    [DataMember(Name="gender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gender")]
    public string Gender { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Customer {\n");
      sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  OrganizationRegistrationId: ").Append(OrganizationRegistrationId).Append("\n");
      sb.Append("  Gender: ").Append(Gender).Append("\n");
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
