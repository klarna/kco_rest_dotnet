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
 * Test cases for the MerchantUrls class.
 */
@RunWith(MockitoJUnitRunner.class)
public class MerchantUrlsTest extends TestCase {

    private MerchantUrls urls;

    @Before
    public void setUp() {
        urls = new MerchantUrls();
    }

    @Test
    public void testGetTerms() {
        assertNull(urls.getTerms());

        urls.setTerms("url");
        assertEquals("url", urls.getTerms());
    }

    @Test
    public void testGetCheckout() {
        assertNull(urls.getCheckout());

        urls.setCheckout("url");
        assertEquals("url", urls.getCheckout());
    }

    @Test
    public void testGetConfirmation() {
        assertNull(urls.getConfirmation());

        urls.setConfirmation("url");
        assertEquals("url", urls.getConfirmation());
    }

    @Test
    public void testGetPush() {
        assertNull(urls.getPush());

        urls.setPush("url");
        assertEquals("url", urls.getPush());
    }

    @Test
    public void testGetValidation() {
        assertNull(urls.getValidation());

        urls.setValidation("url");
        assertEquals("url", urls.getValidation());
    }

    @Test
    public void testGetShippingOptionUpdate() {
        assertNull(urls.getShippingOptionUpdate());

        urls.setShippingOptionUpdate("url");
        assertEquals("url", urls.getShippingOptionUpdate());
    }

    @Test
    public void testGetAddressUpdate() {
        assertNull(urls.getAddressUpdate());

        urls.setAddressUpdate("url");
        assertEquals("url", urls.getAddressUpdate());
    }

    @Test
    public void testGetNotification() {
        assertNull(urls.getNotification());

        urls.setNotification("url");
        assertEquals("url", urls.getNotification());
    }
}
