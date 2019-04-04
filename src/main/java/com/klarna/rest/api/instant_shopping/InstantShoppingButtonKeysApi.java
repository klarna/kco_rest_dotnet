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
public class InstantShoppingButtonKeysApi extends BaseApi {
    protected String PATH = "/instantshopping/v1/buttons";

    public InstantShoppingButtonKeysApi(final HttpTransport transport) {
        super(transport);
    }

    /**
     * Creates a button key based on setup options.
     *
     * @see examples.InstantShoppingExample.CreateButtonKeyExample
     *
     * @param options setup options
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public InstantShoppingButtonSetupOptionsV1 createButtonKey(InstantShoppingButtonSetupOptionsV1 options)
            throws ApiException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(options);
        final ApiResponse response = this.post(PATH, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), InstantShoppingButtonSetupOptionsV1.class);
    }

    /**
     * Updates the setup options for a specific button key.
     *
     * @see examples.InstantShoppingExample.UpdateButtonKeyExample
     *
     * @param options setup options
     * @param buttonKey button identifier
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public InstantShoppingButtonSetupOptionsV1 updateButtonKey(String buttonKey, InstantShoppingButtonSetupOptionsV1 options)
            throws ApiException, IOException {
        final String path = String.format("%s/%s", PATH, buttonKey);
        final byte[] data = objectMapper.writeValueAsBytes(options);
        final ApiResponse response = this.put(path, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), InstantShoppingButtonSetupOptionsV1.class);
    }

    /**
     * Fetches the setup options for a specific button key.
     *
     * @see examples.InstantShoppingExample.FetchButtonKeyExample
     *
     * @param buttonKey button identifier
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public InstantShoppingButtonSetupOptionsV1 updateButtonKey(String buttonKey)
            throws ApiException, IOException {
        final String path = String.format("%s/%s", PATH, buttonKey);
        final ApiResponse response = this.get(path);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), InstantShoppingButtonSetupOptionsV1.class);
    }
}
