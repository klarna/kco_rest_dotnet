using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Address {
    /// <summary>
    /// Given name. Maximum 100 characters.
    /// </summary>
    /// <value>Given name. Maximum 100 characters.</value>
    [DataMember(Name="given_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "given_name")]
    public string GivenName { get; set; }

    /// <summary>
    /// Family name. Maximum 100 characters.
    /// </summary>
    /// <value>Family name. Maximum 100 characters.</value>
    [DataMember(Name="family_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "family_name")]
    public string FamilyName { get; set; }

    /// <summary>
    /// Title. Between 0 and 20 characters.
    /// </summary>
    /// <value>Title. Between 0 and 20 characters.</value>
    [DataMember(Name="title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    /// <summary>
    /// First line of street address. Maximum 100 characters.
    /// </summary>
    /// <value>First line of street address. Maximum 100 characters.</value>
    [DataMember(Name="street_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "street_address")]
    public string StreetAddress { get; set; }

    /// <summary>
    /// Second line of street address. Maximum 100 characters.
    /// </summary>
    /// <value>Second line of street address. Maximum 100 characters.</value>
    [DataMember(Name="street_address2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "street_address2")]
    public string StreetAddress2 { get; set; }

    /// <summary>
    /// Postcode. Maximum 10 characters.
    /// </summary>
    /// <value>Postcode. Maximum 10 characters.</value>
    [DataMember(Name="postal_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postal_code")]
    public string PostalCode { get; set; }

    /// <summary>
    /// City. Maximum 200 characters.
    /// </summary>
    /// <value>City. Maximum 200 characters.</value>
    [DataMember(Name="city", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "city")]
    public string City { get; set; }

    /// <summary>
    /// State/Region. Required for US. Maximum 200 characters.
    /// </summary>
    /// <value>State/Region. Required for US. Maximum 200 characters.</value>
    [DataMember(Name="region", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "region")]
    public string Region { get; set; }

    /// <summary>
    /// Country. ISO 3166 alpha-2.
    /// </summary>
    /// <value>Country. ISO 3166 alpha-2.</value>
    [DataMember(Name="country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    /// <summary>
    /// E-mail address. Maximum 100 characters.
    /// </summary>
    /// <value>E-mail address. Maximum 100 characters.</value>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Phone number. Maximum 100 characters.
    /// </summary>
    /// <value>Phone number. Maximum 100 characters.</value>
    [DataMember(Name="phone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phone")]
    public string Phone { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Address {\n");
      sb.Append("  GivenName: ").Append(GivenName).Append("\n");
      sb.Append("  FamilyName: ").Append(FamilyName).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  StreetAddress: ").Append(StreetAddress).Append("\n");
      sb.Append("  StreetAddress2: ").Append(StreetAddress2).Append("\n");
      sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
      sb.Append("  City: ").Append(City).Append("\n");
      sb.Append("  Region: ").Append(Region).Append("\n");
      sb.Append("  Country: ").Append(Country).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  Phone: ").Append(Phone).Append("\n");
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
