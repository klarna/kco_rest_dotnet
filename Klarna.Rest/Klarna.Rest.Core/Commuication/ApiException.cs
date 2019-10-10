using System;
using System.Net;
using Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Commuication
{
    /// <summary>
    /// Error message model.
    /// </summary>
    [Obsolete("Use Communication namespace instead of Commuication")]
    public class ApiException : Communication.ApiException
    {
        public ApiException(string message,
            HttpStatusCode statusCode,
            ErrorMessage errorMessage,
            Exception innerException) : base(message,
            statusCode,
            errorMessage,
            innerException)
        { }
    }
}
