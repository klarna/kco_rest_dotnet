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

/**
 * Test cases for the ExternalCheckout class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ExternalCheckoutTest extends TestCase {

    ExternalCheckout object;

    @Before
    public void setUp() {
        this.object = new ExternalCheckout();
    }

    @Test
    public void testGetName() {
        assertNull(this.object.getName());

        String expected = "name";
        this.object.setName(expected);

        assertSame(expected, this.object.getName());
    }

    @Test
    public void testGetRedirectUri() {
        assertNull(this.object.getRedirectUrl());

        URI expected = URI.create("http://localhost");
        this.object.setRedirectUrl(expected);

        assertSame(expected, this.object.getRedirectUrl());
    }

    @Test
    public void testGetImageUri() {
        assertNull(this.object.getImageUrl());

        URI expected = URI.create("http://localhost");
        this.object.setImageUrl(expected);

        assertSame(expected, this.object.getImageUrl());
    }

    @Test
    public void testGetFee() {
        assertNull(this.object.getFee());

        Long expected = 1000L;
        this.object.setFee(expected);

        assertSame(expected, this.object.getFee());
    }
}
