using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class MerchantUrlsV1: HostedPaymentPageMerchantUrls {
    /// <summary>
    /// Back URL
    /// </summary>
    /// <value>Back URL</value>
    [DataMember(Name="back", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "back")]
    public string Back { get; set; }

    /// <summary>
    /// System error URL
    /// </summary>
    /// <value>System error URL</value>
    [DataMember(Name="error", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "error")]
    public string Error { get; set; }

    /// <summary>
    /// Status update URL
    /// </summary>
    /// <value>Status update URL</value>
    [DataMember(Name="status_update", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status_update")]
    public string StatusUpdate { get; set; }

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MerchantUrlsV1 {\n");
      sb.Append("  Back: ").Append(Back).Append("\n");
      sb.Append("  Cancel: ").Append(Cancel).Append("\n");
      sb.Append("  Error: ").Append(Error).Append("\n");
      sb.Append("  Failure: ").Append(Failure).Append("\n");
      sb.Append("  PrivacyPolicy: ").Append(PrivacyPolicy).Append("\n");
      sb.Append("  StatusUpdate: ").Append(StatusUpdate).Append("\n");
      sb.Append("  Success: ").Append(Success).Append("\n");
      sb.Append("  Terms: ").Append(Terms).Append("\n");
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
