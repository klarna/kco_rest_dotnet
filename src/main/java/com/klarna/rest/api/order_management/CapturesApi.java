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

import com.fasterxml.jackson.core.type.TypeReference;
import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.order_management.Capture;
import com.klarna.rest.model.order_management.CaptureObject;
import com.klarna.rest.model.order_management.ShippingInfo;


import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import java.io.IOException;
import java.util.List;

/**
 * Order Management API: Captures resource.
 *
 * The Order Management API is used for handling an order after the customer has completed the purchase.
 * It is used for updating, capturing and refunding an order as well as to see the history of events that
 * have affected this order.
 */
public class CapturesApi extends BaseApi {
    protected String PATH;

    /**
     * Creates a Captures resource.
     *
     * @param transport HTTP Transport
     * @param orderId Order id
     */
    public CapturesApi(final Transport transport, String orderId) {
        super(transport);

        this.PATH = String.format("/ordermanagement/v1/orders/%s/captures", orderId);
    }

    /**
     * Gets one capture.
     *
     * @param captureId Capture id
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public Capture fetch(String captureId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format(PATH + "/" + captureId);
        final ApiResponse response = this.get(path);

        response.expectSuccessful()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Capture.class);
    }

    /**
     * Gets all captures for one order.
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public Capture[] fetch() throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format(PATH);
        final ApiResponse response = this.get(path);

        response.expectSuccessful()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), new TypeReference<List<Capture>>() {});
    }

    /**
     * Creates capture.
     *
     * @param capture Capture data
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public void create(CaptureObject capture) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(capture);
        final ApiResponse response = this.post(PATH, data);

        response.expectSuccessful()
                .expectStatusCode(Status.CREATED);
    }

    /**
     * Triggers resend of customer communication.
     *
     * @param captureId Capture ID
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public void triggerSendout(String captureId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, captureId, "trigger-send-out");
        final ApiResponse response = this.post(path, null);

        response.expectSuccessful()
                .expectStatusCode(Status.NO_CONTENT);
    }

    /**
     * Adds shipping info to a capture.
     *
     * @param captureId Capture ID
     * @param shippingInfo Shipping details
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public void addShippingInfo(String captureId, ShippingInfo shippingInfo) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, captureId, "shipping-info");
        final byte[] data = objectMapper.writeValueAsBytes(shippingInfo);
        final ApiResponse response = this.post(path, data);

        response.expectSuccessful()
                .expectStatusCode(Status.NO_CONTENT);
    }
}
