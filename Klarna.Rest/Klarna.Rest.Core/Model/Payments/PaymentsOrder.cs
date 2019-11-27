using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsOrder {
    /// <summary>
    /// The payment method authorized for the order
    /// </summary>
    /// <value>The payment method authorized for the order</value>
    [DataMember(Name="authorized_payment_method", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorized_payment_method")]
    public PaymentsAuthorizedPaymentMethod AuthorizedPaymentMethod { get; set; }

    /// <summary>
    /// Fraud status for the order. Either ACCEPTED, PENDING or REJECTED.
    /// </summary>
    /// <value>Fraud status for the order. Either ACCEPTED, PENDING or REJECTED.</value>
    [DataMember(Name="fraud_status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fraud_status")]
    public string FraudStatus { get; set; }

    /// <summary>
    /// The unique order ID (max 255 characters).
    /// </summary>
    /// <value>The unique order ID (max 255 characters).</value>
    [DataMember(Name="order_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_id")]
    public string OrderId { get; set; }

    /// <summary>
    /// URL to redirect the customer to after placing the order.
    /// </summary>
    /// <value>URL to redirect the customer to after placing the order.</value>
    [DataMember(Name="redirect_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "redirect_url")]
    public string RedirectUrl { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsOrder {\n");
      sb.Append("  AuthorizedPaymentMethod: ").Append(AuthorizedPaymentMethod).Append("\n");
      sb.Append("  FraudStatus: ").Append(FraudStatus).Append("\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
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
