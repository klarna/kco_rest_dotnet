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
 *
 * File containing the UserAgentTest class
 */

package com.klarna.api.ordermanagement.client;

import org.junit.Test;

import static com.klarna.api.ordermanagement.client.UserAgent.newField;
import static org.hamcrest.core.Is.is;
import static org.junit.Assert.assertThat;

public class UserAgentTest {
    @Test
    public void fieldWithKeyContainingSpaces() {
        UserAgent userAgent = agent().add(newField()
                        .withKey("KEY WITH SPACES")
                        .withName("NAME")
        );
        assertThat(userAgent.toString(), is("KEY-WITH-SPACES/NAME"));
    }

    @Test
    public void fieldWithKeyAndName() {
        UserAgent userAgent = agent().add(newField()
                        .withKey("KEY")
                        .withName("NAME")
        );
        assertThat(userAgent.toString(), is("KEY/NAME"));
    }

    @Test
    public void fieldWithKeyAndNameAndVersion() {
        UserAgent userAgent = agent().add(newField()
                        .withKey("KEY")
                        .withName("NAME")
                        .withVersion("2.5.4")
        );
        assertThat(userAgent.toString(), is("KEY/NAME_2.5.4"));
    }

    @Test
    public void fieldWithAllProperties() {
        UserAgent userAgent = agent().add(newField()
                        .withKey("KEY")
                        .withName("NAME")
                        .withVersion("2.5.4")
                        .withOptions("O1", "O2")
        );
        assertThat(userAgent.toString(), is("KEY/NAME_2.5.4 (O1 ; O2)"));
    }

    @Test
    public void withMultipleFields() {
        UserAgent userAgent = agent()
                .add(newField()
                        .withKey("KEY")
                        .withName("NAME"))
                .add(newField()
                        .withKey("KEY_2")
                        .withName("NAME_2")
                );
        assertThat(userAgent.toString(), is("KEY/NAME KEY_2/NAME_2"));
    }

    @Test(expected = IllegalArgumentException.class)
    public void duplicateKeyShouldFail() {
        agent().add(newField()
                        .withKey("KEY")
                        .withName("NAME"))
                .add(newField()
                        .withKey("KEY")
                        .withName("NAME")
        );
    }

    @Test(expected = IllegalArgumentException.class)
    public void blankKeyShouldFail() {
        agent().add(newField()
                .withKey("")
                .withName("SOME NAME")
        );
    }

    @Test(expected = IllegalArgumentException.class)
    public void blankNameShouldFail() {
        agent().add(newField()
                .withKey("SOME KEY")
                .withName("")
        );
    }

    @Test(expected = NullPointerException.class)
    public void nullKeyShouldFail() {
        agent().add(newField()
                .withKey(null)
                .withName("NAME")
        );
    }

    private UserAgent agent() {
        return new UserAgent();
    }

}
