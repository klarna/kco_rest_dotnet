using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class UpdateAuthorization {
    /// <summary>
    /// The new total order amount. Minor units.
    /// </summary>
    /// <value>The new total order amount. Minor units.</value>
    [DataMember(Name="order_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_amount")]
    public long? OrderAmount { get; set; }

    /// <summary>
    /// Description of the change.
    /// </summary>
    /// <value>Description of the change.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// New set of order lines for the order.
    /// </summary>
    /// <value>New set of order lines for the order.</value>
    [DataMember(Name="order_lines", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_lines")]
    public List<OrderLine> OrderLines { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateAuthorization {\n");
      sb.Append("  OrderAmount: ").Append(OrderAmount).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
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
