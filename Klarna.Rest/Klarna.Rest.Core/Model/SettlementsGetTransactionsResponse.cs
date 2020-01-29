using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Get transaction response object
    /// </summary>
    public class SettlementsGetTransactionsResponse
    {
        /// <summary>
        /// Array of transactions
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "transactions")]
        public ICollection<Transaction> Transactions { get; set; }
        /// <summary>
        /// Pagination information
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }
    }
}