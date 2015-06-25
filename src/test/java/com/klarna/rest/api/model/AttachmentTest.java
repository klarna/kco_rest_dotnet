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

package com.klarna.rest.api.model;

import com.klarna.rest.api.TestCase;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

/**
 * Test cases for the Attachment class.
 */
@RunWith(MockitoJUnitRunner.class)
public class AttachmentTest extends TestCase {

    Attachment object;

    @Before
    public void setUp() {
        this.object = new Attachment();
    }

    @Test
    public void testGetContentType() {
        assertNull(this.object.getContentType());

        String expected = "application/json";
        this.object.setContentType(expected);

        assertSame(expected, this.object.getContentType());
    }

    @Test
    public void testGetBody() {
        assertNull(this.object.getBody());

        String expected = "{}";
        this.object.setBody(expected);

        assertSame(expected, this.object.getBody());
    }
}
