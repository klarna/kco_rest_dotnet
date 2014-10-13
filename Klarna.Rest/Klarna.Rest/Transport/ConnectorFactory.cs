#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ConnectorFactory.cs" company="Klarna AB">
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

    /// <summary>
    /// Connector factory
    /// </summary>
    public class ConnectorFactory
    {
        /// <summary>
        /// API base URL.
        /// </summary>
        private static readonly string BASEURL = "https://api.klarna.com";

        /// <summary>
        /// Testing API base URL.
        /// </summary>
        private static readonly string TESTBASEURL = "https://api.playground.klarna.com";

        /// <summary>
        /// Gets the base url
        /// </summary>
        public static Uri BaseUrl 
        {
            get 
            {
                return new Uri(BASEURL);
            }
        }

        /// <summary>
        /// Gets the test base url
        /// </summary>
        public static Uri TestBaseUrl
        {
            get
            {
                return new Uri(TESTBASEURL);
            }
        }

        /// <summary>
        /// Creates a connector.
        /// </summary>
        /// <param name="merchantId">the merchant url</param>
        /// <param name="secret">The shared secret.</param>
        /// <param name="baseUrl">the base url</param>
        /// <returns>the connector</returns>
        public static IConnector Create(string merchantId, string secret, Uri baseUrl)
        {
            return Create(new RequestFactory(), merchantId, secret, new UserAgent(), baseUrl);
        }

        /// <summary>
        /// Creates a connector.
        /// </summary>
        /// <param name="request">the HTTP request factory</param>
        /// <param name="merchantId">the merchant url</param>
        /// <param name="secret">The shared secret.</param>
        /// <param name="userAgent"> the user agent</param>
        /// <param name="baseUrl">the base url</param>
        /// <returns>the connector</returns>
        public static IConnector Create(IRequestFactory request, string merchantId, string secret, UserAgent userAgent, Uri baseUrl)
        {
            return new Connector(request, merchantId, secret, userAgent, baseUrl);
        }
    }
}
