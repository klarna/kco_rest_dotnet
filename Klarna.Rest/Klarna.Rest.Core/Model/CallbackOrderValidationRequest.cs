using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CallbackOrderValidationRequest
    {
        /// <summary>
        /// The unique order ID (max 255 characters).
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// The merchant name (max 255 characters).
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
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
        /// The current status of the order.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).
        /// </summary>
        [JsonProperty(PropertyName = "billing_address")]
        public CheckoutAddressInfo BillingCheckoutAddress { get; set; }
        /// <summary>
        /// Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of BillingAddress.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "shipping_address")]
        public CheckoutAddressInfo ShippingCheckoutAddress { get; set; }
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
        public CheckoutCustomer CheckoutCustomer { get; set; }
        /// <summary>
        /// The MerchantUrls object.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "merchant_urls")]
        public CheckoutMerchantUrls CheckoutMerchantUrls { get; set; }
        /// <summary>
        /// The HTML snippet that is used to render the checkout in an iframe.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "html_snippet")]
        public string HtmlSnippet { get; set; }
        /// <summary>
        /// Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as "order number" (max 255 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference1")]
        public string MerchantReference1 { get; set; }
        /// <summary>
        /// Used for storing merchant's internal order number of other reference (max 255 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference2")]
        public string MerchantReference2 { get; set; }
        /// <summary>
        /// ISO 8601 datetime. When the merchant created the order.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "started_at")]
        public string StartedAt { get; set; }
        /// <summary>
        /// ISO 8601 datetime. When the customer completed the order.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "completed_at")]
        public string CompletedAt { get; set; }
        /// <summary>
        /// ISO 8601 datetime. When the order was last modified.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "last_modified_at")]
        public string LastModifiedAt { get; set; }
        /// <summary>
        /// Options for the purchase.
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public CheckoutOptions CheckoutOptions { get; set; }
        /// <summary>
        /// Additional purchase information required for some industries.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }
        /// <summary>
        /// List of external payment methods.
        /// </summary>
        [JsonProperty(PropertyName = "external_payment_methods")]
        public ICollection<PaymentProvider> ExternalPaymentMethods { get; set; }
        /// <summary>
        /// List of external checkouts.
        /// </summary>
        [JsonProperty(PropertyName = "externa_checkouts")]
        public ICollection<PaymentProvider> ExternalCheckouts { get; set; }
        /// <summary>
        /// A list of countries (ISO 3166 alpha-2). Default is PurchaseCountry only.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_countries")]
        public ICollection<string> ShippingCountries { get; set; }
        /// <summary>
        /// A list of shipping options available for this order.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_options")]
        public ICollection<ShippingOption> ShippingOptions { get; set; }
        /// <summary>
        /// Pass through field (max 1024 characters).
        /// </summary>
        [JsonProperty(PropertyName = "merchant_data")]
        public string MerchantData { get; set; }
        /// <summary>
        /// The gui object.
        /// </summary>
        [JsonProperty(PropertyName = "gui")]
        public Gui Gui { get; set; }
        /// <summary>
        /// Stored merchant requested data.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "merchant_requeted")]
        public MerchantRequested MerchantRequested { get; set; }
        /// <summary>
        /// Current shipping options selected by the customer.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "selected_shipping_option")]
        public ShippingOption SelectedShippingOption { get; set; }
        /// <summary>
        /// Indicates whether this purchase will create a token that can be used by the merchant to create recurring purchases. This must be enabled for the merchant to use. Default: false
        /// </summary>
        [JsonProperty(PropertyName = "recurring")]
        public bool Recurring { get; set; }
        /// <summary>
        /// Token to be used when creating recurring orders.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "recurring_token")]
        public string RecurringToken { get; set; }
        /// <summary>
        /// Description recurring subscriptions.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "recurring_description")]
        public string RecurringDescription { get; set; }
    }
}