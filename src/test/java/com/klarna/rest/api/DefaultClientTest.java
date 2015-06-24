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

package com.klarna.rest.api;

import com.sun.jersey.api.client.WebResource;
import com.sun.jersey.client.apache4.ApacheHttpClient4;
import com.sun.jersey.client.apache4.ApacheHttpClient4Handler;
import org.apache.http.HttpHost;
import org.apache.http.client.CookieStore;
import org.apache.http.client.CredentialsProvider;
import org.apache.http.client.HttpClient;
import org.apache.http.auth.AuthScope;
import org.apache.http.auth.UsernamePasswordCredentials;
import org.apache.http.conn.params.ConnRoutePNames;
import org.apache.http.params.HttpParams;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InOrder;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;

import java.net.URI;
import java.util.HashMap;
import java.util.Map;

import static com.sun.jersey.client.apache4.config.ApacheHttpClient4Config.PROPERTY_PROXY_PASSWORD;
import static com.sun.jersey.client.apache4.config.ApacheHttpClient4Config.PROPERTY_PROXY_URI;
import static com.sun.jersey.client.apache4.config.ApacheHttpClient4Config.PROPERTY_PROXY_USERNAME;
import static com.sun.jersey.client.apache4.config.ApacheHttpClient4Config
        .PROPERTY_CREDENTIALS_PROVIDER;
import static org.mockito.Matchers.eq;
import static org.mockito.Mockito.inOrder;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

/**
 * Test cases for the DefaultClient class.
 */
@RunWith(MockitoJUnitRunner.class)
public class DefaultClientTest extends TestCase {

    private static String merchantId = "0";

    private static String sharedSecret = "secret";

    private static String username = "myuser";

    private static String password = "mypass";

    @Mock private ApacheHttpClient4 http;

    @Mock private HttpClient httpClient;

    @Mock private WebResource resource;

    @Mock private HttpParams params;

    @Mock private CookieStore cookies;

    @Mock private CredentialsProvider credentials;

    private ApacheHttpClient4Handler handler;

    private Map<String, Object> properties;

    private URI baseUrl = URI.create("http://localhost");

    private HttpHost proxy = new HttpHost("example", 8888, "http");

    private Client client;

    @Before
    public void setUp() {
        when(http.resource(baseUrl))
                .thenReturn(resource);

        properties = new HashMap<String, Object>();
        properties.put(PROPERTY_CREDENTIALS_PROVIDER, credentials);

        handler = new ApacheHttpClient4Handler(httpClient, cookies, false);

        client = new DefaultClient(http, baseUrl);
    }

    @Test
    public void testNewCheckoutOrder() {
        when(resource.path(DefaultCheckoutOrder.PATH))
                .thenReturn(resource);

        CheckoutOrder order = client.newCheckoutOrder();
        assertNotNull(order);

        verify(resource).path(DefaultCheckoutOrder.PATH);
    }

    @Test
    public void testNewCheckoutOrderExisting() {
        when(resource.path(DefaultCheckoutOrder.PATH))
                .thenReturn(resource);

        when(resource.path("12345"))
                .thenReturn(resource);

        CheckoutOrder order = client.newCheckoutOrder("12345");
        assertNotNull(order);

        // Verify that the right URL was set
        InOrder ordered = inOrder(resource);
        ordered.verify(resource).path(DefaultCheckoutOrder.PATH);
        ordered.verify(resource).path("12345");
    }

    @Test
    public void testNewOrder() {
        when(resource.path(DefaultOrder.PATH))
                .thenReturn(resource);

        when(resource.path("12345"))
                .thenReturn(resource);

        Order order = client.newOrder("12345");
        assertNotNull(order);

        // Verify that the right URL was set
        InOrder ordered = inOrder(resource);
        ordered.verify(resource).path(DefaultOrder.PATH);
        ordered.verify(resource).path("12345");
    }

    @Test
    public void testNewCapture() {
        when(resource.path(DefaultOrder.PATH))
                .thenReturn(resource);

        when(resource.path("12345"))
                .thenReturn(resource);

        when(resource.path(DefaultCapture.PATH))
                .thenReturn(resource);

        Capture capture = client.newCapture("12345");
        assertNotNull(capture);

        // Verify that the right URL was set
        InOrder ordered = inOrder(resource);
        ordered.verify(resource).path(DefaultOrder.PATH);
        ordered.verify(resource).path("12345");
        ordered.verify(resource).path(DefaultCapture.PATH);
    }

    @Test
    public void testNewCaptureExisting() {
        when(resource.path(DefaultOrder.PATH))
                .thenReturn(resource);

        when(resource.path("12345"))
                .thenReturn(resource);

        when(resource.path(DefaultCapture.PATH))
                .thenReturn(resource);

        when(resource.path("23456"))
                .thenReturn(resource);

        Capture capture = client.newCapture("12345", "23456");
        assertNotNull(capture);

        // Verify that the right URL was set
        InOrder ordered = inOrder(resource);
        ordered.verify(resource).path(DefaultOrder.PATH);
        ordered.verify(resource).path("12345");
        ordered.verify(resource).path(DefaultCapture.PATH);
        ordered.verify(resource).path("23456");
    }

    @Test
    public void testSetConnectTimeout() {
        Integer timeout = new Integer(1000);

        client.setConnectTimeout(timeout);

        verify(http).setConnectTimeout(timeout);

    }

    @Test
    public void testSetReadTimeout() {
        Integer timeout = new Integer(1000);

        client.setReadTimeout(timeout);

        verify(http).setReadTimeout(timeout);
    }

    @Test
    public void testSetProxy() {
        when(http.getProperties())
                .thenReturn(properties);

        when(http.getClientHandler())
                .thenReturn(handler);

        when(httpClient.getParams())
                .thenReturn(params);

        client.setProxy(proxy.getSchemeName(), proxy.getHostName(), proxy.getPort());

        assertEquals(proxy.toString(), properties.get(PROPERTY_PROXY_URI));

        verify(params).setParameter(eq(ConnRoutePNames.DEFAULT_PROXY),
                                    eq(proxy));
    }

    @Test
    public void testSetProxyWithAuth() {
        when(http.getProperties())
                .thenReturn(properties);

        when(http.getClientHandler())
                .thenReturn(handler);

        when(httpClient.getParams())
                .thenReturn(params);

        client.setProxy(proxy.getSchemeName(), proxy.getHostName(), proxy.getPort(), username, password);

        assertEquals(proxy.toString(), properties.get(PROPERTY_PROXY_URI));
        assertEquals(password, properties.get(PROPERTY_PROXY_PASSWORD));
        assertEquals(username, properties.get(PROPERTY_PROXY_USERNAME));

        verify(params).setParameter(eq(ConnRoutePNames.DEFAULT_PROXY),
                                    eq(proxy));

        verify(credentials).setCredentials(eq(new AuthScope(proxy.getHostName(), proxy.getPort())),
                                           eq(new UsernamePasswordCredentials(username, password)));
    }

    @Test
    public void testNewInstance() {
        assertNotNull(client);
    }

    @Test
    public void testNewInstanceUserAgent() {
        assertNotNull(DefaultClient.newInstance(merchantId, sharedSecret, baseUrl, new KlarnaUserAgent()));
    }

    @Test
    public void testBaseUrl() {
        assertNotNull(Client.EU_BASE_URL);
        assertNotNull(Client.EU_TEST_BASE_URL);
        assertNotNull(Client.NA_BASE_URL);
        assertNotNull(Client.NA_TEST_BASE_URL);
    }
}
