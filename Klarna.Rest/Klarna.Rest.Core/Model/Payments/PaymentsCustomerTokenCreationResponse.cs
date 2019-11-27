using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsCustomerTokenCreationResponse {
    /// <summary>
    /// Billing address of the customer.
    /// </summary>
    /// <value>Billing address of the customer.</value>
    [DataMember(Name="billing_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "billing_address")]
    public PaymentsAddress BillingAddress { get; set; }

    /// <summary>
    /// Customer specific information.
    /// </summary>
    /// <value>Customer specific information.</value>
    [DataMember(Name="customer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customer")]
    public PaymentsCustomer Customer { get; set; }

    /// <summary>
    /// Used to connect customer with payment method when it is present.
    /// </summary>
    /// <value>Used to connect customer with payment method when it is present.</value>
    [DataMember(Name="payment_method_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_method_reference")]
    public string PaymentMethodReference { get; set; }

    /// <summary>
    /// URL to redirect the customer to after placing the order.
    /// </summary>
    /// <value>URL to redirect the customer to after placing the order.</value>
    [DataMember(Name="redirect_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "redirect_url")]
    public string RedirectUrl { get; set; }

    /// <summary>
    /// Used when placing the order
    /// </summary>
    /// <value>Used when placing the order</value>
    [DataMember(Name="token_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "token_id")]
    public string TokenId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsCustomerTokenCreationResponse {\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  PaymentMethodReference: ").Append(PaymentMethodReference).Append("\n");
      sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
      sb.Append("  TokenId: ").Append(TokenId).Append("\n");
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
