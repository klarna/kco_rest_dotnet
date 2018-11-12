/*
 * Copyright 2018 Klarna AB
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

package com.klarna.rest.api.checkout.model.emd;


/**
 * The model for locations.
 */
public class Location extends Model {
    /**
     * Street address.
     */
    private String streetAddress;

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
    public Location setStreetAddress(final String streetAddress) {
        this.streetAddress = streetAddress;

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
    public Location setPostalCode(final String postalCode) {
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
    public Location setCity(final String city) {
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
    public Location setCountry(final String country) {
        this.country = country;

        return this;
    }
}
