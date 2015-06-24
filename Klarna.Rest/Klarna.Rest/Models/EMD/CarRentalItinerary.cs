#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CarRentalItinerary.cs" company="Klarna AB">
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
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The model for car rental itineraries.
    /// </summary>
    public class CarRentalItinerary : Model
    {
        /// <summary>
        /// Gets or sets the rental company name.
        /// </summary>
        [JsonProperty("rental_company")]
        public string RentalCompany { get; set; }

        /// <summary>
        /// Gets or sets the driver IDs
        /// </summary>
        [JsonProperty("drivers_id")]
        public List<int> DriverIds { get; set; }

        /// <summary>
        /// Gets or sets the pick up location.
        /// </summary>
        [JsonProperty("pick_up_location")]
        public Location PickUpLocation { get; set; }

        /// <summary>
        /// Gets or sets the drop off location.
        /// </summary>
        [JsonProperty("drop_off_location")]
        public Location DropOffLocation { get; set; }

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
        /// Gets or sets the car price.
        /// </summary>
        [JsonProperty("car_price")]
        public long? CarPrice { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }
    }
}