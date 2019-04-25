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
import com.klarna.rest.api.instant_shopping.model.InstantShoppingButtonSetupOptionsV1;
import com.klarna.rest.api.instant_shopping.model.InstantShoppingShippingOptionV1;
import com.klarna.rest.api.merchant_card_service.VirtualCreditCardApi;
import com.klarna.rest.api.merchant_card_service.model.CardServiceSettlementRequest;
import com.klarna.rest.api.merchant_card_service.model.CardServiceSettlementResponse;
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
public class InstantShoppingButtonKeysApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    private final String payload = "{\n" +
            "    \"button_key\": \"string\",\n" +
            "    \"disabled\": true,\n" +
            "    \"merchant_urls\": {\n" +
            "        \"place_order\": \"string\",\n" +
            "        \"push\": \"string\",\n" +
            "        \"confirmation\": \"string\",\n" +
            "        \"terms\": \"string\",\n" +
            "        \"notification\": \"string\",\n" +
            "        \"update\": \"string\"\n" +
            "    },\n" +
            "    \"purchase_currency\": \"US\",\n" +
            "    \"purchase_country\": \"string\",\n" +
            "    \"billing_countries\": [\n" +
            "        \"string\"\n" +
            "    ],\n" +
            "    \"shipping_countries\": [\n" +
            "        \"string\"\n" +
            "    ],\n" +
            "    \"locale\": \"string\",\n" +
            "    \"order_amount\": 0,\n" +
            "    \"order_tax_amount\": 0,\n" +
            "    \"merchant_reference1\": \"string\",\n" +
            "    \"merchant_reference2\": \"string\",\n" +
            "    \"merchant_data\": \"string\",\n" +
            "    \"options\": {\n" +
            "        \"allow_separate_shipping_address\": false,\n" +
            "        \"date_of_birth_mandatory\": false,\n" +
            "        \"phone_mandatory\": false,\n" +
            "        \"national_identification_number_mandatory\": false,\n" +
            "        \"title_mandatory\": false\n" +
            "    },\n" +
            "    \"attachment\": {\n" +
            "        \"body\": \"string\",\n" +
            "        \"content_type\": \"application/vnd.klarna.internal.emd-v2+json\"\n" +
            "    },\n" +
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
            "    \"shipping_options\": [\n" +
            "        {\n" +
            "            \"id\": \"string\",\n" +
            "            \"name\": \"string\",\n" +
            "            \"description\": \"string\",\n" +
            "            \"promo\": \"string\",\n" +
            "            \"price\": 0,\n" +
            "            \"tax_amount\": 0,\n" +
            "            \"tax_rate\": 0,\n" +
            "            \"preselected\": true,\n" +
            "            \"shipping_method\": \"PICKUPSTORE\"\n" +
            "        }\n" +
            "    ]\n" +
            "}";

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testCreateButtonKey() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(201);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        Client client = new Client(transport);
        InstantShoppingButtonKeysApi api = client.newInstantShoppingButtonKeysApi();
        InstantShoppingButtonSetupOptionsV1 data = new InstantShoppingButtonSetupOptionsV1()
                .purchaseCurrency("EUR")
                .locale("en-GB")
                .orderAmount(100L);

        InstantShoppingButtonSetupOptionsV1 button = api.createButtonKey(data);

        assertEquals("string", button.getButtonKey());
        assertEquals(InstantShoppingShippingOptionV1.ShippingMethodEnum.PICKUPSTORE, button.getShippingOptions().get(0).getShippingMethod());
        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/instantshopping/v1/buttons", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"purchase_currency\":\"EUR\""));
        assertTrue(requestPayout.contains("\"order_amount\":100"));
    }

    @Test
    public void testUpdateButtonKey() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        Client client = new Client(transport);
        InstantShoppingButtonKeysApi api = client.newInstantShoppingButtonKeysApi();
        InstantShoppingButtonSetupOptionsV1 data = new InstantShoppingButtonSetupOptionsV1()
                .purchaseCurrency("EUR")
                .locale("en-GB")
                .orderAmount(100L);

        final String keyId = "test-button-key";

        InstantShoppingButtonSetupOptionsV1 button = api.updateButtonKey(keyId, data);

        assertEquals("string", button.getButtonKey());
        assertEquals(InstantShoppingShippingOptionV1.ShippingMethodEnum.PICKUPSTORE, button.getShippingOptions().get(0).getShippingMethod());
        verify(transport.conn, times(1)).setRequestMethod("PUT");
        assertEquals("/instantshopping/v1/buttons/" + keyId, transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();
        assertTrue(requestPayout.contains("\"purchase_currency\":\"EUR\""));
        assertTrue(requestPayout.contains("\"order_amount\":100"));
    }

    @Test
    public void testFetchButtonKeyOptions() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        Client client = new Client(transport);
        InstantShoppingButtonKeysApi api = client.newInstantShoppingButtonKeysApi();
        final String keyId = "test-button-key";

        InstantShoppingButtonSetupOptionsV1 button = api.fetchButtonKeyOptions(keyId);

        assertEquals("string", button.getButtonKey());
        assertEquals(InstantShoppingShippingOptionV1.ShippingMethodEnum.PICKUPSTORE, button.getShippingOptions().get(0).getShippingMethod());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/instantshopping/v1/buttons/" + keyId, transport.requestPath);
    }
}
