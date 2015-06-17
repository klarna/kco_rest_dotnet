#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Event.cs" company="Klarna AB">
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
    /// The model for events.
    /// </summary>
    public class Event : Model
    {
        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        [JsonProperty("event_name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the event company.
        /// </summary>
        [JsonProperty("event_company")]
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the event genre.
        /// </summary>
        [JsonProperty("genre_of_event")]
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the arena name.
        /// </summary>
        [JsonProperty("arena_name")]
        public string ArenaName { get; set; }

        /// <summary>
        /// Gets or sets the arena location.
        /// </summary>
        [JsonProperty("arena_location")]
        public Location ArenaLocation { get; set; }

        /// <summary>
        /// Gets or sets the event start time.
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the event end time.
        /// </summary>
        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether tickets are digitally checked when entering the venue.
        /// </summary>
        [JsonProperty("access_controlled_venue")]
        public bool? AccessControllerVenue { get; set; }

        /// <summary>
        /// Gets or sets the ticket delivery method.
        /// </summary>
        [JsonProperty("ticket_delivery_method")]
        public string TicketDeliveryMethod { get; set; }

        /// <summary>
        /// Gets or sets the ticket delivery recipient.
        /// </summary>
        [JsonProperty("ticket_delivery_recipient")]
        public string TicketDeliveryRecipient { get; set; }

        /// <summary>
        /// Gets or sets the affiliate name.
        /// </summary>
        [JsonProperty("affiliate_name")]
        public string AffiliateName { get; set; }
    }
}