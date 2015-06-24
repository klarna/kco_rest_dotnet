#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Itinerary.cs" company="Klarna AB">
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
    /// The model for itineraries.
    /// </summary>
    public class Itinerary : Model
    {
        /// <summary>
        /// Gets or sets the departure.
        /// </summary>
        [JsonProperty("departure")]
        public string Departure { get; set; }

        /// <summary>
        /// Gets or sets the departure city.
        /// </summary>
        [JsonProperty("departure_city")]
        public string DepartureCity { get; set; }

        /// <summary>
        /// Gets or sets the arrival IATA.
        /// </summary>
        [JsonProperty("arrival")]
        public string Arrival { get; set; }

        /// <summary>
        /// Gets or sets the arrival city.
        /// </summary>
        [JsonProperty("arrival_city")]
        public string ArrivalCity { get; set; }

        /// <summary>
        /// Gets or sets the carrier name.
        /// </summary>
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets the segment price.
        /// </summary>
        [JsonProperty("segment_price")]
        public long? SegmentPrice { get; set; }

        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Gets or sets the ticket delivery method.
        /// <para>Allowed values are "pick_up", "email", "post" or "phone".</para>
        /// </summary>
        [JsonProperty("ticket_delivery_method")]
        public string TicketDeliveryMethod { get; set; }

        /// <summary>
        /// Gets or sets the ticket delivery recipient
        /// </summary>
        [JsonProperty("ticket_delivery_recipient")]
        public string TicketDeliveryRecipient { get; set; }

        /// <summary>
        /// Gets or sets the passenger IDs
        /// </summary>
        [JsonProperty("passenger_id")]
        public List<int> PassengerIDs { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }
    }
}