#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="RequestFactory.cs" company="Klarna AB">
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
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    /// The HTTP request factory interface.
    /// </summary>
    internal class RequestFactory : IRequestFactory
    {
        /// <summary>
        /// Creates a HttpWebRequest object.
        /// </summary>
        /// <param name="url"> the url</param>
        /// <returns> a HTTP request</returns>
        public System.Net.HttpWebRequest CreateRequest(string url)
        {
            // Create the request with correct method to use
            var request = (HttpWebRequest)WebRequest.Create(url);

            return request;
        }

        /// <summary>
        /// Performs a HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request to send.</param>
        /// <param name="payload">The payload to send if this is a POST or a PATCH.</param>
        /// <param name="httpStatusCode">the http status code</param>
        /// <returns>the response</returns>
        public IResponse Send(System.Net.HttpWebRequest request, string payload, HttpStatusCode httpStatusCode)
        {
            if (!string.IsNullOrEmpty(payload))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(payload);
                request.ContentLength = bytes.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                } 
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                return this.VerifyResponse(response, httpStatusCode);
            }
        }

        /// <summary>
        /// Gets the JSON response.
        /// </summary>
        /// <param name="response">the HTTP response</param>
        /// <returns>the JSON string</returns>
        private string Json(HttpWebResponse response)
        {
            Stream webStream = response.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            return responseReader.ReadToEnd();
        }

        /// <summary>
        /// Verify the response.
        /// </summary>
        /// <param name="response">the response</param>
        /// <param name="httpStatusCode">the http status code</param>
        /// <returns>the verified response</returns>
        private IResponse VerifyResponse(HttpWebResponse response, HttpStatusCode httpStatusCode)
        {
            ResponseValidator responseValidator = new ResponseValidator();

            responseValidator.StatusCode(response.StatusCode, httpStatusCode).ContentType(response.ContentType, "application/json");

            return new Response(this.Json(response), response.GetResponseHeader("Location"));
        }
    }
}
