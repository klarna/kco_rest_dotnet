using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.MerchantCardService {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PromiseResponse {
    /// <summary>
    /// The unique promise ID
    /// </summary>
    /// <value>The unique promise ID</value>
    [DataMember(Name="promise_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "promise_id")]
    public string PromiseId { get; set; }

    /// <summary>
    /// The order id of the promise
    /// </summary>
    /// <value>The order id of the promise</value>
    [DataMember(Name="order_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_id")]
    public string OrderId { get; set; }

    /// <summary>
    /// The list of card specifications 
    /// </summary>
    /// <value>The list of card specifications </value>
    [DataMember(Name="cards", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cards")]
    public List<CardSpecification> Cards { get; set; }

    /// <summary>
    /// The time when the promise was created
    /// </summary>
    /// <value>The time when the promise was created</value>
    [DataMember(Name="created_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The time when the promise expires
    /// </summary>
    /// <value>The time when the promise expires</value>
    [DataMember(Name="expire_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expire_at")]
    public DateTime? ExpireAt { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PromiseResponse {\n");
      sb.Append("  PromiseId: ").Append(PromiseId).Append("\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  Cards: ").Append(Cards).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  ExpireAt: ").Append(ExpireAt).Append("\n");
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
