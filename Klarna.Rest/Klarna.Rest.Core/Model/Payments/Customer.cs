using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Customer : PaymentCustomer {
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Customer {\n");
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
