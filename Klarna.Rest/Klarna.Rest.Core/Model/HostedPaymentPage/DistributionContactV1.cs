using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class DistributionContactV1 {
    /// <summary>
    /// Email where to send the email with the HPP link. Only required if distribution method is 'email'
    /// </summary>
    /// <value>Email where to send the email with the HPP link. Only required if distribution method is 'email'</value>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Phone number where to send the sms with the HPP link. Only required if distribution method is 'sms'
    /// </summary>
    /// <value>Phone number where to send the sms with the HPP link. Only required if distribution method is 'sms'</value>
    [DataMember(Name="phone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phone")]
    public string Phone { get; set; }

    /// <summary>
    /// ISO 3166 alpha-2 phone country. Only required if distribution method is 'sms'
    /// </summary>
    /// <value>ISO 3166 alpha-2 phone country. Only required if distribution method is 'sms'</value>
    [DataMember(Name="phone_country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phone_country")]
    public string PhoneCountry { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DistributionContactV1 {\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  Phone: ").Append(Phone).Append("\n");
      sb.Append("  PhoneCountry: ").Append(PhoneCountry).Append("\n");
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
