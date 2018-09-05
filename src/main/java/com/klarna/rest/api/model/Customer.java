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
 * Customer data model.
 */
public class Customer extends Model {

    /**
     * Customers date of birth.
     */
    private String dateOfBirth;

    /**
     * The default supported value is 'person'. If B2B is enabled for the merchant, the value may be "organization".
     */
    private String type;

    /**
     * The organization's official registration id (organization number). Applicable only for B2B orders.
     */
    private String organizationRegistrationId;

    /**
     * The customer national identification number.
     */
    private String nationalIdentificationNumber;


    /**
     * Gets the date of birth.
     *
     * @return Date of birth (ISO 8601 date), e.g. "1990-07-07"
     */
    public String getDateOfBirth() {
        return this.dateOfBirth;
    }

    /**
     * Sets the date of birth.
     *
     * @param birthDate Date of birth (ISO 8601 date), e.g. "1990-07-07"
     * @return Same instance
     */
    public Customer setDateOfBirth(final String birthDate) {
        this.dateOfBirth = birthDate;

        return this;
    }

    /**
     * Gets the customer type.
     *
     * @return The customer type
     */
    public String getType() {
        return this.type;
    }

    /**
     * Sets the the customer type
     *
     * @param type The default supported value is 'person'.
     *             If B2B is enabled for the merchant, the value may be "organization".
     * @return Same instance
     */
    public Customer setType(final String type) {
        this.type = type;

        return this;
    }

    /**
     * Gets the Organization Registration Id.
     *
     * @return Organization Registration Id
     */
    public String getOrganizationRegistrationId() {
        return this.organizationRegistrationId;
    }

    /**
     * Sets the Organization Registration Id.
     * Applicable only for B2B orders.
     *
     * @param organizationRegistrationId The organization's official registration id (organization number).
     * @return Same instance
     */
    public Customer setOrganizationRegistrationId(final String organizationRegistrationId) {
        this.organizationRegistrationId = organizationRegistrationId;

        return this;
    }

    /**
     * Gets the National Identification Number (NIN).
     *
     * @return NIN
     */
    public String getNationalIdentificationNumber() {
        return this.nationalIdentificationNumber;
    }

    /**
     * Sets the National Identification Number (NIN).
     *
     * @param nin National Identification Number (NIN)
     * @return Same instance
     */
    public Customer setNationalIdentificationNumber(String nin) {
        this.nationalIdentificationNumber = nin;

        return this;
    }
}
