#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Resource.cs" company="Klarna AB">
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
namespace Klarna.Rest
{
    using System;
    using System.Net;
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Abstract resource class.
    /// </summary>
    internal abstract class Resource : IResource
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        public Resource(IConnector connector)
        {
            this.Connector = connector;
        }

        #endregion

        #region Properties of IResource

        /// <summary>
        /// Gets or sets the URL of the resource.
        /// </summary>
        public Uri Location { get; set; }

        /// <summary>
        /// Gets the path to the resource endpoint.
        /// </summary>
        internal abstract string Path { get; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the connector.
        /// </summary>
        protected IConnector Connector { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sends a HTTP GET request to the specified url.
        /// </summary>
        /// <param name="url">the url</param>
        /// <returns>the response</returns>
        protected ResponseValidator Get(string url)
        {
            return this.Request(url, null, HttpMethod.Get);
        }

        /// <summary>
        /// Sends a HTTP PATCH request to the specified url.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="data">the checkout order data</param>
        /// <returns>the response</returns>
        protected ResponseValidator Patch(string url, Model data)
        {
            return this.Request(url, data, HttpMethod.Patch);
        }

        /// <summary>
        /// Sends a HTTP POST request to the specified url.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="data">the checkout order data</param>
        /// <returns>the response</returns>
        protected ResponseValidator Post(string url, Model data)
        {
            return this.Request(url, data, HttpMethod.Post);
        }

        /// <summary>
        /// Sends the request to the specified url.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="data">the checkout order data</param>
        /// <param name="httpMethod">the http method</param>
        /// <returns>the response</returns>
        private ResponseValidator Request(string url, Model data, HttpMethod httpMethod)
        {
            string json = data != null ? data.ConvertToJson() : string.Empty;
            var request = this.Connector.CreateRequest(url, httpMethod, json);
            if (data != null)
            {
                request.ContentType = "application/json";
            }

            return new ResponseValidator(this.Connector.Send(request, json));
        }

        #endregion
    }
}
