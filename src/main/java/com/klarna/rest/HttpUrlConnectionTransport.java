package com.klarna.rest;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URL;

import javax.ws.rs.core.MediaType;

public class HttpUrlConnectionTransport implements Transport {

    protected URI baseUri;

    public HttpUrlConnectionTransport(URI baseUri) {
        this.baseUri = baseUri;
    }

    public ApiResponse get(final String path) throws IOException {
        HttpURLConnection conn = this.buildConnection(path);
        conn.setRequestMethod("GET");

        return this.processConnection(conn);
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

    protected URL buildPath(String path) throws MalformedURLException {
        URI uri = this.baseUri;
        String newPath = uri.getPath() + path;
        uri = uri.resolve(newPath);
        return uri.toURL();
    }

    protected HttpURLConnection buildConnection(String path) throws IOException {
        URL url = this.buildPath(path);

        HttpURLConnection conn = (HttpURLConnection) url.openConnection();

        conn.setRequestProperty("Content-Type", MediaType.APPLICATION_JSON);
        conn.setConnectTimeout(5000);
        conn.setReadTimeout(5000);

        return conn;
    }

    protected ApiResponse processConnection(HttpURLConnection conn) throws IOException {
        ApiResponse response = new ApiResponse();

        final int responseCode = conn.getResponseCode();
        response.setStatus(conn.getResponseCode());
        response.setHeaders(conn.getHeaderFields());

        InputStream is;
        if (response.isSuccessfull()) {
            is = conn.getInputStream();
        } else {
            is = conn.getErrorStream();
        }

        BufferedReader in = new BufferedReader(new InputStreamReader(is));
        String inputLine;
        StringBuilder content = new StringBuilder();
        while ((inputLine = in.readLine()) != null) {
            content.append(inputLine);
        }
        in.close();

        response.setBody(content.toString());
        return response;
    }
}
