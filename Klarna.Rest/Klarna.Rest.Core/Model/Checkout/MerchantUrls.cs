using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class MerchantUrls {
    /// <summary>
    /// URL of merchant terms and conditions. Should be different than checkout, confirmation and push URLs.(max 2000 characters)
    /// </summary>
    /// <value>URL of merchant terms and conditions. Should be different than checkout, confirmation and push URLs.(max 2000 characters)</value>
    [DataMember(Name="terms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "terms")]
    public string Terms { get; set; }

    /// <summary>
    /// URL of merchant cancellation terms.(max 2000 characters)
    /// </summary>
    /// <value>URL of merchant cancellation terms.(max 2000 characters)</value>
    [DataMember(Name="cancellation_terms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cancellation_terms")]
    public string CancellationTerms { get; set; }

    /// <summary>
    /// URL of merchant checkout page. Should be different than terms, confirmation and push URLs. (max 2000 characters)
    /// </summary>
    /// <value>URL of merchant checkout page. Should be different than terms, confirmation and push URLs. (max 2000 characters)</value>
    [DataMember(Name="checkout", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "checkout")]
    public string Checkout { get; set; }

    /// <summary>
    /// URL of merchant confirmation page. Should be different than checkout and confirmation URLs. (max 2000 characters)
    /// </summary>
    /// <value>URL of merchant confirmation page. Should be different than checkout and confirmation URLs. (max 2000 characters)</value>
    [DataMember(Name="confirmation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmation")]
    public string Confirmation { get; set; }

    /// <summary>
    /// URL that will be requested when an order is completed. Should be different than checkout and confirmation URLs. (max 2000 characters)
    /// </summary>
    /// <value>URL that will be requested when an order is completed. Should be different than checkout and confirmation URLs. (max 2000 characters)</value>
    [DataMember(Name="push", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "push")]
    public string Push { get; set; }

    /// <summary>
    /// URL that will be requested for final merchant validation. (must be https, max 2000 characters)
    /// </summary>
    /// <value>URL that will be requested for final merchant validation. (must be https, max 2000 characters)</value>
    [DataMember(Name="validation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "validation")]
    public string Validation { get; set; }

    /// <summary>
    /// URL for shipping option update. (must be https, max 2000 characters)
    /// </summary>
    /// <value>URL for shipping option update. (must be https, max 2000 characters)</value>
    [DataMember(Name="shipping_option_update", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_option_update")]
    public string ShippingOptionUpdate { get; set; }

    /// <summary>
    /// URL for shipping, tax and purchase currency updates. Will be called on address changes. (must be https, max 2000 characters)
    /// </summary>
    /// <value>URL for shipping, tax and purchase currency updates. Will be called on address changes. (must be https, max 2000 characters)</value>
    [DataMember(Name="address_update", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address_update")]
    public string AddressUpdate { get; set; }

    /// <summary>
    /// URL for notifications on pending orders. (max 2000 characters)
    /// </summary>
    /// <value>URL for notifications on pending orders. (max 2000 characters)</value>
    [DataMember(Name="notification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "notification")]
    public string Notification { get; set; }

    /// <summary>
    /// URL for shipping, tax and purchase currency updates. Will be called on purchase country changes. (must be https, max 2000 characters)
    /// </summary>
    /// <value>URL for shipping, tax and purchase currency updates. Will be called on purchase country changes. (must be https, max 2000 characters)</value>
    [DataMember(Name="country_change", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "country_change")]
    public string CountryChange { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MerchantUrls {\n");
      sb.Append("  Terms: ").Append(Terms).Append("\n");
      sb.Append("  CancellationTerms: ").Append(CancellationTerms).Append("\n");
      sb.Append("  Checkout: ").Append(Checkout).Append("\n");
      sb.Append("  Confirmation: ").Append(Confirmation).Append("\n");
      sb.Append("  Push: ").Append(Push).Append("\n");
      sb.Append("  Validation: ").Append(Validation).Append("\n");
      sb.Append("  ShippingOptionUpdate: ").Append(ShippingOptionUpdate).Append("\n");
      sb.Append("  AddressUpdate: ").Append(AddressUpdate).Append("\n");
      sb.Append("  Notification: ").Append(Notification).Append("\n");
      sb.Append("  CountryChange: ").Append(CountryChange).Append("\n");
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
