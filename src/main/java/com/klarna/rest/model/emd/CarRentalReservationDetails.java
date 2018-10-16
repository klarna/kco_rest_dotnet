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
 * The model for car rental reservation details.
 */
public class CarRentalReservationDetails extends Model {
    /**
     * PNR.
     */
    private String pnr;

    /**
     * List of car rental itineraries.
     */
    private List<CarRentalItinerary> carRentalItinerary;

    /**
     * List of insurances.
     */
    private List<Insurance> insurance;

    /**
     * List of drivers.
     */
    private List<Person> drivers;

    /**
     * Affiliate name.
     */
    private String affiliateName;

    /**
     * Get the PNR.
     *
     * @return PNR.
     */
    public String getPnr() {
        return this.pnr;
    }

    /**
     * Set the PNR.
     *
     * @param pnr PNR.
     * @return Same instance.
     */
    public CarRentalReservationDetails setPnr(final String pnr) {
        this.pnr = pnr;

        return this;
    }

    /**
     * Get the list of car rental itineraries.
     *
     * @return List of car rental itineraries.
     */
    public List<CarRentalItinerary> getCarRentalItinerary() {
        return this.carRentalItinerary;
    }

    /**
     * Set the list of car rental itineraries.
     *
     * @param carRentalItinerary List of car rental itineraries.
     * @return Same instance.
     */
    public CarRentalReservationDetails setCarRentalItinerary(
            final List<CarRentalItinerary> carRentalItinerary) {
        this.carRentalItinerary = carRentalItinerary;

        return this;
    }

    /**
     * Get the list insurances.
     *
     * @return List of insurances
     */
    public List<Insurance> getInsurance() {
        return this.insurance;
    }

    /**
     * Set the list of insurances.
     *
     * @param insurance List of insurances.
     * @return Same instance.
     */
    public CarRentalReservationDetails setInsurance(
            final List<Insurance> insurance) {
        this.insurance = insurance;

        return this;
    }

    /**
     * Get the list of drivers.
     *
     * @return List of drivers.
     */
    public List<Person> getDrivers() {
        return this.drivers;
    }

    /**
     * Set the list of drivers.
     *
     * @param drivers List of drivers.
     * @return Same instance.
     */
    public CarRentalReservationDetails setDrivers(
            final List<Person> drivers) {
        this.drivers = drivers;

        return this;
    }

    /**
     * Get the affiliate name.
     *
     * @return Affiliate name.
     */
    public String getAffiliateName() {
        return this.affiliateName;
    }

    /**
     * Set the affiliate name.
     *
     * @param affiliateName Affiliate name.
     * @return Same instance.
     */
    public CarRentalReservationDetails setAffiliateName(
            final String affiliateName) {
        this.affiliateName = affiliateName;

        return this;
    }
}
