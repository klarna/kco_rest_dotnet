using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.CustomerToken {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CustomerTokenOrder {
    /// <summary>
    /// Additional purchase information required for some industries.
    /// </summary>
    /// <value>Additional purchase information required for some industries.</value>
    [DataMember(Name="attachment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attachment")]
    public Attachment Attachment { get; set; }

    /// <summary>
    /// Allow merchant to trigger auto capturing.
    /// </summary>
    /// <value>Allow merchant to trigger auto capturing.</value>
    [DataMember(Name="auto_capture", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "auto_capture")]
    public bool? AutoCapture { get; set; }

    /// <summary>
    /// The merchant_urls object.
    /// </summary>
    /// <value>The merchant_urls object.</value>
    [DataMember(Name="customer_token_order_merchant_urls", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customer_token_order_merchant_urls")]
    public MerchantUrls CustomerTokenOrderMerchantUrls { get; set; }

    /// <summary>
    /// Pass through field (max 1024 characters).
    /// </summary>
    /// <value>Pass through field (max 1024 characters).</value>
    [DataMember(Name="merchant_data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_data")]
    public string MerchantData { get; set; }

    /// <summary>
    /// Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as \"order number\" (max 255 characters).
    /// </summary>
    /// <value>Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as \"order number\" (max 255 characters).</value>
    [DataMember(Name="merchant_reference1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference1")]
    public string MerchantReference1 { get; set; }

    /// <summary>
    /// Used for storing merchant's internal order number or other reference (max 255 characters).
    /// </summary>
    /// <value>Used for storing merchant's internal order number or other reference (max 255 characters).</value>
    [DataMember(Name="merchant_reference2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference2")]
    public string MerchantReference2 { get; set; }

    /// <summary>
    /// Non-negative, minor units. Total amount of the order, including tax and any discounts.
    /// </summary>
    /// <value>Non-negative, minor units. Total amount of the order, including tax and any discounts.</value>
    [DataMember(Name="order_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_amount")]
    public long? OrderAmount { get; set; }

    /// <summary>
    /// The applicable order lines (max 1000)
    /// </summary>
    /// <value>The applicable order lines (max 1000)</value>
    [DataMember(Name="order_lines", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_lines")]
    public List<OrderLine> OrderLines { get; set; }

    /// <summary>
    /// Non-negative, minor units. The total tax amount of the order.
    /// </summary>
    /// <value>Non-negative, minor units. The total tax amount of the order.</value>
    [DataMember(Name="order_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_tax_amount")]
    public long? OrderTaxAmount { get; set; }

    /// <summary>
    /// Used for slice it purchases to use termns
    /// </summary>
    /// <value>Used for slice it purchases to use termns</value>
    [DataMember(Name="payment_method_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_method_reference")]
    public string PaymentMethodReference { get; set; }

    /// <summary>
    /// ISO 4217 purchase currency.
    /// </summary>
    /// <value>ISO 4217 purchase currency.</value>
    [DataMember(Name="purchase_currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_currency")]
    public string PurchaseCurrency { get; set; }

    /// <summary>
    /// Shipping address
    /// </summary>
    /// <value>Shipping address</value>
    [DataMember(Name="shipping_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_address")]
    public Address ShippingAddress { get; set; }

    /// <summary>
    /// Gets or Sets Usage
    /// </summary>
    [DataMember(Name="usage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "usage")]
    public string Usage { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CustomerTokenOrder {\n");
      sb.Append("  Attachment: ").Append(Attachment).Append("\n");
      sb.Append("  AutoCapture: ").Append(AutoCapture).Append("\n");
      sb.Append("  CustomerTokenOrderMerchantUrls: ").Append(CustomerTokenOrderMerchantUrls).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  MerchantReference1: ").Append(MerchantReference1).Append("\n");
      sb.Append("  MerchantReference2: ").Append(MerchantReference2).Append("\n");
      sb.Append("  OrderAmount: ").Append(OrderAmount).Append("\n");
      sb.Append("  OrderLines: ").Append(OrderLines).Append("\n");
      sb.Append("  OrderTaxAmount: ").Append(OrderTaxAmount).Append("\n");
      sb.Append("  PaymentMethodReference: ").Append(PaymentMethodReference).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
      sb.Append("  Usage: ").Append(Usage).Append("\n");
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
