package com.klarna.rest.api.payments;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.payments.*;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

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
