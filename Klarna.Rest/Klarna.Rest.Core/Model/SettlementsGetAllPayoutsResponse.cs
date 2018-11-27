using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Get all payouts response object
    /// </summary>
    public class SettlementsGetAllPayoutsResponse
    {
        /// <summary>
        /// Array of payouts
        /// </summary>
        [JsonProperty(PropertyName = "payouts")]
        public ICollection<SettlementsPayout> Payouts { get; set; }
        /// <summary>
        /// Pagination information
        /// </summary>
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Paginatinon { get; set; }
    }
}
