using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class ProductIdentifiers
    {
        /// <summary>
        /// The product's category path as used in the merchant's webshop. Include the full and most detailed category and separate the segments with ' > '
        /// </summary>
        [JsonProperty(PropertyName = "category_path")]
        public string CategoryPath { get; set; }
        /// <summary>
        /// The product's Global Trade Item Number (GTIN). Common types of GTIN are EAN, ISBN or UPC. Exclude dashes and spaces, where possible
        /// </summary>
        [JsonProperty(PropertyName = "global_trade_item_number")]
        public string GlobalTradeItemNumber { get; set; }
        /// <summary>
        /// The product's Manufacturer Part Number (MPN), which - together with the brand - uniquely identifies a product. Only submit MPNs assigned by a manufacturer and use the most specific MPN possible
        /// </summary>
        [JsonProperty(PropertyName = "manufacturer_part_number")]
        public string ManufacturerPartNumber { get; set; }
        /// <summary>
        /// The product's brand name as generally recognized by consumers. If no brand is available for a product, do not supply any value.
        /// </summary>
        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }
    }
}