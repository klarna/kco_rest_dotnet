using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Options : CheckoutOptions {
    /// <summary>
    /// If true, the consumer can not skip phone (in countries were this usually is possible). Only available for orders for DACH countries.
    /// </summary>
    /// <value>If true, the consumer can not skip phone (in countries were this usually is possible). Only available for orders for DACH countries.</value>
    [DataMember(Name="phone_mandatory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phone_mandatory")]
    public bool? PhoneMandatory { get; set; }

    /// <summary>
    /// If true, VAT is not included in total price
    /// </summary>
    /// <value>If true, VAT is not included in total price</value>
    [DataMember(Name="vat_removed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vat_removed")]
    public bool? VatRemoved { get; set; }

    /// <summary>
    /// Enable verification of National Identification Numbers in Sweden and Norway.This option also make the national identification number mandatory 
    /// </summary>
    /// <value>Enable verification of National Identification Numbers in Sweden and Norway.This option also make the national identification number mandatory </value>
    [DataMember(Name="verify_national_identification_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "verify_national_identification_number")]
    public bool? VerifyNationalIdentificationNumber { get; set; }

    /// <summary>
    /// If true, a optional VAT registration number field will be shown in the address form. Only applies for b2b orders.
    /// </summary>
    /// <value>If true, a optional VAT registration number field will be shown in the address form. Only applies for b2b orders.</value>
    [DataMember(Name="show_vat_registration_number_field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "show_vat_registration_number_field")]
    public bool? ShowVatRegistrationNumberField { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Options {\n");
      sb.Append("  AcquiringChannel: ").Append(AcquiringChannel).Append("\n");
      sb.Append("  AllowSeparateShippingAddress: ").Append(AllowSeparateShippingAddress).Append("\n");
      sb.Append("  ColorButton: ").Append(ColorButton).Append("\n");
      sb.Append("  ColorButtonText: ").Append(ColorButtonText).Append("\n");
      sb.Append("  ColorCheckbox: ").Append(ColorCheckbox).Append("\n");
      sb.Append("  ColorCheckboxCheckmark: ").Append(ColorCheckboxCheckmark).Append("\n");
      sb.Append("  ColorHeader: ").Append(ColorHeader).Append("\n");
      sb.Append("  ColorLink: ").Append(ColorLink).Append("\n");
      sb.Append("  DateOfBirthMandatory: ").Append(DateOfBirthMandatory).Append("\n");
      sb.Append("  ShippingDetails: ").Append(ShippingDetails).Append("\n");
      sb.Append("  TitleMandatory: ").Append(TitleMandatory).Append("\n");
      sb.Append("  AdditionalCheckbox: ").Append(AdditionalCheckbox).Append("\n");
      sb.Append("  NationalIdentificationNumberMandatory: ").Append(NationalIdentificationNumberMandatory).Append("\n");
      sb.Append("  AdditionalMerchantTerms: ").Append(AdditionalMerchantTerms).Append("\n");
      sb.Append("  PhoneMandatory: ").Append(PhoneMandatory).Append("\n");
      sb.Append("  RadiusBorder: ").Append(RadiusBorder).Append("\n");
      sb.Append("  AllowedCustomerTypes: ").Append(AllowedCustomerTypes).Append("\n");
      sb.Append("  ShowSubtotalDetail: ").Append(ShowSubtotalDetail).Append("\n");
      sb.Append("  AdditionalCheckboxes: ").Append(AdditionalCheckboxes).Append("\n");
      sb.Append("  RequireValidateCallbackSuccess: ").Append(RequireValidateCallbackSuccess).Append("\n");
      sb.Append("  VatRemoved: ").Append(VatRemoved).Append("\n");
      sb.Append("  VerifyNationalIdentificationNumber: ").Append(VerifyNationalIdentificationNumber).Append("\n");
      sb.Append("  ShowVatRegistrationNumberField: ").Append(ShowVatRegistrationNumberField).Append("\n");
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
