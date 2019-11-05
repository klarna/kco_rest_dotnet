using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class SessionCreationResponseV1 {
    /// <summary>
    /// Endpoint for link distribution
    /// </summary>
    /// <value>Endpoint for link distribution</value>
    [DataMember(Name="distribution_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "distribution_url")]
    public string DistributionUrl { get; set; }

    /// <summary>
    /// HPP url to download qr code image
    /// </summary>
    /// <value>HPP url to download qr code image</value>
    [DataMember(Name="qr_code_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "qr_code_url")]
    public string QrCodeUrl { get; set; }

    /// <summary>
    /// HPP url to redirect the consumer to
    /// </summary>
    /// <value>HPP url to redirect the consumer to</value>
    [DataMember(Name="redirect_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "redirect_url")]
    public string RedirectUrl { get; set; }

    /// <summary>
    /// HPP session id
    /// </summary>
    /// <value>HPP session id</value>
    [DataMember(Name="session_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "session_id")]
    public string SessionId { get; set; }

    /// <summary>
    /// Endpoint to read the session
    /// </summary>
    /// <value>Endpoint to read the session</value>
    [DataMember(Name="session_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "session_url")]
    public string SessionUrl { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SessionCreationResponseV1 {\n");
      sb.Append("  DistributionUrl: ").Append(DistributionUrl).Append("\n");
      sb.Append("  QrCodeUrl: ").Append(QrCodeUrl).Append("\n");
      sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
      sb.Append("  SessionId: ").Append(SessionId).Append("\n");
      sb.Append("  SessionUrl: ").Append(SessionUrl).Append("\n");
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
