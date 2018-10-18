package com.klarna.rest;

import org.mockito.Mock;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;
import java.util.Map;

import static org.mockito.Matchers.isA;
import static org.mockito.Mockito.doNothing;
import static org.mockito.Mockito.mock;

public class FakeHttpUrlConnectionTransport extends HttpUrlConnectionTransport {
    @Mock
    public HttpURLConnection conn = mock(HttpURLConnection.class);
    public String requestPath;
    public Map<String, String> requestHeaders;

    public FakeHttpUrlConnectionTransport(String merchantId, String sharedSecret, URI uri) {
        super(merchantId, sharedSecret, uri);
    }

    public FakeHttpUrlConnectionTransport() {
        super("merchantId", "sharedSecret", Transport.EU_TEST_BASE_URL);
    }

    public HttpURLConnection testBuildConnection(String path, Map<String, String> headers) throws IOException {
        return super.buildConnection(path, headers);
    }

    @Override
    protected HttpURLConnection buildConnection(String path, Map<String, String> headers) throws IOException {
        this.requestHeaders = headers;
        this.requestPath = path;

        doNothing().when(conn).setRequestMethod(isA(String.class));
        doNothing().when(conn).setDoOutput(isA(Boolean.class));
        return conn;
    }
}