using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Hosted payment page session status
    /// </summary>
    public class HostedPaymentPageSessionStatus
    {
        /// <summary>
        /// KP authorization token
        /// </summary>
        [JsonProperty(PropertyName = "auth_token")]
        public string AuthToken { get; set; }
        /// <summary>
        /// Current session status
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public HostedPaymentPageStatus Status { get; set; }
        /// <summary>
        /// Latest status update time
        /// </summary>
        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }
    }
}