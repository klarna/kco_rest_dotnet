package com.klarna.rest.api.customer_token;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.customer_token.CustomerTokenOrder;
import com.klarna.rest.model.customer_token.CustomerTokenV1;
import com.klarna.rest.model.customer_token.Order;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

public class TokensApi extends BaseApi {
    protected String PATH;

    public TokensApi(final Transport transport, String customerToken) {
        super(transport);

        this.PATH = String.format("/customer-token/v1/tokens/%s", customerToken);
    }

    public CustomerTokenV1 fetchDetails()
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), CustomerTokenV1.class);
    }

    public Order createOrder(CustomerTokenOrder order)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = this.post(PATH + "/order", data);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }
}
