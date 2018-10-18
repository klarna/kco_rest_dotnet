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

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.merchant_card_service.SettlementRequest;
import com.klarna.rest.model.merchant_card_service.SettlementResponse;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

/**
 * Merchant Card Service API: Virtual credit card resource.
 *
 * The Merchant Card Service (MCS) API is used to settle orders with virtual credit cards.
 */
public class VirtualCreditCardApi extends BaseApi {
    protected String PATH = "/merchantcard/v3/settlements";

    public VirtualCreditCardApi(final Transport transport) {
        super(transport);
    }

    /**
     * Creates a new settlement.
     * To create a settlement resource provide a completed order identifier and (optionally) a promise identifier.
     *
     * @see examples.MerchantCardServiceExample.CreateSettlementExample
     *
     * @param settlement Settlement data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public SettlementResponse createSettlement(SettlementRequest settlement)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(settlement);
        final ApiResponse response = this.post(PATH, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SettlementResponse.class);
    }

    /**
     * Retrieves an existing settlement.
     *
     * @see examples.MerchantCardServiceExample.RetrieveExistingSettlementExample
     *
     * @param settlementId Unique settlement identifier
     * @param keyId Unique identifier for the public key used for encryption of the card data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public SettlementResponse retrieveExistingSettlement(String settlementId, String keyId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        Map<String, String> headers = new HashMap<>();
        headers.put("KeyId", keyId);
        final ApiResponse response = this.get(PATH + "/" + settlementId, headers);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SettlementResponse.class);
    }

    /**
     * Retrieves a settled order's settlement.
     *
     * @see examples.MerchantCardServiceExample.RetriveOrdersSettlementsExample
     *
     * @param orderId Unique identifier for the order associated to the settlement
     * @param keyId Unique identifier for the public key used for encryption of the card data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public SettlementResponse retrieveSettledOrderSettlement(String orderId, String keyId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        Map<String, String> headers = new HashMap<>();
        headers.put("KeyId", keyId);
        final ApiResponse response = this.get(PATH + "/order/" + orderId, headers);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SettlementResponse.class);
    }
}
