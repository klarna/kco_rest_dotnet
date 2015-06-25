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
 * The model for insurances.
 */
public class Insurance extends Model {
    /**
     * Insurance company name.
     */
    private String insuranceCompany;

    /**
     * Insurance type.
     */
    private String insuranceType;

    /**
     * Insurance price.
     */
    private Long insurancePrice;

    /**
     * Get the insurance company name.
     *
     * @return Insurance company name.
     */
    public String getInsuranceCompany() {
        return this.insuranceCompany;
    }

    /**
     * Set the insurance company name.
     *
     * @param insuranceCompany Insurance company name.
     * @return Same instance.
     */
    public Insurance setInsuranceCompany(final String insuranceCompany) {
        this.insuranceCompany = insuranceCompany;

        return this;
    }

    /**
     * Get the insurance type.
     *
     * @return Insurance type.
     */
    public String getInsuranceType() {
        return this.insuranceType;
    }

    /**
     * Set the insurance type.
     * <p>
     * Allowed values are "cancellation", "travel", "cancellation_travel"
     * or "bankruptcy".
     * </p>
     *
     * @param insuranceType Insurance type.
     * @return Same instance.
     */
    public Insurance setInsuranceType(final String insuranceType) {
        this.insuranceType = insuranceType;

        return this;
    }

    /**
     * Get the insurance price.
     *
     * @return Insurance price.
     */
    public Long getInsurancePrice() {
        return this.insurancePrice;
    }

    /**
     * Set the insurance price.
     *
     * @param insurancePrice Insurance price.
     * @return Same instance.
     */
    public Insurance setInsurancePrice(final Long insurancePrice) {
        this.insurancePrice = insurancePrice;

        return this;
    }
}
