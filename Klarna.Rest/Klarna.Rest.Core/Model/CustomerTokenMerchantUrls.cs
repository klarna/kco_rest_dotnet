using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Customer token merchant URLs object
    /// </summary>
    public class CustomerTokenMerchantUrls
    {
        /// <summary>
        /// URL of merchant confirmation page. (max 2000 characters)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "confirmation")]
        public string Confirmation { get; set; }
        /// <summary>
        /// URL that will be requested when an order is completed. Should be different than checkout and confirmation URLs. (max 2000 characters)
        /// </summary>
        [JsonProperty(PropertyName = "push")]
        public string Push { get; set; }
    }
}