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

package com.klarna.rest.api.model.emd;

import com.klarna.rest.api.TestCase;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

/**
 * Test cases for the Location class.
 */
@RunWith(MockitoJUnitRunner.class)
public class LocationTest extends TestCase {

    Location object;

    @Before
    public void setUp() {
        this.object = new Location();
    }

    @Test
    public void testGetStreetAddress() {
        assertNull(this.object.getStreetAddress());

        String expected = "streetAddress";
        this.object.setStreetAddress(expected);

        assertSame(expected, this.object.getStreetAddress());
    }

    @Test
    public void testGetPostalCode() {
        assertNull(this.object.getPostalCode());

        String expected = "123 45";
        this.object.setPostalCode(expected);

        assertSame(expected, this.object.getPostalCode());
    }

    @Test
    public void testGetCity() {
        assertNull(this.object.getCity());

        String expected = "city";
        this.object.setCity(expected);

        assertSame(expected, this.object.getCity());
    }

    @Test
    public void testGetCountry() {
        assertNull(this.object.getCountry());

        String expected = "country";
        this.object.setCountry(expected);

        assertSame(expected, this.object.getCountry());
    }
}
