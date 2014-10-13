#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="OrderLine.cs" company="Klarna AB">
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
    /// Order line describing an item in the order.
    /// </summary>
    public class OrderLine : Model
    {
        /// <summary>
        /// Gets or sets the Item type. Allowed values are: "physical", "discount" or "shipping_fee".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the reference. Optional article number, SKU or similar. Max length is 255 characters.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item quantity.
        /// </summary>
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the optional unit used to describe the quantity, for example kg, pcs. Max length is 10 characters.
        /// </summary>
        [JsonProperty("quantity_unit")]
        public string QuantityUnit { get; set; }

        /// <summary>
        /// Gets or sets the unit price in minor units. Includes tax, excludes discount.
        /// </summary>
        [JsonProperty("unit_price")]
        public long? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the tax rate in percent, two implicit decimals. For example 2500 = 25%.
        /// </summary>
        [JsonProperty("tax_rate")]
        public int? TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the total amount in minor units. Includes tax and discount.
        /// </summary>
        [JsonProperty("total_amount")]
        public long? TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the optional total discount amount in minor units. Includes tax.
        /// </summary>
        [JsonProperty("total_discount_amount")]
        public long? TotalDiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount in minor units. Negative when type is discount.
        /// </summary>
        [JsonProperty("total_tax_amount")]
        public long? TotalTaxAmount { get; set; }
    }
}
