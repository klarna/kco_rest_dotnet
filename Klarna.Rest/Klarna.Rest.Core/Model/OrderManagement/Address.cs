using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Address : OrderManagementAddressInfo{
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
