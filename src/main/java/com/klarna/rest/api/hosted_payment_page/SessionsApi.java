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

package com.klarna.rest.api.hosted_payment_page;

import com.klarna.rest.api.BaseApi;
import com.klarna.rest.api.hosted_payment_page.model.HPPDistributionRequestV1;
import com.klarna.rest.api.hosted_payment_page.model.HPPSessionCreationRequestV1;
import com.klarna.rest.api.hosted_payment_page.model.HPPSessionCreationResponseV1;
import com.klarna.rest.api.hosted_payment_page.model.HPPSessionResponseV1;
import com.klarna.rest.http_transport.Transport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;
import com.klarna.rest.model.ContentTypeException;
import com.klarna.rest.model.ProtocolException;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

/**
 * Hosted Payment Page API: Sessions resource.
 *
 * Hosted Payment Page (HPP) API is a service that lets you integrate Klarna Payments without the need of
 * hosting the web page that manages the client side of Klarna Payments.
 *
 * A complete HPP payment session will involve three of Klarna services:
 *
 * <ul>
 *  <li>{@link com.klarna.rest.api.payments.OrdersApi Klarna Payments API} to start a payment session.</li>
 *  <li>{@link SessionsApi Hosted Payment Page API} to distribute a payment session.</li>
 *  <li>{@link com.klarna.rest.api.order_management.OrdersApi Order Management API}
 *      to capture payment or refund consumer.</li>
 * </ul>
 */
public class SessionsApi extends BaseApi {
    protected String PATH = "/hpp/v1/sessions";

    public SessionsApi(final Transport transport) {
        super(transport);
    }

    /**
     * Creates a new HPP session.
     *
     * @see examples.HostedPaymentPageExample.CreateHPPSessionExample
     *
     * @param session Session data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public HPPSessionCreationResponseV1 create(HPPSessionCreationRequestV1 session) throws ApiException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(session);
        final ApiResponse response = this.post(PATH, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), HPPSessionCreationResponseV1.class);
    }

    /**
     * Distributes a link to the HPP session.
     *
     * @see examples.HostedPaymentPageExample.DistributeLinkToHPPSessionExample
     *
     * @param sessionId HPP session id
     * @param request Session data
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public void distributeLink(String sessionId, HPPDistributionRequestV1 request) throws ApiException, IOException {
        final String path = String.format("%s/%s/%s", PATH, sessionId, "distribution");
        final byte[] data = objectMapper.writeValueAsBytes(request);
        final ApiResponse response = this.post(path, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK);
    }

    /**
     * Gets HPP session status.
     *
     * @see examples.HostedPaymentPageExample.GetHPPSessionExample
     *
     * @param sessionId HPP session id
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public HPPSessionResponseV1 fetch(String sessionId) throws ApiException, IOException {
        final String path = String.format("%s/%s", PATH, sessionId);
        final ApiResponse response = this.get(path);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), HPPSessionResponseV1.class);
    }
}
