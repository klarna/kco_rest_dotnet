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
 * The model for marketplace winner information.
 */
public class MarketplaceWinnerInformation extends Model {
    /**
     * The winner unique account identifier.
     */
    private UniqueAccountIdentifier uniqueAccountIdentifierWinner;

    /**
     * The account registration date.
     */
    private DateTime accountRegistrationDate;

    /**
     * The account last modified model.
     */
    private LastModified accountLastModified;

    /**
     * Number of trades.
     */
    private Integer numberOfTrades;

    /**
     * Volume of trades.
     */
    private Integer volumeOfTrades;

    /**
     * Get the winner unique account identifier.
     *
     * @return Winner unique account identifier.
     */
    public UniqueAccountIdentifier getUniqueAccountIdentifierWinner() {
        return this.uniqueAccountIdentifierWinner;
    }

    /**
     * Set the unique account identifier.
     *
     * @param uniqueAccountIdentifierWinner Unique account identifier.
     * @return Same instance.
     */
    public MarketplaceWinnerInformation setUniqueAccountIdentifierWinner(
            final UniqueAccountIdentifier uniqueAccountIdentifierWinner) {
        this.uniqueAccountIdentifierWinner = uniqueAccountIdentifierWinner;

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
    public MarketplaceWinnerInformation setAccountRegistrationDate(
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
     * @param accountLastModified Last modified model.
     * @return Same instance.
     */
    public MarketplaceWinnerInformation setAccountLastModified(
            final LastModified accountLastModified) {
        this.accountLastModified = accountLastModified;

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
    public MarketplaceWinnerInformation setNumberOfTrades(
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
    public MarketplaceWinnerInformation setVolumeOfTrades(
            final Integer volumeOfTrades) {
        this.volumeOfTrades = volumeOfTrades;

        return this;
    }
}
