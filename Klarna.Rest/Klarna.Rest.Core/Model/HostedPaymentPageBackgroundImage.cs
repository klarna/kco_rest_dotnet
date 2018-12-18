using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create hosted payment page background image
    /// </summary>
    public class HostedPaymentPageBackgroundImage
    {
        /// <summary>
        /// Url for the image
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        /// <summary>
        /// Width of the image
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
    }
}