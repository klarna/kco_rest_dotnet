#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UniqueAccountIdentifier.cs" company="Klarna AB">
//     Copyright 2015 Klarna AB
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
namespace Klarna.Rest.Models.EMD
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model for unique account identifiers.
    /// </summary>
    public class UniqueAccountIdentifier : Model
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the PNO.
        /// </summary>
        [JsonProperty("pno", Required = Required.Always)]
        public string PNO { get; set; }

        /// <summary>
        /// Gets or sets other information.
        /// </summary>
        [JsonProperty("other")]
        public string Other { get; set; }
    }
}