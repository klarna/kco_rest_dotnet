using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Options {
    /// <summary>
    /// Acquiring channel for the order. Use MOTO for \"Mail Order Telephone Order\" or ECOMMERCE for \"E-commerce\" or IN_STORE for \"Purchase in boutique\" or TELESALES for \"Telesales/telemarketing\". Default : ECOMMERCE
    /// </summary>
    /// <value>Acquiring channel for the order. Use MOTO for \"Mail Order Telephone Order\" or ECOMMERCE for \"E-commerce\" or IN_STORE for \"Purchase in boutique\" or TELESALES for \"Telesales/telemarketing\". Default : ECOMMERCE</value>
    [DataMember(Name="acquiring_channel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "acquiring_channel")]
    public string AcquiringChannel { get; set; }

    /// <summary>
    /// If true, the consumer can enter different billing and shipping addresses. Default: false
    /// </summary>
    /// <value>If true, the consumer can enter different billing and shipping addresses. Default: false</value>
    [DataMember(Name="allow_separate_shipping_address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "allow_separate_shipping_address")]
    public bool? AllowSeparateShippingAddress { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_button", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_button")]
    public string ColorButton { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_button_text", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_button_text")]
    public string ColorButtonText { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_checkbox", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_checkbox")]
    public string ColorCheckbox { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_checkbox_checkmark", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_checkbox_checkmark")]
    public string ColorCheckboxCheckmark { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_header", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_header")]
    public string ColorHeader { get; set; }

    /// <summary>
    /// CSS hex color, e.g. \"#FF9900\"
    /// </summary>
    /// <value>CSS hex color, e.g. \"#FF9900\"</value>
    [DataMember(Name="color_link", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color_link")]
    public string ColorLink { get; set; }

    /// <summary>
    /// If true, the consumer cannot skip date of birth. Default: false
    /// </summary>
    /// <value>If true, the consumer cannot skip date of birth. Default: false</value>
    [DataMember(Name="date_of_birth_mandatory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date_of_birth_mandatory")]
    public bool? DateOfBirthMandatory { get; set; }

    /// <summary>
    /// A message that will be presented on the confirmation page under the headline \"Delivery\".
    /// </summary>
    /// <value>A message that will be presented on the confirmation page under the headline \"Delivery\".</value>
    [DataMember(Name="shipping_details", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipping_details")]
    public string ShippingDetails { get; set; }

    /// <summary>
    /// If specified to false, title becomes optional. Only available for orders for country GB.
    /// </summary>
    /// <value>If specified to false, title becomes optional. Only available for orders for country GB.</value>
    [DataMember(Name="title_mandatory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title_mandatory")]
    public bool? TitleMandatory { get; set; }

    /// <summary>
    /// Additional merchant defined checkbox. e.g. for Newsletter opt-in.
    /// </summary>
    /// <value>Additional merchant defined checkbox. e.g. for Newsletter opt-in.</value>
    [DataMember(Name="additional_checkbox", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additional_checkbox")]
    public Checkbox AdditionalCheckbox { get; set; }

    /// <summary>
    /// Additional merchant defined field. e.g. for purchases that MUST have a national insurance number.
    /// </summary>
    /// <value>Additional merchant defined field. e.g. for purchases that MUST have a national insurance number.</value>
    [DataMember(Name="national_identification_number_mandatory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "national_identification_number_mandatory")]
    public bool? NationalIdentificationNumberMandatory { get; set; }

    /// <summary>
    /// Additional merchant defined field. e.g. Extra terms and conditions to show.
    /// </summary>
    /// <value>Additional merchant defined field. e.g. Extra terms and conditions to show.</value>
    [DataMember(Name="additional_merchant_terms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additional_merchant_terms")]
    public string AdditionalMerchantTerms { get; set; }

    /// <summary>
    /// If true, the consumer can not skip phone (in countries were this usually is possible). Only available for orders for DACH countries.
    /// </summary>
    /// <value>If true, the consumer can not skip phone (in countries were this usually is possible). Only available for orders for DACH countries.</value>
    [DataMember(Name="phone_mandatory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phone_mandatory")]
    public bool? PhoneMandatory { get; set; }

    /// <summary>
    /// Border radius in pixels
    /// </summary>
    /// <value>Border radius in pixels</value>
    [DataMember(Name="radius_border", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "radius_border")]
    public string RadiusBorder { get; set; }

    /// <summary>
    /// A list of allowed customer types. Supported types: <b>person</b> & <b>organization</b>.
    /// </summary>
    /// <value>A list of allowed customer types. Supported types: <b>person</b> & <b>organization</b>.</value>
    [DataMember(Name="allowed_customer_types", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "allowed_customer_types")]
    public List<string> AllowedCustomerTypes { get; set; }

    /// <summary>
    /// If true, the Order Detail subtotals view is expanded. Default: false
    /// </summary>
    /// <value>If true, the Order Detail subtotals view is expanded. Default: false</value>
    [DataMember(Name="show_subtotal_detail", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "show_subtotal_detail")]
    public bool? ShowSubtotalDetail { get; set; }

    /// <summary>
    /// Additional merchant defined checkboxes. e.g. for Newsletter opt-in.
    /// </summary>
    /// <value>Additional merchant defined checkboxes. e.g. for Newsletter opt-in.</value>
    [DataMember(Name="additional_checkboxes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additional_checkboxes")]
    public List<CheckboxV2> AdditionalCheckboxes { get; set; }

    /// <summary>
    /// If true, validate callback must get a positive response to not stop purchase. Default: false.
    /// </summary>
    /// <value>If true, validate callback must get a positive response to not stop purchase. Default: false.</value>
    [DataMember(Name="require_validate_callback_success", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "require_validate_callback_success")]
    public bool? RequireValidateCallbackSuccess { get; set; }

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
