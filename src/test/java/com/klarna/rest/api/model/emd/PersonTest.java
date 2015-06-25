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
 * Test cases for the Person class.
 */
@RunWith(MockitoJUnitRunner.class)
public class PersonTest extends TestCase {

    Person object;

    @Before
    public void setUp() {
        this.object = new Person();
    }

    @Test
    public void testGetId() {
        assertNull(this.object.getId());

        Integer expected = 123;
        this.object.setId(expected);

        assertSame(expected, this.object.getId());
    }

    @Test
    public void testGetTitle() {
        assertNull(this.object.getTitle());

        String expected = "title";
        this.object.setTitle(expected);

        assertSame(expected, this.object.getTitle());
    }

    @Test
    public void testGetFirstName() {
        assertNull(this.object.getFirstName());

        String expected = "firstName";
        this.object.setFirstName(expected);

        assertSame(expected, this.object.getFirstName());
    }

    @Test
    public void testGetLastName() {
        assertNull(this.object.getLastName());

        String expected = "lastName";
        this.object.setLastName(expected);

        assertSame(expected, this.object.getLastName());
    }
}
