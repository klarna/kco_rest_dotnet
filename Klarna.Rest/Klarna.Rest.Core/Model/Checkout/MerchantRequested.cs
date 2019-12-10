using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class MerchantRequested {
    /// <summary>
    /// Informs whether the additional_checkbox is checked or not, when applicable.
    /// </summary>
    /// <value>Informs whether the additional_checkbox is checked or not, when applicable.</value>
    [DataMember(Name="additional_checkbox", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additional_checkbox")]
    public bool? AdditionalCheckbox { get; set; }

    /// <summary>
    /// Informs whether the additional_checkboxes is checked or not, when applicable.
    /// </summary>
    /// <value>Informs whether the additional_checkboxes is checked or not, when applicable.</value>
    [DataMember(Name="additional_checkboxes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additional_checkboxes")]
    public List<MerchantRequestedCheckbox> AdditionalCheckboxes { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MerchantRequested {\n");
      sb.Append("  AdditionalCheckbox: ").Append(AdditionalCheckbox).Append("\n");
      sb.Append("  AdditionalCheckboxes: ").Append(AdditionalCheckboxes).Append("\n");
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
