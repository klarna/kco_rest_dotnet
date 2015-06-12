#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ApiException.cs" company="Klarna AB">
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
    using System.Runtime.Serialization;
    using Klarna.Rest.Models;

    /// <summary>
    /// Exception thrown for API error responses.
    /// </summary>
    [Serializable]
    public class ApiException : WebException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException" /> class.
        /// </summary>
        /// <param name="message">The text of the error message.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="errorMessage">The API error message model.</param>
        /// <param name="innerException">The nested exception</param>
        public ApiException(string message, HttpStatusCode statusCode, ErrorMessage errorMessage, Exception innerException) : base(message, innerException)
        {
            this.StatusCode = statusCode;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException" /> class.
        /// </summary>
        /// <param name="serializationInfo">Serialization info</param>
        /// <param name="streamingContext">Streaming context</param>
        protected ApiException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        /// <summary>
        /// Gets the API response status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Gets the API error response model.
        /// </summary>
        public ErrorMessage ErrorMessage { get; internal set; }
    }
}