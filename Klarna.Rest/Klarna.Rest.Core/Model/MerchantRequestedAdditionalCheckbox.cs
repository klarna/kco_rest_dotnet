using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    public class MerchantRequestedAdditionalCheckbox
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }
    }
}