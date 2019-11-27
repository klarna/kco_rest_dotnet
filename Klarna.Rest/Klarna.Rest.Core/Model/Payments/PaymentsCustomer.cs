using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsCustomer {
    /// <summary>
    /// ISO 8601 date. The customer date of birth.
    /// </summary>
    /// <value>ISO 8601 date. The customer date of birth.</value>
    [DataMember(Name="date_of_birth", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date_of_birth")]
    public string DateOfBirth { get; set; }

    /// <summary>
    /// The customer gender.
    /// </summary>
    /// <value>The customer gender.</value>
    [DataMember(Name="gender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gender")]
    public string Gender { get; set; }

    /// <summary>
    /// Last four digits for customer social security number
    /// </summary>
    /// <value>Last four digits for customer social security number</value>
    [DataMember(Name="last_four_ssn", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "last_four_ssn")]
    public string LastFourSsn { get; set; }

    /// <summary>
    /// The customer's national identification number
    /// </summary>
    /// <value>The customer's national identification number</value>
    [DataMember(Name="national_identification_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "national_identification_number")]
    public string NationalIdentificationNumber { get; set; }

    /// <summary>
    /// Organization entity type
    /// </summary>
    /// <value>Organization entity type</value>
    [DataMember(Name="organization_entity_type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "organization_entity_type")]
    public string OrganizationEntityType { get; set; }

    /// <summary>
    /// Organization registration id
    /// </summary>
    /// <value>Organization registration id</value>
    [DataMember(Name="organization_registration_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "organization_registration_id")]
    public string OrganizationRegistrationId { get; set; }

    /// <summary>
    /// The customer's title
    /// </summary>
    /// <value>The customer's title</value>
    [DataMember(Name="title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    /// <value>Type</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// VAT id
    /// </summary>
    /// <value>VAT id</value>
    [DataMember(Name="vat_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vat_id")]
    public string VatId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsCustomer {\n");
      sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
      sb.Append("  Gender: ").Append(Gender).Append("\n");
      sb.Append("  LastFourSsn: ").Append(LastFourSsn).Append("\n");
      sb.Append("  NationalIdentificationNumber: ").Append(NationalIdentificationNumber).Append("\n");
      sb.Append("  OrganizationEntityType: ").Append(OrganizationEntityType).Append("\n");
      sb.Append("  OrganizationRegistrationId: ").Append(OrganizationRegistrationId).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  VatId: ").Append(VatId).Append("\n");
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
