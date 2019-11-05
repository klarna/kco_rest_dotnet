using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create hosted payment page background image
    /// </summary>
    [Obsolete("This model is being deprecated. Use BackgroundImageV1 from Klarna.Rest.Core.Model.HostedPaymentPage namespace instead")]
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