/**
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

import java.util.TreeMap;

import static org.apache.commons.lang3.StringUtils.join;
import static org.apache.commons.lang3.Validate.notBlank;
import static org.apache.commons.lang3.Validate.notNull;

/**
 * User agent class for providing environmental information
 * through a user agent header.
 */
/* package */ class DefaultUserAgent implements UserAgent {

    /**
     * User agent fields.
     */
    private final TreeMap<String, Field> fields =
            new TreeMap<String, Field>(String.CASE_INSENSITIVE_ORDER);

    @Override
    public UserAgent add(final Field field) {
        notBlank(field.getKey(), "Field key missing");
        notBlank(field.getName(), "Field name missing");
        notNull(field.getOptions(), "Field options may not be null");

        if (this.fields.containsKey(field.getKey())) {
            throw new IllegalArgumentException(
                    "Field may not be redefined: key = " + field.getKey()
            );
        }

        this.fields.put(field.getKey(), field);

        return this;
    }

    @Override
    public Field newField() {
        return new DefaultField();
    }

    /**
     * Get the string representation of the UserAgent.
     *
     * @return String
     */
    @Override
    public String toString() {
        return join(this.fields.values(), " ");
    }
}
