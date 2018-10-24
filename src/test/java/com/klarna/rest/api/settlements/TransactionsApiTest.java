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

package com.klarna.rest.api.settlements;

import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.model.settlements.Payout;
import com.klarna.rest.model.settlements.PayoutCollection;
import com.klarna.rest.model.settlements.PayoutSummary;
import com.klarna.rest.model.settlements.TransactionCollection;
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
import java.util.UUID;

import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class)
public class TransactionsApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testGetTransactions() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{ \"transactions\": [ { \"amount\": 2000, \"capture_id\": \"33db6f16-9f43-43fa-a587-cc51411c98e4\" } ], \"pagination\": { \"total\": 42 } }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        TransactionsApi api = new TransactionsApi(transport);
        TransactionCollection transactions = api.getTransactions();

        assertEquals(UUID.fromString("33db6f16-9f43-43fa-a587-cc51411c98e4"), transactions.getTransactions().get(0).getCaptureId());
        Long amount = 2000L;
        assertEquals(amount, transactions.getTransactions().get(0).getAmount());
        Long total = 42L;
        assertEquals(total, transactions.getPagination().getTotal());

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/transactions?", transport.requestPath);
    }

    @Test
    public void testGetTransactionsWithParams() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        HashMap<String, String> params = new HashMap<>();
        params.put("order_id", "my-order-id");

        TransactionsApi api = new TransactionsApi(transport);
        TransactionCollection transactions = api.getTransactions(params);

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/transactions?order_id=my-order-id", transport.requestPath);
    }
}
