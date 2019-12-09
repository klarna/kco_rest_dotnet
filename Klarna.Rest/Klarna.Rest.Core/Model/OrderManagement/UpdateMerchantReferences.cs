using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class UpdateMerchantReferences {
    /// <summary>
    /// New merchant reference 1. Old reference will be overwritten if this field is present.
    /// </summary>
    /// <value>New merchant reference 1. Old reference will be overwritten if this field is present.</value>
    [DataMember(Name="merchant_reference1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference1")]
    public string MerchantReference1 { get; set; }

    /// <summary>
    /// New merchant reference 2. Old reference will be overwritten if this field is present.
    /// </summary>
    /// <value>New merchant reference 2. Old reference will be overwritten if this field is present.</value>
    [DataMember(Name="merchant_reference2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference2")]
    public string MerchantReference2 { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateMerchantReferences {\n");
      sb.Append("  MerchantReference1: ").Append(MerchantReference1).Append("\n");
      sb.Append("  MerchantReference2: ").Append(MerchantReference2).Append("\n");
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
