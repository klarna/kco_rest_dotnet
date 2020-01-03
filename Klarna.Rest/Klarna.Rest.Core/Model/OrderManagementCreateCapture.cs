using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use the CaptureObject model from Klarna.Rest.Core.Model.OrderManagement namespace instead")]
    public class OrderManagementCreateCapture
    {
        /// <summary>
        /// The captured amount in minor units.
        /// </summary>
        [JsonProperty(PropertyName = "captured_amount")]
        public int CapturedAmount { get; set; }
        /// <summary>
        /// Description of the capture shown to the customer. Maximum 255 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Order lines for this capture. Maximum 1000 items.
        /// </summary>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderManagement.OrderLine> OrderLines { get; set; }
        /// <summary>
        /// Shipping information for this capture. Maximum 500 items.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_info")]
        public ICollection<OrderManagement.ShippingInfo> ShippingInfo { get; set; }
        /// <summary>
        /// Delay before the order will be shipped. Use for improving the customer experience regarding payments. This field is currently not returned when reading the order. Minimum: 0. Please note: to be able to submit values larger than 0, this has to be enabled in your merchant account. Please contact Klarna for further information.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_delay")]
        public int ShippingDelay { get; set; }
    }
}