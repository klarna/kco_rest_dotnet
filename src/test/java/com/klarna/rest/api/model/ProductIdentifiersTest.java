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

/**
 * Test cases for the CaptureData class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ProductIdentifiersTest extends TestCase {

    private ProductIdentifiers data;

    @Before
    public void setUp() {
        data = new ProductIdentifiers();
    }

    @Test
    public void testGetCategoryPath() {
        assertNull(data.getCategoryPath());

        data.setCategoryPath("/path/");
        assertEquals("/path/", data.getCategoryPath());
    }

    @Test
    public void testGetGlobalTradeItemNumber() {
        assertNull(data.getGlobalTradeItemNumber());

        data.setGlobalTradeItemNumber("12345");
        assertEquals("12345", data.getGlobalTradeItemNumber());
    }

    @Test
    public void testGetManufacturerPartNumber() {
        assertNull(data.getManufacturerPartNumber());

        data.setManufacturerPartNumber("12345");
        assertEquals("12345", data.getManufacturerPartNumber());
    }

    @Test
    public void testGetBrand() {
        assertNull(data.getBrand());

        data.setBrand("BrandName");
        assertEquals("BrandName", data.getBrand());
    }
}
