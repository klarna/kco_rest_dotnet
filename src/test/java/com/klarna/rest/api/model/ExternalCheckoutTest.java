/*
 * Copyright 2015 Klarna AB
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

import java.net.URI;
import java.util.ArrayList;
import java.util.Arrays;

/**
 * Test cases for the ExternalCheckout class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ExternalCheckoutTest extends TestCase {

    ExternalCheckout checkout;

    @Before
    public void setUp() {
        checkout = new ExternalCheckout();
    }

    @Test
    public void testGetName() {
        assertNull(checkout.getName());

        String expected = "name";
        checkout.setName(expected);

        assertSame(expected, checkout.getName());
    }

    @Test
    public void testGetRedirectUri() {
        assertNull(checkout.getRedirectUrl());

        URI expected = URI.create("http://localhost");
        checkout.setRedirectUrl(expected);

        assertSame(expected, checkout.getRedirectUrl());
    }

    @Test
    public void testGetImageUri() {
        assertNull(checkout.getImageUrl());

        URI expected = URI.create("http://localhost");
        checkout.setImageUrl(expected);

        assertSame(expected, checkout.getImageUrl());
    }

    @Test
    public void testGetFee() {
        assertNull(checkout.getFee());

        Long expected = 1000L;
        checkout.setFee(expected);

        assertSame(expected, checkout.getFee());
    }

    @Test
    public void testGetDescription() {
        assertNull(checkout.getDescription());

        checkout.setDescription("Custom checkout");

        assertSame("Custom checkout", checkout.getDescription());
    }

    @Test
    public void testCountries() {
        assertNull(checkout.getCountries());

        checkout.addCountriesItem("SE");
        assertTrue(checkout.getCountries().equals(new ArrayList<String>(Arrays.asList("SE"))));

        ArrayList<String> expected = new ArrayList<>(Arrays.asList("GB", "DE"));
        checkout.setCountries(expected);
        assertTrue(expected.equals(checkout.getCountries()));
    }
}
