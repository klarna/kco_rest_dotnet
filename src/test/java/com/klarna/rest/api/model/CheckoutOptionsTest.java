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
 * Test cases for the CheckoutOptions class.
 */
@RunWith(MockitoJUnitRunner.class)
public class CheckoutOptionsTest extends TestCase {

    private CheckoutOptions options;

    @Before
    public void setUp() {
        options = new CheckoutOptions();
    }

    @Test
    public void testGetDateOfBirthMandatory() {
        assertNull(options.getDateOfBirthMandatory());

        options.setDateOfBirthMandatory(true);
        assertTrue(options.getDateOfBirthMandatory());
    }

    @Test
    public void testGetAllowSeparateShippingAddress() {
        assertNull(options.getAllowSeparateShippingAddress());

        options.setAllowSeparateShippingAddress(true);
        assertTrue(options.getAllowSeparateShippingAddress());
    }

    @Test
    public void testGetColorButton() {
        assertNull(options.getColorButton());

        options.setColorButton("color");
        assertEquals("color", options.getColorButton());
    }

    @Test
    public void testGetColorButtonText() {
        assertNull(options.getColorButtonText());

        options.setColorButtonText("color");
        assertEquals("color", options.getColorButtonText());
    }

    @Test
    public void testGetColorCheckbox() {
        assertNull(options.getColorCheckbox());

        options.setColorCheckbox("color");
        assertEquals("color", options.getColorCheckbox());
    }

    @Test
    public void testGetColorCheckboxCheckmark() {
        assertNull(options.getColorCheckboxCheckmark());

        options.setColorCheckboxCheckmark("color");
        assertEquals("color", options.getColorCheckboxCheckmark());
    }

    @Test
    public void testGetColorHeader() {
        assertNull(options.getColorHeader());

        options.setColorHeader("color");
        assertEquals("color", options.getColorHeader());
    }

    @Test
    public void testGetColorLink() {
        assertNull(options.getColorLink());

        options.setColorLink("color");
        assertEquals("color", options.getColorLink());
    }
}
