using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.MerchantCardService {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PromiseCreatedResponse {
    /// <summary>
    /// Gets or Sets ExpiresAt
    /// </summary>
    [DataMember(Name="expires_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expires_at")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// The unique promise ID
    /// </summary>
    /// <value>The unique promise ID</value>
    [DataMember(Name="promise_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "promise_id")]
    public string PromiseId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PromiseCreatedResponse {\n");
      sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
      sb.Append("  PromiseId: ").Append(PromiseId).Append("\n");
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
