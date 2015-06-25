#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="MarketplaceSellerInformation.cs" company="Klarna AB">
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
    /// The model for marketplace seller information.
    /// </summary>
    public class MarketplaceSellerInformation : Model
    {
        /// <summary>
        /// Gets or sets the unique account identifier.
        /// </summary>
        [JsonProperty("unique_account_identifier_seller")]
        public UniqueAccountIdentifier UniqueAccountIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the sub merchant id.
        /// </summary>
        [JsonProperty("sub_merchant_id")]
        public string SubMerchantID { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        [JsonProperty("product_category")]
        public string ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the account registration date.
        /// </summary>
        [JsonProperty("account_registration_date")]
        public DateTime AccountRegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the account last modified date.
        /// </summary>
        [JsonProperty("account_last_modified")]
        public LastModified AccountLastModified { get; set; }

        /// <summary>
        /// Gets or sets the seller rating.
        /// </summary>
        [JsonProperty("seller_rating")]
        public long? SellerRating { get; set; }

        /// <summary>
        /// Gets or sets the number of trades.
        /// </summary>
        [JsonProperty("number_of_trades")]
        public int NumberOfTrades { get; set; }

        /// <summary>
        /// Gets or sets the volume of trades.
        /// </summary>
        [JsonProperty("volume_of_trades")]
        public int VolumeOfTrades { get; set; }
    }
}