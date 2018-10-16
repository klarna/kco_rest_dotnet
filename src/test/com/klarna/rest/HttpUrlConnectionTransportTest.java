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

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;
import java.util.Map;

@RunWith(MockitoJUnitRunner.class)
public class HttpUrlConnectionTransportTest extends TestCase {
    FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testBuildConnection() throws IOException {
        HttpURLConnection conn = transport.testBuildConnection("/orders", null);
        assertEquals(new URL("https://api.playground.klarna.com/orders"), conn.getURL());
    }
}

class FakeHttpUrlConnectionTransport extends HttpUrlConnectionTransport {
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
        HttpURLConnection conn = null;
        return conn;
    }
}
