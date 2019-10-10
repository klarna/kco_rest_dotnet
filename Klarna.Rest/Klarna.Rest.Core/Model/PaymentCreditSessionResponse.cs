using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class PaymentCreditSessionResponse
    {
        /// <summary>
        /// Id of the created session
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }
        /// <summary>
        /// Token to be passed to the JS client
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "client_token")]
        public string ClientToken { get; set; }
        /// <summary>
        /// Available payment method categories
        /// </summary>
        [JsonProperty(PropertyName = "payment_method_categories")]
        public ICollection<PaymentMethodCategory> PaymentMethodCategories { get; set; }
    }
}