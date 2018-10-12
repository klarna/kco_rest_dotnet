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
import java.util.Map;


/**
 * General interface for an HTTP transport.
 *
 * @see HttpUrlConnectionTransport Default HTTP transport based on HttpURLConnection.
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

    /**
     * Sends HTTP GET request to specified path.
     *
     * @param path URL path.
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    ApiResponse get(final String path, Map<String, String> headers) throws ApiException, ProtocolException, IOException;

    /**
     * Sends HTTP POST request to specified path.
     *
     * @param path URL path.
     * @param data Data to be sent to API server in a payload.
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    ApiResponse post(final String path, final byte[] data, Map<String, String> headers) throws ApiException, ProtocolException, IOException;

    /**
     * Sends HTTP PUT request to specified path.
     *
     * @param path URL path.
     * @param data Data to be sent to API server in a payload.
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    ApiResponse put(final String path, final byte[] data, Map<String, String> headers) throws ApiException, ProtocolException, IOException;

    /**
     * Sends HTTP PATCH request to specified path.
     *
     * @param path URL path.
     * @param data Data to be sent to API server in a payload.
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    ApiResponse patch(final String path, final byte[] data, Map<String, String> headers) throws ApiException, ProtocolException, IOException;

    /**
     * Sends HTTP DELETE request to specified path.
     *
     * @param path URL path.
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    ApiResponse delete(final String path, Map<String, String> headers) throws ApiException, ProtocolException, IOException;
}
