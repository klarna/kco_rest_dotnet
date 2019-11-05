using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create hosted payment page merchant URLs
    /// </summary>
    [Obsolete("This model is being deprecated. Use MerchantUrlsV1 from Klarna.Rest.Core.Model.HostedPaymentPage namespace instead")]
    public class HostedPaymentPageMerchantUrls
    {
        /// <summary>
        /// Cancel url
        /// </summary>
        [JsonProperty(PropertyName = "cancel")]
        public string Cancel { get; set; }
        /// <summary>
        /// Failure url
        /// </summary>
        [JsonProperty(PropertyName = "failure")]
        public string Failure { get; set; }
        /// <summary>
        /// Privacy policy url
        /// </summary>
        [JsonProperty(PropertyName = "privacy_policy")]
        public string PrivacyPolicy { get; set; }
        /// <summary>
        /// Success url
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public string Success { get; set; }
        /// <summary>
        /// Terms url
        /// </summary>
        [JsonProperty(PropertyName = "terms")]
        public string Terms { get; set; }
    }
}