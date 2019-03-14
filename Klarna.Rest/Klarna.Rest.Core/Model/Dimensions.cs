using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Represents a product's dimensions
    /// </summary>
    public class Dimensions
    {
        /// <summary>
        /// The product's height as used in the merchant's webshop. Non-negative. Measured in millimeters.
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public long Height { get; set; }

        /// <summary>
        /// The product's width as used in the merchant's webshop. Non-negative. Measured in millimeters.
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public long Width { get; set; }

        /// <summary>
        /// The product's length as used in the merchant's webshop. Non-negative. Measured in millimeters.
        /// </summary>
        [JsonProperty(PropertyName = "length")]
        public long Length { get; set; }
        
        
    }
}