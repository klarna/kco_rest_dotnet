using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class Gui
    {
        /// <summary>
        /// An array of options to define the checkout behaviour. Supported options: disable_autofocux, minimal_confirmation.
        /// </summary>
        /// <remarks>Read only</remarks>
        [JsonProperty(PropertyName = "options")]
        public ICollection<string> Options { get; set; }
    }
}