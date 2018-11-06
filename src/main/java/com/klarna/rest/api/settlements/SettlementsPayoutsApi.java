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

import com.klarna.rest.api.BaseApi;
import com.klarna.rest.api.settlements.model.SettlementsPayout;
import com.klarna.rest.api.settlements.model.SettlementsPayoutCollection;
import com.klarna.rest.api.settlements.model.SettlementsPayoutSummary;
import com.klarna.rest.http_transport.Transport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;
import com.klarna.rest.model.ContentTypeException;
import com.klarna.rest.model.ProtocolException;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.Map;

/**
 * Settlements API: Payouts resource.
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
public class SettlementsPayoutsApi extends BaseApi {
    protected String PATH = "/settlements/v1/payouts";

    public SettlementsPayoutsApi(final Transport transport) {
        super(transport);
    }

    /**
     * Returns a specific payout based on a given payment reference.
     *
     * @see examples.SettlementsExample.PayoutFetchExample
     *
     * @param paymentReference The reference id of the payout
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public SettlementsPayout getPayout(String paymentReference) throws ApiException, IOException {
        final ApiResponse response = this.get(PATH + "/" + paymentReference);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), SettlementsPayout.class);
    }

    /**
     * Returns a collection of payouts.
     *
     * @see examples.SettlementsExample.PayoutFetchAllExample
     * @see <a href="https://developers.klarna.com/api/#settlements-api-get-all-payouts">URL params</a>
     *
     * @param urlParams extra URL params
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public SettlementsPayoutCollection getAllPayouts(Map<String, String> urlParams) throws ApiException, IOException {
        final ApiResponse response = this.get(PATH + "?" + BaseApi.buildQueryString(urlParams));
        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), SettlementsPayoutCollection.class);
    }

    /**
     * Returns a collection of payouts.
     *
     * @see examples.SettlementsExample.PayoutFetchAllExample
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public SettlementsPayoutCollection getAllPayouts() throws ApiException, IOException {
        return this.getAllPayouts(null);
    }

    /**
     * Returns a summary of payouts for each currency code in a date range.
     *
     * @see examples.SettlementsExample.PayoutGetSummaryExample
     * @see <a href="https://developers.klarna.com/api/#settlements-api-get-summary-of-payouts">URL params</a>
     *
     * @param urlParams extra URL params.
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public SettlementsPayoutSummary[] getSummary(Map<String, String> urlParams) throws ApiException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "summary", BaseApi.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), SettlementsPayoutSummary[].class);
    }
}
