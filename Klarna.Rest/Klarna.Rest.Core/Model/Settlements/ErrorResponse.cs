using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Settlements {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ErrorResponse {
    /// <summary>
    /// ERROR_CODE
    /// </summary>
    /// <value>ERROR_CODE</value>
    [DataMember(Name="error_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "error_code")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// Array of error messages
    /// </summary>
    /// <value>Array of error messages</value>
    [DataMember(Name="error_messages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "error_messages")]
    public List<string> ErrorMessages { get; set; }

    /// <summary>
    /// Unique id for this request used for troubleshooting.
    /// </summary>
    /// <value>Unique id for this request used for troubleshooting.</value>
    [DataMember(Name="correlation_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "correlation_id")]
    public string CorrelationId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ErrorResponse {\n");
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
