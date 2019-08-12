using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CallbackAddressUpdateResponse
    {
        /// <summary>
        /// Non-negative, minor units. Total total amount of the order, including tax and any discounts.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "order_amount")]
        public int OrderAmount { get; set; }
        /// <summary>
        /// Non-negative, minor units. The total tax amount of the order.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "order_tax_amount")]
        public int OrderTaxAmount { get; set; }
        /// <summary>
        /// Pass through field (max 1024 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_data")]
        public string MerchantData { get; set; }
        /// <summary>
        /// The applicable order lines (max 1000)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderLine> OrderLines { get; set; }
        /// <summary>
        /// A list of shipping options available for this order.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_options")]
        public ICollection<ShippingOption> ShippingOptions { get; set; }
        /// <summary>
        /// Additional purchase information required for some industries.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }
        /// <summary>
        /// ISO 4217 purchase currency.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "purchase_currency")]
        public string PurchaseCurrency { get; set; }
        /// <summary>
        /// RFC 1766 customer's locale.
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
    }
}
