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

import javax.ws.rs.ext.ContextResolver;
import javax.ws.rs.ext.Provider;

import static org.codehaus.jackson.map.DeserializationConfig.Feature
        .FAIL_ON_UNKNOWN_PROPERTIES;
import static org.codehaus.jackson.map.PropertyNamingStrategy
        .CAMEL_CASE_TO_LOWER_CASE_WITH_UNDERSCORES;
import static org.codehaus.jackson.map.SerializationConfig
        .Feature.WRITE_DATES_AS_TIMESTAMPS;
import static org.codehaus.jackson.map.annotate.JsonSerialize.Inclusion
        .NON_NULL;

/**
 * Custom object serialization/deserialization provider.
 */
@Provider
public class ObjectMapperProvider
        implements ContextResolver<ObjectMapper> {

    /**
     * Object mapper instance.
     */
    private final ObjectMapper om;

    /**
     * Constructs a object mapper provider instance.
     */
    public ObjectMapperProvider() {
        om = new ObjectMapper();

        // Convert propertyName to property_name
        om.setPropertyNamingStrategy(CAMEL_CASE_TO_LOWER_CASE_WITH_UNDERSCORES);

        // Do not serialize null properties
        om.setSerializationInclusion(NON_NULL);

        // Do not crash if an unknown property is deserialized
        om.configure(FAIL_ON_UNKNOWN_PROPERTIES, Boolean.FALSE);

        // Use strings for dates not timestamps
        om.configure(WRITE_DATES_AS_TIMESTAMPS, Boolean.FALSE);
    }

    /**
     * Gets the object mapper for the specified type.
     *
     * @param type Context type
     * @return Object mapper
     */
    @Override
    public ObjectMapper getContext(final Class<?> type) {
        return om;
    }
}
