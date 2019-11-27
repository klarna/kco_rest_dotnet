using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsPaymentMethodCategory {
    /// <summary>
    /// Asset URLs
    /// </summary>
    /// <value>Asset URLs</value>
    [DataMember(Name="asset_urls", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "asset_urls")]
    public PaymentsAssetUrls AssetUrls { get; set; }

    /// <summary>
    /// Id for the category
    /// </summary>
    /// <value>Id for the category</value>
    [DataMember(Name="identifier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "identifier")]
    public string Identifier { get; set; }

    /// <summary>
    /// Name of the category
    /// </summary>
    /// <value>Name of the category</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsPaymentMethodCategory {\n");
      sb.Append("  AssetUrls: ").Append(AssetUrls).Append("\n");
      sb.Append("  Identifier: ").Append(Identifier).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
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
