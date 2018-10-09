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
import com.klarna.rest.model.payments.*;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

/**
 * Payments API: Orders resource.
 */
public class OrdersApi extends BaseApi {
    protected String PATH = "/payments/v1/authorizations";

    public OrdersApi(final Transport transport) {
        super(transport);
    }

    public Order create(String authorizationToken, CreateOrderRequest order)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, authorizationToken, "order");
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = this.post(path, data);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    public CustomerTokenCreationResponse generateToken(String authorizationToken, CustomerTokenCreationRequest request)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, authorizationToken, "customer-token");
        final byte[] data = objectMapper.writeValueAsBytes(request);
        final ApiResponse response = this.post(path, data);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), CustomerTokenCreationResponse.class);
    }

    public void cancelAuthorization(String authorizationToken)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.delete(PATH + "/" + authorizationToken);

        response.validator()
                .expectStatusCode(Response.Status.NO_CONTENT);
    }
}
