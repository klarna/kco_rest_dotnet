using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class OrderManagementSetNewOrderAmountAndLines
    {
        /// <summary>
        /// The new total order amount. Minor units.
        /// </summary>
        [JsonProperty(PropertyName = "order_amount")]
        public int OrderAmount { get; set; }
        /// <summary>
        /// Description of the change.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// New set of order lines for the order.
        /// </summary>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}