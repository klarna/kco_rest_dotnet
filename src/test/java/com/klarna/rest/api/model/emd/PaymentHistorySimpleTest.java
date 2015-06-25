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
 * Test cases for the PaymentHistorySimple class.
 */
@RunWith(MockitoJUnitRunner.class)
public class PaymentHistorySimpleTest extends TestCase {

    PaymentHistorySimple object;

    @Before
    public void setUp() {
        this.object = new PaymentHistorySimple();
    }

    @Test
    public void testGetUniqueAccountIdentifier() {
        assertNull(this.object.getUniqueAccountIdentifier());

        String expected = "stuff";
        this.object.setUniqueAccountIdentifier(expected);

        assertSame(expected, this.object.getUniqueAccountIdentifier());
    }

    @Test
    public void testIsPaidBefore() {
        assertNull(this.object.isPaidBefore());

        Boolean expected = true;
        this.object.setPaidBefore(expected);

        assertSame(expected, this.object.isPaidBefore());
    }
}
