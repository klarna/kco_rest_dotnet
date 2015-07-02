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
 * Test cases for the Voucher class.
 */
public class VoucherTest extends TestCase {

    Voucher object;

    @Before
    public void setUp() {
        this.object = new Voucher();

    }

    @Test
    public void testGetVoucherName() {
        assertNull(this.object.getVoucherName());

        String expected = "name";
        this.object.setVoucherName(expected);

        assertSame(expected, this.object.getVoucherName());
    }

    @Test
    public void testGetVoucherCompany() {
        assertNull(this.object.getVoucherCompany());

        String expected = "company1";
        this.object.setVoucherCompany(expected);

        assertSame(expected, this.object.getVoucherCompany());
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
    public void testGetAffiliateName() {
        assertNull(this.object.getAffiliateName());

        String expected = "affiliateName";
        this.object.setAffiliateName(expected);

        assertSame(expected, this.object.getAffiliateName());
    }
}
