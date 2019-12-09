/*
 * Copyright 2018 Klarna AB
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

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.core.JsonGenerator;
import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.databind.*;
import com.fasterxml.jackson.databind.module.SimpleModule;
import org.threeten.bp.LocalDate;
import org.threeten.bp.LocalDateTime;
import org.threeten.bp.OffsetDateTime;

import java.io.IOException;
import java.text.SimpleDateFormat;

/**
 * FasterXML jackson ObjectMapper with predefined settings.
 */
public class DefaultMapper extends ObjectMapper {
    public DefaultMapper() {
        SimpleModule module = new SimpleModule();
        module.addDeserializer(OffsetDateTime.class, new DateDeserializer<OffsetDateTime>(OffsetDateTime.class));
        module.addDeserializer(LocalDateTime.class, new DateDeserializer<LocalDateTime>(LocalDateTime.class));
        module.addDeserializer(LocalDate.class, new DateDeserializer<LocalDate>(LocalDate.class));

        module.addSerializer(OffsetDateTime.class, new DateSerializer<OffsetDateTime>());
        module.addSerializer(LocalDateTime.class, new DateSerializer<LocalDateTime>());
        module.addSerializer(LocalDate.class, new DateSerializer<LocalDate>());

        this.registerModule(module);
        this.findAndRegisterModules();

        this.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
        this.setSerializationInclusion(JsonInclude.Include.NON_NULL);
        this.setDateFormat(new SimpleDateFormat());
    }

    class DateDeserializer<T> extends JsonDeserializer<T> {
        Class<T> type;
        DateDeserializer(Class<T> type) {
            this.type = type;
        }

        @Override
        @SuppressWarnings("unchecked")
        public T deserialize(JsonParser p, DeserializationContext ctxt) throws IOException {
            switch (this.type.getSimpleName()) {
                case "OffsetDateTime": return (T) OffsetDateTime.parse(p.getText());
                case "LocalDateTime": return (T) LocalDateTime.parse(p.getText());
                case "LocalDate": return (T) LocalDate.parse(p.getText());
                default: return null;
            }
        }
    }

    class DateSerializer<T> extends JsonSerializer<T> {
        @Override
        public void serialize(T value, JsonGenerator gen, SerializerProvider serializers) throws IOException {
            serializers.defaultSerializeValue(value.toString(), gen);
        }
    }
}
