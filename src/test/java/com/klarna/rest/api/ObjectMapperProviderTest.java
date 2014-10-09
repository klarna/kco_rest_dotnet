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

import org.codehaus.jackson.map.ObjectMapper;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import static org.codehaus.jackson.map.DeserializationConfig.Feature
        .FAIL_ON_UNKNOWN_PROPERTIES;
import static org.codehaus.jackson.map.PropertyNamingStrategy
        .CAMEL_CASE_TO_LOWER_CASE_WITH_UNDERSCORES;
import static org.codehaus.jackson.map.SerializationConfig.Feature
        .WRITE_DATES_AS_TIMESTAMPS;
import static org.codehaus.jackson.map.annotate.JsonSerialize.Inclusion
        .NON_NULL;

/**
 * Test cases for the ObjectMapperProvider class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ObjectMapperProviderTest extends TestCase {

    private ObjectMapperProvider provider;

    private ObjectMapper om;

    @Before
    public void setUp() {
        provider = new ObjectMapperProvider();
        om = provider.getContext(Object.class);
    }

    @Test
    public void testGetContext() {
        assertNotNull(om);
    }

    @Test
    public void testConfiguration() {
        assertEquals(CAMEL_CASE_TO_LOWER_CASE_WITH_UNDERSCORES,
                om.getDeserializationConfig().getPropertyNamingStrategy());
        assertEquals(CAMEL_CASE_TO_LOWER_CASE_WITH_UNDERSCORES,
                om.getSerializationConfig().getPropertyNamingStrategy());

        assertEquals(NON_NULL,
                om.getSerializationConfig().getSerializationInclusion());

        assertFalse(om.isEnabled(FAIL_ON_UNKNOWN_PROPERTIES));

        assertFalse(om.isEnabled(WRITE_DATES_AS_TIMESTAMPS));
    }
}
