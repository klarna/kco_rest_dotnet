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
 * Test cases for the ExternalPaymentMethod class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ExternalPaymentMethodTest extends TestCase {

    ExternalPaymentMethod paymentMethod;

    @Before
    public void setUp() {
        paymentMethod = new ExternalPaymentMethod();
    }

    @Test
    public void testGetName() {
        assertNull(paymentMethod.getName());

        String expected = "name";
        paymentMethod.setName(expected);

        assertSame(expected, paymentMethod.getName());
    }

    @Test
    public void testGetRedirectUri() {
        assertNull(paymentMethod.getRedirectUrl());

        URI expected = URI.create("http://localhost");
        paymentMethod.setRedirectUrl(expected);

        assertSame(expected, paymentMethod.getRedirectUrl());
    }

    @Test
    public void testGetImageUri() {
        assertNull(paymentMethod.getImageUrl());

        URI expected = URI.create("http://localhost");
        paymentMethod.setImageUrl(expected);

        assertSame(expected, paymentMethod.getImageUrl());
    }

    @Test
    public void testGetFee() {
        assertNull(paymentMethod.getFee());

        Long expected = 1000L;
        paymentMethod.setFee(expected);

        assertSame(expected, paymentMethod.getFee());
    }

    @Test
    public void testGetDescription() {
        assertNull(paymentMethod.getDescription());

        paymentMethod.setDescription("Custom checkout");

        assertSame("Custom checkout", paymentMethod.getDescription());
    }

    @Test
    public void testCountries() {
        assertNull(paymentMethod.getCountries());

        paymentMethod.addCountriesItem("SE");
        assertTrue(paymentMethod.getCountries().equals(new ArrayList<String>(Arrays.asList("SE"))));

        ArrayList<String> expected = new ArrayList<>(Arrays.asList("GB", "DE"));
        paymentMethod.setCountries(expected);
        assertTrue(expected.equals(paymentMethod.getCountries()));
    }
}
