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

/**
 * Product identifiers data model.
 */
public class ProductIdentifiers extends Model {

    /**
     * The product's category path as used in the merchant's webshop. Include the full and most detailed
     * category and separate the segments with ' > '
     */
    private String categoryPath = null;

    /**
     * The product's Global Trade Item Number (GTIN). Common types of GTIN are EAN, ISBN or UPC.
     * Exclude dashes and spaces, where possible
     */
    private String globalTradeItemNumber = null;

    /**
     * The product's Manufacturer Part Number (MPN), which - together with the brand - uniquely identifies a product.
     * Only submit MPNs assigned by a manufacturer and use the most specific MPN possible
     */
    private String manufacturerPartNumber = null;

    /**
     * The product's brand name as generally recognized by consumers.
     * If no brand is available for a product, do not supply any value.
     */
    private String brand = null;

    /**
     * Gets the product's category path.
     *
     * @return Category path
     */
    public String getCategoryPath() {
        return categoryPath;
    }

    /**
     * Sets the product's category path.
     *
     * @param categoryPath Category path
     * @return Same instance
     */
    public ProductIdentifiers setCategoryPath(String categoryPath) {
        this.categoryPath = categoryPath;

        return this;
    }

    /**
     * Gets the product's Global Trade Item Number (GTIN).
     *
     * @return GTIN
     */
    public String getGlobalTradeItemNumber() {
        return globalTradeItemNumber;
    }

    /**
     * Sets the product's Global Trade Item Number (GTIN).
     *
     * @param globalTradeItemNumber GTIN
     * @return Same instance
     */
    public ProductIdentifiers setGlobalTradeItemNumber(String globalTradeItemNumber) {
        this.globalTradeItemNumber = globalTradeItemNumber;
        return this;
    }

    /**
     * Gets the product's Manufacturer Part Number (MPN).
     *
     * @return MPN
     */
    public String getManufacturerPartNumber() {
        return manufacturerPartNumber;
    }

    /**
     * Sets the product's Manufacturer Part Number (MPN).
     *
     * @param manufacturerPartNumber MPN
     * @return Same instance
     */
    public ProductIdentifiers setManufacturerPartNumber(String manufacturerPartNumber) {
        this.manufacturerPartNumber = manufacturerPartNumber;

        return this;
    }

    /**
     * Gets the product's brand name.
     *
     * @return Brand name
     */
    public String getBrand() {
        return brand;
    }

    /**
     * Sets the product's brand name.
     *
     * @param brand Product's brand
     * @return Same instance
     */
    public ProductIdentifiers setBrand(String brand) {
        this.brand = brand;

        return this;
    }
}
