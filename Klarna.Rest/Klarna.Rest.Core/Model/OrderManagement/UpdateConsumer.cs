using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class UpdateConsumer {
    /// <summary>
    /// Customer shipping address.
    /// </summary>
    /// <value>Customer shipping address.</value>
    [DataMember(Name="shipping_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_address")]
    public Address ShippingAddress { get; set; }

    /// <summary>
    /// Customer billing address.
    /// </summary>
    /// <value>Customer billing address.</value>
    [DataMember(Name="billing_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "billing_address")]
    public Address BillingAddress { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateConsumer {\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
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
