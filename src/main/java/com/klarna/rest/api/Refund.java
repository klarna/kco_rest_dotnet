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


/**
 * Refund resource interface.
 */
public interface Refund extends Resource {

    /**
     * Path to the refunds endpoint.
     */
    String PATH = "/refunds";

    /**
     * Creates the refund.
     *
     * @param data Resource data
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    void create(final com.klarna.rest.api.model.Refund data) throws ApiException, ProtocolException;

    /**
     * Fetches the data for this refund.
     *
     * @return Data for the resource
     * @throws ApiException If the status is not successful
     * @throws ProtocolException If the response status code is not expected
     */
    com.klarna.rest.api.model.Refund fetch() throws ApiException, ProtocolException;
}
