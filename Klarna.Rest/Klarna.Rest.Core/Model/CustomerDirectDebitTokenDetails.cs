using Newtonsoft.Json;
namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class CustomerDirectDebitTokenDetails
    {
        [JsonProperty(PropertyName = "brand")]
        public string Brand;
        [JsonProperty(PropertyName = "masked_number")]
        public string MaskedNumber;
    }
}
