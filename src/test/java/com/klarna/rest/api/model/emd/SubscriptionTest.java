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

/**
 * Test cases for the Subscription class.
 */
public class SubscriptionTest extends TestCase {

    Subscription object;

    @Before
    public void setUp() {
        this.object = new Subscription();
    }

    @Test
    public void testGetSubscriptionName() {
        assertNull(this.object.getSubscriptionName());

        String expected = "name";
        this.object.setSubscriptionName(expected);

        assertSame(expected, this.object.getSubscriptionName());
    }

    @Test
    public void testGetStartTime() {
        assertNull(this.object.getStartTime());

        DateTime expected = new DateTime();
        this.object.setStartTime(expected);

        assertSame(expected, this.object.getStartTime());
    }

    @Test
    public void testGetEndTime() {
        assertNull(this.object.getEndTime());

        DateTime expected = new DateTime();
        this.object.setEndTime(expected);

        assertSame(expected, this.object.getEndTime());
    }

    @Test
    public void testIsAutoRenewalOfSubscription() {
        assertNull(this.object.isAutoRenewalOfSubscription());

        Boolean expected = true;
        this.object.setAutoRenewalOfSubscription(expected);

        assertSame(expected, this.object.isAutoRenewalOfSubscription());
    }

    @Test
    public void testAffiliateName() {
        assertNull(this.object.getAffiliateName());

        String expected = "Name";
        this.object.setAffiliateName(expected);

        assertSame(expected, this.object.getAffiliateName());
    }
}
