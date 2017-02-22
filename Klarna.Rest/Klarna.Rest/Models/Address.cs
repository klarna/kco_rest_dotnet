#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="Klarna AB">
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
    /// Customer address.
    /// </summary>
    public class Address : Model
    {
        /// <summary>
        /// Gets or sets the given name.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the family name.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the title of the customer.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets optional street address.
        /// </summary>
        [JsonProperty("street_address2")]
        public string StreetAddress2 { get; set; }

        /// <summary>
        /// Gets or sets the street name.
        /// </summary>
        [JsonProperty("street_name")]
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the street number.
        /// </summary>
        [JsonProperty("street_number")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the house extension.
        /// </summary>
        [JsonProperty("house_extension")]
        public string HouseExtension { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
