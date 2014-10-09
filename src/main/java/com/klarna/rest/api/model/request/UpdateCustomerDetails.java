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

package com.klarna.rest.api.model.request;

import com.klarna.rest.api.model.Address;
import com.klarna.rest.api.model.Model;

/**
 * Update customer details data model.
 */
public class UpdateCustomerDetails extends Model {

    /**
     * Customer billing address.
     */
    private Address billingAddress;

    /**
     * Customer shipping address.
     */
    private Address shippingAddress;

    /**
     * Gets the billing address.
     *
     * @return Billing address
     */
    public Address getBillingAddress() {
        return this.billingAddress;
    }

    /**
     * Sets the billing address.
     *
     * @param address Billing address
     * @return Same instance
     */
    public UpdateCustomerDetails setBillingAddress(final Address address) {
        this.billingAddress = address;

        return this;
    }

    /**
     * Gets the shipping address.
     *
     * @return Shipping address
     */
    public Address getShippingAddress() {
        return this.shippingAddress;
    }

    /**
     * Sets the shipping address.
     *
     * @param address Shipping address
     * @return Same instance
     */
    public UpdateCustomerDetails setShippingAddress(final Address address) {
        this.shippingAddress = address;

        return this;
    }
}
