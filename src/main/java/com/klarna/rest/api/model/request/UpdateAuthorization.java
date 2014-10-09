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
import com.klarna.rest.api.model.OrderLine;

import java.util.List;

/**
 * Update authorization data model.
 */
public class UpdateAuthorization extends Model {

    /**
     * Update amount for the order.
     */
    private Long orderAmount;

    /**
     * Update description.
     */
    private String description;

    /**
     * List of updates items.
     */
    private List<OrderLine> orderLines;

    /**
     * Gets the order amount.
     *
     * @return Order amount
     */
    public Long getOrderAmount() {
        return this.orderAmount;
    }

    /**
     * Sets the order amount.
     *
     * @param amount Order amount
     * @return Same instance
     */
    public UpdateAuthorization setOrderAmount(final Long amount) {
        this.orderAmount = amount;

        return this;
    }

    /**
     * Gets the update description.
     *
     * @return Description
     */
    public String getDescription() {
        return this.description;
    }

    /**
     * Sets the update description.
     *
     * @param description Description
     * @return Same instance
     */
    public UpdateAuthorization setDescription(final String description) {
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
    public UpdateAuthorization setOrderLines(final List<OrderLine> lines) {
        this.orderLines = lines;

        return this;
    }
}
