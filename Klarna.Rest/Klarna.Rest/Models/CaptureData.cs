#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CaptureData.cs" company="Klarna AB">
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
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A captured order.
    /// </summary>
    public class CaptureData : Model
    {
        /// <summary>
        /// Gets the id of this capture, generated at time of capture.
        /// </summary>
        [JsonProperty("capture_id")]
        public string CaptureId { get; private set; }

        /// <summary>
        /// Gets the Klarna reference.
        /// Customer friendly reference id, used as order reference when communicating with the customer.
        /// </summary>
        [JsonProperty("klarna_reference")]
        public string KlarnaReference { get; private set; }

        /// <summary>
        /// Gets or sets the capture amount.
        /// </summary>
        [JsonProperty("captured_amount")]
        public int? CapturedAmount { get;  set; }

        /// <summary>
        /// Gets the amount that has been refunded for this capture.
        /// </summary>
        [JsonProperty("refunded_amount")]
        public int? RefundedAmount { get; private set; }

        /// <summary>
        /// Gets the time of the capture.
        /// </summary>
        [JsonProperty("captured_at")]
        public DateTime CapturedAt { get; private set; }

        /// <summary>
        /// Gets or sets the description of the capture shown to the customer.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the order lines for the capture shown to the customer.
        /// </summary>
        [JsonProperty("order_lines")]
        public IList<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Gets or sets the billing address for the capture.
        /// </summary>
        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Gets the shipping address for the capture.
        /// </summary>
        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; private set; }

        /// <summary>
        /// Gets or sets the shipping information for the capture.
        /// </summary>
        [JsonProperty("shipping_info")]
        public IList<ShippingInfo> ShippingInfo { get; set; }
    }
}
