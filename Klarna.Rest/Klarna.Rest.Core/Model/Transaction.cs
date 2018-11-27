using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// The settlements API transaction object
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Total amount of the specific transaction, in minor units
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
        /// <summary>
        /// The Klarna assigned id reference of a specific capture
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "capture_id")]
        public string CaptureId { get; set; }
        /// <summary>
        /// Merchant assigned reference, typically a reference to an order management system id
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference1")]
        public string MerchantReference1 { get; set; }
        /// <summary>
        /// ISO-8601 formatted date-time string
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "sale_date")]
        public string SaleDate { get; set; }
        /// <summary>
        /// The type of transaction.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        /// <summary>
        /// ISO-8601 formatted date-time string
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "capture_date")]
        public string CaptureDate { get; set; }
        /// <summary>
        /// Reference to the specific payout the transaction is part of, if available.
        /// </summary>
        [JsonProperty(PropertyName = "payment_reference")]
        public string PaymentReference { get; set; }
        /// <summary>
        /// The Klarna assigned order id reference
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// Link to the payout that this transaction is part of
        /// </summary>
        [JsonProperty(PropertyName = "payout")]
        public string Payout { get; set; }
        /// <summary>
        /// The Klarna assigned id reference of a specific refund
        /// </summary>
        [JsonProperty(PropertyName = "refund_id")]
        public string RefundId { get; set; }
        /// <summary>
        /// The Klarna assigned short order id reference
        /// </summary>
        [JsonProperty(PropertyName = "short_order_id")]
        public string ShortOrderId { get; set; }
        /// <summary>
        /// Merchant assigned reference, typically a reference to an order management system id
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference2")]
        public string MerchantReference2 { get; set; }
        /// <summary>
        /// ISO-3166 Currency Code.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }
        /// <summary>
        /// ISO Alpha-2 Country Code
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "purchase_country")]
        public string PurchaseCountry { get; set; }

    }
}
