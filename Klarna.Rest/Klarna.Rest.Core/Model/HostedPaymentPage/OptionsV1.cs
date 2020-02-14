using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class OptionsV1 {
    /// <summary>
    /// Array of Images to use for the background. Best matching resolution will be used.
    /// </summary>
    /// <value>Array of Images to use for the background. Best matching resolution will be used.</value>
    [DataMember(Name="background_images", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "background_images")]
    public List<BackgroundImageV1> BackgroundImages { get; set; }

    /// <summary>
    /// URL of the logo to be displayed
    /// </summary>
    /// <value>URL of the logo to be displayed</value>
    [DataMember(Name="logo_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logo_url")]
    public string LogoUrl { get; set; }

    /// <summary>
    /// Title for the Payment Page
    /// </summary>
    /// <value>Title for the Payment Page</value>
    [DataMember(Name="page_title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "page_title")]
    public string PageTitle { get; set; }

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
    /// Payment Method Category to show on the Payment Page. All available categories will be given to the customer if none is specified using payment_method_category or payment_method_categories. Ignored field for KCO Orders.
    /// </summary>
    /// <value>Payment Method Category to show on the Payment Page. All available categories will be given to the customer if none is specified using payment_method_category or payment_method_categories. Ignored field for KCO Orders.</value>
    [DataMember(Name="payment_method_category", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_method_category")]
    public string PaymentMethodCategory { get; set; }

    /// <summary>
    /// The type of this purchase
    /// </summary>
    /// <value>The type of this purchase</value>
    [DataMember(Name="purchase_type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_type")]
    public string PurchaseType { get; set; }


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
