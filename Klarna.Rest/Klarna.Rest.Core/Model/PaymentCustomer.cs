using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class PaymentCustomer
    {
        /// <summary>
        /// ISO 8601 date. The customer date of birth
        /// </summary>
        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; set; }
        /// <summary>
        /// The customer's title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// The customer gender
        /// </summary>
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
        /// <summary>
        /// Last four digits for customer social security number
        /// </summary>
        [JsonProperty(PropertyName = "last_four_ssn")]
        public string LastFourSsn { get; set; }
        /// <summary>
        /// The customer's national identification number
        /// </summary>
        [JsonProperty(PropertyName = "national_identification_number")]
        public string NationalIdentificationNumber { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        ///  VAT id
        /// </summary>
        [JsonProperty(PropertyName = "vat_id")]
        public string VatId { get; set; }
        /// <summary>
        /// Organization entity type
        /// </summary>
        [JsonProperty(PropertyName = "organization_registration_id")]
        public string OrganizationRegistrationId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "organization_entity_type")]
        public PaymentCustomerOrganizationEntityType OrganizationEntityType { get; set; }
    }
}