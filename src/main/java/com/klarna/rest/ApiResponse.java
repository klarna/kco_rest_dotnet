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

import com.klarna.rest.model.ErrorMessage;

import com.fasterxml.jackson.databind.ObjectMapper;

import javax.ws.rs.core.Response.Status;
import javax.ws.rs.core.Response.Status.Family;

import java.io.IOException;

import java.util.*;

import static javax.ws.rs.core.Response.Status.Family.SUCCESSFUL;

/**
 * General HTTP response instance.
 */
public class ApiResponse {
    /**
     * HTTP response Status code
     */
    private int status;

    /**
     * HTTP Response headers
     */
    private Map<String, List<String>> headers;

    /**
     * HTTP body binary payout
     */
    private byte[] body = null;


    public ApiResponse() {
        this.headers = new HashMap<>();
    }

    /**
     * Sets HTTP Status code.
     *
     * @param status HTTP status
     * @return self
     */
    public ApiResponse setStatus(int status) {
        this.status = status;
        return this;
    }

    /**
     * Gets HTTP Status code.
     *
     * @return Status code
     */
    public int getStatus() {
        return this.status;
    }

    /**
     * Sets binary body payout.
     *
     * @param body Payout
     * @return self
     */
    public ApiResponse setBody(byte[] body) {
        this.body = body;
        return this;
    }

    /**
     * Gets binary body payout.
     *
     * @return Payout
     */
    public byte[] getBody() {
        return this.body;
    }

    /**
     * Sets HTTP headers map
     *
     * @param headers Headers
     * @return self
     */
    public ApiResponse setHeaders(Map headers) {
        this.headers = headers;
        return this;
    }

    /**
     * Sets single HTTP header value.
     *
     * @param name Header name
     * @param values Header values
     * @return self
     */
    public ApiResponse setHeader(String name, List<String> values) {
        this.headers.put(name, values);
        return this;
    }

    /**
     * Gets HTTP Headers map
     *
     * @return Headers
     */
    public Map getHeaders() {
        return this.headers;
    }

    /**
     * Gets single header value
     *
     * @param name Header name
     * @return Header values
     */
    public List<String> getHeader(String name) {
        return this.headers.get(name);
    }

    /**
     * Checks if current ApiResponse is successful (response code >=200 && <300)
     *
     * @return true if successful
     */
    public Boolean isSuccessfull () {
        if (Status.fromStatusCode(this.getStatus()).getFamily().equals(SUCCESSFUL)) {
            return true;
        }
        return false;
    }

    /**
     * Sets successful expectation.
     *
     * @return self
     * @throws ProtocolException if response code is not successful
     */
    public ApiResponse expectSuccessfull() throws ProtocolException {
        if (this.isSuccessfull()) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(this.getStatus());
    }

    /**
     * Sets status code expectation.
     *
     * @param expected Expected HTTP status code.
     * @return self
     * @throws ProtocolException if status code does not match the expectation
     */
    public ApiResponse expectStatusCode(final Status expected) throws ProtocolException {
        if (expected.getStatusCode() == this.getStatus()) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(this.getStatus());
    }

    /**
     * Sets status code expectation.
     *
     * @param expected Expected HTTP status codes.
     * @return self
     * @throws ProtocolException if status code does not match the expectations
     */
    public ApiResponse expectStatusCode(final Status... expected) throws ProtocolException {
        List<Status> statuses = Arrays.asList(expected);
        Status status = Status.fromStatusCode(this.getStatus());

        if (statuses.contains(status)) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(
                this.getStatus());
    }

    /**
     * Sets content-type expectation.
     *
     * @param value expected Content Type
     * @return self
     * @throws ContentTypeException if content type does not match the expectation
     */
    public ApiResponse expectContentType(final String value) throws ContentTypeException {
        List<String> contentType = this.getHeader("Content-Type");
        if (contentType != null && contentType.contains(value)) {
            return this;
        }

        for (String type : contentType) {
            if (type.startsWith(value)) {
                return this;
            }
        }

        throw ContentTypeException.unexpectedType(contentType.toString());
    }

    /**
     * Checks if response is successful or fetches the ErrorMessage otherwise.
     *
     * @return self
     * @throws ApiException if response is not successful and payout contains ErrorMessage
     * @see ErrorMessage
     */
    public ApiResponse validator() throws ApiException {
        Family family = Status.fromStatusCode(this.getStatus()).getFamily();

        if (family.equals(SUCCESSFUL)) {
            return this;
        }

        ErrorMessage message = null;
        ObjectMapper objectMapper = new DefaultMapper();
        try {
            byte[] body = this.getBody();
            if (body != null) {
                message = objectMapper.readValue(this.getBody(), ErrorMessage.class);
            }

        } catch (IOException e) {
            message = null;
        }
        throw new ApiException(this.getStatus(), message);
    }
}
