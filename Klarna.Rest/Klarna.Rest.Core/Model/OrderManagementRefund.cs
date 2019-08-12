using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class OrderManagementRefund
    {
        /// <summary>
        /// Refund ID
        /// </summary>
        [JsonProperty(PropertyName = "refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// Refunded amount in minor units.
        /// </summary>
        [JsonProperty(PropertyName = "refunded_amount")]
        public int RefundedAmount { get; set; }

        /// <summary>
        /// Date for refund
        /// </summary>
        [JsonProperty(PropertyName = "refunded_at")]
        public string RefundedAt { get; set; }

        /// <summary>
        /// Description of the refund shown to the customer. Max length is 255 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Order lines for the refund shown to the customer. Optional but increases the customer experience. Maximum 1000 order lines.
        /// </summary>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}