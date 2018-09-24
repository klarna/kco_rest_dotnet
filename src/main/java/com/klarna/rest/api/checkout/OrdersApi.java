package com.klarna.rest.api.checkout;

import com.klarna.rest.Transport;
import com.klarna.rest.ApiException;
import com.klarna.rest.ApiResponse;
import com.klarna.rest.ContentTypeException;
import com.klarna.rest.ProtocolException;
import com.klarna.rest.JacksonMapper;
import com.klarna.rest.api.BaseApi;

import com.klarna.rest.model.checkout.Order;

import javax.ws.rs.core.Response.Status;
import javax.ws.rs.core.MediaType;

import java.io.IOException;

public class OrdersApi extends BaseApi {
    String PATH = "/checkout/v3/orders";

    public OrdersApi(final Transport transport) {
        super(transport);
        this.setObjectMapper(new JacksonMapper());
    }

    public Order create(Order order) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = transport.post(PATH, data);

        response.validator()
                .expectStatusCode(Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    public Order get(String orderId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = transport.get(PATH + '/' + orderId);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    public Order update(String orderId, Order order) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = transport.post(PATH + '/' + orderId, data);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }
}
