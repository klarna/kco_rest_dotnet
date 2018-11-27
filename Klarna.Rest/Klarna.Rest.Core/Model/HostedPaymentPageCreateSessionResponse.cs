using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create hosted payment page session response
    /// </summary>
    public class HostedPaymentPageCreateSessionResponse
    {
        /// <summary>
        /// Endpoint for link distribution
        /// </summary>
        [JsonProperty(PropertyName = "distribution_url")]
        public string DistributionUrl { get; set; }
        /// <summary>
        /// HPP url to redirect the consumer to
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    }

 
}