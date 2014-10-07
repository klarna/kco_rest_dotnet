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
 * File containing the Capture class
 */

package com.klarna.api.ordermanagement.client.model.request;

import com.klarna.api.ordermanagement.client.model.OrderLine;
import com.klarna.api.ordermanagement.client.model.ShippingInfo;

import java.util.Collections;
import java.util.List;

/**
 * Capture all or part of an order. Use this call when fulfillment is completed,
 * e.g. physical goods are being shipped to the customer.
 */
public class Capture extends Request {

    /**
     * Required captured amount in minor units. For example a captured amount of £1 should be sent as 100.
     */
    public final Long captured_amount;

    /**
     * Optional description of the capture shown to the customer. Max length is 255 characters.
     */
    public final String description;

    /**
     * Optional list of order lines. A maximum of 1000 order lines are allowed. If provided,
     * all mandatory fields must be included.
     */
    public final List<OrderLine> order_lines;

    /**
     * Optional list of shipping information for the capture.
     */
    public final List<ShippingInfo> shipping_info;

    /**
     * Capture the supplied amount.
     * <p/>
     * 'captured_amount' must be equal to or less than the order's 'remaining_authorized_amount'.
     * <p/>
     * Shipping address is inherited from the order.
     *
     * @param captured_amount The capture amount in minor units.
     * @param description     Optional description.
     * @param order_lines     Optional list of order lines.
     * @param shipping_info   Optional list of shipping information.
     */
    public Capture(Long captured_amount, String description, List<OrderLine> order_lines,
                   List<ShippingInfo> shipping_info) {
        this.captured_amount = captured_amount;
        this.description = description;
        this.order_lines = Collections.unmodifiableList(order_lines);
        this.shipping_info = Collections.unmodifiableList(shipping_info);
    }

}
