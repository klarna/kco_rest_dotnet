using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ShippingInfo : OrderManagementShippingInfo {
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingInfo {\n");
      sb.Append("  ShippingCompany: ").Append(ShippingCompany).Append("\n");
      sb.Append("  ShippingMethod: ").Append(ShippingMethod).Append("\n");
      sb.Append("  TrackingNumber: ").Append(TrackingNumber).Append("\n");
      sb.Append("  TrackingUri: ").Append(TrackingUri).Append("\n");
      sb.Append("  ReturnShippingCompany: ").Append(ReturnShippingCompany).Append("\n");
      sb.Append("  ReturnTrackingNumber: ").Append(ReturnTrackingNumber).Append("\n");
      sb.Append("  ReturnTrackingUri: ").Append(ReturnTrackingUri).Append("\n");
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
