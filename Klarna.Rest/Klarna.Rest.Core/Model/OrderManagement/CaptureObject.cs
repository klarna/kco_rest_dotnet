using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CaptureObject {
    /// <summary>
    /// The captured amount in minor units.
    /// </summary>
    /// <value>The captured amount in minor units.</value>
    [DataMember(Name="captured_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "captured_amount")]
    public long? CapturedAmount { get; set; }

    /// <summary>
    /// Description of the capture shown to the customer. Maximum 255 characters.
    /// </summary>
    /// <value>Description of the capture shown to the customer. Maximum 255 characters.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Internal reference to the capture. This will be included in the settlement files. Max length is 255 characters.
    /// </summary>
    /// <value>Internal reference to the capture. This will be included in the settlement files. Max length is 255 characters.</value>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Order lines for this capture. Maximum 1000 items.
    /// </summary>
    /// <value>Order lines for this capture. Maximum 1000 items.</value>
    [DataMember(Name="order_lines", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_lines")]
    public List<OrderLine> OrderLines { get; set; }

    /// <summary>
    /// Shipping information for this capture. Maximum 500 items.
    /// </summary>
    /// <value>Shipping information for this capture. Maximum 500 items.</value>
    [DataMember(Name="shipping_info", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_info")]
    public List<ShippingInfo> ShippingInfo { get; set; }

    /// <summary>
    /// Delay before the order will be shipped. Use for improving the customer experience regarding payments. This field is currently not returned when reading the order. Minimum: 0. Please note: to be able to submit values larger than 0, this has to be enabled in your merchant account. Please contact Klarna for further information.
    /// </summary>
    /// <value>Delay before the order will be shipped. Use for improving the customer experience regarding payments. This field is currently not returned when reading the order. Minimum: 0. Please note: to be able to submit values larger than 0, this has to be enabled in your merchant account. Please contact Klarna for further information.</value>
    [DataMember(Name="shipping_delay", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_delay")]
    public long? ShippingDelay { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CaptureObject {\n");
      sb.Append("  CapturedAmount: ").Append(CapturedAmount).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  OrderLines: ").Append(OrderLines).Append("\n");
      sb.Append("  ShippingInfo: ").Append(ShippingInfo).Append("\n");
      sb.Append("  ShippingDelay: ").Append(ShippingDelay).Append("\n");
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
