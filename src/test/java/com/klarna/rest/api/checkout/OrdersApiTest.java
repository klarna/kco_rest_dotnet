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

package com.klarna.rest.api.checkout;

import com.klarna.rest.*;
import com.klarna.rest.model.checkout.Order;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.MediaType;
import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class OrdersApiTest extends TestCase {
    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() throws IOException {
        transport = new FakeHttpUrlConnectionTransport();
        ByteArrayOutputStream os = new ByteArrayOutputStream();
        when(transport.conn.getOutputStream()).thenReturn(os);
    }

    @Test
    public void testCreateOrder() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(201);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{\"order_amount\": 200}";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        Order data = new Order(){
            {
                setOrderAmount(100L);
                setLocale("en-GB");
                setRecurring(true);
            }
        };

        OrdersApi api = new OrdersApi(transport);
        Order order = api.create(data);

        assertEquals(new Long(200), order.getOrderAmount());
        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/checkout/v3/orders", transport.requestPath);
    }

    @Test(expected = ApiException.class)
    public void testCreateOrderWrongResponseCode() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(403);

        OrdersApi api = new OrdersApi(transport);
        Order order = api.create(null);
    }

    @Test(expected = ProtocolException.class)
    public void testCreateOrderWrongSuccessfulResponseCode() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        OrdersApi api = new OrdersApi(transport);
        Order order = api.create(null);
    }

    @Test(expected = ContentTypeException.class)
    public void testCreateOrderWrongContentType() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(201);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_OCTET_STREAM);
                }
            });
        }});

        OrdersApi api = new OrdersApi(transport);
        Order order = api.create(null);
    }
}
