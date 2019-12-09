using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Order : OrderManagementOrder {
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Order {\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  FraudStatus: ").Append(FraudStatus).Append("\n");
      sb.Append("  OrderAmount: ").Append(OrderAmount).Append("\n");
      sb.Append("  OriginalOrderAmount: ").Append(OriginalOrderAmount).Append("\n");
      sb.Append("  CapturedAmount: ").Append(CapturedAmount).Append("\n");
      sb.Append("  RefundedAmount: ").Append(RefundedAmount).Append("\n");
      sb.Append("  RemainingAuthorizedAmount: ").Append(RemainingAuthorizedAmount).Append("\n");
      sb.Append("  PurchaseCurrency: ").Append(PurchaseCurrency).Append("\n");
      sb.Append("  Locale: ").Append(Locale).Append("\n");
      sb.Append("  OrderLines: ").Append(OrderLines).Append("\n");
      sb.Append("  MerchantReference1: ").Append(MerchantReference1).Append("\n");
      sb.Append("  MerchantReference2: ").Append(MerchantReference2).Append("\n");
      sb.Append("  KlarnaReference: ").Append(KlarnaReference).Append("\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
      sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
      sb.Append("  Captures: ").Append(Captures).Append("\n");
      sb.Append("  Refunds: ").Append(Refunds).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  InitialPaymentMethod: ").Append(InitialPaymentMethod).Append("\n");
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
