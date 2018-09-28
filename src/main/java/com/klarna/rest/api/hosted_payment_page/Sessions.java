package com.klarna.rest.api.hosted_payment_page;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.hosted_payment_page.DistributionRequestV1;
import com.klarna.rest.model.hosted_payment_page.SessionRequestV1;
import com.klarna.rest.model.hosted_payment_page.SessionResponseV1;
import com.klarna.rest.model.hosted_payment_page.SessionStatusResponseV1;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

public class Sessions extends BaseApi {
    protected String PATH = "/hpp/v1/sessions";

    public Sessions(final Transport transport) {
        super(transport);
    }

    public SessionResponseV1 create(SessionRequestV1 session)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(session);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SessionResponseV1.class);
    }

    public void distributeLink(String sessionId, DistributionRequestV1 request)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, sessionId, "distribution");
        final byte[] data = objectMapper.writeValueAsBytes(request);
        final ApiResponse response = this.post(path, data);

        response.validator()
                .expectStatusCode(Response.Status.OK);
    }

    public SessionStatusResponseV1 getStatus(String sessionId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s/%s", PATH, sessionId, "status");
        final ApiResponse response = this.get(path);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SessionStatusResponseV1.class);
    }
}
