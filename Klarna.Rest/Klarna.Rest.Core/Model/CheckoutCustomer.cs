using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class CheckoutCustomer
    {
        /// <summary>
        /// ISO 8601 date. The customer date of birth.
        /// </summary>
        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; set; }
        /// <summary>
        /// The default supported value is 'person'. If B2B is enabled for the merchant, the value may be "organization".
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The organization's official registration id (organization number). Applicable only for B2B orders
        /// </summary>
        [JsonProperty(PropertyName = "organization_registration_id")]
        public string OrganizationRegistrationId { get; set; }
    }
}