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

package com.klarna.rest.api;

import com.klarna.rest.api.model.OrderData;
import com.klarna.rest.api.model.Refund;
import com.klarna.rest.api.model.request.UpdateAuthorization;
import com.klarna.rest.api.model.request.UpdateCustomerDetails;
import com.klarna.rest.api.model.request.UpdateMerchantReferences;
import com.sun.jersey.api.client.ClientResponse.Status;
import com.sun.jersey.api.client.WebResource;

/**
 * Order resource for the order management API.
 */
/* package */ class DefaultOrder extends BaseResource implements Order {

    /**
     * Constructs a order resource instance.
     *
     * @param root Base url for the resource
     * @param orderId The resource id
     */
    /* package */ DefaultOrder(final WebResource root, final String orderId) {
        this.setWebResource(root.path(PATH).path(orderId));
    }

    @Override
    public OrderData fetch() {
        return this.get()
                .andExpect(Status.OK)
                .getEntity(OrderData.class);
    }

    @Override
    public void acknowledge() {
        this.post("acknowledge", null)
                .andExpect(Status.NO_CONTENT);
    }

    @Override
    public void cancel() {
        this.post("cancel", null)
                .andExpect(Status.NO_CONTENT);
    }

    @Override
    public void extendAuthorizationTime() {
        this.post("extend-authorization-time", null)
                .andExpect(Status.NO_CONTENT);
    }

    @Override
    public void releaseRemainingAuthorization() {
        this.post("release-remaining-authorization", null)
                .andExpect(Status.NO_CONTENT);
    }

    @Override
    public void refund(final Refund data) {
        this.post("refunds", data)
                .andExpect(Status.NO_CONTENT);
    }

    @Override
    public void updateCustomerDetails(final UpdateCustomerDetails data) {
        this.patch("customer-details", data)
                .andExpect(Status.NO_CONTENT);
    }

    @Override
    public void updateMerchantReferences(final UpdateMerchantReferences data) {
        this.patch("merchant-references", data)
                .andExpect(Status.NO_CONTENT);
    }

    @Override
    public void updateAuthorization(final UpdateAuthorization data) {
        this.patch("authorization", data)
                .andExpect(Status.NO_CONTENT);
    }
}
