#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="PaymentHistoryFull.cs" company="Klarna AB">
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
    /// The model for a full payment history.
    /// </summary>
    public class PaymentHistoryFull : Model
    {
        /// <summary>
        /// Gets or sets the unique account identifier.
        /// </summary>
        [JsonProperty("unique_account_identifier")]
        public string UniqueAccountIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the payment option.
        /// <para>Allowed values are "card", "direct banking", "non klarna credit", "SMS" or "other".</para>
        /// </summary>
        [JsonProperty("payment_option")]
        public string PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets the number of paid purchases.
        /// </summary>
        [JsonProperty("number_paid_purchases")]
        public int NumberPaidPurchases { get; set; }

        /// <summary>
        /// Gets or sets the total amount for paid purchases.
        /// </summary>
        [JsonProperty("total_amount_paid_purchases")]
        public long? TotalAmountPaidPurchases { get; set; }

        /// <summary>
        /// Gets or sets the date of the last paid purchase.
        /// </summary>
        [JsonProperty("date_of_last_paid_purchase")]
        public DateTime DateOfLastPaidPurchase { get; set; }

        /// <summary>
        /// Gets or sets the date of the first paid purchase.
        /// </summary>
        [JsonProperty("date_of_first_paid_purchase")]
        public DateTime DateOfFirstPaidPurchase { get; set; }
    }
}