using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create order using customer token response object
    /// </summary>
    [Obsolete("This model is being deprecated. Use Order model from Klarna.Rest.Core.Model.CustomerToken namespace instead")]
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

