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

package com.klarna.rest.api.model;

import java.net.URI;

/**
 * The model for an external checkout.
 */
public class ExternalCheckout extends Model {
    /**
     * External checkout name.
     */
    private String name;

    /**
     * Redirect URI.
     */
    private URI redirectUrl;

    /**
     * Image URI.
     */
    private URI imageUrl;

    /**
     * Fee in cents, including tax.
     */
    private Long fee;

    /**
     * Get the checkout name.
     *
     * @return Checkout name.
     */
    public String getName() {
        return this.name;
    }

    /**
     * Set the checkout name.
     *
     * @param name Checkout name.
     * @return same instance.
     */
    public ExternalCheckout setName(final String name) {
        this.name = name;

        return this;
    }

    /**
     * Get the redirect URI.
     *
     * @return Redirect URI.
     */
    public URI getRedirectUrl() {
        return this.redirectUrl;
    }

    /**
     * Set the redirect URI.
     *
     * @param redirectUrl Redirect URI.
     * @return Same instance.
     */
    public ExternalCheckout setRedirectUrl(final URI redirectUrl) {
        this.redirectUrl = redirectUrl;

        return this;
    }

    /**
     * Get the image URI.
     *
     * @return Image URI.
     */
    public URI getImageUrl() {
        return this.imageUrl;
    }

    /**
     * Set the image URI.
     *
     * @param imageUrl Image URI.
     * @return Same instance.
     */
    public ExternalCheckout setImageUrl(final URI imageUrl) {
        this.imageUrl = imageUrl;

        return this;
    }

    /**
     * Get the checkout fee.
     *
     * @return Checkout fee.
     */
    public Long getFee() {
        return this.fee;
    }

    /**
     * Set the checkout fee.
     *
     * @param fee Checkout fee.
     * @return Same instance.
     */
    public ExternalCheckout setFee(final Long fee) {
        this.fee = fee;

        return this;
    }
}
