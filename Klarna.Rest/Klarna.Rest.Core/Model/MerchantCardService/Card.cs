using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.MerchantCardService {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Card: VirtualCardCard {
    /// <summary>
    /// Initialization vector for symmetric decryption with the AES key.
    /// </summary>
    /// <value>Initialization vector for symmetric decryption with the AES key.</value>
    [DataMember(Name="iv", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "iv")]
    public string Iv { get; set; }

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
