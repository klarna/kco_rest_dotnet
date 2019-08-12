using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// The content type of the body property.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }
        /// <summary>
        /// This field should be a <b>string</b> containing the body of the attachment. The body should be an object containing any of the keys and sub objects described at <a href="https://developers.klarna.com/api/#checkout-api__create-a-new-orderattachment__content_type">https://developers.klarna.com/api/#checkout-api__create-a-new-orderattachment__content_type</a> serialised to JSON.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
    }
}