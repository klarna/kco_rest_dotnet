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

package com.klarna.rest.api.customer_token;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.customer_token.CustomerTokenOrder;
import com.klarna.rest.model.customer_token.CustomerTokenV1;
import com.klarna.rest.model.customer_token.Order;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

/**
 * Customer Token API: Tokens resource.
 *
 * The Customer Token API is used to charge customers with a tokenized Klarna payment method and can be used for
 * recurring purchases, subscriptions and for storing a customer's payment method. Tokens are created using
 * the generate a customer token call in the {@link com.klarna.rest.api.payments.OrdersApi PaymentAPI}.
 */
public class TokensApi extends BaseApi {
    protected String PATH;

    public TokensApi(final Transport transport, String customerToken) {
        super(transport);

        this.PATH = String.format("/customer-token/v1/tokens/%s", customerToken);
    }

    /**
     * Reads customer tokens details.
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public CustomerTokenV1 fetchDetails()
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), CustomerTokenV1.class);
    }

    /**
     * Creates a new order using the customer token.
     *
     * @param order Order details
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Order createOrder(CustomerTokenOrder order)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = this.post(PATH + "/order", data);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }
}
