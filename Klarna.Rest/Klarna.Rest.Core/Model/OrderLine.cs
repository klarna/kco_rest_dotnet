using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Order line type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        public OrderLineType Type { get; set; }
        /// <summary>
        /// Article number, SKU or similar.
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        /// <summary>
        /// Descriptive item name.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Non-negative. The item quantity.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        /// <summary>
        /// Unit used to describe the quantity, e.g. kg, pcs... If defined has to be 1-8 characters
        /// </summary>
        [JsonProperty(PropertyName = "quantity_unit")]
        public string QuantityUnit { get; set; }
        /// <summary>
        /// Minor units. Includes tax, excludes discount. (max value: 100000000)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "unit_price")]
        public int UnitPrice { get; set; }
        /// <summary>
        /// Non-negative. In percent, two implicit decimals. I.e 2500 = 25%. (max value: 10000)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "tax_rate")]
        public int TaxRate { get; set; }
        /// <summary>
        /// Includes tax and discount. Must match (quantity * unit_price) - total_discount_amount within ±quantity. (max value: 100000000)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "total_amount")]
        public int TotalAmount { get; set; }
        /// <summary>
        /// Non-negative minor units. Includes tax.
        /// </summary>
        [JsonProperty(PropertyName = "total_discount_amount")]
        public int TotalDiscountAmount { get; set; }
        /// <summary>
        /// Must be within ±1 of total_amount - total_amount * 10000 / (10000 + tax_rate). Negative when type is discount.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "total_tax_amount")]
        public int TotalTaxAmount { get; set; }
        /// <summary>
        /// Pass through field. (max 255 characters)
        /// </summary>
        [JsonProperty(PropertyName = "merchant_data")]
        public string MerchantData { get; set; }
        /// <summary>
        /// URL to the product page that can be later embedded in communications between Klarna and the customer. (max 1024 characters)
        /// </summary>
        [JsonProperty(PropertyName = "product_url")]
        public string ProductUrl { get; set; }
        /// <summary>
        /// URL to an image that can be later embedded in communications between Klarna and the customer. (max 1024 characters)
        /// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
        /// <summary>
        /// Additional information identifying an item
        /// </summary>
        [JsonProperty(PropertyName = "product_identifiers")]
        public ProductIdentifiers ProductIdentifiers { get; set; }

        /// <summary>
        /// Shipping attributes of an item
        /// </summary>
        /// <value>Shipping attributes of an item</value>
        [JsonProperty(PropertyName = "shipping_attributes")]
        public ShippingAttributes ShippingAttributes { get; set; }
    }
}