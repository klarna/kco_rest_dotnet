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

package com.klarna.rest;

import edu.emory.mathcs.backport.java.util.LinkedList;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;
import java.util.*;

import static org.mockito.Matchers.isA;
import static org.mockito.Mockito.doNothing;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class HttpUrlConnectionTransportTest extends TestCase {
    FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testBuildConnection() throws IOException {
        HashMap<String, String> testHeaders = new HashMap<>();
        testHeaders.put("Test", "123");
        HttpURLConnection conn = transport.testBuildConnection("/orders", testHeaders);

        assertEquals(new URL(Transport.EU_TEST_BASE_URL + "/orders"), conn.getURL());
        assertEquals(transport.getUserAgent(), conn.getRequestProperty("User-Agent"));
        assertEquals(MediaType.APPLICATION_JSON, conn.getRequestProperty("Content-Type"));
        assertEquals("123", conn.getRequestProperty("Test"));
        assertEquals(transport.getTimeout(), conn.getConnectTimeout());
        assertEquals(transport.getTimeout(), conn.getReadTimeout());
    }

    @Test
    public void testGetRequest() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        ApiResponse response = transport.get("/test-url", null);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);
    }

    @Test(expected = ApiException.class)
    public void testUnsuccessfullRequest() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(500);

        ApiResponse response = transport.get("/test-url", null);
        response.validator();
    }

    @Test(expected = ProtocolException.class)
    public void testUnexpectedCode() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(201);

        ApiResponse response = transport.get("/test-url", null);
        response.validator().expectStatusCode(Response.Status.NO_CONTENT);
    }

    @Test(expected = ContentTypeException.class)
    public void testUnexpectedContentType() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_OCTET_STREAM);
                }
            });
        }});

        ApiResponse response = transport.get("/test-url", null);
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);
    }

    @Test
    public void testUserAgentProperty() {
        transport.setUserAgent("No-Agent");
        assertEquals("No-Agent", transport.getUserAgent());
    }

    @Test
    public void testTimeoutPropery() {
        transport.setTimeout(1);
        assertEquals(1, transport.getTimeout());
    }

    @Test
    public void testTransportTimeout() {
        HttpUrlConnectionTransport t = new HttpUrlConnectionTransport("0","sharedSecret", Transport.EU_TEST_BASE_URL);
        t.setTimeout(1);
        try {
            ApiResponse response = t.get("/", null);
        } catch (IOException e) {
            return;
        }
        fail("No timeout exception");
    }

    @Test
    public void testWrongEndpoint() throws IOException {
        HttpUrlConnectionTransport t = new HttpUrlConnectionTransport("0","sharedSecret", Transport.EU_TEST_BASE_URL);
        ApiResponse response = t.get("/wrong-service-endpoint", null);
        try {
            response.validator();
        } catch (ApiException e) {
            assertEquals(404, e.getHttpStatus());
            return;
        }
        fail("Validator did not throw exception");
    }

    @Test
    public void testBodyResponse() throws IOException {
        final String payload = "{\"hello\": 123}";

        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});
        ByteArrayOutputStream out = new ByteArrayOutputStream();
        out.write(payload.getBytes());
        InputStream is = new ByteArrayInputStream(out.toByteArray());
        when(transport.conn.getInputStream()).thenReturn(is);

        ApiResponse response = transport.get("/hello", null);
        assertEquals(payload, new String(response.getBody()));
    }

    @Test
    public void testErrorResponse() throws IOException {
        final String payload = "{ \"error_code\" : \"CODE_123\", " +
                "\"error_messages\" : [\"Missing required field\"], " +
                "\"correlation_id\" : \"12345-asdf\", " +
                "\"service_version\": \"0x8903\" }";

        when(transport.conn.getResponseCode()).thenReturn(400);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});
        ByteArrayOutputStream out = new ByteArrayOutputStream();
        out.write(payload.getBytes());
        InputStream is = new ByteArrayInputStream(out.toByteArray());
        when(transport.conn.getErrorStream()).thenReturn(is);

        ApiResponse response = transport.get("/error-message", null);
        try {
            response.validator();
        } catch (ApiException e) {
            assertEquals(400, e.getHttpStatus());
            assertEquals("12345-asdf", e.getErrorMessage().getCorrelationId());
            assertEquals("CODE_123", e.getErrorMessage().getErrorCode());
            assertEquals(new ArrayList<String>(){{add("Missing required field");}}, e.getErrorMessage().getErrorMessages());
            assertEquals("0x8903", e.getErrorMessage().getServiceVersion());
            return;
        }
        fail("Unable to parse error message");
    }
}

class FakeHttpUrlConnectionTransport extends HttpUrlConnectionTransport {
    @Mock public HttpURLConnection conn = mock(HttpURLConnection.class);

    FakeHttpUrlConnectionTransport(String merchantId, String sharedSecret, URI uri) {
        super(merchantId, sharedSecret, uri);
    }

    FakeHttpUrlConnectionTransport() {
        super("merchantId", "sharedSecret", Transport.EU_TEST_BASE_URL);
    }

    public HttpURLConnection testBuildConnection(String path, Map<String, String> headers) throws IOException {
        return super.buildConnection(path, headers);
    }

    @Override
    protected HttpURLConnection buildConnection(String path, Map<String, String> headers) throws IOException {
        doNothing().when(conn).setRequestMethod(isA(String.class));
        return conn;
    }
}
