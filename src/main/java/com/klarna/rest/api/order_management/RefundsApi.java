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
import com.klarna.rest.model.order_management.Refund;
import com.klarna.rest.model.order_management.RefundObject;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import java.io.IOException;

/**
 * Order Management API: Refunds resource.
 *
 * The Order Management API is used for handling an order after the customer has completed the purchase.
 * It is used for updating, capturing and refunding an order as well as to see the history of events that
 * have affected this order.
 */
public class RefundsApi extends BaseApi {
    protected String PATH;

    /**
     * Creates a new refund resource.
     * @param transport HTTP Transport
     * @param orderId The unique order ID
     */
    public RefundsApi(final Transport transport, String orderId) {
        super(transport);

        this.PATH = String.format("/ordermanagement/v1/orders/%s/refunds", orderId);
    }

    /**
     * Creates a refund.
     *
     * @see examples.OrderManagementExample.CreateRefundExample
     *
     * @param refund Refund data
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void create(RefundObject refund) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(refund);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Status.CREATED);
    }

    /**
     * Gets refund.
     *
     * @see examples.OrderManagementExample.FetchRefundExample
     *
     * @param refundId Refund ID
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Refund fetch(String refundId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        ApiResponse response = this.get(PATH + "/" + refundId);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Refund.class);
    }

    /**
     * Gets refund using the Location header from the previous server response.
     *
     * @see examples.OrderManagementExample.FetchRefundExample
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Refund fetch() throws ApiException, ProtocolException, ContentTypeException, IOException {
        if (this.location == null) {
            throw new IOException("Unknown location");
        }
        ApiResponse response = this.get(this.location);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Refund.class);
    }
}
