using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use the UpdateShippingInfo model from Klarna.Rest.Core.Model.OrderManagement namespace instead")]
    public class OrderManagementAddShippingInfo
    {
        /// <summary>
        /// New shipping info. Maximum: 500 items.
        /// </summary>
        [JsonProperty(PropertyName = "shipping_info")]
        public ICollection<OrderManagementShippingInfo> ShippingInfo { get; set; }
    }
}