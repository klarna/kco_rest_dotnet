package com.klarna.rest.api;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.klarna.rest.*;

import java.io.IOException;

public abstract class BaseApi {
    protected Transport transport;
    protected ObjectMapper objectMapper;
    protected ApiResponse lastResponse;

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

    protected ApiResponse get(final String path) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("GET", path, null);
    }

    protected ApiResponse post(final String path, final byte[] data) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("POST", path, data);
    }

    protected ApiResponse put(final String path, final byte[] data) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("PUT", path, data);
    }

    protected ApiResponse patch(final String path, final byte[] data) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("PATCH", path, data);
    }

    protected ApiResponse delete(final String path) throws ApiException, ProtocolException, IOException {
        return this.makeRequest("DELETE", path, null);
    }

    protected ApiResponse makeRequest(String method, String path, byte[] data)
            throws ApiException, ProtocolException, IOException {
        // TODO: Place for debugger and logger
        ApiResponse response = null;
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
        }

        this.lastResponse = response;

        // TODO: Place for debugger and logger
        return response;
    }
}
