using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsProductIdentifiers {
    /// <summary>
    /// The product's brand name as generally recognized by consumers. If no brand is available for a product, do not supply any value.
    /// </summary>
    /// <value>The product's brand name as generally recognized by consumers. If no brand is available for a product, do not supply any value.</value>
    [DataMember(Name="brand", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "brand")]
    public string Brand { get; set; }

    /// <summary>
    /// The product's category path as used in the merchant's webshop. Include the full and most detailed category and separate the segments with ' > '
    /// </summary>
    /// <value>The product's category path as used in the merchant's webshop. Include the full and most detailed category and separate the segments with ' > '</value>
    [DataMember(Name="category_path", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "category_path")]
    public string CategoryPath { get; set; }

    /// <summary>
    /// The product's Global Trade Item Number (GTIN). Common types of GTIN are EAN, ISBN or UPC. Exclude dashes and spaces, where possible
    /// </summary>
    /// <value>The product's Global Trade Item Number (GTIN). Common types of GTIN are EAN, ISBN or UPC. Exclude dashes and spaces, where possible</value>
    [DataMember(Name="global_trade_item_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "global_trade_item_number")]
    public string GlobalTradeItemNumber { get; set; }

    /// <summary>
    /// The product's Manufacturer Part Number (MPN), which - together with the brand - uniquely identifies a product. Only submit MPNs assigned by a manufacturer and use the most specific MPN possible
    /// </summary>
    /// <value>The product's Manufacturer Part Number (MPN), which - together with the brand - uniquely identifies a product. Only submit MPNs assigned by a manufacturer and use the most specific MPN possible</value>
    [DataMember(Name="manufacturer_part_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "manufacturer_part_number")]
    public string ManufacturerPartNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsProductIdentifiers {\n");
      sb.Append("  Brand: ").Append(Brand).Append("\n");
      sb.Append("  CategoryPath: ").Append(CategoryPath).Append("\n");
      sb.Append("  GlobalTradeItemNumber: ").Append(GlobalTradeItemNumber).Append("\n");
      sb.Append("  ManufacturerPartNumber: ").Append(ManufacturerPartNumber).Append("\n");
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
