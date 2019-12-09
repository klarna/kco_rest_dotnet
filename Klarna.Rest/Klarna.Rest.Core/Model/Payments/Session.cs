using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Payments {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Session : PaymentCreditSession{
    /// <summary>
    /// Authorization token.
    /// </summary>
    /// <value>Authorization token.</value>
    [DataMember(Name="authorization_token", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorization_token")]
    public string AuthorizationToken { get; set; }

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Session {\n");
      sb.Append("  AcquiringChannel: ").Append(AcquiringChannel).Append("\n");
      sb.Append("  Attachment: ").Append(Attachment).Append("\n");
      sb.Append("  AuthorizationToken: ").Append(AuthorizationToken).Append("\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  ClientToken: ").Append(ClientToken).Append("\n");
      sb.Append("  CustomPaymentMethodIds: ").Append(CustomPaymentMethodIds).Append("\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  Design: ").Append(Design).Append("\n");
      sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
      sb.Append("  Locale: ").Append(Locale).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  MerchantReference1: ").Append(MerchantReference1).Append("\n");
      sb.Append("  MerchantReference2: ").Append(MerchantReference2).Append("\n");
      sb.Append("  MerchantUrls: ").Append(MerchantUrls).Append("\n");
      sb.Append("  Options: ").Append(Options).Append("\n");
      sb.Append("  OrderAmount: ").Append(OrderAmount).Append("\n");
      sb.Append("  OrderLines: ").Append(OrderLines).Append("\n");
      sb.Append("  OrderTaxAmount: ").Append(OrderTaxAmount).Append("\n");
      sb.Append("  PaymentMethodCategories: ").Append(PaymentMethodCategories).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
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
