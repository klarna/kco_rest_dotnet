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

package com.klarna.rest.api;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import static org.junit.Assert.assertArrayEquals;

/**
 * Test cases for the DefaultField class.
 */
@RunWith(MockitoJUnitRunner.class)
public class DefaultFieldTest extends TestCase {

    private static final String KEY = "the-key";

    private static final String NAME = "the-name";

    private static final String VERSION = "the-version";

    private static final String[] OPTIONS = {"opt1", "opt2"};

    private DefaultField field;

    @Before
    public void setUp() {
        field = new DefaultField();
    }

    @Test
    public void testGetKey() {
        field.setKey(KEY);

        assertEquals(KEY, field.getKey());
    }

    @Test
    public void testGetName() {
        field.setName(NAME);

        assertEquals(NAME, field.getName());
    }

    @Test
    public void testVersion() {
        field.setVersion(VERSION);

        assertEquals(VERSION, field.getVersion());
    }

    @Test
    public void testGetOptions() {
        field.setOptions(OPTIONS);

        assertArrayEquals(OPTIONS, field.getOptions());
    }

    @Test
    public void testToString() {
        assertEquals("null/null", field.toString());

        field.setKey(KEY)
                .setName(NAME);

        assertEquals("The-key/the-name", field.toString());

        field.setVersion(VERSION);

        assertEquals("The-key/the-name_the-version", field.toString());

        field.setOptions(OPTIONS);

        assertEquals("The-key/the-name_the-version (opt1; opt2)",
                field.toString());
    }

    @Test
    public void testEquals() {
        DefaultField other = new DefaultField();

        assertTrue(field.equals(other));

        assertFalse(field.setKey(KEY).equals(other));
        assertTrue(other.setKey(KEY).equals(field));

        assertFalse(field.equals(null));
        assertFalse(field.equals(new Object()));

        assertTrue(field.equals(field));
    }
}
