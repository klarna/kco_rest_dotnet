using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentProvider {
    /// <summary>
    /// The name of the payment provider. (max 255 characters)
    /// </summary>
    /// <value>The name of the payment provider. (max 255 characters)</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// URL to redirect to. (must be https, min 7, max 2000 characters)
    /// </summary>
    /// <value>URL to redirect to. (must be https, min 7, max 2000 characters)</value>
    [DataMember(Name="redirect_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "redirect_url")]
    public string RedirectUrl { get; set; }

    /// <summary>
    /// URL to an image to display. (must be https, max 2000 characters)
    /// </summary>
    /// <value>URL to an image to display. (must be https, max 2000 characters)</value>
    [DataMember(Name="image_url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "image_url")]
    public string ImageUrl { get; set; }

    /// <summary>
    /// Minor units. Includes tax.
    /// </summary>
    /// <value>Minor units. Includes tax.</value>
    [DataMember(Name="fee", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fee")]
    public long? Fee { get; set; }

    /// <summary>
    /// Description. (max 500 characters)
    /// </summary>
    /// <value>Description. (max 500 characters)</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// If specified, limits the method to the listed countries (alpha 2 codes).
    /// </summary>
    /// <value>If specified, limits the method to the listed countries (alpha 2 codes).</value>
    [DataMember(Name="countries", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countries")]
    public List<string> Countries { get; set; }

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
