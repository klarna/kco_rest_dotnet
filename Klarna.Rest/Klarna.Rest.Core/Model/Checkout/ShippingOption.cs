using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ShippingOption {
    /// <summary>
    /// id
    /// </summary>
    /// <value>id</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    /// <value>Name.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    /// <value>Description.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Promotion name. To be used if this shipping option is promotional.
    /// </summary>
    /// <value>Promotion name. To be used if this shipping option is promotional.</value>
    [DataMember(Name="promo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "promo")]
    public string Promo { get; set; }

    /// <summary>
    /// Price including tax.
    /// </summary>
    /// <value>Price including tax.</value>
    [DataMember(Name="price", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "price")]
    public long? Price { get; set; }

    /// <summary>
    /// Tax amount.
    /// </summary>
    /// <value>Tax amount.</value>
    [DataMember(Name="tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tax_amount")]
    public long? TaxAmount { get; set; }

    /// <summary>
    /// Non-negative. In percent, two implicit decimals. I.e 2500 = 25%.
    /// </summary>
    /// <value>Non-negative. In percent, two implicit decimals. I.e 2500 = 25%.</value>
    [DataMember(Name="tax_rate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tax_rate")]
    public long? TaxRate { get; set; }

    /// <summary>
    /// If true, this option will be preselected when checkout loads. Default: false
    /// </summary>
    /// <value>If true, this option will be preselected when checkout loads. Default: false</value>
    [DataMember(Name="preselected", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "preselected")]
    public bool? Preselected { get; set; }

    /// <summary>
    /// Shipping method. Possible values:<ul><li>PickUpStore</li><li>Home</li><li>BoxReg</li><li>BoxUnreg</li><li>PickUpPoint</li><li>Own</li><li>Postal</li><li>DHLPackstation</li><li>Digital</li></ul> If DHLPackstation is selected the correct form will be displayed.
    /// </summary>
    /// <value>Shipping method. Possible values:<ul><li>PickUpStore</li><li>Home</li><li>BoxReg</li><li>BoxUnreg</li><li>PickUpPoint</li><li>Own</li><li>Postal</li><li>DHLPackstation</li><li>Digital</li></ul> If DHLPackstation is selected the correct form will be displayed.</value>
    [DataMember(Name="shipping_method", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_method")]
    public string ShippingMethod { get; set; }

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
