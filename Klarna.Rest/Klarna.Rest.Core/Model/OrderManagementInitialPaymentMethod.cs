using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class OrderManagementInitialPaymentMethod
    {
        /// <summary>
        /// The type of the initial payment method.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        public OrderManagementInitialPaymentMethodType Type { get; set; }
        /// <summary>
        /// The description of the initial payment method.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}