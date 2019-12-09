using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class OrderLine {
    /// <summary>
    /// Article number, SKU or similar.
    /// </summary>
    /// <value>Article number, SKU or similar.</value>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Order line type. Matches: physical|discount|shipping_fee|sales_tax|store_credit|gift_card|digital|surcharge
    /// </summary>
    /// <value>Order line type. Matches: physical|discount|shipping_fee|sales_tax|store_credit|gift_card|digital|surcharge</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Item quantity. Non-negative. Between 0 and 100000
    /// </summary>
    /// <value>Item quantity. Non-negative. Between 0 and 100000</value>
    [DataMember(Name="quantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity")]
    public long? Quantity { get; set; }

    /// <summary>
    /// Unit used to describe the quantity. Maximum 10 characters.
    /// </summary>
    /// <value>Unit used to describe the quantity. Maximum 10 characters.</value>
    [DataMember(Name="quantity_unit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity_unit")]
    public string QuantityUnit { get; set; }

    /// <summary>
    /// Descriptive item name. Maximum 255 characters.
    /// </summary>
    /// <value>Descriptive item name. Maximum 255 characters.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Total amount including tax and discounts (`quantity * unit_price - total_discount_amount`).
    /// </summary>
    /// <value>Total amount including tax and discounts (`quantity * unit_price - total_discount_amount`).</value>
    [DataMember(Name="total_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_amount")]
    public long? TotalAmount { get; set; }

    /// <summary>
    /// Unit price including tax without applying discounts in minor units.
    /// </summary>
    /// <value>Unit price including tax without applying discounts in minor units.</value>
    [DataMember(Name="unit_price", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unit_price")]
    public long? UnitPrice { get; set; }

    /// <summary>
    /// The discount amount in minor units. Includes tax. Example: 1200 = $12. Max value: 100000000
    /// </summary>
    /// <value>The discount amount in minor units. Includes tax. Example: 1200 = $12. Max value: 100000000</value>
    [DataMember(Name="total_discount_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_discount_amount")]
    public long? TotalDiscountAmount { get; set; }

    /// <summary>
    /// The tax rate in percent with two implicit decimals. Non-negative. Example: 2500 = 25%.
    /// </summary>
    /// <value>The tax rate in percent with two implicit decimals. Non-negative. Example: 2500 = 25%.</value>
    [DataMember(Name="tax_rate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tax_rate")]
    public int? TaxRate { get; set; }

    /// <summary>
    /// The total tax amount in minor units. Negative if the order line type is discount. Example: 500 = $5.
    /// </summary>
    /// <value>The total tax amount in minor units. Negative if the order line type is discount. Example: 500 = $5.</value>
    [DataMember(Name="total_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_tax_amount")]
    public long? TotalTaxAmount { get; set; }

    /// <summary>
    /// Data about the order line. Set at creation or update and returned when fetching the order through the API. Maximum 1024 characters.
    /// </summary>
    /// <value>Data about the order line. Set at creation or update and returned when fetching the order through the API. Maximum 1024 characters.</value>
    [DataMember(Name="merchant_data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_data")]
    public string MerchantData { get; set; }

    /// <summary>
    /// URL to the product that can be used in communications between Klarna and the customer. Maximum 1024 characters.
    /// </summary>
    /// <value>URL to the product that can be used in communications between Klarna and the customer. Maximum 1024 characters.</value>
    [DataMember(Name="product_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "product_url")]
    public string ProductUrl { get; set; }

    /// <summary>
    /// URL to an image that can be embedded in communications between Klarna and the customer. Maximum 1024 characters.
    /// </summary>
    /// <value>URL to an image that can be embedded in communications between Klarna and the customer. Maximum 1024 characters.</value>
    [DataMember(Name="image_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "image_url")]
    public string ImageUrl { get; set; }

    /// <summary>
    /// Identifiers to better describe the product for improved risk assessment, support, presentation to consumers and promotional functionality.
    /// </summary>
    /// <value>Identifiers to better describe the product for improved risk assessment, support, presentation to consumers and promotional functionality.</value>
    [DataMember(Name="product_identifiers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "product_identifiers")]
    public ProductIdentifiers ProductIdentifiers { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class OrderLine {\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Quantity: ").Append(Quantity).Append("\n");
      sb.Append("  QuantityUnit: ").Append(QuantityUnit).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  TotalAmount: ").Append(TotalAmount).Append("\n");
      sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
      sb.Append("  TotalDiscountAmount: ").Append(TotalDiscountAmount).Append("\n");
      sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
      sb.Append("  TotalTaxAmount: ").Append(TotalTaxAmount).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  ProductUrl: ").Append(ProductUrl).Append("\n");
      sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
      sb.Append("  ProductIdentifiers: ").Append(ProductIdentifiers).Append("\n");
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
