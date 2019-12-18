using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class OptionsV1: HostedPaymentPageOptions {
    /// <summary>
    /// Whether or not the Payment Page will show fallback payment methods to the Consumer if the the specified payment methods fail. Ignored field for KCO Orders.
    /// </summary>
    /// <value>Whether or not the Payment Page will show fallback payment methods to the Consumer if the the specified payment methods fail. Ignored field for KCO Orders.</value>
    [DataMember(Name="payment_fallback", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_fallback")]
    public bool? PaymentFallback { get; set; }

    /// <summary>
    /// Payment Method Categories to show on the Payment Page. All available categories will be given to the customer if none is specified using payment_method_category or payment_method_categories. Ignored field for KCO Orders.
    /// </summary>
    /// <value>Payment Method Categories to show on the Payment Page. All available categories will be given to the customer if none is specified using payment_method_category or payment_method_categories. Ignored field for KCO Orders.</value>
    [DataMember(Name="payment_method_categories", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_method_categories")]
    public List<string> PaymentMethodCategories { get; set; }
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class OptionsV1 {\n");
      sb.Append("  BackgroundImages: ").Append(BackgroundImages).Append("\n");
      sb.Append("  LogoUrl: ").Append(LogoUrl).Append("\n");
      sb.Append("  PageTitle: ").Append(PageTitle).Append("\n");
      sb.Append("  PaymentFallback: ").Append(PaymentFallback).Append("\n");
      sb.Append("  PaymentMethodCategories: ").Append(PaymentMethodCategories).Append("\n");
      sb.Append("  PaymentMethodCategory: ").Append(PaymentMethodCategory).Append("\n");
      sb.Append("  PurchaseType: ").Append(PurchaseType).Append("\n");
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
