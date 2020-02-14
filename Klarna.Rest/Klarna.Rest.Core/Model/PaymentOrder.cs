using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class PaymentOrder
    {
        /// <summary>
        /// Design.
        /// </summary>
        [JsonProperty(PropertyName = "design")]
        public string Design { get; set; }
        /// <summary>
        /// ISO 3166 alpha-2 purchase country.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "purchase_country")]
        public string PurchaseCountry { get; set; }
        /// <summary>
        /// ISO 4217 purchase currency.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "purchase_currency")]
        public string PurchaseCurrency { get; set; }
        /// <summary>
        /// RFC 1766 customer's locale.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
        /// <summary>
        /// Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).
        /// </summary>
        [JsonProperty(PropertyName = "billing_address")]
        public PaymentAddressInfo BillingAddress { get; set; }
        /// <summary>
        /// Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of billing_address.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_address")]
        public PaymentAddressInfo ShippingAddress { get; set; }
        /// <summary>
        /// Non-negative, minor units. Total amount of the order, including tax and any discounts.
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
        /// The applicable order lines (max 1000)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderLine> OrderLines { get; set; }
        /// <summary>
        /// Information about the liable customer of the order.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public PaymentCustomer Customer { get; set; }
        /// <summary>
        /// The merchant_urls object.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_urls")]
        public PaymentMerchantUrls MerchantUrls { get; set; }
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
        /// Pass through field (max 1024 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_data")]
        public string MerchantData { get; set; }
        /// <summary>
        /// Options for this purchase.
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public PaymentOptions Options { get; set; }
        /// <summary>
        /// Additional purchase information required for some industries.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }
        /// <summary>
        /// Ids for custom payment methods available in a given order. Only applicable in GB/US sessions.
        /// </summary>
        [JsonProperty(PropertyName = "customer_payment_method_ids")]
        public ICollection<string> CustomPaymentMethodIds { get; set; }
        /// <summary>
        /// The current status of the session. Possible values: 'complete', 'incomplete' where 'complete' is set when the order has been placed.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "status")]
        public CreditSessionStatus Status { get; set; }
        /// <summary>
        /// Token to be passed to the JS client
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "client_token")]
        public string ClientToken { get; set; }
        /// <summary>
        /// Session expiration date
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "expires_at")]
        //public ExpiresAt ExpiresAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        /// <summary>
        /// Type of acquiring channel
        /// </summary>
        [JsonProperty(PropertyName = "acquiring_channel")]
        public string AcquiringChannel { get; set; }
        /// <summary>
        /// Available payment method categories
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "payment_method_categories")]
        public ICollection<PaymentMethodCategory> PaymentMethodCategories { get; set; }
        /// <summary>
        /// Allow merchant to trigger auto capturing.
        /// </summary>
        [JsonProperty(PropertyName = "auto_capture")]
        public bool AutoCapture { get; set; }
    }
}