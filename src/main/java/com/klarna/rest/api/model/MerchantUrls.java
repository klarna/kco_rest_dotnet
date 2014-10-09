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
 * Merchant URLs data model.
 */
public class MerchantUrls extends Model {

    /**
     * URL to the terms page.
     */
    private String terms;

    /**
     * URL to the checkout page.
     */
    private String checkout;

    /**
     * URL to the thank you page.
     */
    private String confirmation;

    /**
     * URL to the push notification page.
     */
    private String push;

    /**
     * URL to the validation page.
     */
    private String validation;

    /**
     * Gets the terms URL.
     *
     * @return Terms page
     */
    public String getTerms() {
        return this.terms;
    }

    /**
     * Sets the terms URL.
     *
     * @param url Terms page
     * @return Same instance
     */
    public MerchantUrls setTerms(final String url) {
        this.terms = url;

        return this;
    }

    /**
     * Gets the checkout URL.
     *
     * @return Checkout page
     */
    public String getCheckout() {
        return this.checkout;
    }

    /**
     * Sets the checkout URL.
     *
     * @param url Checkout page
     * @return Same instance
     */
    public MerchantUrls setCheckout(final String url) {
        this.checkout = url;

        return this;
    }

    /**
     * Gets the confirmation URL.
     *
     * @return Thank you page
     */
    public String getConfirmation() {
        return this.confirmation;
    }

    /**
     * Sets the confirmation URL.
     *
     * @param url Thank you page
     * @return Same instance
     */
    public MerchantUrls setConfirmation(final String url) {
        this.confirmation = url;

        return this;
    }

    /**
     * Gets the push URL.
     *
     * @return Push notification page
     */
    public String getPush() {
        return this.push;
    }

    /**
     * Sets the push URL.
     *
     * @param url Push notification page
     * @return Same instance
     */
    public MerchantUrls setPush(final String url) {
        this.push = url;

        return this;
    }

    /**
     * Gets the validation URL.
     *
     * @return Validation page
     */
    public String getValidation() {
        return this.validation;
    }

    /**
     * Sets the validation URL.
     *
     * @param url Validation page
     * @return Same instance
     */
    public MerchantUrls setValidation(final String url) {
        this.validation = url;

        return this;
    }
}
