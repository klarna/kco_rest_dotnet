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

package com.klarna.rest.api.payments;

import com.klarna.rest.Client;
import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.api.payments.model.PaymentsMerchantSession;
import com.klarna.rest.api.payments.model.PaymentsMerchantUrls;
import com.klarna.rest.api.payments.model.PaymentsSession;
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.MediaType;
import java.io.IOException;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class)
public class SessionsApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testCreate() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});
        final String payload = "{ \"expired_at\": \"2011-08-12T20:17:46.384Z\", \"session_id\": \"0b1d9815-165e-42e2\", \"client_token\": \"eyJhb.ewogI\", \"payment_method_categories\": [ { \"identifier\": \"pay_later\", \"name\": \"Pay Later\" } ] }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        PaymentsSession data = new PaymentsSession()
            .orderAmount(100L)
            .merchantUrls(new PaymentsMerchantUrls()
                .confirmation("https://example.com/confirm")
            );

        Client client = new Client(transport);
        PaymentsSessionsApi api = client.newPaymentsSessionsApi();
        PaymentsMerchantSession session = api.create(data);

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/payments/v1/sessions", transport.requestPath);
        assertEquals("0b1d9815-165e-42e2", session.getSessionId());
        assertEquals("eyJhb.ewogI", session.getClientToken());
        assertEquals("pay_later", session.getPaymentMethodCategories().get(0).getIdentifier());

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"order_amount\":100"));
        assertTrue(requestPayout.contains("\"confirmation\":\"https://example.com/confirm\""));
    }

    @Test
    public void testFetch() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});
        final String payload = "{ \"purchase_country\": \"US\", \"order_amount\": 100, \"status\": \"incomplete\", \"client_token\": \"eyJhbGciOi.ewogIC\" }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        Client client = new Client(transport);
        PaymentsSessionsApi api = client.newPaymentsSessionsApi();
        PaymentsSession session = api.fetch("my-session-id");

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/payments/v1/sessions/my-session-id", transport.requestPath);
        assertEquals("US", session.getPurchaseCountry());
        Long amount = 100L;
        assertEquals(amount, session.getOrderAmount());
        assertEquals(PaymentsSession.StatusEnum.INCOMPLETE, session.getStatus());
    }

    @Test
    public void testUpdate() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        PaymentsSession data = new PaymentsSession()
            .orderAmount(100L)
            .merchantUrls(new PaymentsMerchantUrls()
                .confirmation("https://example.com/confirm")
            );

        Client client = new Client(transport);
        PaymentsSessionsApi api = client.newPaymentsSessionsApi();
        api.update("my-session-id", data);

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/payments/v1/sessions/my-session-id", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"order_amount\":100"));
        assertTrue(requestPayout.contains("\"confirmation\":\"https://example.com/confirm\""));
    }
}
