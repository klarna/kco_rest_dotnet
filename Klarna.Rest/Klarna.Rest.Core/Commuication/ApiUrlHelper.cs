using System.Collections.Specialized;
using System.Linq;

namespace Klarna.Rest.Core.Commuication
{
    internal static class ApiUrlHelper
    {
        public static string GetApiUrlForController(string baseApiUrl, string controller, string append = null,
            NameValueCollection parameters = null)
        {
            var controllerUri = $"{baseApiUrl.TrimEnd('/')}/{controller.TrimStart('/')}{(!string.IsNullOrEmpty(append) ? $"/{append}" : string.Empty)}";

            if (parameters == null || parameters.Count == 0)
                return controllerUri;

            return $"{controllerUri}{(controllerUri.IndexOf('?') > -1 ? "&" : "?")}{parameters.ToQueryString()}";
        }

        private static string ToQueryString(this NameValueCollection nvc)
        {
            return string.Join("&",
                nvc.AllKeys.Distinct().Select(a => a + "=" + nvc[a]));
        }
    }
}
