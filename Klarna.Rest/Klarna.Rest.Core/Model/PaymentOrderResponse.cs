using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class PaymentOrderResponse
    {
        /// <summary>
        /// The unique order ID (max 255 characters).
        /// </summary>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// URL to redirect the customer to after placing the order.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
        /// <summary>
        /// Fraud status for the order. Either ACCEPTED, PENDING or REJECTED.
        /// </summary>
        //[JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "fraud_status")]
        //public PaymentOrderFraudStatus FraudStatus { get; set; } // todo: Should be ENUM, waiting for clarification on ENUM-values from Klarna. BON 2018-10-16
        public string FraudStatus { get; set; }
    }
}