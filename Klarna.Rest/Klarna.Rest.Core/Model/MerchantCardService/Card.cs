using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.MerchantCardService {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Card {
    /// <summary>
    /// Identifier to reference order line.
    /// </summary>
    /// <value>Identifier to reference order line.</value>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Unique card identifier.
    /// </summary>
    /// <value>Unique card identifier.</value>
    [DataMember(Name="card_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// The total amount available on the card. In minor units. The number of decimals are controlled by the currency.
    /// </summary>
    /// <value>The total amount available on the card. In minor units. The number of decimals are controlled by the currency.</value>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public long? Amount { get; set; }

    /// <summary>
    /// The ISO 4217 code states which currency it is and how many decimals the amount has.
    /// </summary>
    /// <value>The ISO 4217 code states which currency it is and how many decimals the amount has.</value>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Encrypted, PCI compliant card data.
    /// </summary>
    /// <value>Encrypted, PCI compliant card data.</value>
    [DataMember(Name="pci_data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pci_data")]
    public string PciData { get; set; }

    /// <summary>
    /// Initialization vector for symmetric decryption with the AES key.
    /// </summary>
    /// <value>Initialization vector for symmetric decryption with the AES key.</value>
    [DataMember(Name="iv", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "iv")]
    public string Iv { get; set; }

    /// <summary>
    /// The symmetric key complying the Advanced Encryption Standard.
    /// </summary>
    /// <value>The symmetric key complying the Advanced Encryption Standard.</value>
    [DataMember(Name="aes_key", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "aes_key")]
    public string AesKey { get; set; }

    /// <summary>
    /// The brand of the card.
    /// </summary>
    /// <value>The brand of the card.</value>
    [DataMember(Name="brand", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "brand")]
    public string Brand { get; set; }

    /// <summary>
    /// Card holder name on the card.
    /// </summary>
    /// <value>Card holder name on the card.</value>
    [DataMember(Name="holder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "holder")]
    public string Holder { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Card {\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  CardId: ").Append(CardId).Append("\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
      sb.Append("  PciData: ").Append(PciData).Append("\n");
      sb.Append("  Iv: ").Append(Iv).Append("\n");
      sb.Append("  AesKey: ").Append(AesKey).Append("\n");
      sb.Append("  Brand: ").Append(Brand).Append("\n");
      sb.Append("  Holder: ").Append(Holder).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
