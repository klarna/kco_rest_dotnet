using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Dimensions {
    /// <summary>
    /// The product's height as used in the merchant's webshop. Non-negative. Measured in millimeters.
    /// </summary>
    /// <value>The product's height as used in the merchant's webshop. Non-negative. Measured in millimeters.</value>
    [DataMember(Name="height", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "height")]
    public long? Height { get; set; }

    /// <summary>
    /// The product's width as used in the merchant's webshop. Non-negative. Measured in millimeters.
    /// </summary>
    /// <value>The product's width as used in the merchant's webshop. Non-negative. Measured in millimeters.</value>
    [DataMember(Name="width", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "width")]
    public long? Width { get; set; }

    /// <summary>
    /// The product's length as used in the merchant's webshop. Non-negative. Measured in millimeters.
    /// </summary>
    /// <value>The product's length as used in the merchant's webshop. Non-negative. Measured in millimeters.</value>
    [DataMember(Name="length", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "length")]
    public long? Length { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Dimensions {\n");
      sb.Append("  Height: ").Append(Height).Append("\n");
      sb.Append("  Width: ").Append(Width).Append("\n");
      sb.Append("  Length: ").Append(Length).Append("\n");
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
