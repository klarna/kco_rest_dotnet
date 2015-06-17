#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="BusReservationDetails.cs" company="Klarna AB">
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
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The model for bus reservation details.
    /// </summary>
    public class BusReservationDetails : Model
    {
        /// <summary>
        /// Gets or sets the PNR.
        /// </summary>
        [JsonProperty("pnr")]
        public string PNR { get; set; }

        /// <summary>
        /// Gets or sets the list of itineraries.
        /// </summary>
        [JsonProperty("itinerary")]
        public List<Itinerary> Itineraries { get; set; }

        /// <summary>
        /// Gets or sets the list of insurances.
        /// </summary>
        [JsonProperty("insurance")]
        public List<Insurance> Insurances { get; set; }

        /// <summary>
        /// Gets or sets the list of passengers.
        /// </summary>
        [JsonProperty("passengers")]
        public List<Person> Passengers { get; set; }

        /// <summary>
        /// Gets or sets the affiliate name.
        /// </summary>
        [JsonProperty("affiliate_name")]
        public string AffiliateName { get; set; }
    }
}