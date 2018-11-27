using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create order using customer token response object
    /// </summary>
    public class CustomerTokenCreateOrderResponse
    {
        /// <summary>
        /// Fraud status
        /// </summary>
        [JsonProperty(PropertyName = "fraud_status")]
        public string FraudStatus { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// Redirect URL
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    }
}

