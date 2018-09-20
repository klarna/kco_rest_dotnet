package com.klarna.rest.api;

import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.ws.rs.core.Response.Status;

import static javax.ws.rs.core.Response.Status.Family.SUCCESSFUL;

public class ApiResponse {
    private Status status;

    private Map<String, String> headers;

    private String body;

    ApiResponse() {
        this.headers = new HashMap<>();
    }

    public void setStatus(Status status) {
        this.status = status;
    }

    public Status getStatus() {
        return this.status;
    }

    public void setBody(String body) {
        this.body = body;
    }

    public String getBody() {
        return this.body;
    }

    public void setHeaders(Map headers) {
        this.headers = headers;
    }

    public void setHeader(String name, String value) {
        this.headers.put(name, value);
    }

    public Map getHeaders() {
        return this.headers;
    }

    public String getHeader(String name) {
        return this.headers.get(name);
    }

    public Boolean isSuccessfull () {
        if (this.getStatus().getFamily().equals(SUCCESSFUL)) {
            return true;
        }
        return false;
    }

    public ApiResponse expectSuccessfull() throws ProtocolException {
        if (this.isSuccessfull()) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(this.getStatus().getStatusCode());
    }

    public ApiResponse expectStatusCode(final Status status) throws ProtocolException {
        if (status.getStatusCode() == this.getStatus().getStatusCode()) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(this.getStatus().getStatusCode());
    }

    public ApiResponse expectStatusCode(final Status... expected) throws ProtocolException {
        List<Status> statuses = Arrays.asList(expected);
        Status status = this.getStatus();

        if (statuses.contains(status)) {
            return this;
        }

        throw ProtocolException.unexpectedStatus(
                this.getStatus().getStatusCode());
    }
}
