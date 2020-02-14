using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckoutOrder
    {
        /// <summary>
        /// The unique order ID (max 255 characters).
        /// </summary>
        /// <value>The unique order ID (max 255 characters).</value>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// The merchant name (max 255 characters).
        /// </summary>
        /// <value>The merchant name (max 255 characters).</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// ISO 3166 alpha-2 purchase country.
        /// </summary>
        /// <value>ISO 3166 alpha-2 purchase country.</value>
        [JsonProperty(PropertyName = "purchase_country")]
        public string PurchaseCountry { get; set; }

        /// <summary>
        /// ISO 4217 purchase currency.
        /// </summary>
        /// <value>ISO 4217 purchase currency.</value>
        [JsonProperty(PropertyName = "purchase_currency")]
        public string PurchaseCurrency { get; set; }

        /// <summary>
        /// RFC 1766 customer's locale.
        /// </summary>
        /// <value>RFC 1766 customer's locale.</value>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// The current status of the order.
        /// </summary>
        /// <value>The current status of the order.</value>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).
        /// </summary>
        /// <value>Once the customer has provided any data in the checkout iframe, updates to this object will be ignored (without generating an error).</value>
        [JsonProperty(PropertyName = "billing_address")]
        public CheckoutAddressInfo BillingCheckoutAddress { get; set; }

        /// <summary>
        /// Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of billing_address.
        /// </summary>
        /// <value>Unless the customer has explicitly chosen to enter a separate shipping address, this is a clone of billing_address.</value>
        [JsonProperty(PropertyName = "shipping_address")]
        public CheckoutAddressInfo ShippingCheckoutAddress { get; set; }

        /// <summary>
        /// Non-negative, minor units. Total amount of the order, including tax and any discounts.
        /// </summary>
        /// <value>Non-negative, minor units. Total amount of the order, including tax and any discounts.</value>
        [JsonProperty(PropertyName = "order_amount")]
        public int OrderAmount { get; set; }

        /// <summary>
        /// Non-negative, minor units. The total tax amount of the order.
        /// </summary>
        /// <value>Non-negative, minor units. The total tax amount of the order.</value>
        [JsonProperty(PropertyName = "order_tax_amount")]
        public int OrderTaxAmount { get; set; }

        /// <summary>
        /// The applicable order lines (max 1000)
        /// </summary>
        /// <value>The applicable order lines (max 1000)</value>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Information about the liable customer of the order.
        /// </summary>
        /// <value>Information about the liable customer of the order.</value>
        [JsonProperty(PropertyName = "customer")]
        public CheckoutCustomer CheckoutCustomer { get; set; }

        /// <summary>
        /// The merchant_urls object.
        /// </summary>
        /// <value>The merchant_urls object.</value>
        [JsonProperty(PropertyName = "merchant_urls")]
        public CheckoutMerchantUrls MerchantUrls { get; set; }

        /// <summary>
        /// The HTML snippet that is used to render the checkout in an iframe.
        /// </summary>
        /// <value>The HTML snippet that is used to render the checkout in an iframe.</value>
        [JsonProperty(PropertyName = "html_snippet")]
        public string HtmlSnippet { get; set; }

        /// <summary>
        /// Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as \"order number\" (max 255 characters).
        /// </summary>
        /// <value>Used for storing merchant's internal order number or other reference. If set, will be shown on the confirmation page as \"order number\" (max 255 characters).</value>
        [JsonProperty(PropertyName = "merchant_reference1")]
        public string MerchantReference1 { get; set; }

        /// <summary>
        /// Used for storing merchant's internal order number or other reference (max 255 characters).
        /// </summary>
        /// <value>Used for storing merchant's internal order number or other reference (max 255 characters).</value>
        [JsonProperty(PropertyName = "merchant_reference2")]
        public string MerchantReference2 { get; set; }

        /// <summary>
        /// ISO 8601 datetime. When the merchant created the order.
        /// </summary>
        /// <value>ISO 8601 datetime. When the merchant created the order.</value>
        [JsonProperty(PropertyName = "started_at")]
        public string StartedAt { get; set; }

        /// <summary>
        /// ISO 8601 datetime. When the customer completed the order.
        /// </summary>
        /// <value>ISO 8601 datetime. When the customer completed the order.</value>
        [JsonProperty(PropertyName = "completed_at")]
        public string CompletedAt { get; set; }

        /// <summary>
        /// ISO 8601 datetime. When the order was last modified.
        /// </summary>
        /// <value>ISO 8601 datetime. When the order was last modified.</value>
        [JsonProperty(PropertyName = "last_modified_at")]
        public string LastModifiedAt { get; set; }

        /// <summary>
        /// Options for this purchase.
        /// </summary>
        /// <value>Options for this purchase.</value>
        [JsonProperty(PropertyName = "options")]
        public CheckoutOptions CheckoutOptions { get; set; }

        /// <summary>
        /// Additional purchase information required for some industries.
        /// </summary>
        /// <value>Additional purchase information required for some industries.</value>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }

        /// <summary>
        /// List of external payment methods.
        /// </summary>
        /// <value>List of external payment methods.</value>
        [JsonProperty(PropertyName = "external_payment_methods")]
        public ICollection<PaymentProvider> ExternalPaymentMethods { get; set; }

        /// <summary>
        /// List of external checkouts.
        /// </summary>
        /// <value>List of external checkouts.</value>
        [JsonProperty(PropertyName = "external_checkouts")]
        public ICollection<PaymentProvider> ExternalCheckouts { get; set; }

        /// <summary>
        /// A list of countries (ISO 3166 alpha-2). Default is purchase_country only.
        /// </summary>
        /// <value>A list of countries (ISO 3166 alpha-2). Default is purchase_country only.</value>
        [JsonProperty(PropertyName = "shipping_countries")]
        public ICollection<string> ShippingCountries { get; set; }

        /// <summary>
        /// A list of shipping options available for this order.
        /// </summary>
        /// <value>A list of shipping options available for this order.</value>
        [JsonProperty(PropertyName = "shipping_options")]
        public ICollection<ShippingOption> ShippingOptions { get; set; }

        /// <summary>
        /// Pass through field (max 6000 characters).
        /// </summary>
        /// <value>Pass through field (max 6000 characters).</value>
        [JsonProperty(PropertyName = "merchant_data")]
        public string MerchantData { get; set; }

        /// <summary>
        /// The gui object.
        /// </summary>
        /// <value>The gui object.</value>
        [JsonProperty(PropertyName = "gui")]
        public Gui Gui { get; set; }

        /// <summary>
        /// Stores merchant requested data.
        /// </summary>
        /// <value>Stores merchant requested data.</value>
        [JsonProperty(PropertyName = "merchant_requested")]
        public MerchantRequested MerchantRequested { get; set; }

        /// <summary>
        /// Current shipping options selected by the customer.
        /// </summary>
        /// <value>Current shipping options selected by the customer.</value>
        [JsonProperty(PropertyName = "selected_shipping_option")]
        public ShippingOption SelectedShippingOption { get; set; }

        /// <summary>
        /// Indicates whether this purchase will create a token that can be used by the merchant to create recurring purchases. This must be enabled for the merchant to use. Default: false
        /// </summary>
        /// <value>Indicates whether this purchase will create a token that can be used by the merchant to create recurring purchases. This must be enabled for the merchant to use. Default: false</value>
        [JsonProperty(PropertyName = "recurring")]
        public bool Recurring { get; set; }

        /// <summary>
        /// Token to be used when creating recurring orders.
        /// </summary>
        /// <value>Token to be used when creating recurring orders.</value>
        [JsonProperty(PropertyName = "recurring_token")]
        public string RecurringToken { get; set; }

        /// <summary>
        /// Description recurring subscription.
        /// </summary>
        /// <value>Description recurring subscription.</value>
        [JsonProperty(PropertyName = "recurring_description")]
        public string RecurringDescription { get; set; }

        /// <summary>
        /// A list of countries (ISO 3166 alpha-2) to specify allowed billing countries.
        /// </summary>
        /// <value>A list of countries (ISO 3166 alpha-2) to specify allowed billing countries.</value>
        [JsonProperty(PropertyName = "billing_countries")]
        public ICollection<string> BillingCountries { get; set; }

        /// <summary>
        /// The product's extra features
        /// </summary>
        /// <value>The product's extra features</value>
        [JsonProperty(PropertyName = "tags")]
        public ICollection<string> Tags { get; set; }
    }
}