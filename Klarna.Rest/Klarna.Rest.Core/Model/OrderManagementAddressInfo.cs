using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class OrderManagementAddressInfo
    {
        /// <summary>
        /// Given name. Maximum 100 characters.
        /// </summary>
        [JsonProperty(PropertyName = "given_name")]
        public string GivenName { get; set; }
        /// <summary>
        /// Family name. Maximum 100 characters.
        /// </summary>
        [JsonProperty(PropertyName = "family_name")]
        public string FamilyName { get; set; }
        /// <summary>
        /// Title. Between 0 and 20 characters.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// First line of street address. Maximum 100 characters.
        /// </summary>
        [JsonProperty(PropertyName = "street_address")]
        public string StreetAddress { get; set; }
        /// <summary>
        /// Second line of street address. Maximum 100 characters.
        /// </summary>
        [JsonProperty(PropertyName = "street_address2")]
        public string StreetAddress2 { get; set; }
        /// <summary>
        /// Postcode. Maximum 10 characters.
        /// </summary>
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }
        /// <summary>
        /// City. Maximum 200 characters.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        /// <summary>
        /// State/Region. Required for some countries. Maximum 200 characters.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
        /// <summary>
        /// Country. ISO 3166 alpha-2.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// E-mail address. Maximum 100 characters.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        /// <summary>
        /// Phone number. Maximum 100 characters.
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
    }
}