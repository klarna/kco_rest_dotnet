using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use UpdateMerchantReferences model from Klarna.Rest.Core.Model.OrderManagement namespace instead")]
    public class OrderManagementMerchantReferences
    {
        /// <summary>
        /// New merchant reference 1. Old reference will be overwritten if this field is present.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference1")]
        public string MerchantReference1 { get; set; }
        /// <summary>
        /// New merchant reference 2. Old reference will be overwritten if this field is present.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference2")]
        public string MerchantReference2 { get; set; }
    }
}