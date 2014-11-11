#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="OrderData.cs" company="Klarna AB">
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
    /// The current state of an order.
    /// </summary>
    public class OrderData : Model
    {
        /// <summary>
        /// Gets the unique order id.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; private set; }

        /// <summary>
        /// Gets or sets the total amount for this order.
        /// </summary>
        [JsonProperty("order_amount")]
        public int? OrderAmount { get; set; }

        /// <summary>
        /// Gets the original amount for this order.
        /// </summary>
        [JsonProperty("original_order_amount")]
        public int? OriginalOrderAmount { get; private set; }

        /// <summary>
        /// Gets the total amount of all captures.
        /// </summary>
        [JsonProperty("captured_amount")]
        public int? CapturedAmount { get; private set; }

        /// <summary>
        /// Gets the remaining authorized amount for this order.
        /// </summary>
        [JsonProperty("remaining_authorized_amount")]
        public int? RemainingAuthorizedAmount { get; private set; }

        /// <summary>
        /// Gets  the total amount refunded for this order.
        /// </summary>
        [JsonProperty("refunded_amount")]
        public int? RefundedAmount { get; private set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        /// Gets or sets the purchase currency.
        /// </summary>
        [JsonProperty("purchase_currency")]
        public string PurchaseCurrency { get; set; }

        /// <summary>
        /// Gets or sets the customer's locale.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the order lines.
        /// </summary>
        [JsonProperty("order_lines")]
        public IList<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Gets or sets the merchant reference 1, can be used for storing merchant's internal order number or other references.
        /// </summary>
        [JsonProperty("merchant_reference1")]
        public string MerchantReference1 { get; set; }

        /// <summary>
        /// Gets or sets the merchant reference 2, can be used for storing merchant's internal order number or other references.
        /// </summary>
        [JsonProperty("merchant_reference2")]
        public string MerchantReference2 { get; set; }

        /// <summary>
        /// Gets the Klarna reference.
        /// Customer friendly reference id, used as order reference when communicating with the customer.
        /// </summary>
        [JsonProperty("klarna_reference")]
        public string KlarnaReference { get; private set; }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets the time when the order was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets or sets the purchase country.
        /// </summary>
        [JsonProperty("purchase_country")]
        public string PurchaseCountry { get; set; }

        /// <summary>
        /// Gets the expiration time.
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; private set; }

        /// <summary>
        /// Gets or sets the information about the liable customer of the order.
        /// </summary>
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the captures for this order.
        /// </summary>
        [JsonProperty("captures")]
        public IList<CaptureData> Captures { get; set; }

        /// <summary>
        /// Gets or sets the refunds for this order.
        /// </summary>
        [JsonProperty("refunds")]
        public IList<Refund> Refunds { get; set; }
    }
}
