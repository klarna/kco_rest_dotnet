using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsCreateOrderRequest {
    /// <summary>
    /// Type of acquiring channel
    /// </summary>
    /// <value>Type of acquiring channel</value>
    [DataMember(Name="acquiring_channel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "acquiring_channel")]
    public string AcquiringChannel { get; set; }

    /// <summary>
    /// Additional purchase information required for some industries.
    /// </summary>
    /// <value>Additional purchase information required for some industries.</value>
    [DataMember(Name="attachment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attachment")]
    public PaymentsAttachment Attachment { get; set; }

    /// <summary>
    /// Authorization token.
    /// </summary>
    /// <value>Authorization token.</value>
    [DataMember(Name="authorization_token", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorization_token")]
    public string AuthorizationToken { get; set; }

    /// <summary>
    /// Allow merchant to trigger auto capturing.
    /// </summary>
    /// <value>Allow merchant to trigger auto capturing.</value>
    [DataMember(Name="auto_capture", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "auto_capture")]
    public bool? AutoCapture { get; set; }

    /// <summary>
    /// Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).
    /// </summary>
    /// <value>Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).</value>
    [DataMember(Name="billing_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "billing_address")]
    public PaymentsAddress BillingAddress { get; set; }

    /// <summary>
    /// Token to be passed to the JS client
    /// </summary>
    /// <value>Token to be passed to the JS client</value>
    [DataMember(Name="client_token", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "client_token")]
    public string ClientToken { get; set; }

    /// <summary>
    /// Ids for custom payment methods available in a given order. Only applicable in GB/US sessions.
    /// </summary>
    /// <value>Ids for custom payment methods available in a given order. Only applicable in GB/US sessions.</value>
    [DataMember(Name="custom_payment_method_ids", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "custom_payment_method_ids")]
    public List<string> CustomPaymentMethodIds { get; set; }

    /// <summary>
    /// Information about the liable customer of the order.
    /// </summary>
    /// <value>Information about the liable customer of the order.</value>
    [DataMember(Name="customer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customer")]
    public PaymentsCustomer Customer { get; set; }

    /// <summary>
    /// Gets or Sets Design
    /// </summary>
    [DataMember(Name="design", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "design")]
    public string Design { get; set; }

    /// <summary>
    /// Session expiration date
    /// </summary>
    /// <value>Session expiration date</value>
    [DataMember(Name="expires_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expires_at")]
    public PaymentsInstant ExpiresAt { get; set; }

    /// <summary>
    /// RFC 1766 customer's locale.
    /// </summary>
    /// <value>RFC 1766 customer's locale.</value>
    [DataMember(Name="locale", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locale")]
    public string Locale { get; set; }

    /// <summary>
    /// Pass through field (max 1024 characters).
    /// </summary>
    /// <value>Pass through field (max 1024 characters).</value>
    [DataMember(Name="merchant_data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_data")]
    public string MerchantData { get; set; }

    /// <summary>
    /// Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as \"order number\" and send to the customer in the confirmation mail after a successful direct bank transfer payment. It will also be included in the payments description in the customer's bank account (max 255 characters).
    /// </summary>
    /// <value>Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as \"order number\" and send to the customer in the confirmation mail after a successful direct bank transfer payment. It will also be included in the payments description in the customer's bank account (max 255 characters).</value>
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
    /// The merchant_urls object.
    /// </summary>
    /// <value>The merchant_urls object.</value>
    [DataMember(Name="merchant_urls", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_urls")]
    public PaymentsMerchantUrls MerchantUrls { get; set; }

    /// <summary>
    /// Options for this purchase.
    /// </summary>
    /// <value>Options for this purchase.</value>
    [DataMember(Name="options", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "options")]
    public PaymentsOptions Options { get; set; }

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
    public List<PaymentsOrderLine> OrderLines { get; set; }

    /// <summary>
    /// Non-negative, minor units. The total tax amount of the order.
    /// </summary>
    /// <value>Non-negative, minor units. The total tax amount of the order.</value>
    [DataMember(Name="order_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_tax_amount")]
    public long? OrderTaxAmount { get; set; }

    /// <summary>
    /// Available payment method categories
    /// </summary>
    /// <value>Available payment method categories</value>
    [DataMember(Name="payment_method_categories", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_method_categories")]
    public List<PaymentsPaymentMethodCategory> PaymentMethodCategories { get; set; }

    /// <summary>
    /// ISO 3166 alpha-2 purchase country.
    /// </summary>
    /// <value>ISO 3166 alpha-2 purchase country.</value>
    [DataMember(Name="purchase_country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_country")]
    public string PurchaseCountry { get; set; }

    /// <summary>
    /// ISO 4217 purchase currency.
    /// </summary>
    /// <value>ISO 4217 purchase currency.</value>
    [DataMember(Name="purchase_currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_currency")]
    public string PurchaseCurrency { get; set; }

    /// <summary>
    /// Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of billing_address.
    /// </summary>
    /// <value>Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of billing_address.</value>
    [DataMember(Name="shipping_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_address")]
    public PaymentsAddress ShippingAddress { get; set; }

    /// <summary>
    /// The current status of the session. Possible values: 'complete', 'incomplete' where 'complete' is set when the order has been placed.
    /// </summary>
    /// <value>The current status of the session. Possible values: 'complete', 'incomplete' where 'complete' is set when the order has been placed.</value>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsCreateOrderRequest {\n");
      sb.Append("  AcquiringChannel: ").Append(AcquiringChannel).Append("\n");
      sb.Append("  Attachment: ").Append(Attachment).Append("\n");
      sb.Append("  AuthorizationToken: ").Append(AuthorizationToken).Append("\n");
      sb.Append("  AutoCapture: ").Append(AutoCapture).Append("\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  ClientToken: ").Append(ClientToken).Append("\n");
      sb.Append("  CustomPaymentMethodIds: ").Append(CustomPaymentMethodIds).Append("\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  Design: ").Append(Design).Append("\n");
      sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
      sb.Append("  Locale: ").Append(Locale).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  MerchantReference1: ").Append(MerchantReference1).Append("\n");
      sb.Append("  MerchantReference2: ").Append(MerchantReference2).Append("\n");
      sb.Append("  MerchantUrls: ").Append(MerchantUrls).Append("\n");
      sb.Append("  Options: ").Append(Options).Append("\n");
      sb.Append("  OrderAmount: ").Append(OrderAmount).Append("\n");
      sb.Append("  OrderLines: ").Append(OrderLines).Append("\n");
      sb.Append("  OrderTaxAmount: ").Append(OrderTaxAmount).Append("\n");
      sb.Append("  PaymentMethodCategories: ").Append(PaymentMethodCategories).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
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
