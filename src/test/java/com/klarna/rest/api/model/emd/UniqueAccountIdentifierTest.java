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

/**
 * Test cases for the UniqueAccountIdentifier class.
 */
public class UniqueAccountIdentifierTest extends TestCase {

    UniqueAccountIdentifier object;

    @Before
    public void setUp() {
        this.object = new UniqueAccountIdentifier();
    }

    @Test
    public void testGetEmail() {
        assertNull(this.object.getEmail());

        String expected = "email";
        this.object.setEmail(expected);

        assertSame(expected, this.object.getEmail());
    }

    @Test
    public void testGetPno() {
        assertNull(this.object.getPno());

        String expected = "4103219202";
        this.object.setPno(expected);

        assertSame(expected, this.object.getPno());
    }

    @Test
    public void testGetOther() {
        assertNull(this.object.getOther());

        String expected = "Some other information";
        this.object.setOther(expected);

        assertSame(expected, this.object.getOther());
    }
}
