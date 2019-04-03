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

package com.klarna.rest.api.merchant_card_service;

import com.klarna.rest.api.BaseApi;
import com.klarna.rest.api.merchant_card_service.model.*;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

/**
 * Merchant Card Service API: Virtual credit card Promise resource.
 *
 * The Merchant Card Service (MCS) API is used to settle orders with virtual credit cards.
 */
public class VirtualCreditCardPromisesApi extends BaseApi {
    protected String PATH = "/merchantcard/v3/promises";

    public VirtualCreditCardPromisesApi(final HttpTransport transport) {
        super(transport);
    }

    /**
     * Creates a new promise.
     *
     * To create promise provide a purchase currency and the cards to be created. The old promise is automatically
     * invalidated if a new promise is created for an order.
     *
     * @see examples.MerchantCardServiceExample.CreatePromiseExample
     *
     * @param promise Promise data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public CardServicePromiseCreatedResponse createPromise(final CardServicePromiseRequest promise)
            throws ApiException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(promise);
        final ApiResponse response = this.post(PATH, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), CardServicePromiseCreatedResponse.class);
    }

    /**
     * Retrieves an existing promise.
     *
     * @see examples.MerchantCardServiceExample.RetrieveExistingPromiseExample
     *
     * @param promiseId Unique promise identifier
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public CardServicePromiseResponse retrievePromise(final String promiseId)
            throws ApiException, IOException {
        final ApiResponse response = this.get(PATH + "/" + promiseId);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), CardServicePromiseResponse.class);
    }
}
