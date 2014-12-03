#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ShippingInfo.cs" company="Klarna AB">
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
    /// Shipping information, e.g. applicable to a capture.
    /// </summary>
    public class ShippingInfo : Model
    {
        /// <summary>
        /// Gets or sets the shipping company name.
        /// </summary>
        [JsonProperty("shipping_company")]
        public string ShippingCompany { get; set; }

        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        [JsonProperty("shipping_method")]
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Gets or sets the tracking ID.
        /// </summary>
        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the tracking uri. Tracking URL where the customer can track the shipment.
        /// </summary>
        [JsonProperty("tracking_uri")]
        public Uri TrackingUri { get; set; }

        /// <summary>
        /// Gets or sets the return shipping company. RMA company name.
        /// </summary>
        [JsonProperty("return_shipping_company")]
        public string ReturnShippingCompany { get; set; }

        /// <summary>
        /// Gets or sets the return shipping number. RMA tracking ID.
        /// </summary>
        [JsonProperty("return_tracking_number")]
        public string ReturnTrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the return shipping company. RMA tracking URL where the customer can track the shipment.
        /// </summary>
        [JsonProperty("return_tracking_uri")]
        public Uri ReturnTrackingUri { get; set; }
    }
}
