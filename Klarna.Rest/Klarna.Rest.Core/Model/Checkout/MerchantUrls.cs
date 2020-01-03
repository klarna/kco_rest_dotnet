using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class MerchantUrls: CheckoutMerchantUrls {
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
