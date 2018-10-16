/*
 * Copyright 2018 Klarna AB
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.klarna.rest.api.settlements;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.settlements.PayoutSummary;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.Map;

/**
 * Settlements API: Reports resource.
 *
 * This API gives you access to your payouts and transactions.
 *
 * Resources are split into two broad types:
 *
 * <ul>
 *  <li>Collections, including pagination information: collections are queryable,
 *      typically by the attributes of the sub-resource as well as pagination</li>
 *  <li>Entity resources containing a single entity</li>
 * </ul>
 */
public class ReportsApi extends BaseApi {
    protected String PATH = "/settlements/v1/reports";

    public ReportsApi(final Transport transport) {
        super(transport);
    }

    /**
     * Gets CSV payout report.
     *
     * More information about this CSV format is available at:
     * <a href="https://developers.klarna.com/en/gb/kco-v3/settlement-files">Settlement-files</a>
     *
     * @see <a href="https://developers.klarna.com/api/#settlements-api-get-csv-payout-report">URL params</a>
     * @see examples.SettlementsExample.GetCSVPayoutReportExample
     *
     * @param urlParams extra URL params
     * @return CSV binary content
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public byte[] getCSVPayoutReport(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payout-with-transactions", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("text/csv");

        return response.getBody();
    }

    /**
     * Gets CSV summary report.
     *
     * More information about this CSV format is available at:
     * <a href="https://developers.klarna.com/en/gb/kco-v3/settlement-files">Settlement-files</a>
     *
     * @see <a href="https://developers.klarna.com/api/#settlements-api-get-csv-summary">URL params</a>
     * @see examples.SettlementsExample.GetCSVSummaryExample
     *
     * @param urlParams extra URL params
     * @return CSV binary content
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public byte[] getCSVSummary(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payouts-summary-with-transactions", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("text/csv");

        return response.getBody();
    }

    /**
     * Gets PDF payout summary report.
     *
     * @see <a href="https://developers.klarna.com/api/#settlements-api-get-pdf-payout-summary-report">URL params</a>
     * @see examples.SettlementsExample.GetPDFPayoutReportExample
     *
     * @param urlParams extra URL params
     * @return PDF binary content
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public byte[] getPDFPayoutsSummaryReport(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payout", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("application/pdf");

        return response.getBody();
    }

    /**
     * Gets PDF summary.
     *
     * @see <a href="https://developers.klarna.com/api/#settlements-api-get-pdf-summary">URL params</a>
     * @see examples.SettlementsExample.GetPDFSummaryExample
     *
     * @param urlParams extra URL params
     * @return PDF binary content
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public byte[] getPDFSummary(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "payouts-summary", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType("application/pdf");

        return response.getBody();
    }
}
