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
 * Shipping info data model.
 */
public class ShippingInfo extends Model {

    /**
     * Shipping company name.
     */
    private String shippingCompany;

    /**
     * Shipping method.
     */
    private String shippingMethod;

    /**
     * Tracking ID.
     */
    private String trackingNumber;

    /**
     * Tracking URL where the customer can track the shipment.
     */
    private String trackingUri;

    /**
     * RMA company name.
     */
    private String returnShippingCompany;

    /**
     * RMA tracking ID.
     */
    private String returnTrackingNumber;

    /**
     * RMA tracking URL where the customer can track the shipment.
     */
    private String returnTrackingUri;

    /**
     * Gets the shipping company.
     *
     * @return Company name
     */
    public String getShippingCompany() {
        return this.shippingCompany;
    }

    /**
     * Sets the shipping company.
     *
     * @param company Company name
     * @return Same instance
     */
    public ShippingInfo setShippingCompany(final String company) {
        this.shippingCompany = company;

        return this;
    }

    /**
     * Gets the shipping method.
     *
     * @return Shipping method
     */
    public String getShippingMethod() {
        return this.shippingMethod;
    }

    /**
     * Sets the shipping method.
     *
     * @param method Shipping method
     * @return Same instance
     */
    public ShippingInfo setShippingMethod(final String method) {
        this.shippingMethod = method;

        return this;
    }

    /**
     * Gets the tracking number.
     *
     * @return Tracking number
     */
    public String getTrackingNumber() {
        return this.trackingNumber;
    }

    /**
     * Sets the tracking number.
     *
     * @param number Tracking number
     * @return Same instance
     */
    public ShippingInfo setTrackingNumber(final String number) {
        this.trackingNumber = number;

        return this;
    }

    /**
     * Gets the tracking URI.
     *
     * @return Tracking URI
     */
    public String getTrackingUri() {
        return this.trackingUri;
    }

    /**
     * Sets the tracking URI.
     *
     * @param uri Tracking URI
     * @return Same instance
     */
    public ShippingInfo setTrackingUri(final String uri) {
        this.trackingUri = uri;

        return this;
    }

    /**
     * Gets the shipping company for returns.
     *
     * @return Company name
     */
    public String getReturnShippingCompany() {
        return this.returnShippingCompany;
    }

    /**
     * Sets the shipping company for returns.
     *
     * @param company Company name
     * @return Same instance
     */
    public ShippingInfo setReturnShippingCompany(final String company) {
        this.returnShippingCompany = company;

        return this;
    }

    /**
     * Gets the tracking number for returns.
     *
     * @return Tracking number
     */
    public String getReturnTrackingNumber() {
        return this.returnTrackingNumber;
    }

    /**
     * Sets the tracking number for returns.
     *
     * @param number Tracking number
     * @return Same instance
     */
    public ShippingInfo setReturnTrackingNumber(final String number) {
        this.returnTrackingNumber = number;

        return this;
    }

    /**
     * Gets the tracking URI for returns.
     *
     * @return Tracking URI
     */
    public String getReturnTrackingUri() {
        return this.returnTrackingUri;
    }

    /**
     * Sets the tracking URI for returns.
     *
     * @param uri Tracking URI
     * @return Same instance
     */
    public ShippingInfo setReturnTrackingUri(final String uri) {
        this.returnTrackingUri = uri;

        return this;
    }
}
