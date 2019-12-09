using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ShippingAttributes {
    /// <summary>
    /// The product's weight as used in the merchant's webshop. Non-negative. Measured in grams.
    /// </summary>
    /// <value>The product's weight as used in the merchant's webshop. Non-negative. Measured in grams.</value>
    [DataMember(Name="weight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "weight")]
    public long? Weight { get; set; }

    /// <summary>
    /// The product's dimensions: height, width and length. Of type Long.
    /// </summary>
    /// <value>The product's dimensions: height, width and length. Of type Long.</value>
    [DataMember(Name="dimensions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensions")]
    public Dimensions Dimensions { get; set; }

    /// <summary>
    /// The product's extra features
    /// </summary>
    /// <value>The product's extra features</value>
    [DataMember(Name="tags", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tags")]
    public List<string> Tags { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingAttributes {\n");
      sb.Append("  Weight: ").Append(Weight).Append("\n");
      sb.Append("  Dimensions: ").Append(Dimensions).Append("\n");
      sb.Append("  Tags: ").Append(Tags).Append("\n");
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
