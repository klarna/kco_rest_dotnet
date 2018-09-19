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

package com.klarna.rest.model.emd;

import com.klarna.rest.model.Model;

/**
 * Model for unique account identifiers.
 */
public class UniqueAccountIdentifier extends Model {
    /**
     * Email address.
     */
    private String email;

    /**
     * PNO.
     */
    private String pno;

    /**
     * Other information.
     */
    private String other;

    /**
     * Get the email address.
     *
     * @return Email address.
     */
    public String getEmail() {
        return this.email;
    }

    /**
     * Set the email address.
     *
     * @param email Email address.
     * @return Same instance.
     */
    public UniqueAccountIdentifier setEmail(final String email) {
        this.email = email;

        return this;
    }

    /**
     * Get the PNO.
     *
     * @return PNO.
     */
    public String getPno() {
        return this.pno;
    }

    /**
     * Set the PNO.
     *
     * @param pno PNO.
     * @return Same instance.
     */
    public UniqueAccountIdentifier setPno(final String pno) {
        this.pno = pno;

        return this;
    }

    /**
     * Get the other information.
     *
     * @return other information.
     */
    public String getOther() {
        return this.other;
    }

    /**
     * Set the other information.
     *
     * @param other Other information.
     * @return Same instance.
     */
    public UniqueAccountIdentifier setOther(final String other) {
        this.other = other;

        return this;
    }
}
