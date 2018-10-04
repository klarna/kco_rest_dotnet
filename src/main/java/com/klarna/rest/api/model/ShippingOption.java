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
    private String id;

    /**
     * Shipping name.
     */
    private String name;

    /**
     * Shipping description.
     */
    private String description;

    /**
     * Promotion name. To be used if this shipping option is promotional.
     */
    private String promo;

    /**
     * Price including tax.
     */
    private Long price;

    /**
     * Tax amount.
     */
    private Long taxAmount;

    /**
     * Non-negative. In percent, two implicit decimals. I.e 2500 = 25%.
     */
    private Long taxRate;

    /**
     *
     */
    private Boolean preselected;

    /**
     * If true, this option will be preselected when checkout loads. Default: false
     */
    private String shippingMethod;


    /**
     * id
     * @return id
     **/
    public String getId() {
        return this.id;
    }

    public ShippingOption setId(String id) {
        this.id = id;
        return this;
    }

    /**
     * Name.
     * @return name
     **/
    public String getName() {
        return this.name;
    }

    public ShippingOption setName(String name) {
        this.name = name;
        return this;
    }

    /**
     * Description.
     * @return description
     **/
    public String getDescription() {
        return this.description;
    }

    public ShippingOption setDescription(String description) {
        this.description = description;
        return this;
    }

    /**
     * Promotion name. To be used if this shipping option is promotional.
     * @return promo
     **/
    public String getPromo() {
        return this.promo;
    }

    public ShippingOption setPromo(String promo) {
        this.promo = promo;
        return this;
    }

    /**
     * Price including tax.
     * @return price
     **/
    public Long getPrice() {
        return this.price;
    }

    public ShippingOption setPrice(Long price) {
        this.price = price;
        return this;
    }

    /**
     * Tax amount.
     * @return taxAmount
     **/
    public Long getTaxAmount() {
        return this.taxAmount;
    }

    public ShippingOption setTaxAmount(Long taxAmount) {
        this.taxAmount = taxAmount;
        return this;
    }

    /**
     * Non-negative. In percent, two implicit decimals. I.e 2500 &#x3D; 25%.
     * @return taxRate
     **/
    public Long getTaxRate() {
        return this.taxRate;
    }

    public ShippingOption setTaxRate(Long taxRate) {
        this.taxRate = taxRate;
        return this;
    }

    /**
     * If true, this option will be preselected when checkout loads. Default: false
     * @return preselected
     **/
    public Boolean getPreselected() {
        return this.preselected;
    }

    public ShippingOption setPreselected(Boolean preselected) {
        this.preselected = preselected;
        return this;
    }

    /**
     * Shipping method.
     * @return shippingMethod
     **/
    public String getShippingMethod() {
        return this.shippingMethod;
    }

    public ShippingOption setShippingMethod(String shippingMethod) {
        this.shippingMethod = shippingMethod;
        return this;
    }
}

