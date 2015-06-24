#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Voucher.cs" company="Klarna AB">
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
    /// The model for vouchers.
    /// </summary>
    public class Voucher : Model
    {
        /// <summary>
        /// Gets or sets the voucher name.
        /// </summary>
        [JsonProperty("voucher_name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the voucher company name.
        /// </summary>
        [JsonProperty("voucher_company")]
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the affiliate name.
        /// </summary>
        [JsonProperty("affiliate_name")]
        public string AffiliateName { get; set; }
    }
}