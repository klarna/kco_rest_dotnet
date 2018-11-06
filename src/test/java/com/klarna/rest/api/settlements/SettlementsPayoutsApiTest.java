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
import com.klarna.rest.api.settlements.model.SettlementsPayout;
import com.klarna.rest.api.settlements.model.SettlementsPayoutCollection;
import com.klarna.rest.api.settlements.model.SettlementsPayoutSummary;
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

import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class SettlementsPayoutsApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testGetPayout() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        final String payload = "{ \"totals\": { \"commission_amount\": 550 }, \"payment_reference\": \"XISA93DJ\", \"payout_date\": \"2016-12-14T07:52:26Z\", \"merchant_settlement_type\": \"NET\" }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        SettlementsPayoutsApi api = new SettlementsPayoutsApi(transport);
        SettlementsPayout payout = api.getPayout("payment-ref");

        assertEquals("XISA93DJ", payout.getPaymentReference());
        assertEquals(SettlementsPayout.MerchantSettlementTypeEnum.NET, payout.getMerchantSettlementType());
        assertEquals("2016-12-14T07:52:26Z", payout.getPayoutDate().toString());

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/payouts/payment-ref", transport.requestPath);
    }

    @Test
    public void testGetAllPayouts() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        final String payload = "{ \"payouts\": [ { \"totals\": { \"commission_amount\": 550 }, \"payment_reference\": \"XISA93DJ\" } ], \"pagination\": { \"count\": 10 } }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        SettlementsPayoutsApi api = new SettlementsPayoutsApi(transport);
        SettlementsPayoutCollection payouts = api.getAllPayouts();

        Long count = 10L;
        assertEquals(count, payouts.getPagination().getCount());
        assertEquals("XISA93DJ", payouts.getPayouts().get(0).getPaymentReference());
        Long comission = 550L;
        assertEquals(comission, payouts.getPayouts().get(0).getTotals().getCommissionAmount());

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/payouts?", transport.requestPath);
    }

    @Test
    public void testGetAllPayoutsWithParams() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        HashMap<String, String> params = new HashMap<>();
        params.put("size", "10");
        params.put("start_date", "2016-12-14T07:52:26Z");

        SettlementsPayoutsApi api = new SettlementsPayoutsApi(transport);
        api.getAllPayouts(params);

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertTrue(transport.requestPath.contains("size=10"));
        assertTrue(transport.requestPath.contains("start_date=2016-12-14T07%3A52%3A26Z"));
    }

    @Test
    public void testGetSumamry() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});
        final String payload = "[ { \"summary_total_fee_correction_amount\": 550, \"summary_payout_date_start\": \"2016-12-14T07:52:26Z\" } ]";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        HashMap<String, String> params = new HashMap<>();
        params.put("start_date", "2016-12-14T07:52:26Z");
        params.put("end_date", "2018-12-14T07:52:26Z");

        SettlementsPayoutsApi api = new SettlementsPayoutsApi(transport);
        SettlementsPayoutSummary[] summary = api.getSummary(params);
        Long fee = 550L;
        assertEquals(fee, summary[0].getSummaryTotalFeeCorrectionAmount());
        assertEquals("2016-12-14T07:52:26Z", summary[0].getSummaryPayoutDateStart().toString());

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertTrue(transport.requestPath.contains("end_date=2018-12-14T07%3A52%3A26Z"));
        assertTrue(transport.requestPath.contains("start_date=2016-12-14T07%3A52%3A26Z"));
    }
}
