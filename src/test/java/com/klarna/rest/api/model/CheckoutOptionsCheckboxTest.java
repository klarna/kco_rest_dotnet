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
 * Test cases for the CaptureData class.
 */
@RunWith(MockitoJUnitRunner.class)
public class CheckoutOptionsCheckboxTest extends TestCase {

    private CheckoutOptionsCheckbox data;

    @Before
    public void setUp() {
        data = new CheckoutOptionsCheckbox();
    }

    @Test
    public void testGetId() {
        assertNull(data.getId());

        data.setId("1");
        assertEquals("1", data.getId());
    }

    @Test
    public void testGetText() {
        assertNull(data.getText());

        data.setText("checkbox");
        assertEquals("checkbox", data.getText());
    }

    @Test
    public void testGetChecked() {
        assertNull(data.getChecked());

        data.setChecked(true);
        assertTrue(data.getChecked());
    }

    @Test
    public void testGetRequired() {
        assertNull(data.getRequired());

        data.setRequired(true);
        assertTrue(data.getRequired());
    }
}
