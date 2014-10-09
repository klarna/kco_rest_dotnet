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
import com.klarna.rest.api.model.OrderLine;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.ArrayList;
import java.util.List;

/**
 * Test cases for the UpdateAuthorization class.
 */
@RunWith(MockitoJUnitRunner.class)
public class UpdateAuthorizationTest extends TestCase {

    private UpdateAuthorization update;

    @Before
    public void setUp() {
        update = new UpdateAuthorization();
    }

    @Test
    public void testGetOrderAmount() {
        assertNull(update.getOrderAmount());

        long expected = 1000L;
        update.setOrderAmount(expected);

        long actual = update.getOrderAmount();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetDescription() {
        assertNull(update.getDescription());

        update.setDescription("description");

        assertEquals("description", update.getDescription());
    }

    @Test
    public void testGetOrderLines() {
        assertNull(update.getOrderLines());

        List<OrderLine> lines = new ArrayList<OrderLine>();

        update.setOrderLines(lines);

        assertSame(lines, update.getOrderLines());
    }
}
