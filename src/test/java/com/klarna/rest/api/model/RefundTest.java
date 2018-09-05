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
 * Test cases for the Refund class.
 */
@RunWith(MockitoJUnitRunner.class)
public class RefundTest extends TestCase {

    private Refund refund;

    @Before
    public void setUp() {
        refund = new Refund();
    }

    @Test
    public void testGetRefundedAmount() {
        assertNull(refund.getRefundedAmount());

        long expected = 300L;
        refund.setRefundedAmount(expected);

        long actual = refund.getRefundedAmount();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetDescription() {
        assertNull(refund.getDescription());

        refund.setDescription("description");

        assertEquals("description", refund.getDescription());
    }

    @Test
    public void testGetOrderLines() {
        assertNull(refund.getOrderLines());

        List<OrderLine> lines = new ArrayList<OrderLine>();

        refund.setOrderLines(lines);

        assertSame(lines, refund.getOrderLines());
    }

    @Test
    public void testGetReadonly() {
        assertNull(refund.getRefundedAt());
        assertNull(refund.getRefundId());
        assertNull(refund.getProcessedOrderLines());
        assertNull(refund.getMerchantReversal());
    }
}
