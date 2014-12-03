#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="IConnector.cs" company="Klarna AB">
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
    using System.Net;

    /// <summary>
    /// HTTP transport connector interface used to authenticate and make HTTP requests against the Klarna APIs.
    /// </summary>
    public interface IConnector
    {
        /// <summary>
        /// Gets the user agent.
        /// </summary>
        UserAgent UserAgent { get; }

        /// <summary>
        /// Creates a request object.
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="method">the HTTP method</param>
        /// <param name="payload">the payload</param>
        /// <returns>the HTTP request</returns>
        HttpWebRequest CreateRequest(string url, HttpMethod method, string payload);

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">the request</param>
        /// <param name="payload">the payload</param>
        /// <returns>the response</returns>
        IResponse Send(HttpWebRequest request, string payload);
    }
}
