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
    public abstract class Resource
    {
        #region Private Fields

        /// <summary>
        /// HTTP transport connector instance.
        /// </summary>
        private IConnector connector;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        public Resource(IConnector connector)
        {
            this.connector = connector;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the URL of the resource.
        /// </summary>
        public Uri Location { get; set; }

        /// <summary>
        /// Gets the path to the resource endpoint.
        /// </summary>
        public abstract string Path { get; }

        /// <summary>
        /// Gets the connector.
        /// </summary>
        protected IConnector Connector
        {
            get
            {
                return this.connector;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sends a HTTP GET request to the specified url.
        /// </summary>
        /// <param name="url"> the url</param>
        /// <param name="httpStatusCode">the http status code</param>
        /// <returns>the response</returns>
        protected IResponse Get(string url, HttpStatusCode httpStatusCode)
        {
            return this.Request(url, null, HttpMethod.Get, httpStatusCode);
        }

        /// <summary>
        /// Sends a HTTP PATCH request to the specified url.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="data">the checkout order data</param>
        /// <param name="httpStatusCode">the http status code</param>
        /// <returns>the response</returns>
        protected IResponse Patch(string url, Model data, HttpStatusCode httpStatusCode)
        {
            return this.Request(url, data, HttpMethod.Patch, httpStatusCode);
        }

        /// <summary>
        /// Sends a HTTP POST request to the specified url.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="data">the checkout order data</param>
        /// <param name="statusCode">the status code</param>
        /// <returns>the response</returns>
        protected IResponse Post(string url, Model data, HttpStatusCode statusCode)
        {
            return this.Request(url, data, HttpMethod.Post, statusCode);
        }

        /// <summary>
        /// The request.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="data">the checkout order data</param>
        /// <param name="httpMethod">the http method</param>
        /// <param name="statusCode">the status code</param>
        /// <returns>the response</returns>
        private IResponse Request(string url, Model data, HttpMethod httpMethod, HttpStatusCode statusCode)
        {
            string json = data != null ? data.ConvertToJson() : string.Empty;
            var request = this.connector.CreateRequest(url, httpMethod, json);

            return this.connector.Send(request, json, statusCode);
        }

        #endregion
    }
}
