using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class MerchantAggregatedOrderV2 {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets TermsUri
    /// </summary>
    [DataMember(Name="terms_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "terms_uri")]
    public string TermsUri { get; set; }

    /// <summary>
    /// Gets or Sets CheckoutUri
    /// </summary>
    [DataMember(Name="checkout_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "checkout_uri")]
    public string CheckoutUri { get; set; }

    /// <summary>
    /// Gets or Sets ConfirmationUri
    /// </summary>
    [DataMember(Name="confirmation_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmation_uri")]
    public string ConfirmationUri { get; set; }

    /// <summary>
    /// Gets or Sets PushUri
    /// </summary>
    [DataMember(Name="push_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "push_uri")]
    public string PushUri { get; set; }

    /// <summary>
    /// Gets or Sets ValidationUri
    /// </summary>
    [DataMember(Name="validation_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "validation_uri")]
    public string ValidationUri { get; set; }

    /// <summary>
    /// Gets or Sets BackToStoreUri
    /// </summary>
    [DataMember(Name="back_to_store_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "back_to_store_uri")]
    public string BackToStoreUri { get; set; }

    /// <summary>
    /// Gets or Sets CancellationTermsUri
    /// </summary>
    [DataMember(Name="cancellation_terms_uri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cancellation_terms_uri")]
    public string CancellationTermsUri { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MerchantAggregatedOrderV2 {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  TermsUri: ").Append(TermsUri).Append("\n");
      sb.Append("  CheckoutUri: ").Append(CheckoutUri).Append("\n");
      sb.Append("  ConfirmationUri: ").Append(ConfirmationUri).Append("\n");
      sb.Append("  PushUri: ").Append(PushUri).Append("\n");
      sb.Append("  ValidationUri: ").Append(ValidationUri).Append("\n");
      sb.Append("  BackToStoreUri: ").Append(BackToStoreUri).Append("\n");
      sb.Append("  CancellationTermsUri: ").Append(CancellationTermsUri).Append("\n");
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
