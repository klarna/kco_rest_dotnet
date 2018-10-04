/*
 * Copyright 2014 Klarna AB
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.klarna.rest.api.model;

import java.util.ArrayList;
import java.util.List;

/**
 * Checkout options data model.
 */
public class CheckoutOptions extends Model {

    /**
     * Acquiring channel for the order.
     */
    private String acquiringChannel;

    /**
     * If customers date of birth is mandatory.
     */
    private Boolean dateOfBirthMandatory;

    /**
     * If the customer should be able to supply a different shipping address.
     */
    private Boolean allowSeparateShippingAddress;

    /**
     * Color of buttons, e.g. #FF9900.
     */
    private String colorButton;

    /**
     * Color of button text, e.g. #FF9900.
     */
    private String colorButtonText;

    /**
     * Color of checkboxes, e.g. #FF9900.
     */
    private String colorCheckbox;

    /**
     * Color of checkbox check mark, e.g. #FF9900.
     */
    private String colorCheckboxCheckmark;

    /**
     * Color of headers, e.g. #FF9900.
     */
    private String colorHeader;

    /**
     * Color of links, e.g. #FF9900.
     */
    private String colorLink;

    /**
     * A message that will be presented on the confirmation page under the headline.
     */
    private String shippingDetails;

    /**
     * If specified to false, title becomes optional. Only available for orders for country GB.
     */
    private Boolean titleMandatory;

    /**
     * Additional merchant defined checkbox. e.g. for Newsletter opt-in.
     */
    private CheckoutOptionsCheckbox additionalCheckbox;

    /**
     * Additional merchant defined field. e.g. for purchases that MUST have a national insurance number.
     */
    private Boolean nationalIdentificationNumberMandatory;

    /**
     * Additional merchant defined field. e.g. Extra terms and conditions to show.
     */
    private String additionalMerchantTerms = null;

    /**
     * Border radius
     */
    private String radiusBorder = null;

    /**
     * A list of allowed customer types. Supported types: person, organization.
     */
    private List<String> allowedCustomerTypes = null;

    /**
     * If true, the Order Detail subtotals view is expanded.
     */
    private Boolean showSubtotalDetail;

    /**
     * Additional merchant defined checkboxes. e.g. for Newsletter opt-in.
     */
    private List<CheckoutOptionsCheckbox> additionalCheckboxes = null;

    /**
     * If true, validate callback must get a positive response to not stop purchase.
     */
    private Boolean requireValidateCallbackSuccess;

    /**
     * If true, VAT is not included in total price
     */
    private Boolean vatExcluded;


    /**
     * Gets the acquiring channel for the order.
     *
     * @return Channel
     */
    public String getAcquiringChannel() {
        return this.acquiringChannel;
    }

    /**
     * Sets the acquiring channel for the order.
     *
     * @param channel Acquiring channel
     * @return Same instance
     */
    public CheckoutOptions setAcquiringChannel(final String channel) {
        this.acquiringChannel = channel;

        return this;
    }

    /**
     * Gets whether the customer date of birth is mandatory.
     *
     * @return If it is mandatory
     */
    public Boolean getDateOfBirthMandatory() {
        return this.dateOfBirthMandatory;
    }

    /**
     * Sets whether the customer needs to supply a date of birth.
     *
     * @param mandatory If date of birth should be mandatory
     * @return Same instance
     */
    public CheckoutOptions setDateOfBirthMandatory(final Boolean mandatory) {
        this.dateOfBirthMandatory = mandatory;

        return this;
    }

    /**
     * Gets whether the customer can supply a separate shipping address.
     *
     * @return If the customer can supply a separate shipping address
     */
    public Boolean getAllowSeparateShippingAddress() {
        return this.allowSeparateShippingAddress;
    }

    /**
     * Sets whether the customer should be able to specify a separate
     * shipping address.
     *
     * @param allowed If specifying a separate shipping address is allowed
     * @return Same instance
     */
    public CheckoutOptions setAllowSeparateShippingAddress(
            final Boolean allowed
    ) {
        this.allowSeparateShippingAddress = allowed;

        return this;
    }

    /**
     * Gets the button color.
     *
     * @return Color
     */
    public String getColorButton() {
        return this.colorButton;
    }

    /**
     * Sets the color of the buttons.
     *
     * @param color Color
     * @return Same instance
     */
    public CheckoutOptions setColorButton(final String color) {
        this.colorButton = color;

        return this;
    }

    /**
     * Gets the button text color.
     *
     * @return Color
     */
    public String getColorButtonText() {
        return this.colorButtonText;
    }

    /**
     * Sets the color of button text.
     *
     * @param color Color
     * @return Same instance
     */
    public CheckoutOptions setColorButtonText(final String color) {
        this.colorButtonText = color;

        return this;
    }

    /**
     * Gets the checkbox color.
     *
     * @return Color
     */
    public String getColorCheckbox() {
        return this.colorCheckbox;
    }

    /**
     * Sets the color of the checkboxes.
     *
     * @param color Color
     * @return Same instance
     */
    public CheckoutOptions setColorCheckbox(final String color) {
        this.colorCheckbox = color;

        return this;
    }

    /**
     * Gets checkbox check mark color.
     *
     * @return Color
     */
    public String getColorCheckboxCheckmark() {
        return this.colorCheckboxCheckmark;
    }

    /**
     * Sets the color of the checkbox check marks.
     *
     * @param color Color
     * @return Same instance
     */
    public CheckoutOptions setColorCheckboxCheckmark(final String color) {
        this.colorCheckboxCheckmark = color;

        return this;
    }

    /**
     * Gets the header color.
     *
     * @return Color
     */
    public String getColorHeader() {
        return this.colorHeader;
    }

    /**
     * Sets the color of the headers.
     *
     * @param color Color
     * @return Same instance
     */
    public CheckoutOptions setColorHeader(final String color) {
        this.colorHeader = color;

        return this;
    }

    /**
     * Gets the link color.
     *
     * @return Color
     */
    public String getColorLink() {
        return this.colorLink;
    }

    /**
     * Sets the color of links.
     *
     * @param color Color
     * @return Same instance
     */
    public CheckoutOptions setColorLink(final String color) {
        this.colorLink = color;

        return this;
    }

    /**
     * Gets the message that will be presented on the confirmation page.
     *
     * @return Message
     */
    public String getShippingDetails() {
        return this.shippingDetails;
    }

    /**
     * Sets the message that will be presented on the confirmation page.
     *
     * @param shippingDetails Message
     * @return Same instance
     */
    public CheckoutOptions setShippingDetails(final String shippingDetails) {
        this.shippingDetails = shippingDetails;

        return this;
    }

    /**
     * Gets whether the customer title is mandatory.
     *
     * @return If it is mandatory
     */
    public Boolean getTitleMandatory() {
        return this.titleMandatory;
    }

    /**
     * Sets whether the customer title is mandatory.
     *
     * @param mandatory If specified to false, title becomes optional
     * @return Same instance
     */
    public CheckoutOptions setTitleMandatory(final Boolean mandatory) {
        this.titleMandatory = mandatory;

        return this;
    }

    /**
     * Gets the additional checkbox option.
     *
     * @return Additional checkout checkbox
     */
    public CheckoutOptionsCheckbox getAdditionalCheckbox() {
        return this.additionalCheckbox;
    }

    /**
     * Sets the additional checkout checkbox.
     *
     * @param additionalCheckbox Additional checkbox
     * @return Same instance
     */
    public CheckoutOptions setAdditionalCheckbox(final CheckoutOptionsCheckbox additionalCheckbox) {
        this.additionalCheckbox = additionalCheckbox;

        return this;
    }

    /**
     * Gets whether the additional merchant defined field is mandatory.
     *
     * @return If it is mandatory
     */
    public Boolean getNationalIdentificationNumberMandatory() {
        return this.nationalIdentificationNumberMandatory;
    }

    /**
     * Sets the additional merchant defined mandatory.
     *
     * @param mandatory If the additional merchant defined field is mandatory
     * @return Same instance
     */
    public CheckoutOptions setNationalIdentificationNumberMandatory(final Boolean mandatory) {
        this.nationalIdentificationNumberMandatory = mandatory;

        return this;
    }

    /**
     * Gets Additional merchant defined field. e.g. Extra terms and conditions to show.
     *
     * @return additionalMerchantTerms
     **/
    public String getAdditionalMerchantTerms() {
        return this.additionalMerchantTerms;
    }

    /**
     * Sets Additional merchant defined field.
     *
     * @return Same instance
     **/
    public CheckoutOptions setAdditionalMerchantTerms(String additionalMerchantTerms) {
        this.additionalMerchantTerms = additionalMerchantTerms;

        return this;
    }

    /**
     * Gets Border radius.
     *
     * @return radiusBorder
     **/
    public String getRadiusBorder() {
        return this.radiusBorder;
    }

    /**
     * Sets Border radius.
     *
     * @return Same instance
     **/
    public CheckoutOptions setRadiusBorder(String radiusBorder) {
        this.radiusBorder = radiusBorder;

        return this;
    }

    public CheckoutOptions addAllowedCustomerTypesItem(String allowedCustomerTypesItem) {
        if (this.allowedCustomerTypes == null) {
            this.allowedCustomerTypes = new ArrayList<String>();
        }
        this.allowedCustomerTypes.add(allowedCustomerTypesItem);
        return this;
    }

    /**
     * Gets a list of allowed customer types.
     *
     * @return allowedCustomerTypes
     **/
    public List<String> getAllowedCustomerTypes() {
        return allowedCustomerTypes;
    }

    /**
     * Sets a list of allowed customer types. Supported types: person, organization.
     *
     * @return Same instance
     **/
    public CheckoutOptions setAllowedCustomerTypes(List<String> allowedCustomerTypes) {
        this.allowedCustomerTypes = allowedCustomerTypes;

        return this;
    }

    /**
     * Gets flag if the Order Detail subtotals view is expanded
     *
     * @return If it is mandatory
     */
    public Boolean getShowSubtotalDetail() {
        return this.showSubtotalDetail;
    }

    /**
     * Sets flag if the Order Detail subtotals view should be expanded.
     *
     * @param showSubtotalDetail If specified to false, title becomes optional
     * @return Same instance
     */
    public CheckoutOptions setShowSubtotalDetail(final Boolean showSubtotalDetail) {
        this.showSubtotalDetail = showSubtotalDetail;

        return this;
    }

    public CheckoutOptions addAdditionalCheckboxesItem(CheckoutOptionsCheckbox additionalCheckboxesItem) {
        if (this.additionalCheckboxes == null) {
            this.additionalCheckboxes = new ArrayList<CheckoutOptionsCheckbox>();
        }
        this.additionalCheckboxes.add(additionalCheckboxesItem);
        return this;
    }

    /**
     * Gets additional merchant defined checkboxes. e.g. for Newsletter opt-in.
     *
     * @return Additional checkboxes
     **/
    public List<CheckoutOptionsCheckbox> getAdditionalCheckboxes() {
        return this.additionalCheckboxes;
    }

    /**
     * Sets a list of additional checkboxes.
     *
     * @param additionalCheckboxes
     * @return Same instance
     */
    public CheckoutOptions setAdditionalCheckboxes(List<CheckoutOptionsCheckbox> additionalCheckboxes) {
        this.additionalCheckboxes = additionalCheckboxes;

        return this;
    }

    /**
     * Gets callback validation flag.
     *
     * @return If it should be validated
     */
    public Boolean getRequireValidateCallbackSuccess() {
        return this.requireValidateCallbackSuccess;
    }

    /**
     * Sets callback validation flag.
     *
     * @param requireValidateCallbackSuccess validate callback must get a positive response to not stop purchase
     * @return Same instance
     */
    public CheckoutOptions setRequireValidateCallbackSuccess(final Boolean requireValidateCallbackSuccess) {
        this.requireValidateCallbackSuccess = requireValidateCallbackSuccess;

        return this;
    }

    /**
     * Gets the flag, that shows that VAT is not included in total price
     *
     * @return If VAT should be excluded from total price
     */
    public Boolean getVatExcluded() {
        return this.vatExcluded;
    }

    /**
     * Sets vat exlusion flag.
     *
     * @param vatExcluded ff VAT should be excluded from total price
     * @return Same instance
     */
    public CheckoutOptions setVatExcluded(final Boolean vatExcluded) {
        this.vatExcluded = vatExcluded;

        return this;
    }
}
