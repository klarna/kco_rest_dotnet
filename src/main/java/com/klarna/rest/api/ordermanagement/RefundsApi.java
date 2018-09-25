package com.klarna.rest.api.ordermanagement;

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
        this.setObjectMapper(new JacksonMapper());

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
}
