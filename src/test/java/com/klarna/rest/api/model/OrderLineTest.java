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
 * Test cases for the OrderLine class.
 */
@RunWith(MockitoJUnitRunner.class)
public class OrderLineTest extends TestCase {

    private OrderLine item;

    @Before
    public void setUp() {
        item = new OrderLine();
    }

    @Test
    public void testGetType() {
        assertNull(item.getType());

        item.setType("type");
        assertEquals("type", item.getType());
    }

    @Test
    public void testGetReference() {
        assertNull(item.getReference());

        item.setReference("ref");
        assertEquals("ref", item.getReference());
    }

    @Test
    public void testGetName() {
        assertNull(item.getName());

        item.setName("name");
        assertEquals("name", item.getName());

    }

    @Test
    public void testGetQuantity() {
        assertNull(item.getQuantity());

        long expected = 1L;
        item.setQuantity(expected);

        long actual = item.getQuantity();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetQuantityUnit() {
        assertNull(item.getQuantityUnit());

        item.setQuantityUnit("pcs");
        assertEquals("pcs", item.getQuantityUnit());
    }

    @Test
    public void testGetUnitPrice() {
        assertNull(item.getUnitPrice());

        long expected = 100L;
        item.setUnitPrice(expected);

        long actual = item.getUnitPrice();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetTaxRate() {
        assertNull(item.getTaxRate());

        int expected = 25;
        item.setTaxRate(expected);

        int actual = item.getTaxRate();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetTotalAmount() {
        assertNull(item.getTotalAmount());

        long expected = 1000L;
        item.setTotalAmount(expected);

        long actual = item.getTotalAmount();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetTotalDiscountAmount() {
        assertNull(item.getTotalDiscountAmount());

        long expected = 20L;
        item.setTotalDiscountAmount(expected);

        long actual = item.getTotalDiscountAmount();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetTotalTaxAmount() {
        assertNull(item.getTotalTaxAmount());

        long expected = 15L;
        item.setTotalTaxAmount(expected);

        long actual = item.getTotalTaxAmount();

        assertEquals(expected, actual);
    }
}
