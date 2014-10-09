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

import org.apache.commons.lang3.builder.EqualsBuilder;
import org.apache.commons.lang3.builder.HashCodeBuilder;

import static java.lang.String.format;
import static java.util.Arrays.copyOf;
import static org.apache.commons.lang3.StringUtils.capitalize;
import static org.apache.commons.lang3.StringUtils.join;
import static org.apache.commons.lang3.StringUtils.replace;

/**
 * A user agent field, for example OS/Linux_3.1.2.
 */
/* package */ class DefaultField implements Field {

    /**
     * Field key.
     */
    private String key;

    /**
     * Field name.
     */
    private String name;

    /**
     * Field version.
     */
    private String version;

    /**
     * Field options.
     */
    private String[] options = {};

    @Override
    public DefaultField setKey(final String key) {
        this.key = key;

        return this;
    }

    @Override
    public String getKey() {
        return this.key;
    }

    @Override
    public DefaultField setName(final String name) {
        this.name = name;

        return this;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public DefaultField setVersion(final String version) {
        this.version = version;

        return this;
    }

    @Override
    public String getVersion() {
        return this.version;
    }

    @Override
    public DefaultField setOptions(final String... options) {
        this.options = copyOf(options, options.length);

        return this;
    }

    @Override
    public String[] getOptions() {
        return this.options;
    }

    @Override
    public String toString() {
        String result = replace(capitalize(this.key), " ", "-");
        result += "/" + replace(this.name, " ", "-");

        if (this.version != null) {
            result += "_" + replace(this.version, " ", "-");
        }

        if (this.options.length > 0) {
            result += " " + format("(%s)", join(this.options, "; "));
        }

        return result;
    }

    @Override
    public boolean equals(final Object other) {
        return EqualsBuilder.reflectionEquals(this, other);
    }

    @Override
    public int hashCode() {
        return HashCodeBuilder.reflectionHashCode(this);
    }
}
