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
 * Checkout Shipping Option model.
 */
public class ShippingOption extends Model {
    /**
     * Shipping ID.
     */
    private String id = null;

    /**
     * Shipping name.
     */
    private String name = null;

    /**
     * Shipping description.
     */
    private String description = null;

    /**
     * Promotion name. To be used if this shipping option is promotional.
     */
    private String promo = null;

    /**
     * Price including tax.
     */
    private Long price = null;

    /**
     * Tax amount.
     */
    private Long taxAmount = null;

    /**
     * Non-negative. In percent, two implicit decimals. I.e 2500 = 25%.
     */
    private Long taxRate = null;

    /**
     *
     */
    private Boolean preselected = false;

    /**
     * If true, this option will be preselected when checkout loads. Default: false
     */
    private String shippingMethod = null;


    public ShippingOption id(String id) {
        this.id = id;
        return this;
    }

    /**
     * id
     * @return id
     **/
    public String getId() {
        return id;
    }

    public ShippingOption setId(String id) {
        this.id = id;
        return this;
    }

    public ShippingOption name(String name) {
        this.name = name;
        return this;
    }

    /**
     * Name.
     * @return name
     **/
    public String getName() {
        return name;
    }

    public ShippingOption setName(String name) {
        this.name = name;
        return this;
    }

    public ShippingOption description(String description) {
        this.description = description;
        return this;
    }

    /**
     * Description.
     * @return description
     **/
    public String getDescription() {
        return description;
    }

    public ShippingOption setDescription(String description) {
        this.description = description;
        return this;
    }

    public ShippingOption promo(String promo) {
        this.promo = promo;
        return this;
    }

    /**
     * Promotion name. To be used if this shipping option is promotional.
     * @return promo
     **/
    public String getPromo() {
        return promo;
    }

    public ShippingOption setPromo(String promo) {
        this.promo = promo;
        return this;
    }

    public ShippingOption price(Long price) {
        this.price = price;
        return this;
    }

    /**
     * Price including tax.
     * @return price
     **/
    public Long getPrice() {
        return price;
    }

    public ShippingOption setPrice(Long price) {
        this.price = price;
        return this;
    }

    public ShippingOption taxAmount(Long taxAmount) {
        this.taxAmount = taxAmount;
        return this;
    }

    /**
     * Tax amount.
     * @return taxAmount
     **/
    public Long getTaxAmount() {
        return taxAmount;
    }

    public ShippingOption setTaxAmount(Long taxAmount) {
        this.taxAmount = taxAmount;
        return this;
    }

    public ShippingOption taxRate(Long taxRate) {
        this.taxRate = taxRate;
        return this;
    }

    /**
     * Non-negative. In percent, two implicit decimals. I.e 2500 &#x3D; 25%.
     * @return taxRate
     **/
    public Long getTaxRate() {
        return taxRate;
    }

    public ShippingOption setTaxRate(Long taxRate) {
        this.taxRate = taxRate;
        return this;
    }

    public ShippingOption preselected(Boolean preselected) {
        this.preselected = preselected;
        return this;
    }

    /**
     * If true, this option will be preselected when checkout loads. Default: false
     * @return preselected
     **/
    public Boolean getPreselected() {
        return preselected;
    }

    public ShippingOption setPreselected(Boolean preselected) {
        this.preselected = preselected;
        return this;
    }

    public ShippingOption shippingMethod(String shippingMethod) {
        this.shippingMethod = shippingMethod;
        return this;
    }

    /**
     * Shipping method.
     * @return shippingMethod
     **/
    public String getShippingMethod() {
        return shippingMethod;
    }

    public ShippingOption setShippingMethod(String shippingMethod) {
        this.shippingMethod = shippingMethod;
        return this;
    }
}

