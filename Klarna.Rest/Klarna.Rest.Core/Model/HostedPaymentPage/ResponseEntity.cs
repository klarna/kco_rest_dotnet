using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ResponseEntity {
    /// <summary>
    /// Gets or Sets Body
    /// </summary>
    [DataMember(Name="body", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "body")]
    public Object Body { get; set; }

    /// <summary>
    /// Gets or Sets StatusCode
    /// </summary>
    [DataMember(Name="status_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status_code")]
    public string StatusCode { get; set; }

    /// <summary>
    /// Gets or Sets StatusCodeValue
    /// </summary>
    [DataMember(Name="status_code_value", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status_code_value")]
    public int? StatusCodeValue { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseEntity {\n");
      sb.Append("  Body: ").Append(Body).Append("\n");
      sb.Append("  StatusCode: ").Append(StatusCode).Append("\n");
      sb.Append("  StatusCodeValue: ").Append(StatusCodeValue).Append("\n");
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
