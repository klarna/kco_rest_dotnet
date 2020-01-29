using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class AdditionalCheckboxV2
    {
        /// <summary>
        /// Identifier used when presenting data back to merchant
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        /// <summary>
        /// Text that will be displayed to the consumer aside the checkbox. Links and formatting can be added using Markdown. (max 255 characters)
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        /// <summary>
        /// Default state of the additional checkbox. It will use this value when loaded for the first time.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }
        /// <summary>
        /// Whether it is required for the consumer to check the additional checkbox box or not in order to complete the purchase.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "required")]
        public bool Required { get; set; }
    }
}