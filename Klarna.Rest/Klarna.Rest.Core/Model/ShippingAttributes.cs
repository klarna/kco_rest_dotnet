using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Represents shipping attributes of an order item
    /// </summary>
    public class ShippingAttributes
    {
        /// <summary>
        /// The product's weight as used in the merchant's webshop. Non-negative. Measured in grams.
        /// </summary>
        [JsonProperty(PropertyName = "weight")]
        public int Weight { get; set; }
        
        /// <summary>
        /// The product's dimensions: height, width and length. Each dimension is of type Long.
        /// </summary>
        [JsonProperty(PropertyName = "dimensions")]
        public Dimensions Dimensions { get; set; }

        /// <summary>
        /// The product's extra features
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public ICollection<string> Tags { get; set; }
    }
}