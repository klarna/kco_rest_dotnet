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
 * File containing the Order class
 */

package com.klarna.api.ordermanagement.client.model;

import org.joda.time.DateTime;

import java.util.List;

/**
 * The current state of an order.
 */
public class Order extends TransportObject {

    /**
     * The unique order ID set by Klarna. Max length is 255 characters.
     */
    public String order_id;

    /**
     * The current state of the order. See {@link OrderStatus}.
     */
    public OrderStatus status;

    /**
     * The total amount for this order in minor units.
     */
    public Long order_amount;

    /**
     * The original amount for this order in minor units.
     */
    public Long original_order_amount;

    /**
     * The total amount of all captures for this order.
     */
    public Long captured_amount;

    /**
     * The total amount refunded for this order.
     */
    public Long refunded_amount;

    /**
     * The remaining authorized amount for this order.
     * To increase the remaining_authorized_amount the order_amount needs to be increased.
     */
    public Long remaining_authorized_amount;

    /**
     * Purchase currency. ISO 4217, e.g. "GBP".
     */
    public String purchase_currency;

    /**
     * Customer's locale. RFC 1766, e.g. "en-gb".
     */
    public String locale;

    /**
     * The applicable order lines. A maximum of 1000 order lines are allowed.
     */
    public List<OrderLine> order_lines;

    /**
     * Optional merchant reference 1, can be used for storing merchant's internal order number or other references.
     * Max length is 255 characters.
     */
    public String merchant_reference1;

    /**
     * Optional merchant reference 2, can be used for storing merchant's internal order number or other references.
     * Max length is 255 characters.
     */
    public String merchant_reference2;

    /**
     * Customer friendly reference id, used as order reference when communicating with the customer. Max length is
     * 255 characters.
     */
    public String klarna_reference;

    /**
     * Optional information about the liable customer of the order.
     */
    public CustomerInfo customer_info;

    /**
     * The billing address for the order.
     */
    public Address billing_address;

    /**
     * The shipping address for the order.
     */
    public Address shipping_address;

    /**
     * The purchase time set by klarna.
     */
    public DateTime created_at;

    /**
     * Purchase country. ISO 3166-1 alpha-2, e.g. "GB".
     */
    public String purchase_country;

    /**
     * Authorization expiration time set by Klarna.
     */
    public DateTime expires_at;

    /**
     * The captures for this order. A maximum of 99 captures are allowed.
     */
    public List<CapturedOrder> captures;

    /**
     *  The refunds for this order.
     */
    public List<RefundedOrder> refunds;

}
