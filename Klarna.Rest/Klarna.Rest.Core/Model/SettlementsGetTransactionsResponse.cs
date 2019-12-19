using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Get transaction response object
    /// </summary>
    [Obsolete("This model is being deprecated. Please use the TransactionCollection model from Klarna.Rest.Core.Model.Settlements")]
    public class SettlementsGetTransactionsResponse
    {
        /// <summary>
        /// Array of transactions
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "transactions")]
        public ICollection<Settlements.Transaction> Transactions { get; set; }
        /// <summary>
        /// Pagination information
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "pagination")]
        public Settlements.Pagination Pagination { get; set; }
    }
}