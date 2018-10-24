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

package com.klarna.rest.api.order_management;

import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.model.order_management.Capture;
import com.klarna.rest.model.order_management.CaptureObject;
import com.klarna.rest.model.order_management.ShippingInfo;
import com.klarna.rest.model.order_management.UpdateShippingInfo;
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.MediaType;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class CapturesApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testFetchAll() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "[ { \"capture_id\": \"4ba29b50-be7b-44f5-a492-113e6a865e22\", \"captured_amount\": 100, \"order_lines\": [ { \"reference\": \"75001\", \"type\": \"physical\" } ], \"refunded_amount\": 0, \"billing_address\": { \"given_name\": \"Klara\", \"family_name\": \"Joyce\" }, \"shipping_address\": { \"given_name\": \"Klara\", \"family_name\": \"Joyce\" }, \"shipping_info\": [ { \"shipping_method\": \"Home\", \"tracking_number\": \"63456415674545679874\" } ] } ]";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        CapturesApi api = new CapturesApi(transport, "my-order-id");
        Capture[] captures = api.fetchAll();

        assertEquals("4ba29b50-be7b-44f5-a492-113e6a865e22", captures[0].getCaptureId());
        Long amount = 100L;
        assertEquals(amount, captures[0].getCapturedAmount());
        assertEquals("75001", captures[0].getOrderLines().get(0).getReference());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/ordermanagement/v1/orders/my-order-id/captures", transport.requestPath);
    }

    @Test
    public void testFetchById() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{ \"capture_id\": \"4ba29b50-be7b-44f5-a492-113e6a865e22\", \"captured_amount\": 100, \"order_lines\": [ { \"reference\": \"75001\", \"type\": \"physical\" } ], \"refunded_amount\": 0, \"billing_address\": { \"given_name\": \"Klara\", \"family_name\": \"Joyce\" }, \"shipping_address\": { \"given_name\": \"Klara\", \"family_name\": \"Joyce\" }, \"shipping_info\": [ { \"shipping_method\": \"Home\", \"tracking_number\": \"63456415674545679874\" } ] }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        CapturesApi api = new CapturesApi(transport, "my-order-id");
        Capture capture = api.fetch("my-capture-id");

        assertEquals("4ba29b50-be7b-44f5-a492-113e6a865e22", capture.getCaptureId());
        Long amount = 100L;
        assertEquals(amount, capture.getCapturedAmount());
        assertEquals("75001", capture.getOrderLines().get(0).getReference());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/ordermanagement/v1/orders/my-order-id/captures/my-capture-id", transport.requestPath);
    }

    @Test
    public void testCreate() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(201);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
            put("Location", new ArrayList<String>(){
                {
                    add("https://example.com/new-location");
                }
            });
            put("Capture-Id", new ArrayList<String>(){
                {
                    add("new-capture-id");
                }
            });
        }});

        CaptureObject data = new CaptureObject(){
            {
                setCapturedAmount(100L);
                setDescription("test");
            }
        };

        CapturesApi api = new CapturesApi(transport, "my-order-id");
        String captureId = api.create(data);

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/ordermanagement/v1/orders/my-order-id/captures", transport.requestPath);
        assertEquals("new-capture-id", captureId);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"captured_amount\":100"));

        // Location header should be set up
        when(transport.conn.getResponseCode()).thenReturn(200);
        api.fetch(); // Fetch by location header
        assertEquals("https://example.com/new-location", transport.requestPath);
    }

    @Test
    public void testTriggerSendout() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        CapturesApi api = new CapturesApi(transport, "my-order-id");
        api.triggerSendout("my-capture-id");

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/ordermanagement/v1/orders/my-order-id/captures/my-capture-id/trigger-send-out", transport.requestPath);
    }

    @Test
    public void testAddShippingInfo() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        UpdateShippingInfo data = new UpdateShippingInfo(){};

        CapturesApi api = new CapturesApi(transport, "my-order-id");
        api.addShippingInfo("my-capture-id", data);

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/ordermanagement/v1/orders/my-order-id/captures/my-capture-id/shipping-info", transport.requestPath);
    }
}
