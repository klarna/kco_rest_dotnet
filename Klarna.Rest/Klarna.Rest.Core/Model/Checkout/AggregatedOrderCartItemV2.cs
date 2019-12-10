using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AggregatedOrderCartItemV2 {
    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Quantity
    /// </summary>
    [DataMember(Name="quantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity")]
    public long? Quantity { get; set; }

    /// <summary>
    /// Gets or Sets Reference
    /// </summary>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Gets or Sets DiscountRate
    /// </summary>
    [DataMember(Name="discount_rate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "discount_rate")]
    public long? DiscountRate { get; set; }

    /// <summary>
    /// Gets or Sets TaxRate
    /// </summary>
    [DataMember(Name="tax_rate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tax_rate")]
    public long? TaxRate { get; set; }

    /// <summary>
    /// Gets or Sets UnitPrice
    /// </summary>
    [DataMember(Name="unit_price", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unit_price")]
    public long? UnitPrice { get; set; }

    /// <summary>
    /// Gets or Sets MerchantItemData
    /// </summary>
    [DataMember(Name="merchant_item_data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_item_data")]
    public string MerchantItemData { get; set; }

    /// <summary>
    /// Gets or Sets TotalPriceIncludingTax
    /// </summary>
    [DataMember(Name="total_price_including_tax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_price_including_tax")]
    public long? TotalPriceIncludingTax { get; set; }

    /// <summary>
    /// Gets or Sets TotalTaxAmount
    /// </summary>
    [DataMember(Name="total_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_tax_amount")]
    public long? TotalTaxAmount { get; set; }

    /// <summary>
    /// Gets or Sets TotalPriceExcludingTax
    /// </summary>
    [DataMember(Name="total_price_excluding_tax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_price_excluding_tax")]
    public long? TotalPriceExcludingTax { get; set; }

    /// <summary>
    /// Gets or Sets ImageUri
    /// </summary>
    [DataMember(Name="image_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "image_uri")]
    public string ImageUri { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AggregatedOrderCartItemV2 {\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Quantity: ").Append(Quantity).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  DiscountRate: ").Append(DiscountRate).Append("\n");
      sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
      sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
      sb.Append("  MerchantItemData: ").Append(MerchantItemData).Append("\n");
      sb.Append("  TotalPriceIncludingTax: ").Append(TotalPriceIncludingTax).Append("\n");
      sb.Append("  TotalTaxAmount: ").Append(TotalTaxAmount).Append("\n");
      sb.Append("  TotalPriceExcludingTax: ").Append(TotalPriceExcludingTax).Append("\n");
      sb.Append("  ImageUri: ").Append(ImageUri).Append("\n");
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
