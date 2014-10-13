#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Connector.cs" company="Klarna AB">
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
    using System.Net;

    /// <summary>
    /// Transport connector used to authenticate and make HTTP requests against the Klarna APIs.
    /// </summary>
    internal class Connector : IConnector
    {
        #region Private Fields

        /// <summary>
        /// Merchant ID.
        /// </summary>
        private string merchantId;

        /// <summary>
        /// Shared secret.
        /// </summary>
        private string secret;

        /// <summary>
        /// Http user agent.
        /// </summary>
        private UserAgent userAgent;

        /// <summary>
        /// Base url.
        /// </summary>
        private Uri baseUrl;

        /// <summary>
        /// The HTTP request factory.
        /// </summary>
        private IRequestFactory request;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Connector" /> class.
        /// </summary>
        /// <param name="request"> The HTTP request factory</param>
        /// <param name="merchantId"> the merchant id</param>
        /// <param name="secret">the shared secret</param>
        /// <param name="userAgent">the user agent</param>
        /// <param name="baseUrl">the base url</param>
        internal Connector(IRequestFactory request, string merchantId, string secret, UserAgent userAgent, Uri baseUrl)
        {
            this.request = request;
            this.merchantId = merchantId;
            this.secret = secret;
            this.userAgent = userAgent;
            this.baseUrl = baseUrl;
        }

        #region Implementation of IConnector

        /// <summary>
        /// Creates a request object.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="method">the HTTP method</param>
        /// <param name="payload">the payload</param>
        /// <returns>the HTTP request</returns>
        public System.Net.HttpWebRequest CreateRequest(string url, HttpMethod method, string payload)
        {
            if (!url.StartsWith(this.baseUrl.ToString()))
            {
                url = this.baseUrl + url.TrimStart('/');
            }

            // Create the request with correct method to use
            var request = this.request.CreateRequest(url);
            request.AllowAutoRedirect = false;
            request.Method = method.ToString().ToUpper();
            request.ContentType = "application/json";
            request.ContentLength = payload.Length;

            // Set HTTP Headers
            request.UserAgent = this.userAgent.ToString();

            request.Credentials = new NetworkCredential(this.merchantId, this.secret);

            return request;
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">the HTTP request</param>
        /// <param name="payload">the payload</param>
        /// <param name="httpStatusCode">the HTTP status code</param>
        /// <returns>the response</returns>
        public IResponse Send(HttpWebRequest request, string payload, HttpStatusCode httpStatusCode)
        {
            return this.request.Send(request, payload, httpStatusCode);
        }

        #endregion
    }
}
