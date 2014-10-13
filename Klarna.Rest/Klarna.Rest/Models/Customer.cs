#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Customer.cs" company="Klarna AB">
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
    /// Customer information.
    /// </summary>
    public class Customer : Model
    {
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }
    }
}
