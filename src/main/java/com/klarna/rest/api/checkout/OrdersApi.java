package com.klarna.rest.api.checkout;

import com.klarna.rest.Transport;
import com.klarna.rest.api.ApiException;
import com.klarna.rest.api.ApiResponse;
import com.klarna.rest.api.ContentTypeException;
import com.klarna.rest.api.ProtocolException;
import com.klarna.rest.model.checkout.Order;

import javax.ws.rs.core.Response.Status;
import javax.ws.rs.core.MediaType;

import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;


public class OrdersApi {
    String PATH = "/checkout/v3/orders";

    private Transport transport;
    private ObjectMapper objectMapper;

    public OrdersApi(final Transport transport) {
        this.transport = transport;
        this.objectMapper = new ObjectMapper();
    }

    public Order create(Order order) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = transport.post(PATH, order);

        response
                .expectStatusCode(Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

}
