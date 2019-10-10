using Newtonsoft.Json;
namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class CustomerTokenCardDetails
    {
        [JsonProperty(PropertyName = "brand")]
        public string Brand;
        [JsonProperty(PropertyName = "masked_number")]
        public string MaskedNumber;
        [JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate;
    }
}
