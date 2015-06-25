#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ExternalPaymentMethod.cs" company="Klarna AB">
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
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The model for an external payment method.
    /// </summary>
    public class ExternalPaymentMethod : Model
    {
        /// <summary>
        /// Gets or sets the external payment methods name.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        [JsonProperty("redirect_url", Required = Required.Always)]
        public Uri RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the image URI.
        /// </summary>
        [JsonProperty("image_url")]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// Gets or sets the fee in cents, including tax.
        /// </summary>
        [JsonProperty("fee")]
        public long? Fee { get; set; }
    }
}