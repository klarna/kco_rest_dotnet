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
 * Test cases for the Insurance class.
 */
@RunWith(MockitoJUnitRunner.class)
public class InsuranceTest extends TestCase {

    Insurance object;

    @Before
    public void setUp() {
        this.object = new Insurance();
    }

    @Test
    public void testGetInsuranceCompany() {
        assertNull(this.object.getInsuranceCompany());

        String expected = "insurance company";
        this.object.setInsuranceCompany(expected);

        assertSame(expected, this.object.getInsuranceCompany());
    }

    @Test
    public void testGetInsuranceType() {
        assertNull(this.object.getInsuranceType());

        String expected = "type";
        this.object.setInsuranceType(expected);

        assertSame(expected, this.object.getInsuranceType());
    }

    @Test
    public void testGetInsurancePrice() {
        assertNull(this.object.getInsurancePrice());

        Long expected = 100000L;
        this.object.setInsurancePrice(expected);

        assertSame(expected, this.object.getInsurancePrice());
    }
}
