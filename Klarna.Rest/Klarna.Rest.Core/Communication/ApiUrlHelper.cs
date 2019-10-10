using System.Collections.Specialized;
using System.Linq;

namespace Klarna.Rest.Core.Communication
{
    /// <summary>
    /// Helper util. Contains small tools to work with URL and query strings.
    /// </summary>
    internal static class ApiUrlHelper
    {
        /// <summary>
        /// Builds the API URL based on the Klarna environment, controller and extra 
        /// </summary>
        /// <param name="baseApiUrl">Environment URL (like https://api.klarna.com)</param>
        /// <param name="controllerUrl">Controller URL</param>
        /// <param name="append">URL appendix</param>
        /// <param name="parameters">Extra parameters (will be added as a query string after "?")</param>
        /// <returns>API URL</returns>
        public static string GetApiUrlForController(string baseApiUrl,
            string controllerUrl,
            string append = null,
            NameValueCollection parameters = null)
        {
            var controllerUri = $"{baseApiUrl.TrimEnd('/')}/{controllerUrl.TrimStart('/')}{(!string.IsNullOrEmpty(append) ? $"/{append}" : string.Empty)}";

            if (parameters == null || parameters.Count == 0)
                return controllerUri;

            return $"{controllerUri}{(controllerUri.IndexOf('?') > -1 ? "&" : "?")}{parameters.ToQueryString()}";
        }

        /// <summary>
        /// Converts collection to query URL params
        /// </summary>
        /// <param name="urlParams">Name-Value Collection to convert to query params</param>
        /// <returns>URL query params</returns>
        private static string ToQueryString(this NameValueCollection urlParams)
        {
            return string.Join("&",
                urlParams.AllKeys.Distinct().Select(a => a + "=" + urlParams[a]));
        }
    }
}
