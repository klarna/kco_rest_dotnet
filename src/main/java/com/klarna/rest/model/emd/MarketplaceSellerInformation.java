/*
 * Copyright 2015 Klarna AB
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

package com.klarna.rest.model.emd;

import org.joda.time.DateTime;

/**
 * The model for marketplace seller information.
 */
public class MarketplaceSellerInformation extends Model {
    /**
     * Unique account identifier.
     */
    private UniqueAccountIdentifier uniqueAccountIdentifierSeller;

    /**
     * Sub merchant ID.
     */
    private String subMerchantID;

    /**
     * Product category.
     */
    private String productCategory;

    /**
     * Product name.
     */
    private String productName;

    /**
     * Account registration date.
     */
    private DateTime accountRegistrationDate;

    /**
     * Account last modified model.
     */
    private LastModified accountLastModified;

    /**
     * Seller rating.
     */
    private Long sellerRating;

    /**
     * Number of trades.
     */
    private Integer numberOfTrades;

    /**
     * Volume of trades.
     */
    private Integer volumeOfTrades;

    /**
     * Get the unique account identifier.
     *
     * @return Unique account identifier.
     */
    public UniqueAccountIdentifier getUniqueAccountIdentifierSeller() {
        return this.uniqueAccountIdentifierSeller;
    }

    /**
     * Set the unique account identifier.
     *
     * @param uniqueAccountIdentifierSeller Unique account identifier.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setUniqueAccountIdentifierSeller(
            final UniqueAccountIdentifier uniqueAccountIdentifierSeller) {
        this.uniqueAccountIdentifierSeller = uniqueAccountIdentifierSeller;

        return this;
    }

    /**
     * Get the sub merchant ID.
     *
     * @return Sub merchant ID.
     */
    public String getSubMerchantID() {
        return this.subMerchantID;
    }

    /**
     * Set the sub merchant ID.
     *
     * @param subMerchantID Sub merchant ID.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setSubMerchantID(
            final String subMerchantID) {
        this.subMerchantID = subMerchantID;

        return this;
    }

    /**
     * Get the product category.
     *
     * @return Product category.
     */
    public String getProductCategory() {
        return this.productCategory;
    }

    /**
     * Set the product category.
     *
     * @param productCategory Product category.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setProductCategory(
            final String productCategory) {
        this.productCategory = productCategory;

        return this;
    }

    /**
     * Get the product name.
     *
     * @return Product name.
     */
    public String getProductName() {
        return this.productName;
    }

    /**
     * Set the product name.
     *
     * @param productName Product name.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setProductName(
            final String productName) {
        this.productName = productName;

        return this;
    }

    /**
     * Get the account registration date.
     *
     * @return Account registration date.
     */
    public DateTime getAccountRegistrationDate() {
        return this.accountRegistrationDate;
    }

    /**
     * Set the account registration date.
     *
     * @param accountRegistrationDate Account registration date.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setAccountRegistrationDate(
            final DateTime accountRegistrationDate) {
        this.accountRegistrationDate = accountRegistrationDate;

        return this;
    }

    /**
     * Get the account last modified model.
     *
     * @return Account last modified model.
     */
    public LastModified getAccountLastModified() {
        return this.accountLastModified;
    }

    /**
     * Set the account last modified model.
     *
     * @param accountLastModified Account last modified model.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setAccountLastModified(
            final LastModified accountLastModified) {
        this.accountLastModified = accountLastModified;

        return this;
    }

    /**
     * Get the seller rating.
     *
     * @return Seller rating.
     */
    public Long getSellerRating() {
        return this.sellerRating;
    }

    /**
     * Set the seller rating.
     *
     * @param sellerRating Seller rating.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setSellerRating(
            final Long sellerRating) {
        this.sellerRating = sellerRating;

        return this;
    }

    /**
     * Get the number of trades.
     *
     * @return Number of trades.
     */
    public Integer getNumberOfTrades() {
        return this.numberOfTrades;
    }

    /**
     * Set the number of trades.
     *
     * @param numberOfTrades Number of trades.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setNumberOfTrades(
            final Integer numberOfTrades) {
        this.numberOfTrades = numberOfTrades;

        return this;
    }

    /**
     * Get the volume of trades.
     *
     * @return Volume of trades.
     */
    public Integer getVolumeOfTrades() {
        return this.volumeOfTrades;
    }

    /**
     * Set the volume of trades.
     *
     * @param volumeOfTrades Volume of trades.
     * @return Same instance.
     */
    public MarketplaceSellerInformation setVolumeOfTrades(
            final Integer volumeOfTrades) {
        this.volumeOfTrades = volumeOfTrades;

        return this;
    }
}
