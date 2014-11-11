#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ResponseValidator.cs" company="Klarna AB">
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
    /// The response validator.
    /// </summary>
    internal class ResponseValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseValidator" /> class.
        /// </summary>
        /// <param name="response">the response</param>
        public ResponseValidator(IResponse response)
        {
            this.Response = response;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        public Uri Location
        {
            get
            {
                return new Uri(this.Response.Headers[HttpResponseHeader.Location]);
            }
        }

        /// <summary>
        /// Gets the internal response instance.
        /// </summary>
        public IResponse Response { get; private set; }

        /// <summary>
        /// Asserts the HTTP response status code.
        /// </summary>
        /// <param name="status">the expected HTTP status code</param>
        /// <returns>this response validator</returns>
        public ResponseValidator Status(HttpStatusCode status)
        {
            if (!this.Response.Status.Equals(status))
            {
                throw new Exception(string.Format("Response has wrong StatusCode. Should be {0} but is {1}", (int)status, (int)this.Response.Status));
            }

            return this;
        }

        /// <summary>
        /// Asserts the content type header.
        /// </summary>
        /// <param name="contentType">the expected content type</param>
        /// <returns>this response validator</returns>
        public ResponseValidator ContentType(string contentType)
        {
            if (string.IsNullOrEmpty(this.Response.Headers[HttpResponseHeader.ContentType]))
            {
                throw new Exception("Response has no Content-Type header.");
            }

            if (!this.Response.Headers[HttpResponseHeader.ContentType].Equals(contentType))
            {
                throw new Exception(string.Format("Response has wrong Content-Type. Should be {0} but is {1}", contentType, this.Response.Headers[HttpResponseHeader.ContentType]));
            }

            return this;
        }
    }
}
