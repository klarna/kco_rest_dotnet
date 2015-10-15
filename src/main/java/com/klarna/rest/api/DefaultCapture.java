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

import com.klarna.rest.api.model.CaptureData;
import com.klarna.rest.api.model.request.AddShippingInfo;
import com.klarna.rest.api.model.request.UpdateCustomerDetails;
import com.sun.jersey.api.client.ClientResponse.Status;
import com.sun.jersey.api.client.WebResource;

import java.net.URI;

import static javax.ws.rs.core.HttpHeaders.LOCATION;

/**
 * Capture resource.
 */
/* package */ class DefaultCapture extends BaseResource implements Capture {

    /**
     * Constructs a capture resource instance.
     *
     * @param parent Parent order resource
     */
    /* package */ DefaultCapture(final WebResource parent) {
        this.setWebResource(parent.path(PATH));
    }

    @Override
    public void create(final CaptureData data) {
        ApiResponse response = this.post(data);
        String url = response.andExpect(Status.CREATED)
                .getHeaders().getFirst(LOCATION);

        response.close();

        this.setWebResource(this.getWebResource().uri(URI.create(url)));
    }

    @Override
    public CaptureData fetch() {
        return this.get()
                .andExpect(Status.OK)
                .getEntity(CaptureData.class);
    }

    @Override
    public void triggerSendout() {
        this.post("trigger-send-out", null)
                .andExpect(Status.NO_CONTENT)
                .close();
    }

    @Override
    public void updateCustomerDetails(final UpdateCustomerDetails data) {
        this.patch("customer-details", data)
                .andExpect(Status.NO_CONTENT)
                .close();
    }

    @Override
    public void addShippingInfo(final AddShippingInfo info) {
        this.post("shipping-info", info)
                .andExpect(Status.NO_CONTENT)
                .close();
    }
}
