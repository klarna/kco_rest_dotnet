using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create hosted payment page session response
    /// </summary>
    [Obsolete("This model is being deprecated. Use SessionCreationResponseV1 from Klarna.Rest.Core.Model.HostedPaymentPage namespace instead")]
    public class HostedPaymentPageCreateSessionResponse
    {
        /// <summary>
        /// Endpoint for link distribution
        /// </summary>
        [JsonProperty(PropertyName = "distribution_url")]
        public string DistributionUrl { get; set; }

        /// <summary>
        /// HPP url to download qr code image
        /// </summary>
        [JsonProperty(PropertyName = "qr_code_url")]
        public string QrCodeUrl { get; set; }

        /// <summary>
        /// HPP url to redirect the consumer to
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
        
        /// <summary>
        /// HPP session id
        /// </summary>
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }
        
        /// <summary>
        /// Endpoint to read the session
        /// </summary>
        [JsonProperty(PropertyName = "session_url")]
        public string SessionUrl { get; set; }
    }

 
}