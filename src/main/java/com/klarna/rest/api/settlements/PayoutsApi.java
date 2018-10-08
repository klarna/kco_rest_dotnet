/*
 * Copyright 2014 Klarna AB
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
import com.klarna.rest.model.settlements.Payout;
import com.klarna.rest.model.settlements.PayoutCollection;
import com.klarna.rest.model.settlements.PayoutSummary;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.Map;

public class PayoutsApi extends BaseApi {
    protected String PATH = "/settlements/v1/payouts";

    public PayoutsApi(final Transport transport) {
        super(transport);
    }

    public Payout getPayout(String paymentReference)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + "/" + paymentReference);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Payout.class);
    }

    public PayoutCollection getAllPayout(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + "?" + this.buildQueryString(urlParams));
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), PayoutCollection.class);
    }

    public PayoutCollection getAllPayout()
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        return this.getAllPayout(null);
    }

    public PayoutSummary[] getSummary(Map<String, String> urlParams)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final String path = String.format("%s/%s?%s", PATH, "summary", this.buildQueryString(urlParams));
        final ApiResponse response = this.get(path);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), PayoutSummary[].class);
    }
}
