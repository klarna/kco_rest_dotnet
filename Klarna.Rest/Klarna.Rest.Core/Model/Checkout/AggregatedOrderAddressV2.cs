using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AggregatedOrderAddressV2 {
    /// <summary>
    /// Gets or Sets OrganizationName
    /// </summary>
    [DataMember(Name="organization_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "organization_name")]
    public string OrganizationName { get; set; }

    /// <summary>
    /// Gets or Sets Reference
    /// </summary>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Gets or Sets Attention
    /// </summary>
    [DataMember(Name="attention", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attention")]
    public string Attention { get; set; }

    /// <summary>
    /// Given name.
    /// </summary>
    /// <value>Given name.</value>
    [DataMember(Name="given_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "given_name")]
    public string GivenName { get; set; }

    /// <summary>
    /// Family name.
    /// </summary>
    /// <value>Family name.</value>
    [DataMember(Name="family_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "family_name")]
    public string FamilyName { get; set; }

    /// <summary>
    /// E-mail address.
    /// </summary>
    /// <value>E-mail address.</value>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Title.<p>Valid values for UK:</p><ul><li><em>Mr</em></li><li><em>Ms</em></li><li><em>Mrs</em></li><li><em>Miss</em></li></ul><p>Valid values for DACH:</p><ul><li><em>Herr</em></li><li><em>Frau</em></li></ul><p>Valid values for NL:</p><ul><li><em>Dhr.</em></li><li><em>Mevr.</em></li></ul>
    /// </summary>
    /// <value>Title.<p>Valid values for UK:</p><ul><li><em>Mr</em></li><li><em>Ms</em></li><li><em>Mrs</em></li><li><em>Miss</em></li></ul><p>Valid values for DACH:</p><ul><li><em>Herr</em></li><li><em>Frau</em></li></ul><p>Valid values for NL:</p><ul><li><em>Dhr.</em></li><li><em>Mevr.</em></li></ul></value>
    [DataMember(Name="title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

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
    /// Street name. Only applicable in DE/AT/NL. Do not combine with street_address. See <b>streetNumber</b>.
    /// </summary>
    /// <value>Street name. Only applicable in DE/AT/NL. Do not combine with street_address. See <b>streetNumber</b>.</value>
    [DataMember(Name="street_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "street_name")]
    public string StreetName { get; set; }

    /// <summary>
    /// Street number. Only applicable in DE/AT/NL. Do not combine with street_address. See <b>streetName</b>.
    /// </summary>
    /// <value>Street number. Only applicable in DE/AT/NL. Do not combine with street_address. See <b>streetName</b>.</value>
    [DataMember(Name="street_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "street_number")]
    public string StreetNumber { get; set; }

    /// <summary>
    /// House extension. Only applicable in NL
    /// </summary>
    /// <value>House extension. Only applicable in NL</value>
    [DataMember(Name="house_extension", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "house_extension")]
    public string HouseExtension { get; set; }

    /// <summary>
    /// Postal/post code.
    /// </summary>
    /// <value>Postal/post code.</value>
    [DataMember(Name="postal_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postal_code")]
    public string PostalCode { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    /// <value>City.</value>
    [DataMember(Name="city", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "city")]
    public string City { get; set; }

    /// <summary>
    /// State or Region.
    /// </summary>
    /// <value>State or Region.</value>
    [DataMember(Name="region", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "region")]
    public string Region { get; set; }

    /// <summary>
    /// Phone number.
    /// </summary>
    /// <value>Phone number.</value>
    [DataMember(Name="phone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phone")]
    public string Phone { get; set; }

    /// <summary>
    /// ISO 3166 alpha-2. Country.
    /// </summary>
    /// <value>ISO 3166 alpha-2. Country.</value>
    [DataMember(Name="country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    /// <summary>
    /// Care of.
    /// </summary>
    /// <value>Care of.</value>
    [DataMember(Name="care_of", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "care_of")]
    public string CareOf { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AggregatedOrderAddressV2 {\n");
      sb.Append("  OrganizationName: ").Append(OrganizationName).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  Attention: ").Append(Attention).Append("\n");
      sb.Append("  GivenName: ").Append(GivenName).Append("\n");
      sb.Append("  FamilyName: ").Append(FamilyName).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  StreetAddress: ").Append(StreetAddress).Append("\n");
      sb.Append("  StreetAddress2: ").Append(StreetAddress2).Append("\n");
      sb.Append("  StreetName: ").Append(StreetName).Append("\n");
      sb.Append("  StreetNumber: ").Append(StreetNumber).Append("\n");
      sb.Append("  HouseExtension: ").Append(HouseExtension).Append("\n");
      sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
      sb.Append("  City: ").Append(City).Append("\n");
      sb.Append("  Region: ").Append(Region).Append("\n");
      sb.Append("  Phone: ").Append(Phone).Append("\n");
      sb.Append("  Country: ").Append(Country).Append("\n");
      sb.Append("  CareOf: ").Append(CareOf).Append("\n");
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
