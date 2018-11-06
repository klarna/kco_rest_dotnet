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

import com.klarna.rest.api.BaseApi;
import com.klarna.rest.api.order_management.model.OrderManagementRefund;
import com.klarna.rest.api.order_management.model.OrderManagementRefundObject;
import com.klarna.rest.http_transport.Transport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;
import com.klarna.rest.model.ContentTypeException;
import com.klarna.rest.model.ProtocolException;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import java.io.IOException;
import java.util.List;

/**
 * Order Management API: Refunds resource.
 *
 * The Order Management API is used for handling an order after the customer has completed the purchase.
 * It is used for updating, capturing and refunding an order as well as to see the history of events that
 * have affected this order.
 */
public class OrderManagementRefundsApi extends BaseApi {
    protected String PATH;

    /**
     * Creates a new refund resource.
     * @param transport HTTP Transport
     * @param orderId The unique order ID
     */
    public OrderManagementRefundsApi(final Transport transport, String orderId) {
        super(transport);

        this.PATH = String.format("/ordermanagement/v1/orders/%s/refunds", orderId);
    }

    /**
     * Creates a refund.
     *
     * @see examples.OrderManagementExample.CreateRefundExample
     *
     * @param refund Refund data
     * @return Refund ID
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public String create(OrderManagementRefundObject refund) throws ApiException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(refund);
        final ApiResponse response = this.post(PATH, data);

        response.expectSuccessful()
                .expectStatusCode(Status.CREATED);

        List<String> refundId = response.getHeader("Refund-Id");
        return refundId == null ? "" : refundId.get(0);
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
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public OrderManagementRefund fetch(String refundId) throws ApiException, IOException {
        ApiResponse response = this.get(PATH + "/" + refundId);

        response.expectSuccessful()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), OrderManagementRefund.class);
    }

    /**
     * Gets refund using the Location header from the previous server response.
     *
     * @see examples.OrderManagementExample.FetchRefundExample
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public OrderManagementRefund fetch() throws ApiException, IOException {
        if (this.location == null) {
            throw new IOException("Unknown location");
        }
        ApiResponse response = this.get(this.location);

        response.expectSuccessful()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), OrderManagementRefund.class);
    }
}
