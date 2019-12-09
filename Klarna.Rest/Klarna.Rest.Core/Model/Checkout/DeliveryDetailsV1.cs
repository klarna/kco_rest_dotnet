using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class DeliveryDetailsV1 {
    /// <summary>
    /// Carrier product name
    /// </summary>
    /// <value>Carrier product name</value>
    [DataMember(Name="carrier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrier")]
    public string Carrier { get; set; }

    /// <summary>
    /// Type of shipping class
    /// </summary>
    /// <value>Type of shipping class</value>
    [DataMember(Name="class", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "class")]
    public string Class { get; set; }

    /// <summary>
    /// Upstream carrier product
    /// </summary>
    /// <value>Upstream carrier product</value>
    [DataMember(Name="product", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "product")]
    public ProductV1 Product { get; set; }

    /// <summary>
    /// The selected location for this shipping option
    /// </summary>
    /// <value>The selected location for this shipping option</value>
    [DataMember(Name="pickup_location", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pickup_location")]
    public PickupLocationV1 PickupLocation { get; set; }

    /// <summary>
    /// The selected timeslot for this shipping option
    /// </summary>
    /// <value>The selected timeslot for this shipping option</value>
    [DataMember(Name="timeslot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "timeslot")]
    public TimeslotV1 Timeslot { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DeliveryDetailsV1 {\n");
      sb.Append("  Carrier: ").Append(Carrier).Append("\n");
      sb.Append("  Class: ").Append(Class).Append("\n");
      sb.Append("  Product: ").Append(Product).Append("\n");
      sb.Append("  PickupLocation: ").Append(PickupLocation).Append("\n");
      sb.Append("  Timeslot: ").Append(Timeslot).Append("\n");
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
