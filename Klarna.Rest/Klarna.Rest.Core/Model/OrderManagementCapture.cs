using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use the Capture model from Klarna.Rest.Core.Model.OrderManagement namespace instead")]
    public class OrderManagementCapture
    {
        /// <summary>
        /// The capture id. Generated when the capture is created.
        /// </summary>
        [JsonProperty(PropertyName = "capture_id")]
        public string CaptureId { get; set; }
        /// <summary>
        /// Customer friendly reference id, used as a reference when communicating with the customer.
        /// </summary>
        [JsonProperty(PropertyName = "klarna_reference")]
        public string KlarnaReference { get; set; }
        /// <summary>
        /// The captured amount in minor units.
        /// </summary>
        [JsonProperty(PropertyName = "captured_amount")]
        public int CapturedAmount { get; set; }
        /// <summary>
        /// The time of the capture. Specified in ISO 8601.
        /// </summary>
        [JsonProperty(PropertyName = "captured_at")]
        public string CapturedAt { get; set; }
        /// <summary>
        /// Description of the capture shown to the customer.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// List of order lines for the capture shown to the customer.
        /// </summary>
        [JsonProperty(PropertyName = "order_lines")]
        public ICollection<OrderManagement.OrderLine> OrderLines { get; set; }
        /// <summary>
        /// Refunded amount for this capture in minor units.
        /// </summary>
        [JsonProperty(PropertyName = "refunded_amount")]
        public int RefundedAmount { get; set; }
        /// <summary>
        /// Billing address for the capture.
        /// </summary>
        [JsonProperty(PropertyName = "billing_address")]
        public OrderManagement.Address BillingAddress { get; set; }
        /// <summary>
        /// Shipping address for the capture
        /// </summary>
        [JsonProperty(PropertyName = "shipping_address")]
        public OrderManagement.Address ShippingAddress { get; set; }
        /// <summary>
        /// Shipping information for this capture.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_info")]
        public ICollection<OrderManagement.ShippingInfo> ShippingInfo { get; set; }
    }
}