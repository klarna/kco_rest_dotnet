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
 * Test cases for the LastModified class.
 */
@RunWith(MockitoJUnitRunner.class)
public class LastModifiedTest extends TestCase {

    LastModified object;

    @Before
    public void setUp() {
        this.object = new LastModified();
    }

    @Test
    public void testGetPassword() {
        assertNull(this.object.getPassword());

        DateTime expected = new DateTime();
        this.object.setPassword(expected);

        assertSame(expected, this.object.getPassword());
    }

    @Test
    public void testGetEmail() {
        assertNull(this.object.getEmail());

        DateTime expected = new DateTime();
        this.object.setEmail(expected);

        assertSame(expected, this.object.getEmail());
    }

    @Test
    public void testGetListing() {
        assertNull(this.object.getListing());

        DateTime expected = new DateTime();
        this.object.setListing(expected);

        assertSame(expected, this.object.getListing());
    }

    @Test
    public void testGetLogin() {
        assertNull(this.object.getLogin());

        DateTime expected = new DateTime();
        this.object.setLogin(expected);

        assertSame(expected, this.object.getLogin());
    }

    @Test
    public void testGetAddress() {
        assertNull(this.object.getAddress());

        DateTime expected = new DateTime();
        this.object.setAddress(expected);

        assertSame(expected, this.object.getAddress());
    }
}
