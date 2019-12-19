using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Create hosted payment page options
    /// </summary>
    [Obsolete("This model is being deprecated. Use OptionsV1 from Klarna.Rest.Core.Model.HostedPaymentPage namespace instead")]
    public class HostedPaymentPageOptions
    {
        /// <summary>
        /// Images to use for the background
        /// </summary>
        [JsonProperty(PropertyName = "background_images")]
        public ICollection<HostedPaymentPageBackgroundImage> BackgroundImages { get; set; }
        /// <summary>
        /// URL for the logo to be included in the HPP page
        /// </summary>
        [JsonProperty(PropertyName = "logo_url")]
        public string LogoUrl { get; set; }
        /// <summary>
        /// Title for the HPP page
        /// </summary>
        [JsonProperty(PropertyName = "page_title")]
        public string PageTitle { get; set; }
        /// <summary>
        /// Payment method category to show
        /// </summary>
        [JsonProperty(PropertyName = "payment_method_category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public HostedPaymentPagePaymentMethodCategory PaymentMethodCategory { get; set; }
        /// <summary>
        /// The type of this purchase
        /// </summary>
        [JsonProperty(PropertyName = "purchase_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public HostedPaymentPagePurchaseType PurchaseType { get; set; }

    }
}