using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use CustomerTokenCreationResponse model from Klarna.Rest.Core.Model.Payments namespace instead")]
    public class PaymentGenerateConsumerTokenResponse
    {
        /// <summary>
        /// Used when placing the order.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "token_id")]
        public string TokenId { get; set; }
        /// <summary>
        /// URL to redirect the customer to after placing the order.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    }
}