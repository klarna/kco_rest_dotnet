using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsMerchantSession {
    /// <summary>
    /// Token to be passed to the JS client
    /// </summary>
    /// <value>Token to be passed to the JS client</value>
    [DataMember(Name="client_token", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "client_token")]
    public string ClientToken { get; set; }

    /// <summary>
    /// Available payment method categories
    /// </summary>
    /// <value>Available payment method categories</value>
    [DataMember(Name="payment_method_categories", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_method_categories")]
    public List<PaymentsPaymentMethodCategory> PaymentMethodCategories { get; set; }

    /// <summary>
    /// Id of the created session
    /// </summary>
    /// <value>Id of the created session</value>
    [DataMember(Name="session_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "session_id")]
    public string SessionId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsMerchantSession {\n");
      sb.Append("  ClientToken: ").Append(ClientToken).Append("\n");
      sb.Append("  PaymentMethodCategories: ").Append(PaymentMethodCategories).Append("\n");
      sb.Append("  SessionId: ").Append(SessionId).Append("\n");
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
