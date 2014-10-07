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
 *
 * File containing the UpdateAuthorization class
 */

package com.klarna.api.ordermanagement.client.model.request;

import com.klarna.api.ordermanagement.client.model.OrderLine;

import java.util.Collections;
import java.util.List;

/**
 * Update the total order amount of an order, subject to a new customer credit check.
 * <p/>
 * The updated amount can optionally be accompanied by a descriptive text and new order lines. Supplied order lines
 * will replace the existing order lines. If no order lines are supplied in the call,
 * the existing order lines will be deleted.
 * <p/>
 * The updated 'order_amount' must not be negative, nor less than current 'captured_amount'.
 * <p/>
 * Currency is inferred from the original order.
 */
public class UpdateAuthorization extends Request {

    /**
     * Required order amount in minor unit. For example an order amount of £1 should be sent as 100.  Must be non-negative.
     */
    public final Long order_amount;

    /**
     * Optional description. Max 255 characters.
     */
    public final String description;

    /**
     * Optional list of order lines. A maximum of 1000 order lines are allowed. If provided,
     * all mandatory fields must be included (see {@link com.klarna.api.ordermanagement.client.model.OrderLine}).
     * Note that the order lines (provided or not) will replace existing order lines.
     */
    public final List<OrderLine> order_lines;

    /**
     * Update the total order amount of an order, subject to a new customer credit check.
     * The updated amount can optionally be accompanied by a descriptive text and new order lines. Supplied order
     * lines will replace the existing order lines. If no order lines are supplied in the call,
     * the existing order lines will be deleted.
     *
     * @param order_amount Order amount in minor units.
     * @param description  Optional description. Max 255 characters.
     * @param order_lines  Optional list of order lines.
     */
    public UpdateAuthorization(Long order_amount, String description, List<OrderLine> order_lines) {
        this.order_amount = order_amount;
        this.description = description;
        this.order_lines = Collections.unmodifiableList(order_lines);
    }

}
