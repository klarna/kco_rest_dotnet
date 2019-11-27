using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsOrderLine {
    /// <summary>
    /// URL to an image that can be later embedded in communications between Klarna and the customer. (max 1024 characters)
    /// </summary>
    /// <value>URL to an image that can be later embedded in communications between Klarna and the customer. (max 1024 characters)</value>
    [DataMember(Name="image_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "image_url")]
    public string ImageUrl { get; set; }

    /// <summary>
    /// Pass through field. (max 255 characters)
    /// </summary>
    /// <value>Pass through field. (max 255 characters)</value>
    [DataMember(Name="merchant_data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_data")]
    public string MerchantData { get; set; }

    /// <summary>
    /// Descriptive item name.
    /// </summary>
    /// <value>Descriptive item name.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Additional information identifying an item
    /// </summary>
    /// <value>Additional information identifying an item</value>
    [DataMember(Name="product_identifiers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "product_identifiers")]
    public PaymentsProductIdentifiers ProductIdentifiers { get; set; }

    /// <summary>
    /// URL to the product that can be later used in communications between Klarna and the customer. (max 1024 characters)
    /// </summary>
    /// <value>URL to the product that can be later used in communications between Klarna and the customer. (max 1024 characters)</value>
    [DataMember(Name="product_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "product_url")]
    public string ProductUrl { get; set; }

    /// <summary>
    /// Non-negative. The item quantity.
    /// </summary>
    /// <value>Non-negative. The item quantity.</value>
    [DataMember(Name="quantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity")]
    public long? Quantity { get; set; }

    /// <summary>
    /// Unit used to describe the quantity, e.g. kg, pcs... If defined has to be 1-8 characters
    /// </summary>
    /// <value>Unit used to describe the quantity, e.g. kg, pcs... If defined has to be 1-8 characters</value>
    [DataMember(Name="quantity_unit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity_unit")]
    public string QuantityUnit { get; set; }

    /// <summary>
    /// Article number, SKU or similar. Max length is 64 characters.
    /// </summary>
    /// <value>Article number, SKU or similar. Max length is 64 characters.</value>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Non-negative. In percent, two implicit decimals. I.e 2500 = 25%.
    /// </summary>
    /// <value>Non-negative. In percent, two implicit decimals. I.e 2500 = 25%.</value>
    [DataMember(Name="tax_rate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tax_rate")]
    public long? TaxRate { get; set; }

    /// <summary>
    /// Includes tax and discount. Must match (quantity * unit_price) - total_discount_amount within ±quantity. (max value: 100000000)
    /// </summary>
    /// <value>Includes tax and discount. Must match (quantity * unit_price) - total_discount_amount within ±quantity. (max value: 100000000)</value>
    [DataMember(Name="total_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_amount")]
    public long? TotalAmount { get; set; }

    /// <summary>
    /// Non-negative minor units. Includes tax.
    /// </summary>
    /// <value>Non-negative minor units. Includes tax.</value>
    [DataMember(Name="total_discount_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_discount_amount")]
    public long? TotalDiscountAmount { get; set; }

    /// <summary>
    /// Must be within ±1 of total_amount - total_amount * 10000 / (10000 + tax_rate). Negative when type is discount.
    /// </summary>
    /// <value>Must be within ±1 of total_amount - total_amount * 10000 / (10000 + tax_rate). Negative when type is discount.</value>
    [DataMember(Name="total_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_tax_amount")]
    public long? TotalTaxAmount { get; set; }

    /// <summary>
    /// Order line type. Possible values:<ul><li><em>physical</em></li><li><em>discount</em></li><li><em>shipping_fee</em></li><li><em>sales_tax</em></li><li><em>digital</em></li><li><em>gift_card</em></li><li><em>store_credit</em></li><li><em>surcharge</em></li></ul>
    /// </summary>
    /// <value>Order line type. Possible values:<ul><li><em>physical</em></li><li><em>discount</em></li><li><em>shipping_fee</em></li><li><em>sales_tax</em></li><li><em>digital</em></li><li><em>gift_card</em></li><li><em>store_credit</em></li><li><em>surcharge</em></li></ul></value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Minor units. Includes tax, excludes discount. (max value: 100000000)
    /// </summary>
    /// <value>Minor units. Includes tax, excludes discount. (max value: 100000000)</value>
    [DataMember(Name="unit_price", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unit_price")]
    public long? UnitPrice { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsOrderLine {\n");
      sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ProductIdentifiers: ").Append(ProductIdentifiers).Append("\n");
      sb.Append("  ProductUrl: ").Append(ProductUrl).Append("\n");
      sb.Append("  Quantity: ").Append(Quantity).Append("\n");
      sb.Append("  QuantityUnit: ").Append(QuantityUnit).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
      sb.Append("  TotalAmount: ").Append(TotalAmount).Append("\n");
      sb.Append("  TotalDiscountAmount: ").Append(TotalDiscountAmount).Append("\n");
      sb.Append("  TotalTaxAmount: ").Append(TotalTaxAmount).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
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
