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

package com.klarna.rest.api.checkout.model.emd;

import org.threeten.bp.OffsetDateTime;

/**
 * The model for full purchase history.
 */
public class PaymentHistoryFull extends Model {
    /**
     * Unique account identifier.
     */
    private String uniqueAccountIdentifier;

    /**
     * Payment option.
     */
    private String paymentOption;

    /**
     * Number of paid purchases.
     */
    private Integer numberPaidPurchases;

    /**
     * Total amount of paid purchases.
     */
    private Long totalAmountPaidPurchases;

    /**
     * Date of the last paid purchase.
     */
    private OffsetDateTime dateOfLastPaidPurchase;

    /**
     * Date of the first paid purchase.
     */
    private OffsetDateTime dateOfFirstPaidPurchase;

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
    public PaymentHistoryFull setUniqueAccountIdentifier(
            final String uniqueAccountIdentifier) {
        this.uniqueAccountIdentifier = uniqueAccountIdentifier;

        return this;
    }

    /**
     * Get the payment option.
     * <p>
     * Allowed values are "card", "direct banking", "non klarna credit", "SMS"
     * or "other".
     * </p>
     *
     * @return Payment option.
     */
    public String getPaymentOption() {
        return this.paymentOption;
    }

    /**
     * Set the payment option.
     *
     * @param paymentOption Payment option.
     * @return Same instance.
     */
    public PaymentHistoryFull setPaymentOption(
            final String paymentOption) {
        this.paymentOption = paymentOption;

        return this;
    }

    /**
     * Get the number of paid purchases.
     *
     * @return Number of paid purchases.
     */
    public Integer getNumberPaidPurchases() {
        return this.numberPaidPurchases;
    }

    /**
     * Set the number of paid purchases.
     *
     * @param numberPaidPurchases Number of paid purchases.
     * @return Same instance.
     */
    public PaymentHistoryFull setNumberPaidPurchases(
            final Integer numberPaidPurchases) {
        this.numberPaidPurchases = numberPaidPurchases;

        return this;
    }

    /**
     * Get the total amount of paid purchases.
     *
     * @return Total amount of paid purchases.
     */
    public Long getTotalAmountPaidPurchases() {
        return this.totalAmountPaidPurchases;
    }

    /**
     * Set the total amount of paid purchases.
     *
     * @param totalAmountPaidPurchases Total amount of paid purchases.
     * @return Same instance.
     */
    public PaymentHistoryFull setTotalAmountPaidPurchases(
            final Long totalAmountPaidPurchases) {
        this.totalAmountPaidPurchases = totalAmountPaidPurchases;

        return this;
    }

    /**
     * Get the date of the last paid purchase.
     *
     * @return Date of the last paid purchase.
     */
    public OffsetDateTime getDateOfLastPaidPurchase() {
        return this.dateOfLastPaidPurchase;
    }

    /**
     * Set the date of the last paid purchase.
     *
     * @param dateOfLastPaidPurchase Date of the last paid purchase.
     * @return Same instance.
     */
    public PaymentHistoryFull setDateOfLastPaidPurchase(
            final OffsetDateTime dateOfLastPaidPurchase) {
        this.dateOfLastPaidPurchase = dateOfLastPaidPurchase;

        return this;
    }

    /**
     * Get the date of the first paid purchase.
     *
     * @return Date of the first paid purchase.
     */
    public OffsetDateTime getDateOfFirstPaidPurchase() {
        return this.dateOfFirstPaidPurchase;
    }

    /**
     * Set the date of the first paid purchase.
     *
     * @param dateOfFirstPaidPurchase Date of the first paid purchase.
     * @return Same instance.
     */
    public PaymentHistoryFull setDateOfFirstPaidPurchase(
            final OffsetDateTime dateOfFirstPaidPurchase) {
        this.dateOfFirstPaidPurchase = dateOfFirstPaidPurchase;

        return this;
    }
}
