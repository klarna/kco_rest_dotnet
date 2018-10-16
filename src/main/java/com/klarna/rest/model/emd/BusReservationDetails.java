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

import com.klarna.rest.model.emd.Model;

import java.util.List;

/**
 * The model for bus reservation details.
 */
public class BusReservationDetails extends Model {
    /**
     * PNR.
     */
    private String pnr;

    /**
     * List of itineraries.
     */
    private List<Itinerary> itinerary;

    /**
     * List of insurances.
     */
    private List<Insurance> insurance;

    /**
     * List of passengers.
     */
    private List<Person> passengers;

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
    public BusReservationDetails setPnr(final String pnr) {
        this.pnr = pnr;

        return this;
    }

    /**
     * Get the list of itineraries.
     *
     * @return List of itineraries.
     */
    public List<Itinerary> getItinerary() {
        return this.itinerary;
    }

    /**
     * Set the list of itineraries.
     *
     * @param itinerary List of itineraries.
     * @return Same instance.
     */
    public BusReservationDetails setItinerary(final List<Itinerary> itinerary) {
        this.itinerary = itinerary;

        return this;
    }

    /**
     * Get the list of insurances.
     *
     * @return List of insurances.
     */
    public List<Insurance> getInsurance() {
        return this.insurance;
    }

    /**
     * Set the list of insurances.
     *
     * @param insurance List of insurances.
     * @return Same instance
     */
    public BusReservationDetails setInsurance(final List<Insurance> insurance) {
        this.insurance = insurance;

        return this;
    }

    /**
     * Get the list of passengers.
     *
     * @return List of passengers.
     */
    public List<Person> getPassengers() {
        return this.passengers;
    }

    /**
     * Set the list passengers.
     *
     * @param passengers List of passengers.
     * @return Same instance.
     */
    public BusReservationDetails setPassengers(final List<Person> passengers) {
        this.passengers = passengers;

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
    public BusReservationDetails setAffiliateName(final String affiliateName) {
        this.affiliateName = affiliateName;

        return this;
    }
}
