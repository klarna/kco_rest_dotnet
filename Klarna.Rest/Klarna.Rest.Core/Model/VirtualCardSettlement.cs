using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Virtual card create settlement response
    /// </summary>
    public class VirtualCardSettlement
    {
        /// <summary>
        /// Unique settlement identifier.
        /// </summary>
        [JsonProperty(PropertyName = "settlement_id")]
        public string SettlementId { get; set; }
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
        /// An array of Card objects.
        /// </summary>
        [JsonProperty(PropertyName = "cards")]
        public ICollection<VirtualCardCard> Cards { get; set; }
        /// <summary>
        /// Settlement creation datetime (ISO 8601).
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// Settlement expiration datetime (ISO 8601).
        /// </summary>
        [JsonProperty(PropertyName = "expires_at")]
        public string ExpiresAt { get; set; }
    }
}