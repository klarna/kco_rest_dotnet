using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentsCustomerTokenCreationRequest {
    /// <summary>
    /// Once the customer has provided any data, updates to this object will be ignored (without generating an error).
    /// </summary>
    /// <value>Once the customer has provided any data, updates to this object will be ignored (without generating an error).</value>
    [DataMember(Name="billing_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "billing_address")]
    public PaymentsAddress BillingAddress { get; set; }

    /// <summary>
    /// Information about the liable customer of the order.
    /// </summary>
    /// <value>Information about the liable customer of the order.</value>
    [DataMember(Name="customer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customer")]
    public PaymentsCustomer Customer { get; set; }

    /// <summary>
    /// Description of the purpose of the token.
    /// </summary>
    /// <value>Description of the purpose of the token.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Intended use for the token.
    /// </summary>
    /// <value>Intended use for the token.</value>
    [DataMember(Name="intended_use", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "intended_use")]
    public string IntendedUse { get; set; }

    /// <summary>
    /// RFC 1766 customer's locale.
    /// </summary>
    /// <value>RFC 1766 customer's locale.</value>
    [DataMember(Name="locale", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locale")]
    public string Locale { get; set; }

    /// <summary>
    /// ISO 3166 alpha-2 purchase country.
    /// </summary>
    /// <value>ISO 3166 alpha-2 purchase country.</value>
    [DataMember(Name="purchase_country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_country")]
    public string PurchaseCountry { get; set; }

    /// <summary>
    /// ISO 4217 purchase currency.
    /// </summary>
    /// <value>ISO 4217 purchase currency.</value>
    [DataMember(Name="purchase_currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_currency")]
    public string PurchaseCurrency { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentsCustomerTokenCreationRequest {\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  IntendedUse: ").Append(IntendedUse).Append("\n");
      sb.Append("  Locale: ").Append(Locale).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
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
