using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RefundObject {
    /// <summary>
    /// Refunded amount in minor units.
    /// </summary>
    /// <value>Refunded amount in minor units.</value>
    [DataMember(Name="refunded_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "refunded_amount")]
    public long? RefundedAmount { get; set; }

    /// <summary>
    /// Description of the refund shown to the customer. Max length is 255 characters.
    /// </summary>
    /// <value>Description of the refund shown to the customer. Max length is 255 characters.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Internal reference to the refund. This will be included in the settlement files. Max length is 255 characters.
    /// </summary>
    /// <value>Internal reference to the refund. This will be included in the settlement files. Max length is 255 characters.</value>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Order lines for the refund shown to the customer. Optional but increases the customer experience. Maximum 1000 order lines.
    /// </summary>
    /// <value>Order lines for the refund shown to the customer. Optional but increases the customer experience. Maximum 1000 order lines.</value>
    [DataMember(Name="order_lines", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_lines")]
    public List<OrderLine> OrderLines { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RefundObject {\n");
      sb.Append("  RefundedAmount: ").Append(RefundedAmount).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  OrderLines: ").Append(OrderLines).Append("\n");
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
