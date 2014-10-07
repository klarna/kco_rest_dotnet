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
 * File containing the OrderLine class
 */

package com.klarna.api.ordermanagement.client.model;

/**
 * Order line describing an item in the order.
 */
public class OrderLine extends TransportObject {

    /**
     * Optional article number, SKU or similar. Max length is 255 characters.
     */
    public String reference;

    /**
     * Item type. Allowed values are: "physical", "discount" or "shipping_fee".
     */
    public String type;

    /**
     * The item quantity.
     */
    public Long quantity;

    /**
     * Optional unit used to describe the quantity, for example kg, pcs. Max length is 10 characters.
     */
    public String quantity_unit;

    /**
     * Descriptive item name. Max length is 255 characters.
     */
    public String name;

    /**
     * Total amount in minor units. Includes tax and discount.
     */
    public Long total_amount;

    /**
     * Unit price in minor units. Includes tax, excludes discount.
     */
    public Long unit_price;

    /**
     * Optional total discount amount in minor units. Includes tax.
     */
    public Long total_discount_amount = 0L;

    /**
     * In percent, two implicit decimals. For example 2500 = 25%.
     */
    public Integer tax_rate;

    /**
     * Total tax amount in minor units. Negative when type is discount.
     */
    public Long total_tax_amount;

}

