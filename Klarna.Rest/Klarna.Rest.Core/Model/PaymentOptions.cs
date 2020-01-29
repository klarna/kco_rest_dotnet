using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class PaymentOptions
    {
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_button")]
        public string ColorButton { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_button_text")]
        public string ColorButtonText { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_checkbox")]
        public string ColorCheckbox { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_checkbox_checkmark")]
        public string ColorCheckboxCheckmark { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_header")]
        public string ColorHeader { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_link")]
        public string ColorLink { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_border")]
        public string ColorBorder { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_border_selected")]
        public string ColorBorderSelected { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_text")]
        public string ColorText { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_details")]
        public string ColorDetails { get; set; }
        /// <summary>
        /// CSS hex color, e.g. "#FF9900"
        /// </summary>
        [JsonProperty(PropertyName = "color_text_secondary")]
        public string ColorTextSecondary { get; set; }
        /// <summary>
        /// Border radius
        /// </summary>
        [JsonProperty(PropertyName = "radius_border")]
        public string RadiusBorder { get; set; }
    }
}