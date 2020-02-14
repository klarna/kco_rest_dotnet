using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class MerchantRequested
    {
        /// <summary>
        /// Informs whether the AdditionalCheckbox is checked or not, when applicable.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "additional_checkbox")]
        public bool AdditionalCheckbox { get; set; }
        /// <summary>
        /// Informs whether the AdditionalCheckboxes is checked or not, when applicable.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "additional_checkboxes")]
        public ICollection<MerchantRequestedAdditionalCheckbox> AdditionalCheckboxes { get; set; }
    }
}