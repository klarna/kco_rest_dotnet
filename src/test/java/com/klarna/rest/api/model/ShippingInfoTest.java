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
 * Test cases for the ShippingInfo class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ShippingInfoTest extends TestCase {

    private ShippingInfo info;

    @Before
    public void setUp() {
        info = new ShippingInfo();
    }

    @Test
    public void testGetShippingCompany() {
        assertNull(info.getShippingCompany());

        info.setShippingCompany("company");

        assertEquals("company", info.getShippingCompany());
    }

    @Test
    public void testGetShippingMethod() {
        assertNull(info.getShippingMethod());

        info.setShippingMethod("method");

        assertEquals("method", info.getShippingMethod());
    }

    @Test
    public void testGetTrackingNumber() {
        assertNull(info.getTrackingNumber());

        info.setTrackingNumber("number");

        assertEquals("number", info.getTrackingNumber());
    }

    @Test
    public void testGetTrackingUri() {
        assertNull(info.getTrackingUri());

        info.setTrackingUri("uri");

        assertEquals("uri", info.getTrackingUri());
    }

    @Test
    public void testGetReturnShippingCompany() {
        assertNull(info.getReturnShippingCompany());

        info.setReturnShippingCompany("company");

        assertEquals("company", info.getReturnShippingCompany());
    }

    @Test
    public void testGetReturnTrackingNumber() {
        assertNull(info.getReturnTrackingNumber());

        info.setReturnTrackingNumber("number");

        assertEquals("number", info.getReturnTrackingNumber());
    }

    @Test
    public void testGetReturnTrackingUri() {
        assertNull(info.getReturnTrackingUri());

        info.setReturnTrackingUri("uri");

        assertEquals("uri", info.getReturnTrackingUri());
    }
}
