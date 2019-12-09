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
  public class AggregatedOrderUpdateRequestV2 {
    /// <summary>
    /// Gets or Sets Locale
    /// </summary>
    [DataMember(Name="locale", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locale")]
    public string Locale { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets Cart
    /// </summary>
    [DataMember(Name="cart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cart")]
    public AggregatedOrderCartV2 Cart { get; set; }

    /// <summary>
    /// Gets or Sets Customer
    /// </summary>
    [DataMember(Name="customer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customer")]
    public CustomerV2 Customer { get; set; }

    /// <summary>
    /// Gets or Sets Gui
    /// </summary>
    [DataMember(Name="gui", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gui")]
    public Gui Gui { get; set; }

    /// <summary>
    /// Gets or Sets Merchant
    /// </summary>
    [DataMember(Name="merchant", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant")]
    public MerchantAggregatedOrderRequestUpdateV2 Merchant { get; set; }

    /// <summary>
    /// Gets or Sets Options
    /// </summary>
    [DataMember(Name="options", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "options")]
    public Options Options { get; set; }

    /// <summary>
    /// Gets or Sets Attachment
    /// </summary>
    [DataMember(Name="attachment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attachment")]
    public Attachment Attachment { get; set; }

    /// <summary>
    /// Gets or Sets Recurring
    /// </summary>
    [DataMember(Name="recurring", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "recurring")]
    public bool? Recurring { get; set; }

    /// <summary>
    /// Gets or Sets Reservation
    /// </summary>
    [DataMember(Name="reservation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reservation")]
    public string Reservation { get; set; }

    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets StartedAt
    /// </summary>
    [DataMember(Name="started_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "started_at")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// Gets or Sets CompletedAt
    /// </summary>
    [DataMember(Name="completed_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Gets or Sets LastModifiedAt
    /// </summary>
    [DataMember(Name="last_modified_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "last_modified_at")]
    public DateTime? LastModifiedAt { get; set; }

    /// <summary>
    /// Gets or Sets ExpiresAt
    /// </summary>
    [DataMember(Name="expires_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expires_at")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Gets or Sets PurchaseCountry
    /// </summary>
    [DataMember(Name="purchase_country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_country")]
    public string PurchaseCountry { get; set; }

    /// <summary>
    /// Gets or Sets PurchaseCurrency
    /// </summary>
    [DataMember(Name="purchase_currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_currency")]
    public string PurchaseCurrency { get; set; }

    /// <summary>
    /// Gets or Sets MerchantReference
    /// </summary>
    [DataMember(Name="merchant_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference")]
    public Dictionary<string, string> MerchantReference { get; set; }

    /// <summary>
    /// Gets or Sets BillingAddress
    /// </summary>
    [DataMember(Name="billing_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "billing_address")]
    public AggregatedOrderAddressV2 BillingAddress { get; set; }

    /// <summary>
    /// Gets or Sets ShippingAddress
    /// </summary>
    [DataMember(Name="shipping_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_address")]
    public AggregatedOrderAddressV2 ShippingAddress { get; set; }

    /// <summary>
    /// Gets or Sets TraderId
    /// </summary>
    [DataMember(Name="trader_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "trader_id")]
    public string TraderId { get; set; }

    /// <summary>
    /// Gets or Sets ExternalPaymentMethods
    /// </summary>
    [DataMember(Name="external_payment_methods", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "external_payment_methods")]
    public List<AggregatedOrderPaymentProviderV2> ExternalPaymentMethods { get; set; }

    /// <summary>
    /// Gets or Sets ExternalCheckouts
    /// </summary>
    [DataMember(Name="external_checkouts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "external_checkouts")]
    public List<AggregatedOrderPaymentProviderV2> ExternalCheckouts { get; set; }

    /// <summary>
    /// Gets or Sets MerchantOrderData
    /// </summary>
    [DataMember(Name="merchant_order_data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_order_data")]
    public string MerchantOrderData { get; set; }

    /// <summary>
    /// Gets or Sets MerchantRequested
    /// </summary>
    [DataMember(Name="merchant_requested", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_requested")]
    public MerchantRequested MerchantRequested { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AggregatedOrderUpdateRequestV2 {\n");
      sb.Append("  Locale: ").Append(Locale).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Cart: ").Append(Cart).Append("\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  Gui: ").Append(Gui).Append("\n");
      sb.Append("  Merchant: ").Append(Merchant).Append("\n");
      sb.Append("  Options: ").Append(Options).Append("\n");
      sb.Append("  Attachment: ").Append(Attachment).Append("\n");
      sb.Append("  Recurring: ").Append(Recurring).Append("\n");
      sb.Append("  Reservation: ").Append(Reservation).Append("\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  StartedAt: ").Append(StartedAt).Append("\n");
      sb.Append("  CompletedAt: ").Append(CompletedAt).Append("\n");
      sb.Append("  LastModifiedAt: ").Append(LastModifiedAt).Append("\n");
      sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
      sb.Append("  MerchantReference: ").Append(MerchantReference).Append("\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
      sb.Append("  TraderId: ").Append(TraderId).Append("\n");
      sb.Append("  ExternalPaymentMethods: ").Append(ExternalPaymentMethods).Append("\n");
      sb.Append("  ExternalCheckouts: ").Append(ExternalCheckouts).Append("\n");
      sb.Append("  MerchantOrderData: ").Append(MerchantOrderData).Append("\n");
      sb.Append("  MerchantRequested: ").Append(MerchantRequested).Append("\n");
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
