using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class NotAllowedErrorMessage {
    /// <summary>
    /// Error code
    /// </summary>
    /// <value>Error code</value>
    [DataMember(Name="error_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "error_code")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// Error messages
    /// </summary>
    /// <value>Error messages</value>
    [DataMember(Name="error_messages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "error_messages")]
    public List<string> ErrorMessages { get; set; }

    /// <summary>
    /// Correlation id. For searching logs.
    /// </summary>
    /// <value>Correlation id. For searching logs.</value>
    [DataMember(Name="correlation_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "correlation_id")]
    public string CorrelationId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class NotAllowedErrorMessage {\n");
      sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
      sb.Append("  ErrorMessages: ").Append(ErrorMessages).Append("\n");
      sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
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
