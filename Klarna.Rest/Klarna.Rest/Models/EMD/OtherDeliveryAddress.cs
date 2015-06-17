#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="OtherDeliveryAddress.cs" company="Klarna AB">
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
    /// The model for other delivery addresses.
    /// </summary>
    public class OtherDeliveryAddress : Model
    {
        /// <summary>
        /// Gets or sets the shipping method.
        /// <para>Allowed values are "store pick-up", "pick-up point", "registered box" or "unregistered box".</para>
        /// </summary>
        [JsonProperty("shipping_method")]
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Gets or sets the shipping type.
        /// <para>Allowed values are "normal" or "express".</para>
        /// </summary>
        [JsonProperty("shipping_type")]
        public string ShippingType { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last_name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the street number.
        /// </summary>
        [JsonProperty("street_number")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}