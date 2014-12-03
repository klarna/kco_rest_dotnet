#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="IRequestFactory.cs" company="Klarna AB">
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
    /// The HTTP request factory interface.
    /// </summary>
    internal interface IRequestFactory
    {
        /// <summary>
        /// Creates a HttpWebRequest object.
        /// </summary>
        /// <param name="url">request url</param>
        /// <returns>a HTTP request object</returns>
        HttpWebRequest CreateRequest(string url);

        /// <summary>
        /// Performs a HTTP request.
        /// </summary>
        /// <param name="request">the HTTP request to send</param>
        /// <param name="payload">the payload to send if this is a POST</param>
        /// <returns>the response</returns>
        IResponse Send(HttpWebRequest request, string payload);
    }
}
