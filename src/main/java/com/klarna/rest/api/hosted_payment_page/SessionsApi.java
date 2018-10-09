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

package com.klarna.rest.api.hosted_payment_page;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.hosted_payment_page.DistributionRequestV1;
import com.klarna.rest.model.hosted_payment_page.SessionRequestV1;
import com.klarna.rest.model.hosted_payment_page.SessionResponseV1;
import com.klarna.rest.model.hosted_payment_page.SessionStatusResponseV1;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

/**
 * Hosted Payment Page API: Sessions resource.
 */
public class SessionsApi extends BaseApi {
    protected String PATH = "/hpp/v1/sessions";

    public SessionsApi(final Transport transport) {
        super(transport);
    }

    public SessionResponseV1 create(SessionRequestV1 session)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(session);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SessionResponseV1.class);
    }

    public void distributeLink(String sessionId, DistributionRequestV1 request)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, sessionId, "distribution");
        final byte[] data = objectMapper.writeValueAsBytes(request);
        final ApiResponse response = this.post(path, data);

        response.validator()
                .expectStatusCode(Response.Status.OK);
    }

    public SessionStatusResponseV1 getStatus(String sessionId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, sessionId, "status");
        final ApiResponse response = this.get(path);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SessionStatusResponseV1.class);
    }
}
