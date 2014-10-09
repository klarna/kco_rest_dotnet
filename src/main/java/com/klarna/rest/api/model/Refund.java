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

package com.klarna.rest.api.model;

import org.joda.time.DateTime;

import java.util.List;

/**
 * Refund data model.
 */
public class Refund extends Model {

    /**
     * Refund amount.
     */
    private Long refundedAmount;

    /**
     * Refund creation date.
     */
    private DateTime refundedAt;

    /**
     * Refund description.
     */
    private String description;

    /**
     * Order lines.
     */
    private List<OrderLine> orderLines;

    /**
     * Gets the refunded amount.
     *
     * @return Amount
     */
    public Long getRefundedAmount() {
        return this.refundedAmount;
    }

    /**
     * Sets the amount to refund.
     *
     * @param amount Refund amount
     * @return Same instance
     */
    public Refund setRefundedAmount(final Long amount) {
        this.refundedAmount = amount;

        return this;
    }

    /**
     * Gets the refund description.
     *
     * @return Description
     */
    public String getDescription() {
        return this.description;
    }

    /**
     * Sets the refund description.
     *
     * @param description Description
     * @return Same instance
     */
    public Refund setDescription(final String description) {
        this.description = description;

        return this;
    }

    /**
     * Gets the order lines.
     *
     * @return Order lines
     */
    public List<OrderLine> getOrderLines() {
        return this.orderLines;
    }

    /**
     * Sets the order lines.
     *
     * @param lines Order lines
     * @return Same instance
     */
    public Refund setOrderLines(final List<OrderLine> lines) {
        this.orderLines = lines;

        return this;
    }

    /**
     * Gets the refund date.
     *
     * @return Creation date
     */
    public DateTime getRefundedAt() {
        return this.refundedAt;
    }
}
