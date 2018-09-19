package com.klarna.rest;

import java.net.URI;
import javax.ws.rs.core.Response;

/**
 * General interface for an HTTP transport.
 */
public interface Transport {
    /**
     * API library client version.
     */
    String VERSION = "3.0.0";

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

    Response get(final String path);

    <T> Response post(final String path, final T data);

    <T> Response put(final String path, final T data);

    <T> Response delete(final String path);
}
