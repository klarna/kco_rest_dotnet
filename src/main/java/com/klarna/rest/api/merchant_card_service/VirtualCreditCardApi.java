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

package com.klarna.rest.api.merchant_card_service;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.checkout.Order;
import com.klarna.rest.model.merchant_card_service.SettlementRequest;
import com.klarna.rest.model.merchant_card_service.SettlementResponse;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;

public class VirtualCreditCardApi extends BaseApi {
    protected String PATH = "/merchantcard/v3/settlements";

    public VirtualCreditCardApi(final Transport transport) {
        super(transport);
    }

    public SettlementResponse createSettlement(SettlementRequest settlement)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(settlement);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SettlementResponse.class);
    }

    public SettlementResponse retrieveExistingSettlement(String settlementId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + "/" + settlementId);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SettlementResponse.class);
    }

    public SettlementResponse retrieveSetteledOrderSettlement(String orderId)
            throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + "/order/" + orderId);

        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), SettlementResponse.class);
    }
}
