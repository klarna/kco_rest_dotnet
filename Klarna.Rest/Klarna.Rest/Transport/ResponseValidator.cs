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
        /// Asserts the HTTP response status code.
        /// </summary>
        /// <param name="responseStatusCode">the status code</param>
        /// <param name="httpStatusCode">the expected http status code</param>
        /// <returns>this response validator</returns>
        public ResponseValidator StatusCode(HttpStatusCode responseStatusCode, HttpStatusCode httpStatusCode)
        {
            if (responseStatusCode != httpStatusCode)
            {
                throw new Exception(string.Format("Response has wrong StatusCode. Should be {0} but is {1}", (int)httpStatusCode, (int)responseStatusCode));
            }

            return this;
        }

        /// <summary>
        /// Asserts the content type header.
        /// </summary>
        /// <param name="responseContentType">the content type</param>
        /// <param name="contentType">the expected content type</param>
        /// <returns>this response validator</returns>
        public ResponseValidator ContentType(string responseContentType, string contentType)
        {
            if (!responseContentType.Equals(contentType))
            {
                throw new Exception("Response has wrong ContentType");
            }

            return this;
        }
    }
}
