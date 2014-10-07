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
 * File containing the UserAgent class
 */

package com.klarna.api.ordermanagement.client;

import java.util.ArrayList;
import java.util.List;

import static java.lang.String.format;
import static java.lang.System.getProperty;
import static java.util.Arrays.copyOf;
import static org.apache.commons.lang3.StringUtils.join;
import static org.apache.commons.lang3.Validate.notBlank;
import static org.apache.commons.lang3.Validate.notNull;

/**
 * User agent class for providing environmental information
 * through a user agent header.
 */
public class UserAgent {

    /**
     * Partner field key.
     */
    public static final String PARTNER = "Partner";
    /**
     * Platform field key.
     */
    public static final String PLATFORM = "Platform";
    /**
     * Module field key.
     */
    public static final String MODULE = "Module";

    /**
     * User agent fields.
     */
    private final List<UserAgent.Field> fields = new ArrayList<>();

    /**
     * A user agent header with default set of fields
     * including library, operating system and java information.
     */
    public static UserAgent withDefaultFields() {
        UserAgent userAgent = new UserAgent();
        userAgent.addDefaultFields();
        return userAgent;
    }

    private void addDefaultFields() {
        add(newField()
                .withKey("Library")
                .withName("Klarna.kco_rest_java")
                .withVersion(ApiClient.VERSION));
        add(newField()
                .withKey("OS")
                .withName(getProperty("os.name"))
                .withVersion(getProperty("os.version")));
        add(newField()
                .withKey("Language")
                .withName("Java")
                .withVersion(getProperty("java.version"))
                .withOptions(
                        "Vendor/" + getProperty("java.vendor"),
                        "VM/" + getProperty("java.vm.name")
                ));
    }

    /**
     * Add a new field to the user agent.
     *
     * @param field the new field to add
     * @return this user agent
     * @throws java.lang.IllegalArgumentException if field with key already exists in user agent
     * @throws java.lang.NullPointerException     if key or name is null
     * @throws java.lang.IllegalArgumentException if key or name is empty
     */
    public UserAgent add(Field field) {
        notBlank(field.key, "Field key missing!");
        notBlank(field.name, "Field name missing!");
        notNull(field.options, "Field options may not be null!");

        if (fields.contains(field)) {
            throw new IllegalArgumentException("Field may not be redefined: key = " + field.key);
        }
        fields.add(field);
        return this;
    }

    /**
     * Create an empty new field. Use the field with* methods to populate the new field.
     * Field key and name are mandatory.
     *
     * @return an empty new field
     */
    public static Field newField() {
        return new Field();
    }

    /**
     * Get the string representation of the UserAgent.
     *
     * @return String
     */
    @Override
    public String toString() {
        return join(fields, " ");
    }

    /**
     * A user agent field, for example OS/Linux_3.1.2.
     */
    public static class Field {

        private String key;
        private String name;
        private String version;
        private String[] options = {};

        private Field() {
            // intentionally empty
        }

        public Field withKey(String key) {
            this.key = key;
            return this;
        }

        public Field withName(String name) {
            this.name = name;
            return this;
        }

        public Field withVersion(String version) {
            this.version = version;
            return this;
        }

        public Field withOptions(String... options) {
            this.options = copyOf(options, options.length);
            return this;
        }

        @Override
        public String toString() {
            String result = replaceSpaces(key) + "/" + name;
            if (version != null) {
                result += "_" + version;
            }
            if (options.length > 0) {
                result += " " + format("(%s)", join(options, " ; "));
            }
            return result;
        }

        private String replaceSpaces(String input) {
            if (input == null) {
                return null;
            }
            return input.replace(" ", "-");
        }

        @Override
        public boolean equals(Object other) {
            if (other instanceof Field) {
                return key.equals(((Field) other).key);
            }
            return false;
        }

        @Override
        public int hashCode() {
            return key.hashCode();
        }
    }
}