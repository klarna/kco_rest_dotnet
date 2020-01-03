using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using LegacyModels = Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ShippingOption: LegacyModels.ShippingOption {
    /// <summary>
    /// The delivery details for this shipping option
    /// </summary>
    /// <value>The delivery details for this shipping option</value>
    [DataMember(Name="delivery_details", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "delivery_details")]
    public DeliveryDetailsV1 DeliveryDetails { get; set; }

    /// <summary>
    /// TMS reference. Required to map completed orders to shipments reserved in TMS.
    /// </summary>
    /// <value>TMS reference. Required to map completed orders to shipments reserved in TMS.</value>
    [DataMember(Name="tms_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tms_reference")]
    public string TmsReference { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingOption {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Promo: ").Append(Promo).Append("\n");
      sb.Append("  Price: ").Append(Price).Append("\n");
      sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
      sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
      sb.Append("  Preselected: ").Append(Preselected).Append("\n");
      sb.Append("  ShippingMethod: ").Append(ShippingMethod).Append("\n");
      sb.Append("  DeliveryDetails: ").Append(DeliveryDetails).Append("\n");
      sb.Append("  TmsReference: ").Append(TmsReference).Append("\n");
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
