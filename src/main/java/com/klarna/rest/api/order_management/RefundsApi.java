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

package com.klarna.rest.api.order_management;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.order_management.Refund;
import com.klarna.rest.model.order_management.RefundObject;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import java.io.IOException;

public class RefundsApi extends BaseApi {
    protected String PATH;

    public RefundsApi(final Transport transport, String orderId) {
        super(transport);

        this.PATH = String.format("/ordermanagement/v1/orders/%s/refunds", orderId);
    }

    public void create(RefundObject refund) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(refund);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Status.CREATED);
    }

    public Refund fetch(String refundId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        ApiResponse response = this.get(PATH + "/" + refundId);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Refund.class);
    }

    public Refund fetch() throws ApiException, ProtocolException, ContentTypeException, IOException {
        if (this.location == null) {
            throw new IOException("Unknown location");
        }
        ApiResponse response = this.get(this.location);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Refund.class);
    }
}
