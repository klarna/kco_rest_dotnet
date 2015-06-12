#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CheckoutOptions.cs" company="Klarna AB">
//     Copyright 2014 Klarna AB
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------
#endregion
namespace Klarna.Rest.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Checkout options data model.
    /// </summary>
    public class CheckoutOptions : Model
    {
        /// <summary>
        /// Gets or sets a value indicating whether the customer's date of birth is mandatory or not.
        /// </summary>
        [JsonProperty("date_of_birth_mandatory")]
        public bool? DateOfBirthMandatory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer should be able to supply a different shipping address or not.
        /// </summary>
        [JsonProperty("allow_separate_shipping_address")]
        public bool? AllowSeparateShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the color of buttons, e.g. #FF9900.
        /// </summary>
        [JsonProperty("color_button")]
        public string ColorButton { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the color of button text, e.g. #FF9900.
        /// </summary>
        [JsonProperty("color_button_text")]
        public string ColorButtonText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the color of checkboxes, e.g. #FF9900.
        /// </summary>
        [JsonProperty("color_checkbox")]
        public string ColorCheckbox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the color of checkbox check mark, e.g. #FF9900.
        /// </summary>
        [JsonProperty("color_checkbox_checkmark")]
        public string ColorCheckboxCheckmark { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the color of headers, e.g. #FF9900.
        /// </summary>
        [JsonProperty("color_header")]
        public string ColorHeader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the color of links, e.g. #FF9900.
        /// </summary>
        [JsonProperty("color_link")]
        public string ColorLink { get; set; }
    }
}
