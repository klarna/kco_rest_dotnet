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
 *
 * File containing the UpdateConsumerDetails class
 */

package com.klarna.api.ordermanagement.client.model.request;

import com.klarna.api.ordermanagement.client.model.Address;

/**
 * Update billing and/or shipping address for an order, subject to customer credit check.
 */
public class UpdateCustomerDetails extends Request {

    /**
     * Optional shipping address.
     */
    public final Address shipping_address;

    /**
     * Optional billing address.
     */
    public final Address billing_address;

    /**
     * Update billing and/or shipping address for an order, subject to customer credit check.
     * Address fields can be updated independently. To clear an address newField, set its value to "" (empty string).
     * Mandatory fields can not be cleared, see {@link com.klarna.api.ordermanagement.client.model.Address}.
     *
     * @param shipping_address Update of shipping address
     * @param billing_address  Update of billing address
     */
    public UpdateCustomerDetails(Address shipping_address, Address billing_address) {
        this.shipping_address = shipping_address;
        this.billing_address = billing_address;
    }

}
