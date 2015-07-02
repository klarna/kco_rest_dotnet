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

package com.klarna.rest.api.model.emd;

import com.klarna.rest.api.model.Model;
import org.codehaus.jackson.annotate.JsonProperty;
import org.joda.time.DateTime;

import java.util.List;

/**
 * The model for car rental itineraries.
 */
public class CarRentalItinerary extends Model {
    /**
     * Rental company name.
     */
    private String rentalCompany;

    /**
     * List of driver IDs.
     */
    private List<Integer> driversID;

    /**
     * Pickup location.
     */
    private Location pickUpLocation;

    /**
     * Drop off location.
     */
    private Location dropOffLocation;

    /**
     * Start time.
     */
    private DateTime startTime;

    /**
     * End time.
     */
    private DateTime endTime;

    /**
     * Car price.
     */
    private Long carPrice;

    /**
     * Car class.
     */
    private String cls;

    /**
     * Get the rental company name.
     *
     * @return Rental company name.
     */
    public String getRentalCompany() {
        return this.rentalCompany;
    }

    /**
     * Set the rental company name.
     *
     * @param rentalCompany Rental company name.
     * @return Same instance.
     */
    public CarRentalItinerary setRentalCompany(final String rentalCompany) {
        this.rentalCompany = rentalCompany;

        return this;
    }

    /**
     * Get the list of driver IDs.
     *
     * @return List of driver IDs.
     */
    public List<Integer> getDriversID() {
        return this.driversID;
    }

    /**
     * Set the list of driver IDs.
     *
     * @param driversID List of driver IDs.
     * @return Same instance.
     */
    public CarRentalItinerary setDriversID(final List<Integer> driversID) {
        this.driversID = driversID;

        return this;
    }

    /**
     * Get the pickup location.
     *
     * @return Pickup location.
     */
    public Location getPickUpLocation() {
        return this.pickUpLocation;
    }

    /**
     * Set the pickup location.
     *
     * @param pickUpLocation Pickup location.
     * @return Same instance.
     */
    public CarRentalItinerary setPickUpLocation(final Location pickUpLocation) {
        this.pickUpLocation = pickUpLocation;

        return this;
    }

    /**
     * Get the drop off location.
     *
     * @return Drop off location.
     */
    public Location getDropOffLocation() {
        return this.dropOffLocation;
    }

    /**
     * Set the drop off location.
     *
     * @param dropOffLocation Drop off location.
     * @return Same instance.
     */
    public CarRentalItinerary setDropOffLocation(
            final Location dropOffLocation) {
        this.dropOffLocation = dropOffLocation;

        return this;
    }

    /**
     * Get the start time.
     *
     * @return Start time.
     */
    public DateTime getStartTime() {
        return this.startTime;
    }

    /**
     * Set the start time.
     *
     * @param startTime Start time.
     * @return Same instance.
     */
    public CarRentalItinerary setStartTime(final DateTime startTime) {
        this.startTime = startTime;

        return this;
    }

    /**
     * Get end time.
     *
     * @return End time.
     */
    public DateTime getEndTime() {
        return this.endTime;
    }

    /**
     * Set the end time.
     *
     * @param endTime End time.
     * @return Same instance.
     */
    public CarRentalItinerary setEndTime(final DateTime endTime) {
        this.endTime = endTime;

        return this;
    }

    /**
     * Get the car price.
     *
     * @return Car price.
     */
    public Long getCarPrice() {
        return this.carPrice;
    }

    /**
     * Set the car price.
     *
     * @param carPrice Car price.
     * @return Same instance.
     */
    public CarRentalItinerary setCarPrice(final Long carPrice) {
        this.carPrice = carPrice;

        return this;
    }

    /**
     * Get the car class.
     *
     * @return Car class.
     */
    @JsonProperty("class")
    public String getCls() {
        return this.cls;
    }

    /**
     * Set the car class.
     *
     * @param cls Car class
     * @return Same instance.
     */
    @JsonProperty("class")
    public CarRentalItinerary setCls(final String cls) {
        this.cls = cls;

        return this;
    }
}
