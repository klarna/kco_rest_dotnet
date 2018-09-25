package com.klarna.rest.api.ordermanagement;

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
    protected String PATH = "/ordermanagement/v1/orders";

    public OrdersApi(final Transport transport) {
        super(transport);
        this.setObjectMapper(new JacksonMapper());
    }

    public Order get(String orderId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = transport.get(PATH + '/' + orderId);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    public void releaseRemainingAuthorization(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "release-remaining-authorization");
        final ApiResponse response = transport.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void extendAuthorizationTime(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "extend-authorization-time");
        final ApiResponse response = transport.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void updateCustomerAddresses(String orderId, UpdateConsumer customerAddress)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "customer-details");
        final byte[] data = objectMapper.writeValueAsBytes(customerAddress);

        final ApiResponse response = transport.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void cancelOrder(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "cancel");

        final ApiResponse response = transport.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void updateMerchantReferences(String orderId, UpdateMerchantReferences references)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "merchant-references");
        final byte[] data = objectMapper.writeValueAsBytes(references);
        final ApiResponse response = transport.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void acknowledgeOrder(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "acknowledge");
        final ApiResponse response = transport.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void setOrderAmountAndOrderLines(String orderId, UpdateAuthorization orderData)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, orderId, "authorization");
        final byte[] data = objectMapper.writeValueAsBytes(orderData);
        final ApiResponse response = transport.patch(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }
}
