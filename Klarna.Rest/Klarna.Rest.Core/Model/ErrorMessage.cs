using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets error messages.
        /// </summary>
        [JsonProperty("error_messages")]
        public string[] ErrorMessages { get; set; }

        /// <summary>
        /// Gets or sets correlation id.
        /// <para>The correlation id may be requested by merchant support to facilitate support inquiries.</para>
        /// </summary>
        [JsonProperty("correlation_id")]
        public string CorrelationId { get; set; }
    }
}
