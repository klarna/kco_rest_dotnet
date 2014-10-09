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

/**
 * Capture resource interface.
 */
public interface Capture extends Resource {

    /**
     * Path to the captures endpoint.
     */
    String PATH = "/captures";

    /**
     * Creates the capture.
     *
     * @param data Resource data
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void create(final CaptureData data) throws ApiException, ProtocolException;

    /**
     * Fetches the data for this capture.
     *
     * @return Data for the resource
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    CaptureData fetch() throws ApiException, ProtocolException;

    /**
     * Trigger send outs for this capture.
     *
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void triggerSendout() throws ApiException, ProtocolException;

    /**
     * Updates the customers details.
     *
     * @param data Customer data
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void updateCustomerDetails(UpdateCustomerDetails data) throws
            ApiException, ProtocolException;

    /**
     * Appends shipping information to the capture.
     *
     * @param info Shipping info
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void addShippingInfo(AddShippingInfo info) throws
            ApiException, ProtocolException;
}
