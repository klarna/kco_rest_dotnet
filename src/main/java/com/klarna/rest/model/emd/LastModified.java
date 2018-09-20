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
 * Model for last modified dates.
 */
public class LastModified extends Model {
    /**
     * Last modified date of password.
     */
    private DateTime password;

    /**
     * Last modified date of email.
     */
    private DateTime email;

    /**
     * Last modified date of listing.
     */
    private DateTime listing;

    /**
     * Last modified date of login.
     */
    private DateTime login;

    /**
     * Last modified date of address.
     */
    private DateTime address;

    /**
     * Get the password last modified date.
     *
     * @return Password last modified date.
     */
    public DateTime getPassword() {
        return this.password;
    }

    /**
     * Set the password last modified date.
     *
     * @param password Password last modified date.
     * @return Same instance.
     */
    public LastModified setPassword(final DateTime password) {
        this.password = password;

        return this;
    }

    /**
     * Get the email last modified date.
     *
     * @return Email last modified date.
     */
    public DateTime getEmail() {
        return this.email;
    }

    /**
     * Set the email last modified date.
     *
     * @param email Email last modified date.
     * @return Same instance.
     */
    public LastModified setEmail(final DateTime email) {
        this.email = email;

        return this;
    }

    /**
     * Get the listing last modified date.
     *
     * @return Listing last modified date.
     */
    public DateTime getListing() {
        return this.listing;
    }

    /**
     * Set the listing last modified date.
     *
     * @param listing Listing last modified date.
     * @return Same instance.
     */
    public LastModified setListing(final DateTime listing) {
        this.listing = listing;

        return this;
    }

    /**
     * Get the login last modified date.
     *
     * @return Login last modified date.
     */
    public DateTime getLogin() {
        return this.login;
    }

    /**
     * Set the login last modified date.
     *
     * @param login Login last modified date.
     * @return Same instance.
     */
    public LastModified setLogin(final DateTime login) {
        this.login = login;

        return this;
    }

    /**
     * Get the address last modified date.
     *
     * @return Address last modified date.
     */
    public DateTime getAddress() {
        return this.address;
    }

    /**
     * Set the address last modified date.
     *
     * @param address Address last modified date.
     * @return Same instance.
     */
    public LastModified setAddress(final DateTime address) {
        this.address = address;

        return this;
    }
}
