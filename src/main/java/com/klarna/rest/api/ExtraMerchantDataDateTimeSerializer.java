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

package com.klarna.rest.api;

import org.codehaus.jackson.JsonGenerator;
import org.codehaus.jackson.JsonProcessingException;
import org.codehaus.jackson.map.SerializerProvider;
import org.codehaus.jackson.map.ser.std.SerializerBase;
import org.joda.time.DateTime;
import org.joda.time.format.DateTimeFormat;
import org.joda.time.format.DateTimeFormatter;

import java.io.IOException;

/**
 * Custom date serialized for EMD dates.
 */
public class ExtraMerchantDataDateTimeSerializer extends
        SerializerBase<DateTime> {
    /**
     * Constructors.
     */
    public ExtraMerchantDataDateTimeSerializer() {
        super(DateTime.class, true);
    }

    /**
     * Serialize a DateTime object according to the format EMD needs.
     *
     * @param value    Value to serialize; can <b>not</b> be null.
     * @param jgen     Generator used to output resulting Json content
     * @param provider Provider that can be used to get serializers for
     */
    @Override
    public void serialize(final DateTime value,
                          final JsonGenerator jgen,
                          final SerializerProvider provider) throws
            IOException, JsonProcessingException {
        DateTimeFormatter formatter = DateTimeFormat.forPattern(
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");
        String format = formatter.print(value);
        jgen.writeString(format);
    }
}
