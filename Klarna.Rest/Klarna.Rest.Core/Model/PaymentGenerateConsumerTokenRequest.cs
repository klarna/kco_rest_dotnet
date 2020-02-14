using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    public class PaymentGenerateConsumerTokenRequest
    {
        /// <summary>
        /// ISO 3166 alpha-2 purchase country.
        /// </summary>
        [JsonProperty(PropertyName = "purchase_country")]
        public string PurchaseCountry { get; set; }
        /// <summary>
        /// ISO 4217 purchase currency.
        /// </summary>
        [JsonProperty(PropertyName = "purchase_currency")]
        public string PurchaseCurrency { get; set; }
        /// <summary>
        /// RFC 1766 customer's locale.
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
        /// <summary>
        /// Once the customer has provided any data, updates to this object will be ignored (without generating an error).
        /// </summary>
        [JsonProperty(PropertyName = "billing_address")]
        public PaymentAddressInfo BillingAddress { get; set; }
        /// <summary>
        /// Information about the liable customer of the order.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public PaymentCustomer Customer { get; set; }
        /// <summary>
        /// Description of the purpose of the token.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Intended use for the token.
        /// * SUBSCRIPTION
        /// </summary>
        [JsonProperty(PropertyName = "intended_use")]
        public string IntendedUse { get; set; }
    }
}