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

import com.fasterxml.jackson.databind.ObjectMapper;
import com.klarna.rest.*;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.List;
import java.util.Map;

/**
 * API Resource helper.
 * Simplifies work with HTTP Transport and Logging.
 * @see Transport
 */
public abstract class BaseApi {
    /**
     * Default URL Encoding
     */
    private static final String URL_ENCODING = "UTF-8";

    /**
     * HTTP Transport
     */
    protected Transport transport;

    /**
     * Preferred ObjectMapper
     */
    protected ObjectMapper objectMapper;

    /**
     * Last response instance
     */
    protected ApiResponse lastResponse;

    /**
     * Fetched location from last response
     */
    protected String location;

    public BaseApi(Transport transport) {
        this.transport = transport;
        this.objectMapper = new DefaultMapper();
    }

    public void setObjectMapper(ObjectMapper objectMapper) {
        this.objectMapper = objectMapper;
    }

    public ApiResponse getLastResponse() {
        return lastResponse;
    }

    /**
     * Convers Map to URL Query string.
     *
     * @param params Params map
     * @return HTTP Query string.
     * @throws RuntimeException if Params map has Unsupported encoding
     */
    public String buildQueryString(Map<String, String> params) throws RuntimeException {
        if (params == null) {
            return "";
        }

        StringBuilder stringBuilder = new StringBuilder();

        for (String key : params.keySet()) {
            if (stringBuilder.length() > 0) {
                stringBuilder.append("&");
            }
            String value = params.get(key);
            try {
                if (key != null) {
                    stringBuilder.append(URLEncoder.encode(key, URL_ENCODING));
                    stringBuilder.append("=");
                    stringBuilder.append(value != null ? URLEncoder.encode(value, URL_ENCODING) : "");
                }
            } catch (UnsupportedEncodingException e) {
                throw new RuntimeException("Unsupported encoding", e);
            }
        }

        return stringBuilder.toString();
    }

    /**
     * Wraps HTTP GET request to be able to log the query and result.
     *
     * @param path URL path.
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    protected ApiResponse get(final String path) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("GET", path, null);
    }

    /**
     * Wraps HTTP POST request to be able to log the query and result.
     *
     * @param path URL path.
     * @param data Data to be sent to API server in a payload.
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    protected ApiResponse post(final String path, final byte[] data) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("POST", path, data);
    }

    /**
     * Wraps HTTP PUT request to be able to log the query and result.
     *
     * @param path URL path.
     * @param data Data to be sent to API server in a payload.
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    protected ApiResponse put(final String path, final byte[] data) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("PUT", path, data);
    }

    /**
     * Wraps HTTP PATCH request to be able to log the query and result.
     *
     * @param path URL path.
     * @param data Data to be sent to API server in a payload.
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    protected ApiResponse patch(final String path, final byte[] data) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("PATCH", path, data);
    }

    /**
     * Wraps HTTP DELETE request to be able to log the query and result.
     *
     * @param path URL path.
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    protected ApiResponse delete(final String path) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("DELETE", path, null);
    }

    /**
     * Performs HTTP request using HTTP Transport
     *
     * @param method Request method
     * @param path URL path
     * @param data Request payout
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws IOException if an error occurred connecting to the server.
     */
    protected ApiResponse makeRequest(String method, String path, byte[] data)
            throws ApiException, ProtocolException, IOException {
        // TODO: Place for debugger and logger
        final ApiResponse response;
        switch (method) {
            case "GET":
                response = this.transport.get(path);
                break;

            case "POST":
                response = this.transport.post(path, data);
                break;

            case "PUT":
                response = this.transport.put(path, data);
                break;

            case "PATCH":
                response = this.transport.patch(path, data);
                break;

            case "DELETE":
                response = this.transport.delete(path);
                break;

            default: throw new IOException("Unknown request method " + method);
        }

        // Check if the response has a "Location" header
        List<String> header = response.getHeader("Location");
        if (header != null) {
            this.location = header.get(0);
        }

        this.lastResponse = response;

        // TODO: Place for debugger and logger
        return response;
    }
}
