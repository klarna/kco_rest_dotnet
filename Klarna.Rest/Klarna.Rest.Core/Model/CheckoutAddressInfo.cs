using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class CheckoutAddressInfo
    {
        /// <summary>
        /// Gets organization name
        /// </summary>
        [JsonProperty(PropertyName = "organization_name")]
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// Gets Shipping Reference
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        
        /// <summary>
        /// Gets attention
        /// </summary>
        [JsonProperty(PropertyName = "attention")]
        public string Attention { get; set; }
        
        /// <summary>
        /// Gets firstname
        /// </summary>
        [JsonProperty(PropertyName = "given_name")]
        public string GivenName { get; set; }
        
        /// <summary>
        /// Gets lastname
        /// </summary>
        [JsonProperty(PropertyName = "family_name")]
        public string FamilyName { get; set; }
        
        /// <summary>
        /// Gets e-mail
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
        /// <summary>
        /// Title.
        /// Valid values for UK:
        ///   Mr
        ///   Ms
        ///   Mrs
        ///   Miss
        /// Valid values for DACH:
        ///   Herr
        ///   Frau
        /// Valid values for NL:
        ///   Dhr.
        ///   Mevr.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// Street address, first line.
        /// </summary>
        [JsonProperty(PropertyName = "street_address")]
        public string StreetAddress { get; set; }
        /// <summary>
        /// Street address, second line.
        /// </summary>
        [JsonProperty(PropertyName = "street_address2")]
        public string StreetAddress2 { get; set; }
        /// <summary>
        /// Street name. Only applicable in DE/AT/NL. Do not combine with street_address. See streetNumber.
        /// </summary>
        [JsonProperty(PropertyName = "street_name")]
        public string StreetName { get; set; }
        /// <summary>
        /// Street number. Only applicable in DE/AT/NL. Do not combine with street_address. See streetName.
        /// </summary>
        [JsonProperty(PropertyName = "street_number")]
        public string StreetNumber { get; set; }
        /// <summary>
        /// House extension. Only applicable in NL
        /// </summary>
        [JsonProperty(PropertyName = "house_extension")]
        public string HouseExtension { get; set; }
        /// <summary>
        /// Postal/post code.
        /// </summary>
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        /// <summary>
        /// State or Region.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
        /// <summary>
        /// Phone number.
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        /// <summary>
        /// ISO 3166 alpha-2 Country.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// Care of.
        /// </summary>
        [JsonProperty(PropertyName = "care_of")]
        public string CareOf { get; set; }
    }
}