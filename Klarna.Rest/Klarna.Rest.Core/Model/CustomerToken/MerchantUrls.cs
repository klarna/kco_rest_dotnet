using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.CustomerToken {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class MerchantUrls {
    /// <summary>
    /// URL of merchant confirmation page. (max 2000 characters)
    /// </summary>
    /// <value>URL of merchant confirmation page. (max 2000 characters)</value>
    [DataMember(Name="confirmation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmation")]
    public string Confirmation { get; set; }

    /// <summary>
    /// URL that will be requested when an order is completed. Should be different than checkout and confirmation URLs. (max 2000 characters)
    /// </summary>
    /// <value>URL that will be requested when an order is completed. Should be different than checkout and confirmation URLs. (max 2000 characters)</value>
    [DataMember(Name="push", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "push")]
    public string Push { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MerchantUrls {\n");
      sb.Append("  Confirmation: ").Append(Confirmation).Append("\n");
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
