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
 * File containing the Refund class
 */

package com.klarna.api.ordermanagement.client.model.request;

import com.klarna.api.ordermanagement.client.model.OrderLine;

import java.util.Collections;
import java.util.List;

/**
 * Refund an amount of a captured order. The refunded amount will be credited to the customer.
 * The refunded amount must not be higher than the order's 'captured_amount'.
 */
public class Refund extends Request {

    /**
     * Required refund amount in minor units For example a refund amount of £1 should be sent as 100.
     */
    public final Long refunded_amount;

    /**
     * Optional description of the refund shown to the customer. Max length is 255 characters.
     */
    public final String description;

    /**
     * Optional order lines for the refund shown to the customer. A maximum of 1000 order lines are allowed.
     */
    public final List<OrderLine> order_lines;

    /**
     * Refund an amount of a captured order.
     *
     * @param refunded_amount Refund amount in minor units.
     * @param description     Optional description of the refund shown to the customer.
     * @param order_lines     Optional order lines for the refund shown to the customer.
     */
    public Refund(Long refunded_amount, String description, List<OrderLine> order_lines) {
        this.refunded_amount = refunded_amount;
        this.description = description;
        this.order_lines = Collections.unmodifiableList(order_lines);
    }

}
