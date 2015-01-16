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

/**
 * Checkout options data model.
 */
public class CheckoutOptions extends Model {

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
}
