using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Refund : OrderManagementGetRefundResponse {
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Refund {\n");
      sb.Append("  RefundId: ").Append(RefundId).Append("\n");
      sb.Append("  RefundedAmount: ").Append(RefundedAmount).Append("\n");
      sb.Append("  RefundedAt: ").Append(RefundedAt).Append("\n");
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
