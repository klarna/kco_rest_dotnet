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
 * File containing the RefundedOrder class
 */

package com.klarna.api.ordermanagement.client.model;

import org.joda.time.DateTime;

import java.util.List;

/**
 * Refund part of order.
 */
public class RefundedOrder extends TransportObject {

    /**
     * Refund amount in minor units.
     */
    public Long refunded_amount;

    /**
     * The time of the refund.
     */
    public DateTime refunded_at;

    /**
     * Optional description of the refund shown to the customer. Max length is 255 characters.
     */
    public String description;

    /**
     * Optional order lines for the refund shown to the customer. A maximum of 1000 order lines are allowed.
     */
    public List<OrderLine> order_lines;

}
