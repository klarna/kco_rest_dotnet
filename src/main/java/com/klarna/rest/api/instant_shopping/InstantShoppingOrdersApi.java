/*
 * Copyright 2019 Klarna AB
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

package com.klarna.rest.api.instant_shopping;

import com.klarna.rest.api.BaseApi;
import com.klarna.rest.api.instant_shopping.model.*;
import com.klarna.rest.api.order_management.OrderManagementOrdersApi;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

/**
 * The Instant Shopping API is serving two purposes:
 *
 * <ol>
 *    <li>to manage the orders as they result from the Instant Shopping purchase flow</li>
 *    <li>to generate Instant Shopping Button keys necessary for setting up the Instant Shopping
 *    flow both onsite and offsite</li>
 * </ol>
 *
 * Note that as soon as a purchase initiated through Instant Shopping is completed within Klarna,
 * the order should be read and handled using the {@link OrderManagementOrdersApi Order Management API}.
 */
public class InstantShoppingOrdersApi extends BaseApi {
    protected String PATH = "/instantshopping/v1/authorizations";

    protected String authorizationToken;

    public InstantShoppingOrdersApi(final HttpTransport transport, String authorizationToken) {
        super(transport);
        this.authorizationToken = authorizationToken;
        this.PATH += "/" + authorizationToken;
    }

    /**
     * Retrieves an authorized order based on the authorization token.
     *
     * @see examples.InstantShoppingExample.RertieveOrderExample
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public InstantShoppingMerchantGetOrderResponseV1 retrieveAuthorizedOrder()
            throws ApiException, IOException {
        final ApiResponse response = this.get(PATH);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), InstantShoppingMerchantGetOrderResponseV1.class);
    }

    /**
     * Declines an authorized order identified by the authorization token.
     *
     * @see examples.InstantShoppingExample.DeclineOrderExample
     *
     * @param declineReason the reason, why order was declined
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public void declineAuthorizedOrder(InstantShoppingMerchantDeclineOrderRequestV1 declineReason)
            throws ApiException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(declineReason);
        final ApiResponse response = this.delete(PATH, data, null);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.NO_CONTENT);
    }

    /**
     * Approves the authorized order and places an order identified by the authorization token.
     *
     * @see examples.InstantShoppingExample.ApproveOrderExample
     *
     * @param createOrderRequest data to be send to server
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public InstantShoppingMerchantCreateOrderResponseV1 approveAuthorizedOrder(InstantShoppingMerchantCreateOrderRequestV1 createOrderRequest)
            throws ApiException, IOException {
        final String path = String.format("%s/%s", PATH, "orders");
        final byte[] data = objectMapper.writeValueAsBytes(createOrderRequest);
        final ApiResponse response = this.post(path, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), InstantShoppingMerchantCreateOrderResponseV1.class);
    }
}
