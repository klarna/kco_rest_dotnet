package com.klarna.rest;

import com.klarna.rest.api.ApiResponse;

public class HttpUrlConnectionTransport implements Transport {
    public ApiResponse get(final String path) {
        return new ApiResponse();
    }

    public <T> ApiResponse post(final String path, final T data) {
        return new ApiResponse();
    }

    public <T> ApiResponse put(final String path, final T data) {
        return new ApiResponse();
    }

    public <T> ApiResponse delete(final String path) {
        return new ApiResponse();
    }
}
