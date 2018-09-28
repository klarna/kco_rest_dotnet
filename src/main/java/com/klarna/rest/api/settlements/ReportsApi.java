package com.klarna.rest.api.settlements;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.settlements.PayoutSummary;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.Map;

public class ReportsApi extends BaseApi {
    protected String PATH = "/settlements/v1/reports";

    public ReportsApi(final Transport transport) {
        super(transport);
    }

    public String getCSVPayoutReport(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payout-with-transactions", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("text/csv");

        return response.getBody();
    }

    public String getCSVSummary(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payouts-summary-with-transactions", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("text/csv");

        return response.getBody();
    }

    public String getPDFPayoutsSummaryReport(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payout", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("application/pdf");

        return response.getBody();
    }

    public String getPDFSummary(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payouts-summary", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("application/pdf");

        return response.getBody();
    }
}
