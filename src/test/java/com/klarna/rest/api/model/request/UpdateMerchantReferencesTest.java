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

package com.klarna.rest.api.model.request;

import com.klarna.rest.api.TestCase;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

/**
 * Test cases for the UpdateMerchantReferences class.
 */
@RunWith(MockitoJUnitRunner.class)
public class UpdateMerchantReferencesTest extends TestCase {

    private UpdateMerchantReferences update;

    @Before
    public void setUp() {
        update = new UpdateMerchantReferences();
    }

    @Test
    public void testGetMerchantReference1() {
        assertNull(update.getMerchantReference1());

        update.setMerchantReference1("ref");

        assertEquals("ref", update.getMerchantReference1());
    }

    @Test
    public void testGetMerchantReference2() {
        assertNull(update.getMerchantReference2());

        update.setMerchantReference2("ref");

        assertEquals("ref", update.getMerchantReference2());
    }
}
