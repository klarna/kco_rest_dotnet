using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RecurringOrderRequestV1 {
    /// <summary>
    /// Gets or Sets Locale
    /// </summary>
    [DataMember(Name="locale", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locale")]
    public string Locale { get; set; }

    /// <summary>
    /// Gets or Sets Cart
    /// </summary>
    [DataMember(Name="cart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cart")]
    public AggregatedOrderCartV2 Cart { get; set; }

    /// <summary>
    /// Gets or Sets Merchant
    /// </summary>
    [DataMember(Name="merchant", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant")]
    public MerchantAggregatedOrderV2 Merchant { get; set; }

    /// <summary>
    /// Gets or Sets MerchantReference
    /// </summary>
    [DataMember(Name="merchant_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference")]
    public Dictionary<string, string> MerchantReference { get; set; }

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
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RecurringOrderRequestV1 {\n");
      sb.Append("  Locale: ").Append(Locale).Append("\n");
      sb.Append("  Cart: ").Append(Cart).Append("\n");
      sb.Append("  Merchant: ").Append(Merchant).Append("\n");
      sb.Append("  MerchantReference: ").Append(MerchantReference).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
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
