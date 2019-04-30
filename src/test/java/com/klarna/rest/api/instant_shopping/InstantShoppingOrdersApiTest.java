/*
 * Copyright 2019 Klarna AB
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

package com.klarna.rest.api.instant_shopping;

import com.klarna.rest.Client;
import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.api.instant_shopping.model.*;
import org.junit.Before;
import org.junit.Ignore;
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
public class InstantShoppingOrdersApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    private final String payload = "{\n" +
            "    \"name\": \"Women's Fashion\",\n" +
            "    \"purchase_country\": \"US\",\n" +
            "    \"purchase_currency\": \"USD\",\n" +
            "    \"locale\": \"en-US\",\n" +
            "    \"billing_address\": {\n" +
            "        \"given_name\": \"Jane\",\n" +
            "        \"family_name\": \"Doe\",\n" +
            "        \"email\": \"jane@doe.com\",\n" +
            "        \"title\": \"Ms\",\n" +
            "        \"street_address\": \"Lombard St 10\",\n" +
            "        \"street_address2\": \"Apt 214\",\n" +
            "        \"postal_code\": \"90210\",\n" +
            "        \"city\": \"Beverly Hills\",\n" +
            "        \"region\": \"CA\",\n" +
            "        \"phone\": \"333444555\",\n" +
            "        \"country\": \"US\",\n" +
            "        \"organization_name\": \"string\",\n" +
            "        \"attention\": \"string\"\n" +
            "    },\n" +
            "    \"shipping_address\": {\n" +
            "        \"given_name\": \"Jane\",\n" +
            "        \"family_name\": \"Doe\",\n" +
            "        \"email\": \"jane@doe.com\",\n" +
            "        \"title\": \"Ms\",\n" +
            "        \"street_address\": \"Lombard St 10\",\n" +
            "        \"street_address2\": \"Apt 214\",\n" +
            "        \"postal_code\": \"90210\",\n" +
            "        \"city\": \"Beverly Hills\",\n" +
            "        \"region\": \"CA\",\n" +
            "        \"phone\": \"333444555\",\n" +
            "        \"country\": \"US\",\n" +
            "        \"organization_name\": \"string\",\n" +
            "        \"attention\": \"string\"\n" +
            "    },\n" +
            "    \"order_amount\": 50000,\n" +
            "    \"order_tax_amount\": 5000,\n" +
            "    \"order_lines\": [\n" +
            "        {\n" +
            "            \"name\": \"Red T-Shirt\",\n" +
            "            \"type\": \"physical\",\n" +
            "            \"reference\": \"19-402-USA\",\n" +
            "            \"quantity\": 5,\n" +
            "            \"quantity_unit\": \"pcs\",\n" +
            "            \"tax_rate\": 1000,\n" +
            "            \"total_amount\": 50000,\n" +
            "            \"total_discount_amount\": 0,\n" +
            "            \"total_tax_amount\": 5000,\n" +
            "            \"unit_price\": 10000,\n" +
            "            \"product_url\": \"https://www.example.com/products/f2a8d7e34\",\n" +
            "            \"image_url\": \"https://www.example.com/logo.png\",\n" +
            "            \"product_identifiers\": {\n" +
            "                \"category_path\": \"Electronics Store > Computers & Tablets > Desktops\",\n" +
            "                \"global_trade_item_number\": \"735858293167\",\n" +
            "                \"manufacturer_part_number\": \"BOXNUC5CPYH\",\n" +
            "                \"brand\": \"Intel\"\n" +
            "            }\n" +
            "        }\n" +
            "    ],\n" +
            "    \"merchant_reference1\": \"45aa52f387871e3a210645d4\",\n" +
            "    \"merchant_reference2\": \"45aa52f387871e3a210645d4\",\n" +
            "    \"merchant_urls\": {\n" +
            "        \"terms\": \"https://example.com/terms\",\n" +
            "        \"notification\": \"https://example.com/notify\",\n" +
            "        \"confirmation\": \"https://example.com/\",\n" +
            "        \"push\": \"https://example.com/push\",\n" +
            "        \"place_order\": \"https://example.com/place-order\"\n" +
            "    },\n" +
            "    \"customer\": {\n" +
            "        \"date_of_birth\": \"1995-10-20\",\n" +
            "        \"title\": \"Mr\",\n" +
            "        \"gender\": \"male\",\n" +
            "        \"last_four_ssn\": \"0512\",\n" +
            "        \"national_identification_number\": \"3108971100\",\n" +
            "        \"type\": \"person\",\n" +
            "        \"vat_id\": \"string\",\n" +
            "        \"organization_registration_id\": \"556737-0431\",\n" +
            "        \"organization_entity_type\": \"LIMITED_COMPANY\"\n" +
            "    }\n" +
            "}";

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testRetrieveAuthorizedOrder() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        Client client = new Client(transport);
        InstantShoppingOrdersApi api = client.newInstantShoppingOrdersApi("auth-token-123");

        InstantShoppingMerchantGetOrderResponseV1 order = api.retrieveAuthorizedOrder();

        assertEquals(50000L, order.getOrderAmount().longValue());
        assertEquals("Doe", order.getShippingAddress().getFamilyName());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/instantshopping/v1/authorizations/auth-token-123", transport.requestPath);
    }

    @Test
    public void testDeclineAuthorizedOrder() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>() {{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        Client client = new Client(transport);
        InstantShoppingOrdersApi api = client.newInstantShoppingOrdersApi("auth-token-123");

        InstantShoppingMerchantDeclineOrderRequestV1 reason = new InstantShoppingMerchantDeclineOrderRequestV1()
                .denyCode("out_of_stock")
                .denyMessage("The item you are trying to buy is out of stock")
                .denyRedirectUrl("https://example.com/deny");

        api.declineAuthorizedOrder(reason);

        verify(transport.conn, times(1)).setRequestMethod("DELETE");
        assertEquals("/instantshopping/v1/authorizations/auth-token-123", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"deny_code\":\"out_of_stock\""));
        assertTrue(requestPayout.contains("\"deny_message\":\"The item you are trying to buy is out of stock\""));
    }

    @Test
    public void testApproveAuthorizedOrder() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        String payload = "{\n" +
            "    \"order_id\": \"45aa52f387871e3a210645d4\",\n" +
            "    \"fraud_status\": \"REJECTED\"\n" +
            "}";

        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        Client client = new Client(transport);
        InstantShoppingOrdersApi api = client.newInstantShoppingOrdersApi("auth-token-123");

        InstantShoppingMerchantCreateOrderRequestV1 data = new InstantShoppingMerchantCreateOrderRequestV1()
                .orderAmount(1000L)
                .name("test")
                .purchaseCountry("DE");

        InstantShoppingMerchantCreateOrderResponseV1 order = api.approveAuthorizedOrder(data);

        assertEquals("45aa52f387871e3a210645d4", order.getOrderId());
        assertEquals("REJECTED", order.getFraudStatus().toString());
        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/instantshopping/v1/authorizations/auth-token-123/orders", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"name\":\"test\""));
        assertTrue(requestPayout.contains("\"order_amount\":1000"));
        assertTrue(requestPayout.contains("\"purchase_country\":\"DE\""));
    }
}
