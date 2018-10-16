/*
 * Copyright 2018 Klarna AB
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


import java.util.List;

/**
 * The model for EMD attachment body.
 */
public class ExtraMerchantDataBody extends Model {
    /**
     * List of air reservation details.
     */
    private List<AirReservationDetails> airReservationDetails;

    /**
     * List of bus reservation details.
     */
    private List<BusReservationDetails> busReservationDetails;

    /**
     * List of train reservation details.
     */
    private List<TrainReservationDetails> trainReservationDetails;

    /**
     * List of ferry reservation details.
     */
    private List<FerryReservationDetails> ferryReservationDetails;

    /**
     * List of hotel reservation details.
     */
    private List<HotelReservationDetails> hotelReservationDetails;

    /**
     * List of car rental reservation details.
     */
    private List<CarRentalReservationDetails> carRentalReservationDetails;

    /**
     * List of events.
     */
    private List<Event> event;

    /**
     * List of vouchers.
     */
    private List<Voucher> voucher;

    /**
     * List of subscriptions.
     */
    private List<Subscription> subscription;

    /**
     * List of customer account information.
     */
    private List<CustomerAccountInformation> customerAccountInfo;

    /**
     * List of marketplace seller information.
     */
    private List<MarketplaceSellerInformation> marketplaceSellerInfo;

    /**
     * List of marketplace winner information.
     */
    private List<MarketplaceWinnerInformation> marketplaceWinnerInfo;

    /**
     * List of full purchase histories.
     */
    private List<PaymentHistoryFull> paymentHistoryFull;

    /**
     * List of simple purchase histories.
     */
    private List<PaymentHistorySimple> paymentHistorySimple;

    /**
     * List of other delivery addresses.
     */
    private List<OtherDeliveryAddress> otherDeliveryAddress;

    /**
     * Get the air reservation details.
     *
     * @return Air reservation details.
     */
    public List<AirReservationDetails> getAirReservationDetails() {
        return this.airReservationDetails;
    }

    /**
     * Set the list of air reservation details.
     *
     * @param airReservationDetails Air reservation details.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setAirReservationDetails(
            final List<AirReservationDetails> airReservationDetails) {
        this.airReservationDetails = airReservationDetails;

        return this;
    }

    /**
     * Get the bus reservation details.
     *
     * @return Bus reservation details.
     */
    public List<BusReservationDetails> getBusReservationDetails() {
        return this.busReservationDetails;
    }

    /**
     * Set the list of bus reservation details.
     *
     * @param busReservationDetails Bus reservation details.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setBusReservationDetails(
            final List<BusReservationDetails> busReservationDetails) {
        this.busReservationDetails = busReservationDetails;

        return this;
    }

    /**
     * Get the train reservation details.
     *
     * @return Train reservation details.
     */
    public List<TrainReservationDetails> getTrainReservationDetails() {
        return this.trainReservationDetails;
    }

    /**
     * Set the list of train reservation details.
     *
     * @param details Train reservation details.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setTrainReservationDetails(
            final List<TrainReservationDetails> details) {
        this.trainReservationDetails = details;

        return this;
    }

    /**
     * Get the ferry reservation details.
     *
     * @return Ferry reservation details.
     */
    public List<FerryReservationDetails> getFerryReservationDetails() {
        return this.ferryReservationDetails;
    }

    /**
     * Set the list of ferry reservation details.
     *
     * @param details Ferry reservation details.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setFerryReservationDetails(
            final List<FerryReservationDetails> details) {
        this.ferryReservationDetails = details;

        return this;
    }

    /**
     * Get the hotel reservation details.
     *
     * @return Hotel reservation details.
     */
    public List<HotelReservationDetails> getHotelReservationDetails() {
        return this.hotelReservationDetails;
    }

    /**
     * Set the list of hotel reservation details.
     *
     * @param details Hotel reservation details.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setHotelReservationDetails(
            final List<HotelReservationDetails> details) {
        this.hotelReservationDetails = details;

        return this;
    }

    /**
     * Get the car rental reservation details.
     *
     * @return Car rental reservation details.
     */
    public List<CarRentalReservationDetails> getCarRentalReservationDetails() {
        return this.carRentalReservationDetails;
    }

    /**
     * Set the list of car rental reservation details.
     *
     * @param details Car rental reservation details.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setCarRentalReservationDetails(
            final List<CarRentalReservationDetails> details) {
        this.carRentalReservationDetails = details;

        return this;
    }

    /**
     * Get the list of events.
     *
     * @return List of events.
     */
    public List<Event> getEvent() {
        return this.event;
    }

    /**
     * Set the list of events.
     *
     * @param events List of events.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setEvent(final List<Event> events) {
        this.event = events;

        return this;
    }

    /**
     * Get the list of vouchers.
     *
     * @return List of vouchers.
     */
    public List<Voucher> getVoucher() {
        return this.voucher;
    }

    /**
     * Set the list of vouchers.
     *
     * @param vouchers List of vouchers.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setVoucher(final List<Voucher> vouchers) {
        this.voucher = vouchers;

        return this;
    }

    /**
     * Get the list of subscriptions.
     *
     * @return List of subscriptions.
     */
    public List<Subscription> getSubscription() {
        return this.subscription;
    }

    /**
     * Set the list of subscriptions.
     *
     * @param subscriptions List of subscriptions.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setSubscription(
            final List<Subscription> subscriptions) {
        this.subscription = subscriptions;

        return this;
    }

    /**
     * Get the list of customer account information.
     *
     * @return List of customer account information.
     */
    public List<CustomerAccountInformation> getCustomerAccountInfo() {
        return this.customerAccountInfo;
    }

    /**
     * Set the list of customer account information.
     *
     * @param customerAccountInfo List of customer account information.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setCustomerAccountInfo(
            final List<CustomerAccountInformation> customerAccountInfo) {
        this.customerAccountInfo = customerAccountInfo;

        return this;
    }

    /**
     * Get the list of marketplace seller information.
     *
     * @return List of marketplace seller information.
     */
    public List<MarketplaceSellerInformation> getMarketplaceSellerInfo() {
        return this.marketplaceSellerInfo;
    }

    /**
     * Set the list of marketplace seller information.
     *
     * @param marketplaceSellerInfo List of marketplace seller information.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setMarketplaceSellerInfo(
            final List<MarketplaceSellerInformation> marketplaceSellerInfo) {
        this.marketplaceSellerInfo = marketplaceSellerInfo;

        return this;
    }

    /**
     * Get the list of marketplace winner information.
     *
     * @return List of marketplace winner information.
     */
    public List<MarketplaceWinnerInformation> getMarketplaceWinnerInfo() {
        return this.marketplaceWinnerInfo;
    }

    /**
     * Set the list of marketplace winner information.
     *
     * @param marketplaceWinnerInfo List of marketplace winner information.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setMarketplaceWinnerInfo(
            final List<MarketplaceWinnerInformation> marketplaceWinnerInfo) {
        this.marketplaceWinnerInfo = marketplaceWinnerInfo;

        return this;
    }

    /**
     * Get the list of full purchase histories.
     *
     * @return List of full purchase histories.
     */
    public List<PaymentHistoryFull> getPaymentHistoryFull() {
        return this.paymentHistoryFull;
    }

    /**
     * Set the list full purchase histories.
     *
     * @param paymentHistoryFull List of full purchase histories.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setPaymentHistoryFull(
            final List<PaymentHistoryFull> paymentHistoryFull) {
        this.paymentHistoryFull = paymentHistoryFull;

        return this;
    }

    /**
     * Get the list of simple purchase histories.
     *
     * @return List of simple purchase histories.
     */
    public List<PaymentHistorySimple> getPaymentHistorySimple() {
        return this.paymentHistorySimple;
    }

    /**
     * Set the list of simple purchase histories.
     *
     * @param paymentHistorySimple List of simple purchase histories.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setPaymentHistorySimple(
            final List<PaymentHistorySimple> paymentHistorySimple) {
        this.paymentHistorySimple = paymentHistorySimple;

        return this;
    }

    /**
     * Get the list of other delivery addresses.
     *
     * @return List of other delivery addresses.
     */
    public List<OtherDeliveryAddress> getOtherDeliveryAddress() {
        return this.otherDeliveryAddress;
    }

    /**
     * Set the list of other delivery addresses.
     *
     * @param otherDeliveryAddress List of other delivery addresses.
     * @return Same instance.
     */
    public ExtraMerchantDataBody setOtherDeliveryAddress(
            final List<OtherDeliveryAddress> otherDeliveryAddress) {
        this.otherDeliveryAddress = otherDeliveryAddress;

        return this;
    }
}
