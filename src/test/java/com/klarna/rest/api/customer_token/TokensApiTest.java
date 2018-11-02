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

package com.klarna.rest.api.customer_token;

import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.api.customer_token.model.TokenCustomerTokenOrder;
import com.klarna.rest.api.customer_token.model.TokenCustomerTokenV1;
import com.klarna.rest.api.customer_token.model.TokenOrder;
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.MediaType;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class TokensApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testFetchDetails() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        final String payload = "{\"payment_method_type\": \"INVOICE\", \"status\": \"ACTIVE\"}";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        TokensApi api = new TokensApi(transport, "fake-token-id");
        TokenCustomerTokenV1 token = api.fetchDetails();

        assertEquals("INVOICE", token.getPaymentMethodType());
        assertEquals("ACTIVE", token.getStatus());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/customer-token/v1/tokens/fake-token-id", transport.requestPath);
    }

    @Test
    public void testCreateOrder() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        final String payload = "{\"fraud_status\": \"ACCEPTED\", \"order_id\": \"order-id-123\"}";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        TokensApi api = new TokensApi(transport, "fake-token-id");

        TokenCustomerTokenOrder data = new TokenCustomerTokenOrder()
            .orderAmount(100L)
            .purchaseCurrency("EUR");

        TokenOrder order = api.createOrder(data);

        assertEquals("ACCEPTED", order.getFraudStatus());
        assertEquals("order-id-123", order.getOrderId());
        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/customer-token/v1/tokens/fake-token-id/order", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"order_amount\":100"));
        assertTrue(requestPayout.contains("\"purchase_currency\":\"EUR\""));
    }
}
