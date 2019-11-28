using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CustomerV2 {
    /// <summary>
    /// Gets or Sets Gender
    /// </summary>
    [DataMember(Name="gender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gender")]
    public string Gender { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets DateOfBirth
    /// </summary>
    [DataMember(Name="date_of_birth", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date_of_birth")]
    public string DateOfBirth { get; set; }

    /// <summary>
    /// Gets or Sets NationalIdentificationNumber
    /// </summary>
    [DataMember(Name="national_identification_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "national_identification_number")]
    public string NationalIdentificationNumber { get; set; }

    /// <summary>
    /// Gets or Sets OrganizationRegistrationId
    /// </summary>
    [DataMember(Name="organization_registration_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "organization_registration_id")]
    public string OrganizationRegistrationId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CustomerV2 {\n");
      sb.Append("  Gender: ").Append(Gender).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
      sb.Append("  NationalIdentificationNumber: ").Append(NationalIdentificationNumber).Append("\n");
      sb.Append("  OrganizationRegistrationId: ").Append(OrganizationRegistrationId).Append("\n");
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
