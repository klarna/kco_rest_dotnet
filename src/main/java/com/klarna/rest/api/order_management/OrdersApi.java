/*
 * Copyright 2018 Klarna AB
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

package com.klarna.rest.api.order_management;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.order_management.Order;
import com.klarna.rest.model.order_management.UpdateAuthorization;
import com.klarna.rest.model.order_management.UpdateConsumer;
import com.klarna.rest.model.order_management.UpdateMerchantReferences;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import java.io.IOException;

/**
 * Order Management API: Orders resource.
 *
 * The Order Management API is used for handling an order after the customer has completed the purchase.
 * It is used for updating, capturing and refunding an order as well as to see the history of events that
 * have affected this order.
 */
public class OrdersApi extends BaseApi {
    protected String PATH = "/order_management/v1/orders";

    public OrdersApi(final Transport transport) {
        super(transport);
    }

    /**
     * Gets order information.
     *
     * @see examples.OrderManagementExample.FetchOrderExample
     *
     * @param orderId The unique order ID
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Order fetch(String orderId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + '/' + orderId);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    /**
     * Releases remaining authorization.
     *
     * @see examples.OrderManagementExample.ReleaseRemainingAuthorizationExample
     *
     * @param orderId The unique order ID
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void releaseRemainingAuthorization(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "release-remaining-authorization");
        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    /**
     * Extends authorization time.
     *
     * @see examples.OrderManagementExample.ExtendAuthorizationTimeExample
     *
     * @param orderId The unique order ID
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void extendAuthorizationTime(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "extend-authorization-time");
        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    /**
     * Updates customer addresses.
     *
     * @see examples.OrderManagementExample.UpdateCustomerAddressesExample
     *
     * @param orderId The unique order ID
     * @param customerAddress Customer Billing and Shipping addresses
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void updateCustomerAddresses(String orderId, UpdateConsumer customerAddress)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "customer-details");
        final byte[] data = objectMapper.writeValueAsBytes(customerAddress);

        final ApiResponse response = this.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    /**
     * Cancels order.
     *
     * @see examples.OrderManagementExample.CancelOrderExample
     *
     * @param orderId The unique order ID
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void cancelOrder(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "cancel");

        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    /**
     * Updates merchant references.
     *
     * @see examples.OrderManagementExample.UpdateMerchantReferencesExample
     *
     * @param orderId The unique order ID
     * @param references New merchant references
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void updateMerchantReferences(String orderId, UpdateMerchantReferences references)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "merchant-references");
        final byte[] data = objectMapper.writeValueAsBytes(references);
        final ApiResponse response = this.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    /**
     * Acknowledges order.
     *
     * @see examples.OrderManagementExample.AcknowledgeOrderExample
     *
     * @param orderId The unique order ID
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void acknowledgeOrder(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "acknowledge");
        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    /**
     * Sets new order amount and order lines.
     *
     * @see examples.OrderManagementExample.SetOrderAmountAndOrderLines
     *
     * @param orderId The unique order ID
     * @param orderData New order information
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void setOrderAmountAndOrderLines(String orderId, UpdateAuthorization orderData)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "authorization");
        final byte[] data = objectMapper.writeValueAsBytes(orderData);
        final ApiResponse response = this.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }
}
