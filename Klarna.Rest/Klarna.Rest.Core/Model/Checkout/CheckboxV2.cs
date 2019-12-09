using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CheckboxV2 {
    /// <summary>
    /// Identifier used when presenting data back to merchant
    /// </summary>
    /// <value>Identifier used when presenting data back to merchant</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Text that will be displayed to the consumer aside the checkbox. Links and formatting can be added using Markdown. (max 255 characters)
    /// </summary>
    /// <value>Text that will be displayed to the consumer aside the checkbox. Links and formatting can be added using Markdown. (max 255 characters)</value>
    [DataMember(Name="text", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }

    /// <summary>
    /// Default state of the additional checkbox. It will use this value when loaded for the first time.
    /// </summary>
    /// <value>Default state of the additional checkbox. It will use this value when loaded for the first time.</value>
    [DataMember(Name="checked", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "checked")]
    public bool? Checked { get; set; }

    /// <summary>
    /// Whether it is required for the consumer to check the additional checkbox box or not in order to complete the purchase.
    /// </summary>
    /// <value>Whether it is required for the consumer to check the additional checkbox box or not in order to complete the purchase.</value>
    [DataMember(Name="required", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "required")]
    public bool? Required { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CheckboxV2 {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Text: ").Append(Text).Append("\n");
      sb.Append("  Checked: ").Append(Checked).Append("\n");
      sb.Append("  Required: ").Append(Required).Append("\n");
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
