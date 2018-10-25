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

package com.klarna.rest.api.hosted_payment_page;

import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.model.hosted_payment_page.*;
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
public class SessionsApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testGetHPPSession() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{ \"authorization_token\": \"b4bd3423-24e3\", " +
                "\"status\": \"COMPLETED\", " +
                "\"updated_at\": \"2038-01-19T03:14:07.000Z\" }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        SessionsApi api = new SessionsApi(transport);
        SessionResponseV1 session = api.fetch("my-session-id");

        assertEquals("b4bd3423-24e3", session.getAuthorizationToken());
        assertEquals(SessionResponseV1.StatusEnum.COMPLETED, session.getStatus());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/hpp/v1/sessions/my-session-id", transport.requestPath);
    }

    @Test
    public void testDistributeLink() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        SessionsApi api = new SessionsApi(transport);
        DistributionRequestV1 data = new DistributionRequestV1(){
            {
                setContactInformation(new DistributionContactV1(){
                    {
                        setEmail("test@example.com");
                    }
                });
                setMethod(MethodEnum.SMS);
                setTemplate(TemplateEnum.INSTORE_PURCHASE);
            }
        };

        api.distributeLink("my-session-id", data);

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/hpp/v1/sessions/my-session-id/distribution", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"email\":\"test@example.com\""));
        assertTrue(requestPayout.contains("\"method\":\"sms\""));
        assertTrue(requestPayout.contains("\"template\":\"INSTORE_PURCHASE\""));
    }

    @Test
    public void testCreateHPPSession() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(201);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", new ArrayList<String>(){
                {
                    add(MediaType.APPLICATION_JSON);
                }
            });
        }});

        final String payload = "{" +
                "\"distribution_url\": \"https://api.klarna.com/hpp/v1/sessions/9cbc9884/distribution\"," +
                "\"redirect_url\": \"https://buy.klarna.com/hpp/9cbc9884\"" +
                "}";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        SessionCreationRequestV1 data = new SessionCreationRequestV1(){
            {
                setPaymentSessionUrl("https://api.klarna.com/payments/v1/sessions/92d97f60");
                setMerchantUrls(new MerchantUrlsV1(){
                    {
                        setTerms("https://example.com/terms");
                    }
                });
                setOptions(new OptionsV1(){
                    {
                        setPurchaseType(PurchaseTypeEnum.BUY);
                        setPaymentMethodCategory(PaymentMethodCategoryEnum.PAY_LATER);
                    }
                });
            }
        };

        SessionsApi api = new SessionsApi(transport);
        SessionCreationResponseV1 response = api.create(data);

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/hpp/v1/sessions", transport.requestPath);

        assertEquals("https://api.klarna.com/hpp/v1/sessions/9cbc9884/distribution", response.getDistributionUrl());
        assertEquals("https://buy.klarna.com/hpp/9cbc9884", response.getRedirectUrl());

        final String requestPayout = transport.requestPayout.toString();

        assertTrue(requestPayout.contains("\"terms\":\"https://example.com/terms\""));
        assertTrue(requestPayout.contains("\"payment_method_category\":\"PAY_LATER\""));
        assertTrue(requestPayout.contains("\"purchase_type\":\"BUY\""));
        assertTrue(requestPayout.contains("\"payment_session_url\":\"https://api.klarna.com/payments/v1/sessions/92d97f60\""));
    }
}
