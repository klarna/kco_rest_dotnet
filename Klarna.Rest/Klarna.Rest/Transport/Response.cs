#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Response.cs" company="Klarna AB">
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
namespace Klarna.Rest.Transport
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// HTTP response validator helper class. 
    /// </summary>
    public class Response : IResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        private string json;

        /// <summary>
        /// The response location.
        /// </summary>
        private string location;

        /// <summary>
        /// Initializes a new instance of the <see cref="Response" /> class.
        /// </summary>
        /// <param name="json">the JSON data</param>
        /// <param name="location">the location</param>
        public Response(string json, string location)
        {
            this.json = json;
            this.location = location;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        public Uri Location
        {
            get
            {
                if (this.location == null)
                {
                    throw new Exception("Response contains location that is null");
                }

                return new Uri(this.location);
            }
        }

        /// <summary>
        /// Gets the JSON data.
        /// </summary>
        /// <typeparam name="T">generic data object</typeparam>
        /// <returns>the generic data object</returns>
        public T Data<T>()
        {
            return JsonConvert.DeserializeObject<T>(this.json);
        }
    }
}
