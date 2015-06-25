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
import org.joda.time.DateTime;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

/**
 * Test cases for the PaymentHistoryFull class.
 */
@RunWith(MockitoJUnitRunner.class)
public class PaymentHistoryFullTest extends TestCase {

    PaymentHistoryFull object;

    @Before
    public void setUp() {
        this.object = new PaymentHistoryFull();
    }

    @Test
    public void testGetUniqueAccountIdentifier() {
        assertNull(this.object.getUniqueAccountIdentifier());

        String expected = "something";
        this.object.setUniqueAccountIdentifier(expected);

        assertSame(expected, this.object.getUniqueAccountIdentifier());
    }

    @Test
    public void testGetPaymentOption() {
        assertNull(this.object.getPaymentOption());

        String expected = "option";
        this.object.setPaymentOption(expected);

        assertSame(expected, this.object.getPaymentOption());
    }

    @Test
    public void testGetNumberPaidPurchases() {
        assertNull(this.object.getNumberPaidPurchases());

        Integer expected = 4;
        this.object.setNumberPaidPurchases(expected);

        assertSame(expected, this.object.getNumberPaidPurchases());
    }

    @Test
    public void testGetTotalAmountPaidPurchases() {
        assertNull(this.object.getTotalAmountPaidPurchases());

        Long expected = 10000000L;
        this.object.setTotalAmountPaidPurchases(expected);

        assertSame(expected, this.object.getTotalAmountPaidPurchases());
    }

    @Test
    public void testGetDateOfLastPaidPurchase() {
        assertNull(this.object.getDateOfLastPaidPurchase());

        DateTime expected = new DateTime();
        this.object.setDateOfLastPaidPurchase(expected);

        assertSame(expected, this.object.getDateOfLastPaidPurchase());
    }

    @Test
    public void testGetDateOfFirstPaidPurchase() {
        assertNull(this.object.getDateOfFirstPaidPurchase());

        DateTime expected = new DateTime();
        this.object.setDateOfFirstPaidPurchase(expected);

        assertSame(expected, this.object.getDateOfFirstPaidPurchase());
    }
}
