/*
 * Copyright 2018 Klarna AB
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

package com.klarna.rest.http_transport;

import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;
import com.klarna.rest.model.ContentTypeException;
import com.klarna.rest.model.ProtocolException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.*;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.net.*;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.Map;
import java.util.Set;

import javax.ws.rs.core.MediaType;

/**
 * HttpURLConnection implementation of Transpoert interface.
 * Used to send HTTP requests to API server.
 */
public class HttpUrlConnectionTransport implements Transport {
    /**
     * Default HTTP request timeout.
     */
    private static final int DEFAULT_TIMEOUT = 30000;

    /**
     * Default request Media-Type.
     */
    private static final String DEFAULT_MEDIA_TYPE = MediaType.APPLICATION_JSON;

    /**
     * Logger instance.
     */
    private static final Logger log = LoggerFactory.getLogger(HttpUrlConnectionTransport.class);

    /**
     * Base API server URL.
     */
    protected URI baseUri;

    /**
     * Merchant ID.
     */
    protected String merchantId;

    /**
     * Merchant shared secret key.
     */
    protected String sharedSecret;

    /**
     * HTTP UserAgent.
     */
    protected String userAgent;

    /**
     * HTTP request timeout.
     */
    protected int timeout = DEFAULT_TIMEOUT;

    /**
     * HttpUrlConnection Proxy settings.
     * @see Proxy
     */
    protected Proxy proxy;

    /**
     * Proxy authenticator.
     * @see Authenticator
     */
    protected Authenticator proxyAuth;

    public HttpUrlConnectionTransport(final String merchantId,
                                      final String sharedSecret,
                                      final URI baseUri) {
        this.baseUri = baseUri;
        this.merchantId = merchantId;
        this.sharedSecret = sharedSecret;
        this.userAgent = Transport.USER_AGENT;

        HttpUrlConnectionTransport.allowMethods("PATCH"); // Workaround for PATCH method
    }

    /**
     * Sends HTTP GET request to specified path.
     *
     * @param path URL path
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public ApiResponse get(final String path, Map<String, String> headers) throws
            ApiException, com.klarna.rest.model.ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path, headers);
        conn.setRequestMethod("GET");

        return this.makeRequest(conn, null);
    }

    /**
     * Sends HTTP POST request to specified path.
     *
     * @param path URL path
     * @param data Data to be sent to API server in a payload
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public ApiResponse post(final String path, final byte[] data, Map<String, String> headers) throws
            ApiException, com.klarna.rest.model.ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path, headers);
        conn.setRequestMethod("POST");

        return this.makeRequest(conn, data);
    }

    /**
     * Sends HTTP PUT request to specified path.
     *
     * @param path URL path
     * @param data Data to be sent to API server in a payload
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public ApiResponse put(final String path, final byte[] data, Map<String, String> headers) throws
            ApiException, com.klarna.rest.model.ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path, headers);
        conn.setRequestMethod("PUT");

        return this.makeRequest(conn, data);
    }

    /**
     * Sends HTTP PATCH request to specified path.
     *
     * @param path URL path
     * @param data Data to be sent to API server in a payload
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public ApiResponse patch(final String path, final byte[] data, Map<String, String> headers) throws
            ApiException, com.klarna.rest.model.ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path, headers);
        conn.setRequestMethod("PATCH");

        return this.makeRequest(conn, data);
    }

    /**
     * Sends HTTP DELETE request to specified path.
     *
     * @param path URL path
     * @param headers HTTP request headers
     * @return Processed response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws IOException if an error occurred when connecting to the server or when parsing a response.
     */
    public ApiResponse delete(final String path, Map<String, String> headers) throws
            ApiException, ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path, headers);
        conn.setRequestMethod("DELETE");

        return this.makeRequest(conn, null);
    }

    /**
     * Gets current UserAgent.
     *
     * @return UserAgent
     */
    public String getUserAgent() {
        return this.userAgent;
    }

    /**
     * Sets new UserAgent. The UserAgent will be added as 'User-Agent' header to the HTTP request.
     *
     * @param userAgent new UserAgent
     * @return self
     */
    public HttpUrlConnectionTransport setUserAgent(String userAgent) {
        this.userAgent = userAgent;

        return this;
    }

    /**
     * Gets current Timeout limit (in seconds) for an HTTP request.
     *
     * @return Timeout
     */
    public int getTimeout() {
        return this.timeout;
    }

    /**
     * Sets current Timeout limit (in seconds) for an HTTP request.
     *
     * @param timeout Timeout in milliseconds
     * @return self
     */
    public HttpUrlConnectionTransport setTimeout(int timeout) {
        this.timeout = timeout;

        return this;
    }

    /**
     * Sets new Proxy settings
     *
     * @param proxy Proxy
     */
    public void setProxy(Proxy proxy) {
        this.proxy = proxy;
    }

    /**
     * Sets new Proxy settings
     *
     * @param scheme Proxy scheme (http, https)
     * @param host Proxy host
     * @param port Proxy port
     */
    public void setProxy(final Proxy.Type scheme, final String host, final int port) {
        this.proxy = new Proxy(scheme, new InetSocketAddress(host, port));
    }

    /**
     * Sets new Proxy settings
     *
     * @param scheme Proxy scheme (http, https)
     * @param host Proxy host
     * @param port Proxy port
     * @param username Auth: Proxy user name
     * @param password Auth: Proxy password
     */
    public void setProxy(final Proxy.Type scheme, final String host, final int port, final String username, final String password) {
        this.setProxy(scheme, host, port);
        this.proxyAuth = new Authenticator() {
            public PasswordAuthentication getPasswordAuthentication() {
                return (new PasswordAuthentication(username,
                        password.toCharArray()));
            }
        };
        Authenticator.setDefault(this.proxyAuth);
    }

    protected HttpURLConnection buildConnection(String path, Map<String, String> headers) throws IOException {
        URL url = this.buildPath(path);

        HttpURLConnection conn;
        if (this.proxy != null) {
            conn = (HttpURLConnection) url.openConnection(this.proxy);
        } else {
            conn = (HttpURLConnection) url.openConnection();
        }

        conn.setRequestProperty("Content-Type", DEFAULT_MEDIA_TYPE);
        conn.setRequestProperty("User-Agent", this.userAgent);
        conn.setConnectTimeout(this.timeout);
        conn.setReadTimeout(this.timeout);

        this.authorize(conn);

        if (headers != null) {
            for (String key : headers.keySet()) {
                conn.setRequestProperty(key, headers.get(key));
            }
        }

        return conn;
    }

    protected void authorize(HttpURLConnection conn) throws IOException {
        this.setBase64Auth(conn, this.merchantId, this.sharedSecret);
    }

    protected ApiResponse makeRequest(HttpURLConnection conn, byte[] payout) throws IOException {
        log.debug("DEBUG MODE: Request\n"
                + ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n"
                + conn.getRequestMethod() + ": " + conn.getURL() + "\n"
                + "Headers: " + conn.getRequestProperties() + "\n"
                + "Payout: " + (payout == null ? "null" : new String(payout)) + "\n");


        if (payout != null) {
            conn.setDoOutput(true);

            OutputStream os = conn.getOutputStream();
            os.write(payout);
            os.close();
        }

        ApiResponse response = new ApiResponse();

        response.setStatus(conn.getResponseCode());
        response.setHeaders(conn.getHeaderFields());

        InputStream is;
        if (response.isSuccessful()) {
            is = conn.getInputStream();
        } else {
            is = conn.getErrorStream();
        }

        if (is != null) {
            InputStream in = new BufferedInputStream(is);
            ByteArrayOutputStream os = new ByteArrayOutputStream();

            int bytes;
            while ((bytes = is.read()) != -1) {
                os.write(bytes);
            }
            in.close();

            response.setBody(os.toByteArray());
        }

        log.debug("DEBUG MODE: Response\n"
                + "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n"
                + "Headers: " + conn.getHeaderFields() + "\n"
                + "Body: " + (response.getBody() == null ? "null" : new String(response.getBody())) + "\n");

        return response;
    }

    private URL buildPath(String path) throws MalformedURLException {
        URI uri = this.baseUri;
        String newPath = uri.getPath() + path;
        uri = uri.resolve(newPath);
        return uri.toURL();
    }

    private void setBase64Auth(HttpURLConnection conn, String username, String password) throws IOException {
        byte[] message = (username + ":" + password).getBytes("UTF-8");
        String encoded = javax.xml.bind.DatatypeConverter.printBase64Binary(message);

        conn.setRequestProperty("Authorization", "Basic " + encoded);
    }

    /**
     * Workaround: Extends HttpURLConnection with PATCH method. This method does not exist in the "Allowed HTTP methods"
     * but still can be sent.
     *
     * @param methods HTTP methods to be allowed by HttpURLConnection
     */
    private static void allowMethods(String... methods) {
        try {
            Field methodsField = HttpURLConnection.class.getDeclaredField("methods");

            Field modifiersField = Field.class.getDeclaredField("modifiers");
            modifiersField.setAccessible(true);
            modifiersField.setInt(methodsField, methodsField.getModifiers() & ~Modifier.FINAL);

            methodsField.setAccessible(true);

            String[] oldMethods = (String[]) methodsField.get(null);
            Set<String> methodsSet = new LinkedHashSet<>(Arrays.asList(oldMethods));
            methodsSet.addAll(Arrays.asList(methods));
            String[] newMethods = methodsSet.toArray(new String[0]);

            methodsField.set(null/*static field*/, newMethods);
        } catch (NoSuchFieldException | IllegalAccessException e) {
            System.out.println(e);
        }
    }
}
