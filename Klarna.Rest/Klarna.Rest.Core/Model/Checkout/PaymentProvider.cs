using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using LegacyModels = Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentProvider: LegacyModels.PaymentProvider {
    /// <summary>
    /// Controls label of buy button<ul><li>continue</li><li>complete</li></ul>
    /// </summary>
    /// <value>Controls label of buy button<ul><li>continue</li><li>complete</li></ul></value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentProvider {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
      sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
      sb.Append("  Fee: ").Append(Fee).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Countries: ").Append(Countries).Append("\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
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
