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

package com.klarna.rest.api.customer_token;

import com.klarna.rest.api.BaseApi;
import com.klarna.rest.api.customer_token.model.TokenCustomerTokenOrder;
import com.klarna.rest.api.customer_token.model.TokenCustomerTokenV1;
import com.klarna.rest.api.customer_token.model.TokenOrder;
import com.klarna.rest.http_transport.Transport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;
import com.klarna.rest.model.ContentTypeException;
import com.klarna.rest.model.ProtocolException;

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
     * @see examples.CustomerTokenExample.ReadTokenDetailsExample
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public TokenCustomerTokenV1 fetchDetails() throws ApiException, IOException {
        final ApiResponse response = this.get(PATH);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), TokenCustomerTokenV1.class);
    }

    /**
     * Creates a new order using the customer token.
     *
     * @see examples.CustomerTokenExample.CreateOrderExample
     *
     * @param order Order details
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public TokenOrder createOrder(TokenCustomerTokenOrder order) throws ApiException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = this.post(PATH + "/order", data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), TokenOrder.class);
    }
}
