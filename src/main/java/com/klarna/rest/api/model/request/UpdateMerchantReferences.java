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

package com.klarna.rest.api.model.request;

import com.klarna.rest.api.model.Model;

/**
 * Update merchant references data model.
 */
public class UpdateMerchantReferences extends Model {

    /**
     * Merchant order reference.
     */
    private String merchantReference1;

    /**
     * Merchant order reference.
     */
    private String merchantReference2;

    /**
     * Gets the first merchant reference.
     *
     * @return Merchant reference
     */
    public String getMerchantReference1() {
        return this.merchantReference1;
    }

    /**
     * Sets the first merchant reference.
     *
     * @param reference Merchant reference
     * @return Same instance
     */
    public UpdateMerchantReferences setMerchantReference1(
            final String reference) {
        this.merchantReference1 = reference;

        return this;
    }

    /**
     * Gets the second merchant reference.
     *
     * @return Merchant reference
     */
    public String getMerchantReference2() {
        return this.merchantReference2;
    }

    /**
     * Sets the second merchant reference.
     *
     * @param reference Merchant reference
     * @return Same instance
     */
    public UpdateMerchantReferences setMerchantReference2(
            final String reference) {
        this.merchantReference2 = reference;

        return this;
    }
}
