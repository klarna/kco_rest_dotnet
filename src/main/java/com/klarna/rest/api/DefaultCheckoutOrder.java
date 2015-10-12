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

import com.klarna.rest.api.model.CheckoutOrderData;
import com.sun.jersey.api.client.ClientResponse.Status;
import com.sun.jersey.api.client.WebResource;

import java.net.URI;

import static javax.ws.rs.core.HttpHeaders.LOCATION;

/**
 * Checkout order resource for the checkout API.
 */
/* package */ class DefaultCheckoutOrder extends BaseResource
        implements CheckoutOrder {

    /**
     * Constructs a checkout order resource instance.
     *
     * @param root Base url for the resource
     */
    /* package */ DefaultCheckoutOrder(final WebResource root) {
        this.setWebResource(root.path(PATH));
    }

    /**
     * Constructs a checkout order resource instance with an ID.
     *
     * @param root Base url for the resource
     * @param checkoutOrderId The resource id
     */
    /* package */ DefaultCheckoutOrder(
            final WebResource root, final String checkoutOrderId) {
        this.setWebResource(root.path(PATH).path(checkoutOrderId));
    }

    @Override
    public CheckoutOrderData fetch() {
        return this.get()
                .andExpect(Status.OK)
                .getEntity(CheckoutOrderData.class);
    }

    @Override
    public void create(final CheckoutOrderData data) {
        ApiResponse response = this.post(data);
        String url = response.andExpect(Status.CREATED)
                .getHeaders().getFirst(LOCATION);

        response.close();

        this.setWebResource(this.getWebResource().uri(URI.create(url)));
    }

    @Override
    public CheckoutOrderData update(final CheckoutOrderData data) {
        return this.post(data)
                .andExpect(Status.OK)
                .getEntity(CheckoutOrderData.class);
    }
}
