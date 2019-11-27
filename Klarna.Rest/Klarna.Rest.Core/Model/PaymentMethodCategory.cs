using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use PaymentMethodCategory model from Klarna.Rest.Core.Model.Payments namespace instead")]
    public class PaymentMethodCategory
    {
        /// <summary>
        /// Id for the category
        /// </summary>
        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }
        /// <summary>
        /// Name of the category
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Asset URLs
        /// </summary>
        [JsonProperty(PropertyName = "asset_urls")]
        public PaymentMethodCategoryAssetUrls AssetUrls { get; set; }
    }
}