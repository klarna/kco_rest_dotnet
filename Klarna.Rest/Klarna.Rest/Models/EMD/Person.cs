#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Klarna AB">
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
    /// The model of persons.
    /// </summary>
    public class Person : Model
    {
        /// <summary>
        /// Gets or sets the person ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// <para>Allowed values are "mr", "mrs", "ms" or blank if under 12 years.</para>
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}