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

package com.klarna.rest;

import java.io.IOException;
import java.net.URI;


/**
 * General interface for an HTTP transport.
 */
public interface Transport {
    /**
     * API library client version.
     */
    String VERSION = "3.0.0";

    /**
     * API library default user agent.
     */
    String USER_AGENT = "Klarna.kco_rest_java";

    /**
     * API base URL for Europe.
     */
    URI EU_BASE_URL = URI.create("https://api.klarna.com");

    /**
     * Testing API base URL for Europe.
     */
    URI EU_TEST_BASE_URL = URI.create("https://api.playground.klarna.com");

    /**
     * API base URL for North America.
     */
    URI NA_BASE_URL = URI.create("https://api-na.klarna.com");

    /**
     * Testing API base URL for North America.
     */
    URI NA_TEST_BASE_URL = URI.create("https://api-na.playground.klarna.com");

    ApiResponse get(final String path) throws ApiException, ProtocolException, IOException;

    ApiResponse post(final String path, final byte[] data) throws ApiException, ProtocolException, IOException;

    ApiResponse put(final String path, final byte[] data) throws ApiException, ProtocolException, IOException;

    ApiResponse patch(final String path, final byte[] data) throws ApiException, ProtocolException, IOException;

    ApiResponse delete(final String path) throws ApiException, ProtocolException, IOException;
}
