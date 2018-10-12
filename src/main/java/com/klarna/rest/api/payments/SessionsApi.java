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

package com.klarna.rest.api.payments;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.checkout.Order;
import com.klarna.rest.model.payments.MerchantSession;
import com.klarna.rest.model.payments.Session;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

/**
 * Payments API: Sessions resource.
 *
 * The payments API is used to create a session to offer Klarna's payment methods as part of your checkout.
 *
 * As soon as the purchase is completed the order should be read and handled using the
 * {@link com.klarna.rest.api.order_management.OrdersApi Order Management API}.
 */
public class SessionsApi extends BaseApi {
    protected String PATH = "/payments/v1/sessions";

    public SessionsApi(final Transport transport) {
        super(transport);
    }

    /**
     * Creates a new credit session.
     *
     * @param session
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public MerchantSession create(Session session)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(session);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), MerchantSession.class);
    }

    /**
     * Reads an existing credit session.
     *
     * @param sessionId Session ID
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Session fetch(String sessionId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + '/' + sessionId);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Session.class);
    }

    /**
     * Updates an existing credit session.
     *
     * @param sessionId Session ID
     * @param session Session information
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public void update(String sessionId, Session session)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(session);
        final ApiResponse response = this.post(PATH + '/' + sessionId, data);

        response.validator()
                .expectStatusCode(Response.Status.NO_CONTENT);
    }
}
