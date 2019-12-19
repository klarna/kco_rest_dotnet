using System;
using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Hosted payment page session status
    /// </summary>
    [Obsolete("This model is being deprecated. Use SessionResponseV1 from Klarna.Rest.Core.Model.HostedPaymentPage namespace instead")]
    public class HostedPaymentPageSessionStatus
    {
        /// <summary>
        /// KP authorization token
        /// </summary>
        [Obsolete("AuthToken is no longer supported by HPP. Consider using AuthorizationToken instead.")]
        public string AuthToken
        {
            get => AuthorizationToken;
            set => AuthorizationToken = value;
        }
        /// <summary>
        /// KP authorization token
        /// </summary>
        [JsonProperty(PropertyName = "authorization_token")]
        public string AuthorizationToken { get; set; }
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
        
        /// <summary>
        /// The id of the HPP Session
        /// </summary>
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }
    }
}