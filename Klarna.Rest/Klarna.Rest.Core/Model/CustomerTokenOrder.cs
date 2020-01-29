using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Customer token order object
    /// </summary>
    public class CustomerTokenOrder
    {
        /// <summary>
        /// Additional purchase information required for some industries.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }
        /// <summary>
        /// Allow merchant to trigger auto capturing.
        /// </summary>
        [JsonProperty(PropertyName = "auto_capture")]
        public bool AutoCapture { get; set; }
        /// <summary>
        /// The merchant_urls object.
        /// </summary>
        [JsonProperty(PropertyName = "customer_token_order_merchant_urls")]
        public CustomerTokenMerchantUrls MerchantUrls { get; set; }
        /// <summary>
        /// Pass through field (max 1024 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_data")]
        public string MerchantData { get; set; }
        /// <summary>
        /// Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as "order number" (max 255 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference1")]
        public string MerchantReference1 { get; set; }
        /// <summary>
        /// Used for storing merchant's internal order number or other reference (max 255 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference2")]
        public string MerchantReference2 { get; set; }
        /// <summary>
        /// Non-negative, minor units. Total amount of the order, including tax and any discounts.
        /// </summary>
        [JsonProperty(PropertyName = "order_amount")]
        public int OrderAmount { get; set; }
        /// <summary>
        /// The applicable order lines (max 1000)
        /// </summary>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderLine> OrderLines { get; set; }
        /// <summary>
        /// Non-negative, minor units. The total tax amount of the order.
        /// </summary>
        [JsonProperty(PropertyName = "order_tax_amount")]
        public int OrderTaxAmount { get; set; }
        /// <summary>
        /// ISO 4217 purchase currency.
        /// </summary>
        [JsonProperty(PropertyName = "purchase_currency")]
        public string PurchaseCurrency { get; set; }
        /// <summary>
        /// Shipping address
        /// </summary>
        [JsonProperty(PropertyName = "shipping_address")]
        public CustomerTokenAddressInfo ShippingAddress { get; set; }
    }
}
