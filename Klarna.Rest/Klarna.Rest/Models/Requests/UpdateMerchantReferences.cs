#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UpdateMerchantReferences.cs" company="Klarna AB">
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
    using Newtonsoft.Json;

    /// <summary>
    /// Update one or both merchant references. To clear a reference, set its value to "" (empty string).
    /// </summary>
    public class UpdateMerchantReferences : Model
    {
        /// <summary>
        /// Gets or sets the optional merchant reference 1.
        /// </summary>
        [JsonProperty("merchant_reference1")]
        public string MerchantReference1 { get; set; }

        /// <summary>
        /// Gets or sets the optional merchant reference 2.
        /// </summary>
        [JsonProperty("merchant_reference2")]
        public string MerchantReference2 { get; set; }
    }
}
