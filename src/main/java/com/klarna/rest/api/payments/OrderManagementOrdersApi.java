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

package com.klarna.rest.api.payments;

import com.klarna.rest.api.BaseApi;
import com.klarna.rest.api.payments.model.PaymentsCreateOrderRequest;
import com.klarna.rest.api.payments.model.PaymentsCustomerTokenCreationRequest;
import com.klarna.rest.api.payments.model.PaymentsCustomerTokenCreationResponse;
import com.klarna.rest.api.payments.model.PaymentsOrder;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

/**
 * Payments API: Orders resource.
 *
 * The payments API is used to create a session to offer Klarna's payment methods as part of your checkout.
 *
 * As soon as the purchase is completed the order should be read and handled using the
 * {@link com.klarna.rest.api.order_management.OrderManagementOrdersApi Order Management API}.
 */
public class OrderManagementOrdersApi extends BaseApi {
    protected String PATH = "/payments/v1/authorizations";

    public OrderManagementOrdersApi(final HttpTransport transport) {
        super(transport);
    }

    /**
     * Creates a new order.
     *
     * @see examples.PaymentsExample.CreateOrderExample
     *
     * @param authorizationToken Authorization token
     * @param order Order data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public PaymentsOrder create(String authorizationToken, PaymentsCreateOrderRequest order)
            throws ApiException, IOException {
        final String path = String.format("%s/%s/%s", PATH, authorizationToken, "order");
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = this.post(path, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), PaymentsOrder.class);
    }

    /**
     * Generates a consumer token.
     *
     * @see examples.PaymentsExample.GenerateCustomerTokenExample
     *
     * @param authorizationToken Authorization token
     * @param request Customer Token details
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public PaymentsCustomerTokenCreationResponse generateToken(
            String authorizationToken, PaymentsCustomerTokenCreationRequest request) throws ApiException, IOException {
        final String path = String.format("%s/%s/%s", PATH, authorizationToken, "customer-token");
        final byte[] data = objectMapper.writeValueAsBytes(request);
        final ApiResponse response = this.post(path, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), PaymentsCustomerTokenCreationResponse.class);
    }

    /**
     * Cancels an existing authorization.
     *
     * @see examples.PaymentsExample.CancelExistingAuthorizationExample
     *
     * @param authorizationToken Authorization token
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public void cancelAuthorization(String authorizationToken) throws ApiException, IOException {
        final ApiResponse response = this.delete(PATH + "/" + authorizationToken);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.NO_CONTENT);
    }
}
