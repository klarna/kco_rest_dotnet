using System;
using Newtonsoft.Json;
namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use the DirectDebitInformation model from Klarna.Rest.Core.Model.CustomerToken namespace instead")]
    public class CustomerDirectDebitTokenDetails
    {
        [JsonProperty(PropertyName = "brand")]
        public string Brand;
        [JsonProperty(PropertyName = "masked_number")]
        public string MaskedNumber;
    }
}
