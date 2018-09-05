/*
 * Copyright 2014 Klarna AB
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

package com.klarna.rest.api.model;

import com.klarna.rest.api.TestCase;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

/**
 * Test cases for the OrderData class.
 */
@RunWith(MockitoJUnitRunner.class)
public class OrderDataTest extends TestCase {

    private OrderData data;

    @Before
    public void setUp() {
        data = new OrderData();
    }

    @Test
    public void testGetReadonly() {
        assertNull(data.getMerchantReference1());
        assertNull(data.getMerchantReference2());
        assertNull(data.getOrderId());
        assertNull(data.getPurchaseCountry());
        assertNull(data.getPurchaseCurrency());
        assertNull(data.getStatus());
        assertNull(data.getBillingAddress());
        assertNull(data.getShippingAddress());
        assertNull(data.getCapturedAmount());
        assertNull(data.getOrderAmount());
        assertNull(data.getRefundedAmount());
        assertNull(data.getOriginalOrderAmount());
        assertNull(data.getRemainingAuthorizedAmount());
        assertNull(data.getCaptures());
        assertNull(data.getCreatedAt());
        assertNull(data.getCustomer());
        assertNull(data.getExpiresAt());
        assertNull(data.getKlarnaReference());
        assertNull(data.getLocale());
        assertNull(data.getOrderLines());
        assertNull(data.getRefunds());
        assertNull(data.getFraudStatus());
        assertNull(data.getMerchantData());
        assertNull(data.getInitialPaymentMethod());
    }
}
