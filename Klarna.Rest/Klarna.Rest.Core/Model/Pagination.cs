using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Pagination object
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// The amount of elements in the current result
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        /// <summary>
        /// The total amount of elements that are available
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        /// <summary>
        /// The URI to the next "page" of results.
        /// </summary>
        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }
        /// <summary>
        /// The URI to the previous "page" of results.
        /// </summary>
        [JsonProperty(PropertyName = "prev")]
        public string Previous { get; set; }
        /// <summary>
        /// The current offset. Describes "where" in a collection the current starts.
        /// </summary>
        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }
    }
}