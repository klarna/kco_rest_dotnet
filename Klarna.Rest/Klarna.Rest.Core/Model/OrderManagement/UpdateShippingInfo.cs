using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class UpdateShippingInfo {
    /// <summary>
    /// New shipping info. Maximum: 500 items.
    /// </summary>
    /// <value>New shipping info. Maximum: 500 items.</value>
    [DataMember(Name="shipping_info", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_info")]
    public List<ShippingInfo> ShippingInfo { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateShippingInfo {\n");
      sb.Append("  ShippingInfo: ").Append(ShippingInfo).Append("\n");
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
