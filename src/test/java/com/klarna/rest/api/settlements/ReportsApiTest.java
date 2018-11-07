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
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.io.IOException;
import java.util.*;

import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class)
public class ReportsApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testGetCSVPayoutReport() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList("text/csv"));
        }});
        final String payload = "a;b;c\n1;2;3";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        HashMap<String, String> params = new HashMap<>();
        params.put("payment_reference", "ref-id");

        SettlementsReportsApi api = new SettlementsReportsApi(transport);
        byte[] csv = api.getCSVPayoutReport(params);

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/reports/payout-with-transactions?payment_reference=ref-id", transport.requestPath);
        assertEquals(payload, new String(csv));
    }

    @Test
    public void testGetCSVSummary() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList("text/csv"));
        }});
        final String payload = "a;b;c\n1;2;3";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        HashMap<String, String> params = new HashMap<>();
        params.put("start_date", "123456");

        SettlementsReportsApi api = new SettlementsReportsApi(transport);
        byte[] csv = api.getCSVSummary(params);

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/reports/payouts-summary-with-transactions?start_date=123456", transport.requestPath);
        assertEquals(payload, new String(csv));
    }

    @Test
    public void testGetPDFPayoutSummaryReport() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList("application/pdf"));
        }});
        final String payload = "a;b;c\n1;2;3";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        HashMap<String, String> params = new HashMap<>();
        params.put("payment_reference", "ref-123");

        SettlementsReportsApi api = new SettlementsReportsApi(transport);
        byte[] pdf = api.getPDFPayoutsSummaryReport(params);

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/reports/payout?payment_reference=ref-123", transport.requestPath);
        assertEquals(payload, new String(pdf));
    }

    @Test
    public void testGetPDFSummary() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList("application/pdf"));
        }});
        final String payload = "a;b;c\n1;2;3";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        HashMap<String, String> params = new HashMap<>();
        params.put("start_date", "123456");

        SettlementsReportsApi api = new SettlementsReportsApi(transport);
        byte[] pdf = api.getPDFSummary(params);

        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/settlements/v1/reports/payouts-summary?start_date=123456", transport.requestPath);
        assertEquals(payload, new String(pdf));
    }
}
