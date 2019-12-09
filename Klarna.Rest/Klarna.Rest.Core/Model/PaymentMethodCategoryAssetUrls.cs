using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use the AssetUrls model from Klarna.Rest.Core.Model.Payments namespace instead")]
    public class PaymentMethodCategoryAssetUrls
    {
        /// <summary>
        /// Descriptive asset URL
        /// </summary>
        [JsonProperty(PropertyName = "descriptive")]
        public string Descriptive { get; set; }
        /// <summary>
        /// Standard asset URL
        /// </summary>
        [JsonProperty(PropertyName = "standard")]
        public string Standard { get; set; }
    }
}