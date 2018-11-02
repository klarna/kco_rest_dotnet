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
import com.klarna.rest.api.settlements.model.SettlementsTransactionCollection;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.Map;

/**
 * Settlements API: Transactions resource.
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
public class TransactionsApi extends BaseApi {
    protected String PATH = "/settlements/v1/transactions";

    public TransactionsApi(final Transport transport) {
        super(transport);
    }

    /**
     * Returns a collection of transactions.
     *
     * @see <a href="https://developers.klarna.com/api/#settlements-api-get-transactions">URL params</a>
     *
     * @param urlParams extra URL params
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public SettlementsTransactionCollection getTransactions(Map<String, String> urlParams)
        throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + "?" + BaseApi.buildQueryString(urlParams));
        response.expectSuccessful()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), SettlementsTransactionCollection.class);
    }

    /**
     * Returns a collection of transactions.
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred when connecting to the server or when parsing a response
     */
    public SettlementsTransactionCollection getTransactions()
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        return this.getTransactions(null);
    }
}
