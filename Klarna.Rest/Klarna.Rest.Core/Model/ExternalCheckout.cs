using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class ExternalCheckout
    {
        /// <summary>
        /// The name of the payment provider. (max 255 characters)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// URL to redirect to. (must be https, min 7, max 2000 characters)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
        /// <summary>
        /// URL to an image to display. (must be https, max 2000 characters)
        /// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
        /// <summary>
        /// Minor units. Includes tax.
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public int Fee { get; set; }
        /// <summary>
        /// Description. (max 500 characters)
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// If specified, limits the method to the listed countries (ISO 3166 alpha-2)
        /// </summary>
        [JsonProperty(PropertyName = "countries")]
        public ICollection<string> Countries { get; set; }
    }
}