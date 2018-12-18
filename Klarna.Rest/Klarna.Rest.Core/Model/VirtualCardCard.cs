using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// Virtual Card card object
    /// </summary>
    public class VirtualCardCard
    {
        /// <summary>
        /// Identifier to reference order line.
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        /// <summary>
        /// Unique card identifier.
        /// </summary>
        [JsonProperty(PropertyName = "card_id")]
        public string CardId { get; set; }
        /// <summary>
        /// The total amount available on the card. In minor units. The number of decimals are controlled by the currency.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
        /// <summary>
        /// The ISO 4217 code states which currency it is and how many decimals the amount has.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Encrypted, PCI compliant card data.
        /// </summary>
        [JsonProperty(PropertyName = "pci_data")]
        public string PciData { get; set; }
        /// <summary>
        /// Initialization vector for symmetric decryption with the AES key.
        /// </summary>
        [JsonProperty(PropertyName = "iv")]
        public string InitializationVector { get; set; }
        /// <summary>
        /// The symmetric key complying the Advanced Encryption Standard.
        /// </summary>
        [JsonProperty(PropertyName = "aes_key")]
        public string AesKey { get; set; }
        /// <summary>
        /// The brand of the card.
        /// </summary>
        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }
        /// <summary>
        /// Card holder name on the card.
        /// </summary>
        [JsonProperty(PropertyName = "holder")]
        public string Holder { get; set; }
    }
}