#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Checkbox.cs" company="Klarna AB">
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
    /// Checkbox model
    /// </summary>
    public class Checkbox : Model
    {
        /// <summary>
        /// Gets or sets Id of the checkbox
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Text of the checkbox
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Checkbox is checked or not
        /// </summary>
        [JsonProperty("checked")]
        public bool Checked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Checkbox Required or not
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }
    }
}