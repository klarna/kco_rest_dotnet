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

package com.klarna.rest.api;

import com.klarna.rest.api.model.CheckoutOrderData;

/**
 * Checkout order resource interface.
 */
public interface CheckoutOrder extends Resource {

    /**
     * Path to the checkout endpoint.
     */
    String PATH = "/checkout/v3/orders";

    /**
     * Fetches the data for this checkout order.
     *
     * @return Data for the resource
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    CheckoutOrderData fetch() throws ApiException, ProtocolException;

    /**
     * Creates the checkout order.
     *
     * @param data Resource data
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void create(final CheckoutOrderData data) throws
            ApiException, ProtocolException;

    /**
     * Updates the checkout order.
     *
     * @param data Update resource data
     * @return Updated data
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    CheckoutOrderData update(final CheckoutOrderData data) throws
            ApiException, ProtocolException;
}
