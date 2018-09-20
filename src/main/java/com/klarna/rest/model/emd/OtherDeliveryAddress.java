/*
 * Copyright 2015 Klarna AB
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

package com.klarna.rest.model.emd;


/**
 * The model for other delivery addresses.
 */
public class OtherDeliveryAddress extends Model {
    /**
     * Shipping method.
     */
    private String shippingMethod;

    /**
     * Shipping type.
     */
    private String shippingType;

    /**
     * First name.
     */
    private String firstName;

    /**
     * Last name.
     */
    private String lastName;

    /**
     * Street address.
     */
    private String streetAddress;

    /**
     * Street number.
     */
    private String streetNumber;

    /**
     * Postal code.
     */
    private String postalCode;

    /**
     * City name.
     */
    private String city;

    /**
     * Country name.
     */
    private String country;

    /**
     * Get the shipping method.
     *
     * @return Shipping method.
     */
    public String getShippingMethod() {
        return this.shippingMethod;
    }

    /**
     * Set the shipping method.
     * <p>
     * Allowed values are "store pick-up", "pick-up point", "registered box"
     * or "unregistered box".
     * </p>
     *
     * @param shippingMethod Shipping method.
     * @return Same instance.
     */
    public OtherDeliveryAddress setShippingMethod(final String shippingMethod) {
        this.shippingMethod = shippingMethod;

        return this;
    }

    /**
     * Get the shipping type.
     *
     * @return Shipping type.
     */
    public String getShippingType() {
        return this.shippingType;
    }

    /**
     * Set the shipping type.
     * <p>
     * Allowed values are "normal" or "express"
     * </p>
     *
     * @param shippingType Shipping type.
     * @return Same instance.
     */
    public OtherDeliveryAddress setShippingType(final String shippingType) {
        this.shippingType = shippingType;

        return this;
    }

    /**
     * Get the first name.
     *
     * @return First name.
     */
    public String getFirstName() {
        return this.firstName;
    }

    /**
     * Set the first name.
     *
     * @param firstName First name.
     * @return Same instance.
     */
    public OtherDeliveryAddress setFirstName(final String firstName) {
        this.firstName = firstName;

        return this;
    }

    /**
     * Get the last name.
     *
     * @return Last name.
     */
    public String getLastName() {
        return this.lastName;
    }

    /**
     * Set the last name.
     *
     * @param lastName Last name.
     * @return Same instance.
     */
    public OtherDeliveryAddress setLastName(final String lastName) {
        this.lastName = lastName;

        return this;
    }

    /**
     * Get the street address.
     *
     * @return Street address.
     */
    public String getStreetAddress() {
        return this.streetAddress;
    }

    /**
     * Set the street address.
     *
     * @param streetAddress Street address.
     * @return Same instance.
     */
    public OtherDeliveryAddress setStreetAddress(final String streetAddress) {
        this.streetAddress = streetAddress;

        return this;
    }

    /**
     * Get the street number.
     *
     * @return Street number.
     */
    public String getStreetNumber() {
        return this.streetNumber;
    }

    /**
     * Set the street number.
     *
     * @param streetNumber Street number.
     * @return Same instance.
     */
    public OtherDeliveryAddress setStreetNumber(final String streetNumber) {
        this.streetNumber = streetNumber;

        return this;
    }

    /**
     * Get the postal code.
     *
     * @return Postal code.
     */
    public String getPostalCode() {
        return this.postalCode;
    }

    /**
     * Set the postal code.
     *
     * @param postalCode Postal code.
     * @return Same instance.
     */
    public OtherDeliveryAddress setPostalCode(final String postalCode) {
        this.postalCode = postalCode;

        return this;
    }

    /**
     * Get the city name.
     *
     * @return City name.
     */
    public String getCity() {
        return this.city;
    }

    /**
     * Set the city name.
     *
     * @param city City name.
     * @return Same instance.
     */
    public OtherDeliveryAddress setCity(final String city) {
        this.city = city;

        return this;
    }

    /**
     * Get the country name.
     *
     * @return Country name.
     */
    public String getCountry() {
        return this.country;
    }

    /**
     * Set the country name.
     *
     * @param country Country name.
     * @return Same instance.
     */
    public OtherDeliveryAddress setCountry(final String country) {
        this.country = country;

        return this;
    }
}
