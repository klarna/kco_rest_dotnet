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

import com.klarna.rest.api.model.OrderData;
import com.klarna.rest.api.model.Refund;
import com.klarna.rest.api.model.request.UpdateAuthorization;
import com.klarna.rest.api.model.request.UpdateCustomerDetails;
import com.klarna.rest.api.model.request.UpdateMerchantReferences;

/**
 * Order management resource.
 */
public interface Order extends Resource {

    /**
     * Path to the order management endpoint.
     */
    String PATH = "/ordermanagement/v1/orders";

    /**
     * Fetches the data for this order.
     *
     * @return Data for the resource
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    OrderData fetch() throws ApiException, ProtocolException;

    /**
     * Acknowledge the authorized order.
     *
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void acknowledge() throws ApiException, ProtocolException;

    /**
     * Cancels this order.
     *
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void cancel() throws ApiException, ProtocolException;

    /**
     * Extends the authorization time.
     *
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void extendAuthorizationTime() throws ApiException, ProtocolException;

    /**
     * Release the remaining authorization for an order.
     *
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void releaseRemainingAuthorization() throws ApiException, ProtocolException;

    /**
     * Refund an amount of the captured order.
     *
     * @param data Refund data.
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void refund(Refund data) throws ApiException, ProtocolException;

    /**
     * Updates the customer details.
     *
     * @param data Customer data
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void updateCustomerDetails(UpdateCustomerDetails data) throws
            ApiException, ProtocolException;

    /**
     * Update the merchant references.
     *
     * @param data Merchant references
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void updateMerchantReferences(UpdateMerchantReferences data) throws
            ApiException, ProtocolException;

    /**
     * Update the total order amount and order lines.
     *
     * @param data Update data
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void updateAuthorization(UpdateAuthorization data) throws
            ApiException, ProtocolException;
}
