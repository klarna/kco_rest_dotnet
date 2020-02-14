using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
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
        public Pagination Pagination { get; set; }
        /// <summary>
        /// Deprecated param
        /// </summary>
        [Obsolete("Paginatinon has a typo in the name and marked as deprecated. Use Pagination instead.")]
        public Pagination Paginatinon
        {
            get => Pagination;
            set => Pagination = value;
        }
    }
}
