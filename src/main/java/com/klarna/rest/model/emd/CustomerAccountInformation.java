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

import org.joda.time.DateTime;

/**
 * The model for customer account information.
 */
public class CustomerAccountInformation extends Model {
    /**
     * Unique account identifier.
     */
    private String uniqueAccountIdentifier;

    /**
     * Account registration date.
     */
    private DateTime accountRegistrationDate;

    /**
     * Account last modified date.
     */
    private DateTime accountLastModified;

    /**
     * Get the unique account identifier.
     *
     * @return Same instance.
     */
    public String getUniqueAccountIdentifier() {
        return this.uniqueAccountIdentifier;
    }

    /**
     * Set the unique account identifier.
     *
     * @param uniqueAccountIdentifier Unique account identifier.
     * @return Same instance.
     */
    public CustomerAccountInformation setUniqueAccountIdentifier(
            final String uniqueAccountIdentifier) {
        this.uniqueAccountIdentifier = uniqueAccountIdentifier;

        return this;
    }

    /**
     * Get the account registration date.
     *
     * @return Account registration date.
     */
    public DateTime getAccountRegistrationDate() {
        return this.accountRegistrationDate;
    }

    /**
     * Set the account registration date.
     *
     * @param accountRegistrationDate Account registration date.
     * @return Same instance.
     */
    public CustomerAccountInformation setAccountRegistrationDate(
            final DateTime accountRegistrationDate) {
        this.accountRegistrationDate = accountRegistrationDate;

        return this;
    }

    /**
     * Get account last modified date.
     *
     * @return Account last modified date.
     */
    public DateTime getAccountLastModified() {
        return this.accountLastModified;
    }

    /**
     * Set the account last modified date.
     *
     * @param accountLastModified Account last modified date.
     * @return Same account
     */
    public CustomerAccountInformation setAccountLastModified(
            final DateTime accountLastModified) {
        this.accountLastModified = accountLastModified;

        return this;
    }
}
