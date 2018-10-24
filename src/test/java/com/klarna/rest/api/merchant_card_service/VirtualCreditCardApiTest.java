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

package com.klarna.rest.api.merchant_card_service;

import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.model.merchant_card_service.SettlementRequest;
import com.klarna.rest.model.merchant_card_service.SettlementResponse;
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
public class VirtualCreditCardApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testCreateSettlement() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(201);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{ " +
                "\"settlement_id\": \"b0ec0bbd-534c-4b1c-b28a-628bf33c3324\", " +
                "\"promise_id\": \"ee4a8e3a-9dfd-49e0-9ac8-ea2b6c76408c\", " +
                "\"order_id\": \"f3392f8b-6116-4073-ab96-e330819e2c07\", " +
                "\"cards\": [ { \"reference\": \"yPGw6i4lR0GTcyxGpS3Q6Q==\", " +
                    "\"card_id\": \"b846430c-3656-43a1-812e-2ccff4531b7d\", " +
                    "\"amount\": 10000, " +
                    "\"currency\": \"USD\"," +
                    "\"pci_data\": \"string\"," +
                    "\"iv\": \"string\"," +
                    "\"aes_key\": \"string\"," +
                    "\"brand\": \"VISA\"," +
                    "\"holder\": \"Jane Doe\" } ]," +
                "\"created_at\": \"2018-12-03T10:26:06.000Z\"," +
                "\"expires_at\": \"2018-12-04T10:26:06.000Z\" }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        VirtualCreditCardApi api = new VirtualCreditCardApi(transport);
        SettlementRequest data = new SettlementRequest() {
            {
                setPromiseId("ee4a8e3a-9dfd-49e0-9ac8-ea2b6c76408c");
                setKeyId("16e4b85e-899b-4427-a39f-07a496e9515b");
            }
        };
        SettlementResponse settlement = api.createSettlement(data);

        assertEquals("b0ec0bbd-534c-4b1c-b28a-628bf33c3324", settlement.getSettlementId());
        assertEquals("b846430c-3656-43a1-812e-2ccff4531b7d", settlement.getCards().get(0).getCardId());
        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/merchantcard/v3/settlements", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"promise_id\":\"ee4a8e3a-9dfd-49e0-9ac8-ea2b6c76408c\""));
        assertTrue(requestPayout.contains("\"key_id\":\"16e4b85e-899b-4427-a39f-07a496e9515b\""));
    }

    @Test
    public void testRetrieveExistingSettlement() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{ " +
                "\"settlement_id\": \"b0ec0bbd-534c-4b1c-b28a-628bf33c3324\", " +
                "\"promise_id\": \"ee4a8e3a-9dfd-49e0-9ac8-ea2b6c76408c\", " +
                "\"order_id\": \"f3392f8b-6116-4073-ab96-e330819e2c07\"}";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        VirtualCreditCardApi api = new VirtualCreditCardApi(transport);
        SettlementResponse settlement = api.retrieveExistingSettlement("my-settlement-id", "secret-header-key");

        assertEquals("b0ec0bbd-534c-4b1c-b28a-628bf33c3324", settlement.getSettlementId());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/merchantcard/v3/settlements/my-settlement-id", transport.requestPath);
        assertEquals("secret-header-key", transport.requestHeaders.get("KeyId"));
    }

    @Test
    public void testRetrieveSettledOrderSettlement() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{ " +
                "\"settlement_id\": \"b0ec0bbd-534c-4b1c-b28a-628bf33c3324\", " +
                "\"promise_id\": \"ee4a8e3a-9dfd-49e0-9ac8-ea2b6c76408c\", " +
                "\"order_id\": \"f3392f8b-6116-4073-ab96-e330819e2c07\"}";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        VirtualCreditCardApi api = new VirtualCreditCardApi(transport);
        SettlementResponse settlement = api.retrieveSettledOrderSettlement("my-order-id", "secret-header-key");

        assertEquals("b0ec0bbd-534c-4b1c-b28a-628bf33c3324", settlement.getSettlementId());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/merchantcard/v3/settlements/order/my-order-id", transport.requestPath);
        assertEquals("secret-header-key", transport.requestHeaders.get("KeyId"));
    }
}
