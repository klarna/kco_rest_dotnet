using System;
using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Hosted payment page distribute link
    /// </summary>
    [Obsolete("This model is being deprecated. Use DistributionRequestV1 from Klarna.Rest.Core.Model.HostedPaymentPage namespace instead")]
    public class HostedPaymentPageDistributeLink
    {
        /// <summary>
        /// Contact information for the link distribution
        /// </summary>
        [JsonProperty(PropertyName = "contact_information")]
        public HostedPaymentPageContactInformation ContactInformation { get; set; }
        /// <summary>
        /// Method used for distribution
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public HostedPaymentPageDistributionMethod Method { get; set; }
        /// <summary>
        /// INSTORE_PURCHASE
        /// </summary>
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }
    }
}