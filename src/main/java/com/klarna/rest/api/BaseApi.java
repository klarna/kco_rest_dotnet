package com.klarna.rest.api;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.klarna.rest.*;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.List;
import java.util.Map;

public abstract class BaseApi {
    protected Transport transport;
    protected ObjectMapper objectMapper;
    protected ApiResponse lastResponse;
    protected String location;

    private static final String URL_ENCODING = "UTF-8";

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
