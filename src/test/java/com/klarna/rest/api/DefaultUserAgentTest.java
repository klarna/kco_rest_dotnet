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

import static org.hamcrest.core.Is.is;
import static org.junit.Assert.assertThat;

/**
 * Test cases for the DefaultUserAgent class.
 */
@RunWith(MockitoJUnitRunner.class)
public class DefaultUserAgentTest extends TestCase {

    private DefaultUserAgent agent;

    @Before
    public void setUp() {
        agent = new DefaultUserAgent();
    }

    @Test
    public void fieldWithKeyContainingSpaces() {
        Field field = agent.newField()
                .setKey("KEY WITH SPACES")
                .setName("NAME SPACES");

        agent.add(field);

        assertThat(agent.toString(), is("KEY-WITH-SPACES/NAME-SPACES"));
    }

    @Test
    public void fieldWithKeyAndName() {
        Field field = agent.newField()
                .setKey("KEY")
                .setName("NAME");

        agent.add(field);

        assertThat(agent.toString(), is("KEY/NAME"));
    }

    @Test
    public void fieldWithKeyAndNameAndVersion() {
        Field field = agent.newField()
                .setKey("KEY")
                .setName("NAME")
                .setVersion("2.5.4");

        agent.add(field);

        assertThat(agent.toString(), is("KEY/NAME_2.5.4"));
    }

    @Test
    public void fieldWithAllProperties() {
        Field field = agent.newField()
                .setKey("KEY")
                .setName("NAME")
                .setVersion("2.5.4")
                .setOptions("O1", "O2");

        agent.add(field);

        assertThat(agent.toString(), is("KEY/NAME_2.5.4 (O1; O2)"));
    }

    @Test
    public void withMultipleFields() {
        Field field = agent.newField()
                .setKey("KEY")
                .setName("NAME");

        agent.add(field);

        Field field2 = agent.newField()
                .setKey("KEY_2")
                .setName("NAME_2");

        agent.add(field2);

        assertThat(agent.toString(), is("KEY/NAME KEY_2/NAME_2"));
    }

    @Test
    public void testFormat() {
        Field library = agent.newField()
                .setKey("Library")
                .setName("Klarna.kco_rest_java")
                .setVersion("10.2.1 special")
                .setOptions("opt 1", "opt2");

        agent.add(library);

        Field os = agent.newField()
                .setKey("OS")
                .setName("Mac OS X")
                .setVersion("1.2.3_52")
                .setOptions("mountain lion");

        agent.add(os);

        String expected = "Library/Klarna.kco_rest_java_10.2.1-special (opt 1; opt2) OS/Mac-OS-X_1.2.3_52 (mountain lion)";

        assertThat(agent.toString(), is(expected));
    }

    @Test(expected = IllegalArgumentException.class)
    public void duplicateKeyShouldFail() {
        Field field = agent.newField()
                .setKey("KEY")
                .setName("NAME");

        Field field2 = agent.newField()
                .setKey("KEY")
                .setName("NAME");

        agent.add(field);
        agent.add(field2);
    }

    @Test(expected = IllegalArgumentException.class)
    public void blankKeyShouldFail() {
        Field field = agent.newField()
                .setKey("")
                .setName("SOME NAME");

        agent.add(field);
    }

    @Test(expected = IllegalArgumentException.class)
    public void blankNameShouldFail() {
        Field field = agent.newField()
                .setKey("SOME KEY")
                .setName("");

        agent.add(field);
    }

    @Test(expected = NullPointerException.class)
    public void nullKeyShouldFail() {
        Field field = agent.newField()
                .setKey(null)
                .setName("SOME NAME");

        agent.add(field);
    }
}
