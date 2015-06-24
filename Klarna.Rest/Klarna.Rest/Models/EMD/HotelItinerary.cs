#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="HotelItinerary.cs" company="Klarna AB">
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
    /// The model for hotel itineraries.
    /// </summary>
    public class HotelItinerary : Model
    {
        /// <summary>
        /// Gets or sets the hotel name.
        /// </summary>
        [JsonProperty("hotel_name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hotel address.
        /// </summary>
        [JsonProperty("address")]
        public Location Address { get; set; }

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
        /// Gets or sets the number of rooms.
        /// </summary>
        [JsonProperty("number_of_rooms")]
        public int NumberOfRooms { get; set; }

        /// <summary>
        /// Gets or sets the list of passenger IDs.
        /// </summary>
        [JsonProperty("passenger_id")]
        public List<int> PassengerIDs { get; set; }

        /// <summary>
        /// Gets or sets the ticket delivery method.
        /// <para>Allowed values are "pick_up", "email", "post" or "phone".</para>
        /// </summary>
        [JsonProperty("ticket_delivery_method")]
        public string TicketDeliveryMethod { get; set; }

        /// <summary>
        /// Gets or sets the ticket delivery recipient.
        /// </summary>
        [JsonProperty("ticket_delivery_recipient")]
        public string TicketDeliveryRecipient { get; set; }

        /// <summary>
        /// Gets or sets the hotel price.
        /// </summary>
        [JsonProperty("hotel_price")]
        public long? HotelPrice { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }
    }
}