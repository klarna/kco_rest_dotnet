using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Customer token details object
    /// </summary>
    public class CustomerTokenDetails
    {
        /// <summary>
        /// Selected payment method
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "payment_method_type")]
        public string PaymentMethodType { get; set; }
        /// <summary>
        /// Status of token, can be active, cancelled, suspended
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
