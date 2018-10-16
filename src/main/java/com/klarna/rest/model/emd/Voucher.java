/*
 * Copyright 2018 Klarna AB
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

import org.threeten.bp.OffsetDateTime;

/**
 * The model for vouchers.
 */
public class Voucher extends Model {
    /**
     * Voucher name.
     */
    private String voucherName;

    /**
     * Voucher company name.
     */
    private String voucherCompany;

    /**
     * Start time.
     */
    private OffsetDateTime startTime;

    /**
     * End time.
     */
    private OffsetDateTime endTime;

    /**
     * Affiliate name.
     */
    private String affiliateName;

    /**
     * Get the voucher name.
     *
     * @return Voucher name.
     */
    public String getVoucherName() {
        return this.voucherName;
    }

    /**
     * Set the voucher name.
     *
     * @param voucherName Voucher name.
     * @return Same instance.
     */
    public Voucher setVoucherName(final String voucherName) {
        this.voucherName = voucherName;

        return this;
    }

    /**
     * Get the voucher company name.
     *
     * @return Voucher company name.
     */
    public String getVoucherCompany() {
        return this.voucherCompany;
    }

    /**
     * Set the voucher company name.
     *
     * @param voucherCompany Voucher company name.
     * @return Same instance.
     */
    public Voucher setVoucherCompany(final String voucherCompany) {
        this.voucherCompany = voucherCompany;

        return this;
    }

    /**
     * Get the start time.
     *
     * @return Start time.
     */
    public OffsetDateTime getStartTime() {
        return this.startTime;
    }

    /**
     * Set the start time.
     *
     * @param startTime Start time.
     * @return Same instance.
     */
    public Voucher setStartTime(final OffsetDateTime startTime) {
        this.startTime = startTime;

        return this;
    }

    /**
     * Get the end time.
     *
     * @return End time.
     */
    public OffsetDateTime getEndTime() {
        return this.endTime;
    }

    /**
     * Set the end time.
     *
     * @param endTime End time.
     * @return Same instance.
     */
    public Voucher setEndTime(final OffsetDateTime endTime) {
        this.endTime = endTime;

        return this;
    }

    /**
     * Get the affiliate name.
     *
     * @return Affiliate name.
     */
    public String getAffiliateName() {
        return this.affiliateName;
    }

    /**
     * Set the affiliate name.
     *
     * @param affiliateName Affiliate name.
     * @return Same instance.
     */
    public Voucher setAffiliateName(final String affiliateName) {
        this.affiliateName = affiliateName;

        return this;
    }
}
