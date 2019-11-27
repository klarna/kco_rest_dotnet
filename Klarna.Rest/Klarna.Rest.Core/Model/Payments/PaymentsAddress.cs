using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsAddress {
    /// <summary>
    /// Attention
    /// </summary>
    /// <value>Attention</value>
    [DataMember(Name="attention", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attention")]
    public string Attention { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    /// <value>City.</value>
    [DataMember(Name="city", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "city")]
    public string City { get; set; }

    /// <summary>
    /// ISO 3166 alpha-2. Country.
    /// </summary>
    /// <value>ISO 3166 alpha-2. Country.</value>
    [DataMember(Name="country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    /// <summary>
    /// E-mail address.
    /// </summary>
    /// <value>E-mail address.</value>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Family name.
    /// </summary>
    /// <value>Family name.</value>
    [DataMember(Name="family_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "family_name")]
    public string FamilyName { get; set; }

    /// <summary>
    /// Given name.
    /// </summary>
    /// <value>Given name.</value>
    [DataMember(Name="given_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "given_name")]
    public string GivenName { get; set; }

    /// <summary>
    /// Organization name
    /// </summary>
    /// <value>Organization name</value>
    [DataMember(Name="organization_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "organization_name")]
    public string OrganizationName { get; set; }

    /// <summary>
    /// Phone number.
    /// </summary>
    /// <value>Phone number.</value>
    [DataMember(Name="phone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phone")]
    public string Phone { get; set; }

    /// <summary>
    /// Postal/post code.
    /// </summary>
    /// <value>Postal/post code.</value>
    [DataMember(Name="postal_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postal_code")]
    public string PostalCode { get; set; }

    /// <summary>
    /// State or Region.
    /// </summary>
    /// <value>State or Region.</value>
    [DataMember(Name="region", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "region")]
    public string Region { get; set; }

    /// <summary>
    /// Street address, first line.
    /// </summary>
    /// <value>Street address, first line.</value>
    [DataMember(Name="street_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "street_address")]
    public string StreetAddress { get; set; }

    /// <summary>
    /// Street address, second line.
    /// </summary>
    /// <value>Street address, second line.</value>
    [DataMember(Name="street_address2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "street_address2")]
    public string StreetAddress2 { get; set; }

    /// <summary>
    /// Title.
    /// </summary>
    /// <value>Title.</value>
    [DataMember(Name="title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsAddress {\n");
      sb.Append("  Attention: ").Append(Attention).Append("\n");
      sb.Append("  City: ").Append(City).Append("\n");
      sb.Append("  Country: ").Append(Country).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  FamilyName: ").Append(FamilyName).Append("\n");
      sb.Append("  GivenName: ").Append(GivenName).Append("\n");
      sb.Append("  OrganizationName: ").Append(OrganizationName).Append("\n");
      sb.Append("  Phone: ").Append(Phone).Append("\n");
      sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
      sb.Append("  Region: ").Append(Region).Append("\n");
      sb.Append("  StreetAddress: ").Append(StreetAddress).Append("\n");
      sb.Append("  StreetAddress2: ").Append(StreetAddress2).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
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
