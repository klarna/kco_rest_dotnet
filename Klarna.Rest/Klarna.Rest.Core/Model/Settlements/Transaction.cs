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
  public class Transaction {
    /// <summary>
    /// Total amount of the specific transaction, in minor units
    /// </summary>
    /// <value>Total amount of the specific transaction, in minor units</value>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public long? Amount { get; set; }

    /// <summary>
    /// The Klarna assigned id reference of a specific capture
    /// </summary>
    /// <value>The Klarna assigned id reference of a specific capture</value>
    [DataMember(Name="capture_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "capture_id")]
    public Guid? CaptureId { get; set; }

    /// <summary>
    /// Merchant assigned reference, typically a reference to an order management system id
    /// </summary>
    /// <value>Merchant assigned reference, typically a reference to an order management system id</value>
    [DataMember(Name="merchant_reference1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference1")]
    public string MerchantReference1 { get; set; }

    /// <summary>
    /// ISO-8601 formatted date-time string
    /// </summary>
    /// <value>ISO-8601 formatted date-time string</value>
    [DataMember(Name="sale_date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sale_date")]
    public DateTime? SaleDate { get; set; }

    /// <summary>
    /// The type of transaction.
    /// </summary>
    /// <value>The type of transaction.</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// ISO-8601 formatted date-time string
    /// </summary>
    /// <value>ISO-8601 formatted date-time string</value>
    [DataMember(Name="capture_date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "capture_date")]
    public DateTime? CaptureDate { get; set; }

    /// <summary>
    /// Reference to the specific payout the transaction is part of, if available.
    /// </summary>
    /// <value>Reference to the specific payout the transaction is part of, if available.</value>
    [DataMember(Name="payment_reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment_reference")]
    public string PaymentReference { get; set; }

    /// <summary>
    /// The Klarna assigned order id reference
    /// </summary>
    /// <value>The Klarna assigned order id reference</value>
    [DataMember(Name="order_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "order_id")]
    public Guid? OrderId { get; set; }

    /// <summary>
    /// Link to the payout that this transaction is part of
    /// </summary>
    /// <value>Link to the payout that this transaction is part of</value>
    [DataMember(Name="payout", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payout")]
    public string Payout { get; set; }

    /// <summary>
    /// The Klarna assigned id reference of a specific refund
    /// </summary>
    /// <value>The Klarna assigned id reference of a specific refund</value>
    [DataMember(Name="refund_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "refund_id")]
    public Guid? RefundId { get; set; }

    /// <summary>
    /// The Klarna assigned short order id reference
    /// </summary>
    /// <value>The Klarna assigned short order id reference</value>
    [DataMember(Name="short_order_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "short_order_id")]
    public string ShortOrderId { get; set; }

    /// <summary>
    /// Merchant assigned reference, typically a reference to an order management system id
    /// </summary>
    /// <value>Merchant assigned reference, typically a reference to an order management system id</value>
    [DataMember(Name="merchant_reference2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merchant_reference2")]
    public string MerchantReference2 { get; set; }

    /// <summary>
    /// ISO-3166 Currency Code.
    /// </summary>
    /// <value>ISO-3166 Currency Code.</value>
    [DataMember(Name="currency_code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency_code")]
    public string CurrencyCode { get; set; }

    /// <summary>
    /// ISO Alpha-2 Country Code
    /// </summary>
    /// <value>ISO Alpha-2 Country Code</value>
    [DataMember(Name="purchase_country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchase_country")]
    public string PurchaseCountry { get; set; }

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
