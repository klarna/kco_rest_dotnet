using System;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Virtual card create settlement request
    /// </summary>
    public class VirtualCardCreateSettlementRequest
    {
        /// <summary>
        /// Unique identifier for the promise associated to the settlement.
        /// </summary>
        [JsonProperty(PropertyName = "promise_id")]
        public string PromiseId { get; set; }
        /// <summary>
        /// Unique identifier for the order associated to the settlement.
        /// </summary>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// Unique identifier for the public key to be used for encryption of the card data.
        /// </summary>
        [JsonProperty(PropertyName = "key_id")]
        public string KeyId { get; set; }
    }
}
