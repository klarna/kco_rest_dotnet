using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Options : PaymentOptions {
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Options {\n");
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
