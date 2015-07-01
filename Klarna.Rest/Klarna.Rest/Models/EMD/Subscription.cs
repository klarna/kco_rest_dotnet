#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Subscription.cs" company="Klarna AB">
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
    /// The model for subscriptions.
    /// </summary>
    public class Subscription : Model
    {
        /// <summary>
        /// Gets or sets the subscription name.
        /// </summary>
        [JsonProperty("subscription_name")]
        public string Name { get; set; }

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
        /// Gets or sets a value indicating whether if the subscription should be automatically renewed.
        /// </summary>
        [JsonProperty("auto_renewal_of_subscription")]
        public bool? AutoRenewalOfSubscriptions { get; set; }

        /// <summary>
        /// Gets or sets the affiliate name.
        /// </summary>
        [JsonProperty("affiliate_name")]
        public string AffiliateName { get; set; }
    }
}