using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsMerchantUrls {
    /// <summary>
    /// URL of merchant confirmation page. Insert {session.id} and/or {order.id} as placeholder to connect either of those IDs to the URL (max 2000 characters).
    /// </summary>
    /// <value>URL of merchant confirmation page. Insert {session.id} and/or {order.id} as placeholder to connect either of those IDs to the URL (max 2000 characters).</value>
    [DataMember(Name="confirmation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmation")]
    public string Confirmation { get; set; }

    /// <summary>
    /// URL for notifications on pending orders. Insert {session.id} and/or {order.id} as placeholder to connect either of those IDs to the URL (max 2000 characters).
    /// </summary>
    /// <value>URL for notifications on pending orders. Insert {session.id} and/or {order.id} as placeholder to connect either of those IDs to the URL (max 2000 characters).</value>
    [DataMember(Name="notification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "notification")]
    public string Notification { get; set; }

    /// <summary>
    /// URL that will be requested when an order is completed. Should be different than checkout and confirmation URLs. Insert {session.id} and/or {order.id} as placeholder to connect either of those IDs to the URL (max 2000 characters).
    /// </summary>
    /// <value>URL that will be requested when an order is completed. Should be different than checkout and confirmation URLs. Insert {session.id} and/or {order.id} as placeholder to connect either of those IDs to the URL (max 2000 characters).</value>
    [DataMember(Name="push", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "push")]
    public string Push { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsMerchantUrls {\n");
      sb.Append("  Confirmation: ").Append(Confirmation).Append("\n");
      sb.Append("  Notification: ").Append(Notification).Append("\n");
      sb.Append("  Push: ").Append(Push).Append("\n");
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
