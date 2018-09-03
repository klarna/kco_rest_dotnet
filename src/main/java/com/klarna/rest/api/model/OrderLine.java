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

import java.net.URI;

/**
 * Order line data model.
 */
public class OrderLine extends Model {

    /**
     * Item type.
     */
    private String type;

    /**
     * Article number, SKU or similar.
     */
    private String reference;

    /**
     * Article name.
     */
    private String name;

    /**
     * The item quantity.
     */
    private Long quantity;

    /**
     * Unit used to describe the quantity, e.g. "pcs".
     */
    private String quantityUnit;

    /**
     * Unit price in cents, including tax and excluding discounts.
     */
    private Long unitPrice;

    /**
     * Item tax rate in cents, e.g. 2500 is 25%.
     */
    private Integer taxRate;

    /**
     * Total amount in cents, including tax and discounts.
     */
    private Long totalAmount;

    /**
     * Total discount amount in cents, including tax.
     */
    private Long totalDiscountAmount;

    /**
     * Total tax amount in cents.
     */
    private Long totalTaxAmount;

    /**
     * Data about the order line. Set at creation or update and returned when fetching the order through the API.
     */
    private String merchantData;

    /**
     * Product URI.
     */
    private URI productUrl;

    /**
     * Image URI.
     */
    private URI imageUrl;

    /**
     * Identifiers to better describe the product for improved risk assessment, support,
     * presentation to consumers and promotional functionality.
     */
    private ProductIdentifiers productIdentifiers;

    /**
     * Gets the item type.
     *
     * @return Type
     */
    public String getType() {
        return this.type;
    }

    /**
     * Sets the item type.
     *
     * @param type Type, e.g. "physical", "discount" or "shipping_fee"
     * @return Same instance
     */
    public OrderLine setType(final String type) {
        this.type = type;

        return this;
    }

    /**
     * Gets the item reference.
     *
     * @return Reference
     */
    public String getReference() {
        return this.reference;
    }

    /**
     * Sets the item reference.
     *
     * @param reference Reference
     * @return Same instance
     */
    public OrderLine setReference(final String reference) {
        this.reference = reference;

        return this;
    }

    /**
     * Gets the item name.
     *
     * @return Name
     */
    public String getName() {
        return this.name;
    }

    /**
     * Sets the item name.
     *
     * @param name Name
     * @return Same instance
     */
    public OrderLine setName(final String name) {
        this.name = name;

        return this;
    }

    /**
     * Gets the item quantity.
     *
     * @return Quantity
     */
    public Long getQuantity() {
        return this.quantity;
    }

    /**
     * Sets the item quantity.
     *
     * @param quantity Quantity
     * @return Same instance
     */
    public OrderLine setQuantity(final Long quantity) {
        this.quantity = quantity;

        return this;
    }

    /**
     * Gets the quantity unit.
     *
     * @return Quantity unit, e.g. "pcs"
     */
    public String getQuantityUnit() {
        return this.quantityUnit;
    }

    /**
     * Sets the quantity unit.
     *
     * @param unit Quantity unit, e.g. "pcs"
     * @return Same instance
     */
    public OrderLine setQuantityUnit(final String unit) {
        this.quantityUnit = unit;

        return this;
    }

    /**
     * Gets the unit price.
     *
     * @return Price in cents, e.g. 2500 is 25.00
     */
    public Long getUnitPrice() {
        return this.unitPrice;
    }

    /**
     * Sets the unit price.
     *
     * @param price Price in cents, e.g. 2500 is 25.00
     * @return Same instance
     */
    public OrderLine setUnitPrice(final Long price) {
        this.unitPrice = price;

        return this;
    }

    /**
     * Gets the item tax rate.
     *
     * @return Tax rate in cents, e.g. 2500 is 25%
     */
    public Integer getTaxRate() {
        return this.taxRate;
    }

    /**
     * Sets the item tax rate.
     *
     * @param rate Tax rate in cents, e.g. 2500 is 25%
     * @return Same instance
     */
    public OrderLine setTaxRate(final Integer rate) {
        this.taxRate = rate;

        return this;
    }

    /**
     * Gets total amount.
     *
     * @return Amount in cents, e.g. 2500 is 25.00
     */
    public Long getTotalAmount() {
        return this.totalAmount;
    }

    /**
     * Sets the total amount.
     *
     * @param amount Amount in cents, e.g. 2500 is 25.00
     * @return Same instance
     */
    public OrderLine setTotalAmount(final Long amount) {
        this.totalAmount = amount;

        return this;
    }

    /**
     * Gets the total discount amount.
     *
     * @return Amount in cents, e.g. 2500 is 25.00
     */
    public Long getTotalDiscountAmount() {
        return this.totalDiscountAmount;
    }

    /**
     * Sets the total discount amount.
     *
     * @param amount Amount in cents, e.g. 2500 is 25.00
     * @return Same instance
     */
    public OrderLine setTotalDiscountAmount(final Long amount) {
        this.totalDiscountAmount = amount;

        return this;
    }

    /**
     * Gets the total tax amount.
     *
     * @return Amount in cents, e.g. 2500 is 25.00
     */
    public Long getTotalTaxAmount() {
        return this.totalTaxAmount;
    }

    /**
     * Sets the total tax amount.
     *
     * @param amount Amount in cents, e.g. 2500 is 25.00
     * @return Same instance
     */
    public OrderLine setTotalTaxAmount(final Long amount) {
        this.totalTaxAmount = amount;

        return this;
    }

    /**
     * Gets the merchant metadata.
     *
     * @return Merchant metadata
     */
    public String getMerchantData() {
        return this.merchantData;
    }

    /**
     * Sets the merchant metadata.
     *
     * @param merchantData Merchant metadata
     * @return Same instance
     */
    public OrderLine setMerchantData(final String merchantData) {
        this.merchantData = merchantData;

        return this;
    }

    /**
     * Get the product URI.
     *
     * @return Product URI.
     */
    public URI getProductUrl() {
        return this.productUrl;
    }

    /**
     * Set the product URI.
     *
     * @param productUrl Product URI.
     * @return Same instance.
     */
    public OrderLine setProductUrl(final URI productUrl) {
        this.productUrl = productUrl;

        return this;
    }

    /**
     * Get the image URI.
     *
     * @return Image URI.
     */
    public URI getImageUrl() {
        return this.imageUrl;
    }

    /**
     * Set the image URI.
     *
     * @param imageUrl Image URI.
     * @return Same instance.
     */
    public OrderLine setImageUrl(final URI imageUrl) {
        this.imageUrl = imageUrl;

        return this;
    }

    /**
     * Gets product indentifiers
     *
     * @return productIdentifiers
     **/
    public ProductIdentifiers getProductIdentifiers() {
        return this.productIdentifiers;
    }

    /**
     * Sets product indentifiers
     *
     * @return Same instance.
     **/
    public OrderLine setProductIdentifiers(ProductIdentifiers productIdentifiers) {
        this.productIdentifiers = productIdentifiers;

        return this;
    }
}
