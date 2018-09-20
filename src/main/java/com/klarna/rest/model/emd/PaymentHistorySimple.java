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


/**
 * The model for simple purchase history.
 */
public class PaymentHistorySimple extends Model {
    /**
     * Unique account identifier.
     */
    private String uniqueAccountIdentifier;

    /**
     * Is the purchase paid before.
     */
    private Boolean paidBefore;

    /**
     * Get the unique account identifier.
     *
     * @return Unique account identifier.
     */
    public String getUniqueAccountIdentifier() {
        return this.uniqueAccountIdentifier;
    }

    /**
     * Set the unique account identifier.
     *
     * @param uniqueAccountIdentifier Unique account identifier.
     * @return Same instance.
     */
    public PaymentHistorySimple setUniqueAccountIdentifier(
            final String uniqueAccountIdentifier) {
        this.uniqueAccountIdentifier = uniqueAccountIdentifier;

        return this;
    }

    /**
     * Is the purchase paid before.
     *
     * @return True if the purchase is paid before.
     */
    public Boolean isPaidBefore() {
        return this.paidBefore;
    }

    /**
     * Set whether the purchase is paid before.
     *
     * @param paidBefore If the purchase is paid before.
     * @return Same instance.
     */
    public PaymentHistorySimple setPaidBefore(final Boolean paidBefore) {
        this.paidBefore = paidBefore;

        return this;
    }
}
