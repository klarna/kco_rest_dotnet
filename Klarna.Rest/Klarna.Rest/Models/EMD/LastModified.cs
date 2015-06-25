#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="LastModified.cs" company="Klarna AB">
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
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Model for last modified dates.
    /// </summary>
    public class LastModified : Model
    {
        /// <summary>
        /// Gets or sets password last modified date.
        /// </summary>
        [JsonProperty("password")]
        public DateTime Password { get; set; }

        /// <summary>
        /// Gets or sets email last modified date.
        /// </summary>
        [JsonProperty("email")]
        public DateTime Email { get; set; }

        /// <summary>
        /// Gets or sets listing last modified date.
        /// </summary>
        [JsonProperty("listing")]
        public DateTime Listing { get; set; }

        /// <summary>
        /// Gets or sets login last modified date.
        /// </summary>
        [JsonProperty("login")]
        public DateTime Login { get; set; }

        /// <summary>
        /// Gets or sets address last modified date.
        /// </summary>
        [JsonProperty("address")]
        public DateTime Address { get; set; }
    }
}