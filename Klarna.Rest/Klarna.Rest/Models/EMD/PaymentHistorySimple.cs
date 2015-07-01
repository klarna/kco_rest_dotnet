#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="PaymentHistorySimple.cs" company="Klarna AB">
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
    using Newtonsoft.Json;

    /// <summary>
    /// The model for a simple payment history.
    /// </summary>
    public class PaymentHistorySimple : Model
    {
        /// <summary>
        /// Gets or sets the unique account identifier.
        /// </summary>
        [JsonProperty("unique_account_identifier")]
        public string UniqueAccountIdentifier { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the purchase has been paid before.
        /// </summary>
        [JsonProperty("paid_before")]
        public bool PaidBefore { get; set; }
    }
}