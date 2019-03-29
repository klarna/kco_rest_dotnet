using System.Collections.Generic;
using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    public class OrderManagementOrder
    {
        /// <summary>
        /// The unique order ID. No longer than 255 characters.
        /// </summary>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// the order status.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "status")]
        public OrderManagementOrderStatus Status { get; set; }
        /// <summary>
        /// Fraud status for the order.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "fraud_status")]
        public OrderManagementFraudStatus FraudStatus { get; set; }
        /// <summary>
        /// The order amount in minor units. That is the smallest currency unit available such as cent or penny.
        /// </summary>
        [JsonProperty(PropertyName = "order_amount")]
        public int OrderAmount { get; set; }
        /// <summary>
        /// The original order amount. In minor units.
        /// </summary>
        [JsonProperty(PropertyName = "original_order_amount")]
        public int OriginalOrderAmount { get; set; }
        /// <summary>
        /// The total amount of all captures. In minor units.
        /// </summary>
        [JsonProperty(PropertyName = "captured_amount")]
        public int CapturedAmount { get; set; }
        /// <summary>
        /// The total amount of refunded for this order. In minor units.
        /// </summary>
        [JsonProperty(PropertyName = "refunded_amount")]
        public int RefundedAmount { get; set; }
        /// <summary>
        /// he remaining authorized amount for this order. To increase the remaining_authorized_amount the order_amount needs to be increased.
        /// </summary>
        [JsonProperty(PropertyName = "remaining_authorized_amount")]
        public int RemainingAuthorizedAmount { get; set; }
        /// <summary>
        /// The currency for this order. Specified in ISO 4217 format.
        /// </summary>
        [JsonProperty(PropertyName = "purchase_currency")]
        public string PurchaseCurrency { get; set; }
        /// <summary>
        /// The customers locale. Specified according to RFC 1766.
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
        /// <summary>
        /// An array of order_line objects. Each line represents one item in the cart.
        /// </summary>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderLine> OrderLines { get; set; }
        /// <summary>
        /// Merchant reference 1. Can be used to store your internal reference to the order.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference1")]
        public string MerchantReference1 { get; set; }
        /// <summary>
        /// Merchant reference 2. Can be used to store your internal reference to the order.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference2")]
        public string MerchantReference2 { get; set; }
        /// <summary>
        /// Customer friendly reference id, used as order reference when communicating with the customer.
        /// </summary>
        [JsonProperty(PropertyName = "klarna_reference")]
        public string KlarnaReference { get; set; }
        /// <summary>
        /// Information about the customer placing the order.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public OrderManagementCustomer Customer { get; set; }
        /// <summary>
        /// Customer billing address.
        /// </summary>
        [JsonProperty(PropertyName = "billing_address")]
        public OrderManagementAddressInfo BillingAddress { get; set; }
        /// <summary>
        /// Customer shipping address
        /// </summary>
        [JsonProperty(PropertyName = "shipping_address")]
        public OrderManagementAddressInfo ShippingAddress { get; set; }
        /// <summary>
        /// The time for the purchase. Formatted according to ISO 8601.
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// The purchase country. Formatted according to ISO 3166-1 alpha-2.
        /// </summary>
        [JsonProperty(PropertyName = "purchase_country")]
        public string PurchaseCountry { get; set; }
        /// <summary>
        /// Order expiration time. The order can only be captured until this time. Formatted according to ISO 8601.
        /// </summary>
        [JsonProperty(PropertyName = "expires_at")]
        public string ExpiresAt { get; set; }
        /// <summary>
        /// List of captures for this order.
        /// </summary>
        [JsonProperty(PropertyName = "captures")]
        public ICollection<OrderManagementCapture> Captures { get; set; }
        /// <summary>
        /// List of refunds for this order.
        /// </summary>
        [JsonProperty(PropertyName = "refunds")]
        public ICollection<OrderManagementRefund> Refunds { get; set; }
        /// <summary>
        /// Text field for storing data about the order. Set at order creation.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_data")]
        public string MerchantData { get; set; }
        /// <summary>
        /// Initial payment method for this order
        /// </summary>
        [JsonProperty(PropertyName = "initial_payment_method")]
        public OrderManagementInitialPaymentMethod InitialPaymentMethod { get; set; }
    }
}