using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Settlements {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Transaction: Model.Transaction {
    /// <summary>
    /// VAT (Value added tax) rate on Klarna fees
    /// </summary>
    /// <value>VAT (Value added tax) rate on Klarna fees</value>
    [DataMember(Name="vat_rate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vat_rate")]
    public int? VatRate { get; set; }

    /// <summary>
    /// VAT (Value added tax) amount on Klarna fees, in minor units
    /// </summary>
    /// <value>VAT (Value added tax) amount on Klarna fees, in minor units</value>
    [DataMember(Name="vat_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vat_amount")]
    public int? VatAmount { get; set; }

    /// <summary>
    /// ISO Alpha-2 Country Code
    /// </summary>
    /// <value>ISO Alpha-2 Country Code</value>
    [DataMember(Name="shipping_country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_country")]
    public string ShippingCountry { get; set; }

    /// <summary>
    /// Payment method the consumer chose during checkout
    /// </summary>
    /// <value>Payment method the consumer chose during checkout</value>
    [DataMember(Name="initial_payment_method_type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "initial_payment_method_type")]
    public string InitialPaymentMethodType { get; set; }

    /// <summary>
    /// Number of installments the consumer chose during checkout in case of installment payments
    /// </summary>
    /// <value>Number of installments the consumer chose during checkout in case of installment payments</value>
    [DataMember(Name="initial_number_of_installments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "initial_number_of_installments")]
    public int? InitialNumberOfInstallments { get; set; }

    /// <summary>
    /// Your internal reference to the capture, that has been submitted during capturing an order via API
    /// </summary>
    /// <value>Your internal reference to the capture, that has been submitted during capturing an order via API</value>
    [DataMember(Name="merchant_capture_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_capture_reference")]
    public string MerchantCaptureReference { get; set; }

    /// <summary>
    /// Your internal reference to the refund, that has been submitted during refunding an order via API
    /// </summary>
    /// <value>Your internal reference to the refund, that has been submitted during refunding an order via API</value>
    [DataMember(Name="merchant_refund_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_refund_reference")]
    public string MerchantRefundReference { get; set; }

    /// <summary>
    /// Detailed description of the transaction type
    /// </summary>
    /// <value>Detailed description of the transaction type</value>
    [DataMember(Name="detailed_type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "detailed_type")]
    public string DetailedType { get; set; }

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Transaction {\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  CaptureId: ").Append(CaptureId).Append("\n");
      sb.Append("  MerchantReference1: ").Append(MerchantReference1).Append("\n");
      sb.Append("  SaleDate: ").Append(SaleDate).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  CaptureDate: ").Append(CaptureDate).Append("\n");
      sb.Append("  PaymentReference: ").Append(PaymentReference).Append("\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  Payout: ").Append(Payout).Append("\n");
      sb.Append("  RefundId: ").Append(RefundId).Append("\n");
      sb.Append("  ShortOrderId: ").Append(ShortOrderId).Append("\n");
      sb.Append("  MerchantReference2: ").Append(MerchantReference2).Append("\n");
      sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
      sb.Append("  PurchaseCountry: ").Append(PurchaseCountry).Append("\n");
      sb.Append("  VatRate: ").Append(VatRate).Append("\n");
      sb.Append("  VatAmount: ").Append(VatAmount).Append("\n");
      sb.Append("  ShippingCountry: ").Append(ShippingCountry).Append("\n");
      sb.Append("  InitialPaymentMethodType: ").Append(InitialPaymentMethodType).Append("\n");
      sb.Append("  InitialNumberOfInstallments: ").Append(InitialNumberOfInstallments).Append("\n");
      sb.Append("  MerchantCaptureReference: ").Append(MerchantCaptureReference).Append("\n");
      sb.Append("  MerchantRefundReference: ").Append(MerchantRefundReference).Append("\n");
      sb.Append("  DetailedType: ").Append(DetailedType).Append("\n");
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
