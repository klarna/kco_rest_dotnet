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
import com.klarna.rest.model.order_management.Order;
import com.klarna.rest.model.order_management.UpdateAuthorization;
import com.klarna.rest.model.order_management.UpdateConsumer;
import com.klarna.rest.model.order_management.UpdateMerchantReferences;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import java.io.IOException;

public class OrdersApi extends BaseApi {
    protected String PATH = "/order_management/v1/orders";

    public OrdersApi(final Transport transport) {
        super(transport);
    }

    public Order fetch(String orderId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + '/' + orderId);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    public void releaseRemainingAuthorization(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "release-remaining-authorization");
        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void extendAuthorizationTime(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "extend-authorization-time");
        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void updateCustomerAddresses(String orderId, UpdateConsumer customerAddress)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "customer-details");
        final byte[] data = objectMapper.writeValueAsBytes(customerAddress);

        final ApiResponse response = this.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void cancelOrder(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "cancel");

        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void updateMerchantReferences(String orderId, UpdateMerchantReferences references)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "merchant-references");
        final byte[] data = objectMapper.writeValueAsBytes(references);
        final ApiResponse response = this.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void acknowledgeOrder(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "acknowledge");
        final ApiResponse response = this.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void setOrderAmountAndOrderLines(String orderId, UpdateAuthorization orderData)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "authorization");
        final byte[] data = objectMapper.writeValueAsBytes(orderData);
        final ApiResponse response = this.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }
}
