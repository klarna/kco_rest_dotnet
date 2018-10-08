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

public class ApiResponse {
    private int status;

    private Map<String, List<String>> headers;

    private byte[] body = null;


    public ApiResponse() {
        this.headers = new HashMap<>();
    }

    public ApiResponse setStatus(int status) {
        this.status = status;
        return this;
    }

    public int getStatus() {
        return this.status;
    }

    public ApiResponse setBody(byte[] body) {
        this.body = body;
        return this;
    }

    public byte[] getBody() {
        return this.body;
    }

    public ApiResponse setHeaders(Map headers) {
        this.headers = headers;
        return this;
    }

    public ApiResponse setHeader(String name, List<String> values) {
        this.headers.put(name, values);
        return this;
    }

    public Map getHeaders() {
        return this.headers;
    }

    public List<String> getHeader(String name) {
        return this.headers.get(name);
    }

    public Boolean isSuccessfull () {
        if (Status.fromStatusCode(this.getStatus()).getFamily().equals(SUCCESSFUL)) {
            return true;
        }
        return false;
    }

    public ApiResponse expectSuccessfull() throws ProtocolException {
        if (this.isSuccessfull()) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(this.getStatus());
    }

    public ApiResponse expectStatusCode(final Status status) throws ProtocolException {
        if (status.getStatusCode() == this.getStatus()) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(this.getStatus());
    }

    public ApiResponse expectStatusCode(final Status... expected) throws ProtocolException {
        List<Status> statuses = Arrays.asList(expected);
        Status status = Status.fromStatusCode(this.getStatus());

        if (statuses.contains(status)) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(
                this.getStatus());
    }

    public ApiResponse expectContentType(final String value) throws ContentTypeException {
        List<String> contentType = this.getHeader("Content-Type");
        if (contentType != null && contentType.contains(value)) {
            return this;
        }

        throw ContentTypeException.unexpectedType(contentType.toString());
    }

    public ApiResponse validator() throws ApiException {
        Family family = Status.fromStatusCode(this.getStatus()).getFamily();

        if (family.equals(SUCCESSFUL)) {
            return this;
        }

        ErrorMessage message;
        ObjectMapper objectMapper = new DefaultMapper();
        try {
            message = objectMapper.readValue(this.getBody(), ErrorMessage.class);

        } catch (IOException e) {
            message = null;
        }
        throw new ApiException(this.getStatus(), message);
    }
}
