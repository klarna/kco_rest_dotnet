using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsOptions {
    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_border", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_border")]
    public string ColorBorder { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_border_selected", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_border_selected")]
    public string ColorBorderSelected { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_button", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_button")]
    public string ColorButton { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_button_text", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_button_text")]
    public string ColorButtonText { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_checkbox", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_checkbox")]
    public string ColorCheckbox { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_checkbox_checkmark", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_checkbox_checkmark")]
    public string ColorCheckboxCheckmark { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_details", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_details")]
    public string ColorDetails { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_header", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_header")]
    public string ColorHeader { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_link", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_link")]
    public string ColorLink { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_text", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_text")]
    public string ColorText { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_text_secondary", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_text_secondary")]
    public string ColorTextSecondary { get; set; }

    /// <summary>
    /// Border radius
    /// </summary>
    /// <value>Border radius</value>
    [DataMember(Name="radius_border", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "radius_border")]
    public string RadiusBorder { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsOptions {\n");
      sb.Append("  ColorBorder: ").Append(ColorBorder).Append("\n");
      sb.Append("  ColorBorderSelected: ").Append(ColorBorderSelected).Append("\n");
      sb.Append("  ColorButton: ").Append(ColorButton).Append("\n");
      sb.Append("  ColorButtonText: ").Append(ColorButtonText).Append("\n");
      sb.Append("  ColorCheckbox: ").Append(ColorCheckbox).Append("\n");
      sb.Append("  ColorCheckboxCheckmark: ").Append(ColorCheckboxCheckmark).Append("\n");
      sb.Append("  ColorDetails: ").Append(ColorDetails).Append("\n");
      sb.Append("  ColorHeader: ").Append(ColorHeader).Append("\n");
      sb.Append("  ColorLink: ").Append(ColorLink).Append("\n");
      sb.Append("  ColorText: ").Append(ColorText).Append("\n");
      sb.Append("  ColorTextSecondary: ").Append(ColorTextSecondary).Append("\n");
      sb.Append("  RadiusBorder: ").Append(RadiusBorder).Append("\n");
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
