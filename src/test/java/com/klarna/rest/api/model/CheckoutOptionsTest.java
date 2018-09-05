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

    @Test
    public void testGetAcquiringChannel() {
        assertNull(options.getAcquiringChannel());

        options.setAcquiringChannel("channel");
        assertEquals("channel", options.getAcquiringChannel());
    }

    @Test
    public void testGetShippingDetails() {
        assertNull(options.getShippingDetails());

        options.setShippingDetails("details");
        assertEquals("details", options.getShippingDetails());
    }

    @Test
    public void testGetTitleMandatory() {
        assertNull(options.getTitleMandatory());

        options.setTitleMandatory(true);
        assertTrue(options.getTitleMandatory());
    }

    @Test
    public void testGetAdditionalCheckbox() {
        assertNull(options.getAdditionalCheckbox());

        CheckoutOptionsCheckbox checkbox = new CheckoutOptionsCheckbox(){
            {
                setRequired(true);
            }
        };
        options.setAdditionalCheckbox(checkbox);
        assertEquals(checkbox, options.getAdditionalCheckbox());
    }

    @Test
    public void testGetNationalIdentificationNumberMandatory() {
        assertNull(options.getNationalIdentificationNumberMandatory());

        options.setNationalIdentificationNumberMandatory(true);
        assertTrue(options.getNationalIdentificationNumberMandatory());
    }

    @Test
    public void testGetAdditionalMerchantTerms() {
        assertNull(options.getAdditionalMerchantTerms());

        options.setAdditionalMerchantTerms("terms");
        assertEquals("terms", options.getAdditionalMerchantTerms());
    }

    @Test
    public void testGetRadiusBorder() {
        assertNull(options.getRadiusBorder());

        options.setRadiusBorder("1px");
        assertEquals("1px", options.getRadiusBorder());
    }

    @Test
    public void testGetAllowedCustomerTypes() {
        assertNull(options.getAllowedCustomerTypes());

        List<String> types = new ArrayList<String>(Arrays.asList("person", "organization"));
        options.setAllowedCustomerTypes(types);
        assertEquals(types, options.getAllowedCustomerTypes());
    }

    @Test
    public void testGetShowSubtotalDetail() {
        assertNull(options.getShowSubtotalDetail());

        options.setShowSubtotalDetail(true);
        assertTrue(options.getShowSubtotalDetail());
    }

    @Test
    public void testGetAdditionalCheckboxes() {
        assertNull(options.getAdditionalCheckboxes());

        CheckoutOptionsCheckbox checkbox = new CheckoutOptionsCheckbox(){
            {
                setRequired(true);
            }
        };
        options.addAdditionalCheckboxesItem(checkbox);
        assertEquals(Arrays.asList(checkbox), options.getAdditionalCheckboxes());

        List<CheckoutOptionsCheckbox> checkboxes = new ArrayList<CheckoutOptionsCheckbox>(Arrays.asList(checkbox, checkbox));
        options.setAdditionalCheckboxes(checkboxes);
        assertEquals(Arrays.asList(checkbox, checkbox), options.getAdditionalCheckboxes());
    }

    @Test
    public void testGetRequireValidateCallbackSuccess() {
        assertNull(options.getRequireValidateCallbackSuccess());

        options.setRequireValidateCallbackSuccess(true);
        assertTrue(options.getRequireValidateCallbackSuccess());
    }

    @Test
    public void testGetVatExcluded() {
        assertNull(options.getVatExcluded());

        options.setVatExcluded(true);
        assertTrue(options.getVatExcluded());
    }
}
