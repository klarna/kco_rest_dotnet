#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ErrorMessage.cs" company="Klarna AB">
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
    /// Error message model.
    /// </summary>
    public class ErrorMessage : Model
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets error messages.
        /// </summary>
        [JsonProperty("error_messages")]
        public string[] ErrorMessages { get; set; }

        /// <summary>
        /// Gets or sets correlation id.
        /// <para>The correlation id may be requested by merchant support to facilitate support inquiries.</para>
        /// </summary>
        [JsonProperty("correlation_id")]
        public string CorrelationId { get; set; }
    }
}
