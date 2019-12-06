using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.MerchantCardService {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class SettlementRequest {
    /// <summary>
    /// Unique identifier for the promise associated to the settlement.
    /// </summary>
    /// <value>Unique identifier for the promise associated to the settlement.</value>
    [DataMember(Name="promise_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "promise_id")]
    public string PromiseId { get; set; }

    /// <summary>
    /// Unique identifier for the order associated to the settlement.
    /// </summary>
    /// <value>Unique identifier for the order associated to the settlement.</value>
    [DataMember(Name="order_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_id")]
    public string OrderId { get; set; }

    /// <summary>
    /// Unique identifier for the public key to be used for encryption of the card data.
    /// </summary>
    /// <value>Unique identifier for the public key to be used for encryption of the card data.</value>
    [DataMember(Name="key_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "key_id")]
    public string KeyId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SettlementRequest {\n");
      sb.Append("  PromiseId: ").Append(PromiseId).Append("\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  KeyId: ").Append(KeyId).Append("\n");
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
