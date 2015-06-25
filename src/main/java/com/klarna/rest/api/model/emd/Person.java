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

package com.klarna.rest.api.model.emd;

import com.klarna.rest.api.model.Model;

/**
 * The model of persons.
 */
public class Person extends Model {
    /**
     * ID.
     */
    private Integer id;

    /**
     * Title.
     */
    private String title;

    /**
     * First name.
     */
    private String firstName;

    /**
     * Last name.
     */
    private String lastName;

    /**
     * Get the ID.
     *
     * @return ID.
     */
    public Integer getId() {
        return this.id;
    }

    /**
     * Set the ID.
     *
     * @param id ID.
     * @return Same instance.
     */
    public Person setId(final Integer id) {
        this.id = id;

        return this;
    }

    /**
     * Set the title.
     *
     * @return Title.
     */
    public String getTitle() {
        return this.title;
    }

    /**
     * Set the title.
     * <p>
     * Allowed values are "mr", "mrs", "ms" or blank if under 12 years.
     * </p>
     *
     * @param title Title.
     * @return Same instance.
     */
    public Person setTitle(final String title) {
        this.title = title;

        return this;
    }

    /**
     * Get the first name.
     *
     * @return First name.
     */
    public String getFirstName() {
        return this.firstName;
    }

    /**
     * Set the first name.
     *
     * @param firstName First name.
     * @return Same instance.
     */
    public Person setFirstName(final String firstName) {
        this.firstName = firstName;

        return this;
    }

    /**
     * Get the last name.
     *
     * @return Last name.
     */
    public String getLastName() {
        return this.lastName;
    }

    /**
     * Set the last name.
     *
     * @param lastName Last name.
     * @return Same instance.
     */
    public Person setLastName(final String lastName) {
        this.lastName = lastName;

        return this;
    }
}
