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
import java.util.List;
import java.util.Locale;

/**
 * Test cases for the CheckoutOrderData class.
 */
@RunWith(MockitoJUnitRunner.class)
public class CheckoutOrderDataTest extends TestCase {

    private CheckoutOrderData data;

    @Before
    public void setUp() {
        data = new CheckoutOrderData();
    }

    @Test
    public void testGetPurchaseCountry() {
        assertNull(data.getPurchaseCountry());

        data.setPurchaseCountry("country");
        assertEquals("country", data.getPurchaseCountry());
    }

    @Test
    public void testGetShippingCountries() {
        List<String> countries = new ArrayList<String>();

        assertNull(data.getShippingCountries());

        data.setShippingCountries(countries);
        assertSame(countries, data.getShippingCountries());
    }

    @Test
    public void testGetPurchaseCurrency() {
        assertNull(data.getPurchaseCurrency());

        data.setPurchaseCurrency("currency");
        assertEquals("currency", data.getPurchaseCurrency());
    }

    @Test
    public void testGetLocale() {
        assertNull(data.getLocale());

        data.setLocale("locale");
        assertEquals("locale", data.getLocale());

        data.setLocale(Locale.UK);
        assertEquals("en-gb", data.getLocale());

    }

    @Test
    public void testGetBillingAddress() {
        assertNull(data.getBillingAddress());

        Address address = new Address();

        data.setBillingAddress(address);
        assertSame(address, data.getBillingAddress());
    }

    @Test
    public void testGetShippingAddress() {
        assertNull(data.getShippingAddress());

        Address address = new Address();

        data.setShippingAddress(address);
        assertSame(address, data.getShippingAddress());
    }

    @Test
    public void testGetOrderAmount() {
        assertNull(data.getOrderAmount());

        long expected = 1000L;
        data.setOrderAmount(expected);

        long actual = data.getOrderAmount();
        assertEquals(expected, actual);
    }

    @Test
    public void testGetOrderTaxAmount() {
        assertNull(data.getOrderTaxAmount());

        long expected = 1000L;
        data.setOrderTaxAmount(expected);

        long actual = data.getOrderTaxAmount();
        assertEquals(expected, actual);
    }

    @Test
    public void testGetOrderLines() {
        assertNull(data.getOrderLines());

        List<OrderLine> lines = new ArrayList<OrderLine>();

        data.setOrderLines(lines);
        assertSame(lines, data.getOrderLines());
    }

    @Test
    public void testGetCustomer() {
        assertNull(data.getCustomer());

        Customer customer = new Customer();

        data.setCustomer(customer);
        assertSame(customer, data.getCustomer());
    }

    @Test
    public void testGetMerchantUrls() {
        assertNull(data.getMerchantUrls());

        MerchantUrls urls = new MerchantUrls();

        data.setMerchantUrls(urls);
        assertSame(urls, data.getMerchantUrls());
    }

    @Test
    public void testGetMerchantReference1() {
        assertNull(data.getMerchantReference1());

        data.setMerchantReference1("ref");
        assertEquals("ref", data.getMerchantReference1());
    }

    @Test
    public void testGetMerchantReference2() {
        assertNull(data.getMerchantReference2());

        data.setMerchantReference2("ref");
        assertEquals("ref", data.getMerchantReference2());
    }

    @Test
    public void testGetOptions() {
        assertNull(data.getOptions());

        CheckoutOptions options = new CheckoutOptions();

        data.setOptions(options);
        assertSame(options, data.getOptions());
    }

    @Test
    public void testGetReadonly() {
        assertNull(data.getStatus());
        assertNull(data.getCompletedAt());
        assertNull(data.getLastModifiedAt());
        assertNull(data.getHtmlSnippet());
        assertNull(data.getStartedAt());
        assertNull(data.getOrderId());
    }
}
