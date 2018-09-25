package com.klarna.rest.api.ordermanagement;

import com.fasterxml.jackson.core.type.TypeReference;
import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.order_management.Capture;
import com.klarna.rest.model.order_management.CaptureObject;
import com.klarna.rest.model.order_management.ShippingInfo;


import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import java.io.IOException;
import java.util.List;

public class CapturesApi extends BaseApi {
    protected String PATH;

    public CapturesApi(final Transport transport, String orderId) {
        super(transport);
        this.setObjectMapper(new JacksonMapper());

        this.PATH = String.format("/ordermanagement/v1/orders/%s/captures", orderId);
    }

    public Capture get(String captureId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format(PATH + "/" + captureId);
        final ApiResponse response = transport.get(path);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Capture.class);
    }

    public Capture[] get() throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format(PATH);
        final ApiResponse response = transport.get(path);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), new TypeReference<List<Capture>>() {});
    }

    public void create(CaptureObject refund) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(refund);
        final ApiResponse response = transport.post(PATH, data);

        response.validator()
                .expectStatusCode(Status.CREATED);
    }

    public void triggerSendout(String captureId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, captureId, "trigger-send-out");
        final ApiResponse response = transport.post(path, null);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }

    public void addShippingInfo(String captureId, ShippingInfo shippingInfo) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, captureId, "shipping-info");
        final byte[] data = objectMapper.writeValueAsBytes(shippingInfo);
        final ApiResponse response = transport.post(path, data);

        response.validator()
                .expectStatusCode(Status.NO_CONTENT);
    }
}
