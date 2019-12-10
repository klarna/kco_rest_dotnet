using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.MerchantCardService {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PromiseRequest {
    /// <summary>
    /// A valid order id
    /// </summary>
    /// <value>A valid order id</value>
    [DataMember(Name="order_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_id")]
    public string OrderId { get; set; }

    /// <summary>
    /// The cards you would like to issue (max 1000)
    /// </summary>
    /// <value>The cards you would like to issue (max 1000)</value>
    [DataMember(Name="cards", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cards")]
    public List<CardSpecification> Cards { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PromiseRequest {\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  Cards: ").Append(Cards).Append("\n");
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
