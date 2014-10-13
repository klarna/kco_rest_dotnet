#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UpdateAuthorization.cs" company="Klarna AB">
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
namespace Klarna.Rest.Models.Requests
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Update the total order amount of an order, subject to a new customer credit check.
    /// </summary>
    public class UpdateAuthorization : Model
    {
        /// <summary>
        /// Gets or sets the order amount in minor unit. For example an order amount of £1 should be sent as 100.
        /// </summary>
        [JsonProperty("order_amount")]
        public int? OrderAmount { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the order lines.
        /// </summary>
        [JsonProperty("order_lines")]
        public IList<OrderLine> OrderLines { get; set; }
    }
}
