#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CheckoutOrderData.cs" company="Klarna AB">
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
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The Checkout order.
    /// </summary>
    public class CheckoutOrderData : Model
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; private set; }

        /// <summary>
        /// Gets or sets the purchase country.
        /// </summary>
        [JsonProperty("purchase_country")]
        public string PurchaseCountry { get; set; }

        /// <summary>
        /// Gets or sets the shipping countries.
        /// </summary>
        [JsonProperty("shipping_countries")]
        public IList<string> ShippingCountries { get; set; }

        /// <summary>
        /// Gets or sets the purchase currency.
        /// </summary>
        [JsonProperty("purchase_currency")]
        public string PurchaseCurrency { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

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
        /// Gets or sets the order amount.
        /// </summary>
        [JsonProperty("order_amount")]
        public int? OrderAmount { get; set; }

        /// <summary>
        /// Gets or sets the order tax amount.
        /// </summary>
        [JsonProperty("order_tax_amount")]
        public int? OrderTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the order lines.
        /// </summary>
        [JsonProperty("order_lines")]
        public IList<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the merchant URLs.
        /// </summary>
        [JsonProperty("merchant_urls")]
        public MerchantUrls MerchantUrls { get; set; }

        /// <summary>
        /// Gets the HTML snippet that is used to render the checkout in an iframe.
        /// </summary>
        [JsonProperty("html_snippet")]
        public string HtmlSnippet { get; private set; }

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
        /// Gets the started at time.
        /// </summary>
        [JsonProperty("started_at")]
        public DateTime StartedAt { get; private set; }

        /// <summary>
        /// Gets the completed at time.
        /// </summary>
        [JsonProperty("completed_at")]
        public DateTime CompletedAt { get; private set; }

        /// <summary>
        /// Gets the last time modified.
        /// </summary>
        [JsonProperty("last_modified_at")]
        public DateTime LastModifiedAt { get; private set; }

        /// <summary>
        /// Gets or sets the last time modified.
        /// </summary>
        [JsonProperty("options")]
        public CheckoutOptions Options { get; set; }

        /// <summary>
        /// Gets or sets the GUI options.
        /// </summary>
        [JsonProperty("gui")]
        public Gui Gui { get; set; }
    }
}
