using System;
using System.Net;
using Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Communication
{
    /// <summary>
    /// Error message model.
    /// </summary>
    public class ApiException : WebException
    {
        /// <summary>
        /// Gets the API response status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Gets the API error response model.
        /// </summary>
        public ErrorMessage ErrorMessage { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException" /> class.
        /// </summary>
        /// <param name="message">The text of the error message.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="errorMessage">The API error message model.</param>
        /// <param name="innerException">The nested exception</param>
        public ApiException(string message, HttpStatusCode statusCode, ErrorMessage errorMessage, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
