using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsErrorV2 {
    /// <summary>
    /// Gets or Sets AuthorizedPaymentMethod
    /// </summary>
    [DataMember(Name="authorized_payment_method", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorized_payment_method")]
    public PaymentsAuthorizedPaymentMethod AuthorizedPaymentMethod { get; set; }

    /// <summary>
    /// Gets or Sets CorrelationId
    /// </summary>
    [DataMember(Name="correlation_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "correlation_id")]
    public string CorrelationId { get; set; }

    /// <summary>
    /// Gets or Sets ErrorCode
    /// </summary>
    [DataMember(Name="error_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "error_code")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// Gets or Sets ErrorMessages
    /// </summary>
    [DataMember(Name="error_messages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "error_messages")]
    public List<string> ErrorMessages { get; set; }

    /// <summary>
    /// Gets or Sets FraudStatus
    /// </summary>
    [DataMember(Name="fraud_status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fraud_status")]
    public string FraudStatus { get; set; }

    /// <summary>
    /// Gets or Sets Reason
    /// </summary>
    [DataMember(Name="reason", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reason")]
    public string Reason { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsErrorV2 {\n");
      sb.Append("  AuthorizedPaymentMethod: ").Append(AuthorizedPaymentMethod).Append("\n");
      sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
      sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
      sb.Append("  ErrorMessages: ").Append(ErrorMessages).Append("\n");
      sb.Append("  FraudStatus: ").Append(FraudStatus).Append("\n");
      sb.Append("  Reason: ").Append(Reason).Append("\n");
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
