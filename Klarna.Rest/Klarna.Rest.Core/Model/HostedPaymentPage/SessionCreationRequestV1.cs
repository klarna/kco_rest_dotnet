using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.HostedPaymentPage {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class SessionCreationRequestV1 {
    /// <summary>
    /// URLs used to redirect the Consumer
    /// </summary>
    /// <value>URLs used to redirect the Consumer</value>
    [DataMember(Name="merchant_urls", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_urls")]
    public MerchantUrlsV1 MerchantUrls { get; set; }

    /// <summary>
    /// Options
    /// </summary>
    /// <value>Options</value>
    [DataMember(Name="options", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "options")]
    public OptionsV1 Options { get; set; }

    /// <summary>
    /// URL of the KP Session or KCO Order to be hosted by the HPP Session
    /// </summary>
    /// <value>URL of the KP Session or KCO Order to be hosted by the HPP Session</value>
    [DataMember(Name="payment_session_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_session_url")]
    public string PaymentSessionUrl { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SessionCreationRequestV1 {\n");
      sb.Append("  MerchantUrls: ").Append(MerchantUrls).Append("\n");
      sb.Append("  Options: ").Append(Options).Append("\n");
      sb.Append("  PaymentSessionUrl: ").Append(PaymentSessionUrl).Append("\n");
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
