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

/**
 * A user agent field interface, for example OS/Linux_3.1.2.
 */
public interface Field {

    /**
     * Sets the key of the field.
     *
     * @param key Field key
     * @return Same instance
     */
    Field setKey(final String key);

    /**
     * Gets the key of the field.
     *
     * @return Field key
     */
    String getKey();

    /**
     * Sets the name of the field.
     *
     * @param name Field name
     * @return Same instance
     */
    Field setName(final String name);

    /**
     * Gets the name of the field.
     *
     * @return Field name
     */
    String getName();

    /**
     * Sets the version of the field.
     *
     * @param version Field version
     * @return Same instance
     */
    Field setVersion(final String version);

    /**
     * Gets the version of the field.
     *
     * @return Field version
     */
    String getVersion();

    /**
     * Sets the options for the field.
     *
     * @param options Field options
     * @return Same instance
     */
    Field setOptions(final String... options);

    /**
     * Gets the options for the field.
     *
     * @return Field options
     */
    String[] getOptions();
}
