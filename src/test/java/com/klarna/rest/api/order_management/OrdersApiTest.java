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

package com.klarna.rest.api.order_management;

import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import com.klarna.rest.api.order_management.model.*;
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

import static com.klarna.rest.api.order_management.model.OrderManagementOrder.StatusEnum.AUTHORIZED;
import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class OrdersApiTest extends TestCase {
    @Rule
    public ExpectedException expectedEx = ExpectedException.none();

    private FakeHttpUrlConnectionTransport transport;

    @Before
    public void setUp() {
        transport = new FakeHttpUrlConnectionTransport();
    }

    @Test
    public void testFetch() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(200);
        when(transport.conn.getHeaderFields()).thenReturn(new HashMap<String, List<String>>(){{
            put("Content-Type", Arrays.asList(MediaType.APPLICATION_JSON));
        }});

        final String payload = "{ \"order_id\": \"f3392f8b-6116-4073-ab96-e330819e2c07\", \"status\": \"AUTHORIZED\", \"order_amount\": 100, \"order_lines\": [ { \"reference\": \"75001\", \"type\": \"physical\" } ], \"customer\": { \"date_of_birth\": \"1981-09-06\" }, \"billing_address\": { \"given_name\": \"Klara\", \"family_name\": \"Joyce\" }, \"shipping_address\": { \"given_name\": \"Klara\", \"family_name\": \"Joyce\" }, \"created_at\": \"2015-11-29T10:25:40.000Z\", \"captures\": [ { \"capture_id\": \"4ba29b50-be7b-44f5-a492-113e6a865e22\", \"captured_amount\": 0 } ], \"refunds\": [ { \"refunded_amount\": 0, \"refunded_at\": \"2015-12-04T15:17:40.000Z\", \"order_lines\": [ { \"reference\": \"75001\", \"type\": \"physical\" } ] } ], \"initial_payment_method\": { \"type\": \"INVOICE\", \"description\": \"Pay later\" } }";
        when(transport.conn.getInputStream()).thenReturn(this.makeInputStream(payload));

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        OrderManagementOrder order = api.fetch("my-order-id");

        assertEquals("f3392f8b-6116-4073-ab96-e330819e2c07", order.getOrderId());
        assertEquals(AUTHORIZED, order.getStatus());

        Long amount = 100L;
        assertEquals(amount, order.getOrderAmount());
        assertEquals("75001", order.getOrderLines().get(0).getReference());
        verify(transport.conn, times(1)).setRequestMethod("GET");
        assertEquals("/order_management/v1/orders/my-order-id", transport.requestPath);
    }

    @Test
    public void testReleaseRemainingAuthorization() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        api.releaseRemainingAuthorization("my-order-id");

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/order_management/v1/orders/my-order-id/release-remaining-authorization", transport.requestPath);
    }

    @Test
    public void testExtendAuthorizationTime() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        api.extendAuthorizationTime("my-order-id");

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/order_management/v1/orders/my-order-id/extend-authorization-time", transport.requestPath);
    }

    @Test
    public void testUpdateCustomerAddresses() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        final OrderManagementAddress address = new OrderManagementAddress()
            .familyName("Doe")
            .givenName("John");

        OrderManagementUpdateConsumer data = new OrderManagementUpdateConsumer()
            .shippingAddress(address)
            .billingAddress(address);

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        api.updateCustomerAddresses("my-order-id", data);

        verify(transport.conn, times(1)).setRequestMethod("PATCH");
        assertEquals("/order_management/v1/orders/my-order-id/customer-details", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();

        assertTrue(requestPayout.contains("\"given_name\":\"John\""));
        assertTrue(requestPayout.contains("\"family_name\":\"Doe\""));
    }

    @Test
    public void testCancelOrder() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        api.cancelOrder("my-order-id");

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/order_management/v1/orders/my-order-id/cancel", transport.requestPath);
    }

    @Test
    public void testUpdateMerchantReferences() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        OrderManagementUpdateMerchantReferences data = new OrderManagementUpdateMerchantReferences()
            .merchantReference1("ref-1");

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        api.updateMerchantReferences("my-order-id", data);

        verify(transport.conn, times(1)).setRequestMethod("PATCH");
        assertEquals("/order_management/v1/orders/my-order-id/merchant-references", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();

        assertTrue(requestPayout.contains("\"merchant_reference1\":\"ref-1\""));
        assertFalse(requestPayout.contains("merchant_reference2"));
    }

    @Test
    public void testAcknowledgeOrder() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        api.acknowledgeOrder("my-order-id");

        verify(transport.conn, times(1)).setRequestMethod("POST");
        assertEquals("/order_management/v1/orders/my-order-id/acknowledge", transport.requestPath);
    }

    @Test
    public void testSetOrderAmountAndOrderLines() throws IOException {
        when(transport.conn.getResponseCode()).thenReturn(204);

        OrderManagementUpdateAuthorization data = new OrderManagementUpdateAuthorization()
            .orderAmount(100L);

        OrderManagementOrdersApi api = new OrderManagementOrdersApi(transport);
        api.setOrderAmountAndOrderLines("my-order-id", data);

        verify(transport.conn, times(1)).setRequestMethod("PATCH");
        assertEquals("/order_management/v1/orders/my-order-id/authorization", transport.requestPath);

        final String requestPayout = transport.requestPayout.toString();

        assertTrue(requestPayout.contains("\"order_amount\":100"));
        assertFalse(requestPayout.contains("order_lines"));
    }
}
