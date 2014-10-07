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
 * File containing the CapturedOrder class
 */

package com.klarna.api.ordermanagement.client.model;

import org.joda.time.DateTime;

import java.util.List;

/**
 * A captured order.
 */
public class CapturedOrder extends TransportObject {

    /**
     * Capture id set by Klarna. Generated at time of capture. Max length is 255 characters.
     */
    public String capture_id;

    /**
     * Customer friendly reference id set by Klarna, used as order reference when communicating with the
     * customer. Max length is 255 characters.
     */
    public String klarna_reference;

    /**
     * Captured amount in minor units. For example a captured amount of £1 should be sent as 100.
     */
    public Long captured_amount;

    /**
     * The time of capture set by Klarna.
     */
    public DateTime captured_at;

    /**
     * Description of the capture shown to the customer. Max length is 255 characters.
     */
    public String description;

    /**
     * Order lines for the capture shown to the customer. A maximum of 1000 order lines are allowed.
     */
    public List<OrderLine> order_lines;

    /**
     * Amount that has been refunded for this capture set by Klarna.
     */
    public Long refunded_amount;

    /**
     * The billing address for the capture.
     */
    public Address billing_address;

    /**
     * The shipping address for the capture.
     */
    public Address shipping_address;

    /**
     * List of shipping information for the capture.
     */
    public List<ShippingInfo> shipping_info;

}
