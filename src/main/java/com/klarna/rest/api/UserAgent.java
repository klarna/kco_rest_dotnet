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
 * HTTP User agent.
 */
public interface UserAgent {

    /**
     * Partner field key.
     */
    String PARTNER = "Partner";

    /**
     * Platform field key.
     */
    String PLATFORM = "Platform";

    /**
     * Module field key.
     */
    String MODULE = "Module";

    /**
     * Language field key.
     */
    String LANGUAGE = "Language";

    /**
     * Operating system field key.
     */
    String OS = "OS";

    /**
     * Library field key.
     */
    String LIBRARY = "Library";

    /**
     * Add a new field to the user agent.
     *
     * @param field The new field to add
     * @return Same instance
     */
    UserAgent add(Field field);

    /**
     * Create an empty new field.
     *
     * Field key and name need to be set as they are mandatory.
     *
     * @return An empty new field
     */
    Field newField();

    /**
     * Get the string representation of the UserAgent.
     *
     * @return Representation of this user agent
     */
    @Override
    String toString();
}
