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

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Test cases for the CheckoutOptions class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ShippingOptionsTest extends TestCase {

    private ShippingOption options;

    @Before
    public void setUp() {
        options = new ShippingOption();
    }

    @Test
    public void testGetId() {
        assertNull(options.getId());

        options.setId("123");
        assertEquals("123", options.getId());
    }

    @Test
    public void testGetName() {
        assertNull(options.getName());

        options.setName("name");
        assertEquals("name", options.getName());
    }

    @Test
    public void testGetDescription() {
        assertNull(options.getDescription());

        options.setDescription("description");
        assertEquals("description", options.getDescription());
    }

    @Test
    public void testGetPromo() {
        assertNull(options.getPromo());

        options.setPromo("promo");
        assertEquals("promo", options.getPromo());
    }

    @Test
    public void testGetPrice() {
        assertNull(options.getPrice());

        Long price = 1000L;
        options.setPrice(price);
        assertEquals(price, options.getPrice());
    }

    @Test
    public void testGetTaxAmount() {
        assertNull(options.getTaxAmount());

        Long tax = 1000L;
        options.setTaxAmount(tax);
        assertEquals(tax, options.getTaxAmount());
    }

    @Test
    public void testGetTaxRate() {
        assertNull(options.getTaxRate());

        Long taxRate = 10L;
        options.setTaxRate(taxRate);
        assertEquals(taxRate, options.getTaxRate());
    }

    @Test
    public void testGetRequired() {
        assertNull(options.getPreselected());

        options.setPreselected(true);
        assertTrue(options.getPreselected());
    }

    @Test
    public void testGetShippingMethod() {
        assertNull(options.getShippingMethod());

        options.setShippingMethod("DHL");
        assertEquals("DHL", options.getShippingMethod());
    }
}
