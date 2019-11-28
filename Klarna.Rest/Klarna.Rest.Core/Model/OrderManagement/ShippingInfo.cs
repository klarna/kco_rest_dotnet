using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ShippingInfo {
    /// <summary>
    /// Name of the shipping company (as specific as possible). Maximum 100 characters. Example: 'DHL US' and not only 'DHL'
    /// </summary>
    /// <value>Name of the shipping company (as specific as possible). Maximum 100 characters. Example: 'DHL US' and not only 'DHL'</value>
    [DataMember(Name="shipping_company", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_company")]
    public string ShippingCompany { get; set; }

    /// <summary>
    /// Shipping method. Allowed values matches (PickUpStore|Home|BoxReg|BoxUnreg|PickUpPoint|Own)
    /// </summary>
    /// <value>Shipping method. Allowed values matches (PickUpStore|Home|BoxReg|BoxUnreg|PickUpPoint|Own)</value>
    [DataMember(Name="shipping_method", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_method")]
    public string ShippingMethod { get; set; }

    /// <summary>
    /// Tracking number for the shipment. Maximum 100 characters.
    /// </summary>
    /// <value>Tracking number for the shipment. Maximum 100 characters.</value>
    [DataMember(Name="tracking_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tracking_number")]
    public string TrackingNumber { get; set; }

    /// <summary>
    /// URI where the customer can track their shipment. Maximum 1024 characters.
    /// </summary>
    /// <value>URI where the customer can track their shipment. Maximum 1024 characters.</value>
    [DataMember(Name="tracking_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tracking_uri")]
    public string TrackingUri { get; set; }

    /// <summary>
    /// Name of the shipping company for the return shipment (as specific as possible). Maximum 100 characters. Example: 'DHL US' and not only 'DHL'
    /// </summary>
    /// <value>Name of the shipping company for the return shipment (as specific as possible). Maximum 100 characters. Example: 'DHL US' and not only 'DHL'</value>
    [DataMember(Name="return_shipping_company", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "return_shipping_company")]
    public string ReturnShippingCompany { get; set; }

    /// <summary>
    /// Tracking number for the return shipment. Maximum 100 characters.
    /// </summary>
    /// <value>Tracking number for the return shipment. Maximum 100 characters.</value>
    [DataMember(Name="return_tracking_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "return_tracking_number")]
    public string ReturnTrackingNumber { get; set; }

    /// <summary>
    /// URL where the customer can track the return shipment. Maximum 1024 characters.
    /// </summary>
    /// <value>URL where the customer can track the return shipment. Maximum 1024 characters.</value>
    [DataMember(Name="return_tracking_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "return_tracking_uri")]
    public string ReturnTrackingUri { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingInfo {\n");
      sb.Append("  ShippingCompany: ").Append(ShippingCompany).Append("\n");
      sb.Append("  ShippingMethod: ").Append(ShippingMethod).Append("\n");
      sb.Append("  TrackingNumber: ").Append(TrackingNumber).Append("\n");
      sb.Append("  TrackingUri: ").Append(TrackingUri).Append("\n");
      sb.Append("  ReturnShippingCompany: ").Append(ReturnShippingCompany).Append("\n");
      sb.Append("  ReturnTrackingNumber: ").Append(ReturnTrackingNumber).Append("\n");
      sb.Append("  ReturnTrackingUri: ").Append(ReturnTrackingUri).Append("\n");
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
