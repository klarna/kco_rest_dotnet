using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Order : CheckoutOrder {
    /// <summary>
    /// Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).
    /// </summary>
    /// <value>Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).</value>
    [DataMember(Name="billing_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "billing_address")]
    public Address BillingAddress { get; set; }

    /// <summary>
    /// Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of billing_address.
    /// </summary>
    /// <value>Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of billing_address.</value>
    [DataMember(Name="shipping_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_address")]
    public Address ShippingAddress { get; set; }

    /// <summary>
    /// Information about the liable customer of the order.
    /// </summary>
    /// <value>Information about the liable customer of the order.</value>
    [DataMember(Name="customer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customer")]
    public Customer Customer { get; set; }

    /// <summary>
    /// Options for this purchase.
    /// </summary>
    /// <value>Options for this purchase.</value>
    [DataMember(Name="options", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "options")]
    public Options Options { get; set; }

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Order {\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
      sb.Append("  Locale: ").Append(Locale).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
      sb.Append("  OrderAmount: ").Append(OrderAmount).Append("\n");
      sb.Append("  OrderTaxAmount: ").Append(OrderTaxAmount).Append("\n");
      sb.Append("  OrderLines: ").Append(OrderLines).Append("\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  MerchantUrls: ").Append(MerchantUrls).Append("\n");
      sb.Append("  HtmlSnippet: ").Append(HtmlSnippet).Append("\n");
      sb.Append("  MerchantReference1: ").Append(MerchantReference1).Append("\n");
      sb.Append("  MerchantReference2: ").Append(MerchantReference2).Append("\n");
      sb.Append("  StartedAt: ").Append(StartedAt).Append("\n");
      sb.Append("  CompletedAt: ").Append(CompletedAt).Append("\n");
      sb.Append("  LastModifiedAt: ").Append(LastModifiedAt).Append("\n");
      sb.Append("  Options: ").Append(Options).Append("\n");
      sb.Append("  Attachment: ").Append(Attachment).Append("\n");
      sb.Append("  ExternalPaymentMethods: ").Append(ExternalPaymentMethods).Append("\n");
      sb.Append("  ExternalCheckouts: ").Append(ExternalCheckouts).Append("\n");
      sb.Append("  ShippingCountries: ").Append(ShippingCountries).Append("\n");
      sb.Append("  ShippingOptions: ").Append(ShippingOptions).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  Gui: ").Append(Gui).Append("\n");
      sb.Append("  MerchantRequested: ").Append(MerchantRequested).Append("\n");
      sb.Append("  SelectedShippingOption: ").Append(SelectedShippingOption).Append("\n");
      sb.Append("  Recurring: ").Append(Recurring).Append("\n");
      sb.Append("  RecurringToken: ").Append(RecurringToken).Append("\n");
      sb.Append("  RecurringDescription: ").Append(RecurringDescription).Append("\n");
      sb.Append("  BillingCountries: ").Append(BillingCountries).Append("\n");
      sb.Append("  Tags: ").Append(Tags).Append("\n");
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
