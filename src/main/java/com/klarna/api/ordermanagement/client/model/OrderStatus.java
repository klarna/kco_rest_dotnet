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
 * File containing the OrderStatus class
 */

package com.klarna.api.ordermanagement.client.model;

/**
 * Order statuses.
 */
public enum OrderStatus {

    /**
     * No captures have been made on the order.
     */
    AUTHORIZED,

    /**
     * At least one capture has been made on the order with a total captured value lower than the current total order
     * amount.
     */
    PART_CAPTURED,

    /**
     * At least one capture has been made on the order and the total captured amount is equal to the current total order amount.
     */
    CAPTURED,

    /**
     * The order is cancelled prior to making any captures.
     */
    CANCELLED,

    /**
     * The authorization time expired for the order and no captures have been made.
     */
    EXPIRED,

    /**
     *  The order is closed and no further modifications are possible.
     */
    CLOSED

}

