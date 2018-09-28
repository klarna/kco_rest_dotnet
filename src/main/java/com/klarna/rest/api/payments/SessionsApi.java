package com.klarna.rest.api.payments;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.checkout.Order;
import com.klarna.rest.model.payments.MerchantSession;
import com.klarna.rest.model.payments.Session;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

public class SessionsApi extends BaseApi {
    protected String PATH = "/payments/v1/sessions";

    public SessionsApi(final Transport transport) {
        super(transport);
    }

    public MerchantSession create(Session session)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(session);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), MerchantSession.class);
    }

    public Session fetch(String sessionId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + '/' + sessionId);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Session.class);
    }

    public void update(String sessionId, Session session)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(session);
        final ApiResponse response = this.post(PATH + '/' + sessionId, data);

        response.validator()
                .expectStatusCode(Response.Status.NO_CONTENT);
    }
}
