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
 * The model for itineraries.
 */
public class Itinerary extends Model {
    /**
     * Departure name.
     */
    private String departure;

    /**
     * Departure city.
     */
    private String departureCity;

    /**
     * Arrival name.
     */
    private String arrival;

    /**
     * Arrival city.
     */
    private String arrivalCity;

    /**
     * Carrier name.
     */
    private String carrier;

    /**
     * Segment price.
     */
    private Long segmentPrice;

    /**
     * Departure date.
     */
    private DateTime departureDate;

    /**
     * Ticket delivery method.
     */
    private String ticketDeliveryMethod;

    /**
     * Ticket delivery recipient.
     */
    private String ticketDeliveryRecipient;

    /**
     * List of passenger IDs.
     */
    private List<Integer> passengerID;

    /**
     * Itinerary class.
     */
    private String cls;

    /**
     * Get the departure name.
     *
     * @return Departure name.
     */
    public String getDeparture() {
        return this.departure;
    }

    /**
     * Set the departure name.
     *
     * @param departure Departure name.
     * @return Same instance.
     */
    public Itinerary setDeparture(final String departure) {
        this.departure = departure;

        return this;
    }

    /**
     * Get the departure city.
     *
     * @return Departure city.
     */
    public String getDepartureCity() {
        return this.departureCity;
    }

    /**
     * Set the departure city.
     *
     * @param departureCity Departure city.
     * @return Same instance.
     */
    public Itinerary setDepartureCity(final String departureCity) {
        this.departureCity = departureCity;

        return this;
    }

    /**
     * Get the arrival name.
     *
     * @return Arrival name.
     */
    public String getArrival() {
        return this.arrival;
    }

    /**
     * Set the arrival name.
     *
     * @param arrival Arrival name.
     * @return Same instance.
     */
    public Itinerary setArrival(final String arrival) {
        this.arrival = arrival;

        return this;
    }

    /**
     * Get the arrival city.
     *
     * @return Arrival city.
     */
    public String getArrivalCity() {
        return this.arrivalCity;
    }

    /**
     * Set the arrival city.
     *
     * @param arrivalCity Arrival city.
     * @return Same instance.
     */
    public Itinerary setArrivalCity(final String arrivalCity) {
        this.arrivalCity = arrivalCity;

        return this;
    }

    /**
     * Get the carrier name.
     *
     * @return Carrier name.
     */
    public String getCarrier() {
        return this.carrier;
    }

    /**
     * Set the carrier name.
     *
     * @param carrier Carrier name.
     * @return Same instance.
     */
    public Itinerary setCarrier(final String carrier) {
        this.carrier = carrier;

        return this;
    }

    /**
     * Get the segment price.
     *
     * @return Segment price.
     */
    public Long getSegmentPrice() {
        return this.segmentPrice;
    }

    /**
     * Set the segment price.
     *
     * @param segmentPrice Segment price.
     * @return Same instance.
     */
    public Itinerary setSegmentPrice(final Long segmentPrice) {
        this.segmentPrice = segmentPrice;

        return this;
    }

    /**
     * Get the departure date.
     *
     * @return Departure date.
     */
    public DateTime getDepartureDate() {
        return this.departureDate;
    }

    /**
     * Set the departure date.
     *
     * @param departureDate Departure date.
     * @return Same instance.
     */
    public Itinerary setDepartureDate(final DateTime departureDate) {
        this.departureDate = departureDate;

        return this;
    }

    /**
     * Get the ticket delivery method.
     *
     * @return Ticket delivery method.
     */
    public String getTicketDeliveryMethod() {
        return this.ticketDeliveryMethod;
    }

    /**
     * Set the ticket delivery method.
     * <p>
     * Allowed values are "pick_up", "email", "post" or "phone".
     * </p>
     *
     * @param ticketDeliveryMethod Ticket delivery method.
     * @return Same instance.
     */
    public Itinerary setTicketDeliveryMethod(
            final String ticketDeliveryMethod) {
        this.ticketDeliveryMethod = ticketDeliveryMethod;

        return this;
    }

    /**
     * Get the ticket delivery recipient.
     *
     * @return Ticket delivery recipient.
     */
    public String getTicketDeliveryRecipient() {
        return this.ticketDeliveryRecipient;
    }

    /**
     * Set the ticket delivery recipient.
     *
     * @param ticketDeliveryRecipient Ticket delivery recipient.
     * @return Same instance.
     */
    public Itinerary setTicketDeliveryRecipient(
            final String ticketDeliveryRecipient) {
        this.ticketDeliveryRecipient = ticketDeliveryRecipient;

        return this;
    }

    /**
     * Get the list of passenger IDs.
     *
     * @return List of passenger IDs.
     */
    public List<Integer> getPassengerID() {
        return this.passengerID;
    }

    /**
     * Set the list of passenger IDs.
     *
     * @param passengerID List of passenger IDs.
     * @return Same instance.
     */
    public Itinerary setPassengerID(
            final List<Integer> passengerID) {
        this.passengerID = passengerID;

        return this;
    }

    /**
     * Get the itinerary class.
     *
     * @return Itinerary class.
     */
    @JsonProperty("class")
    public String getCls() {
        return this.cls;
    }

    /**
     * Set the itinerary class.
     *
     * @param cls Itinerary class.
     * @return Same instance.
     */
    @JsonProperty("class")
    public Itinerary setCls(final String cls) {
        this.cls = cls;

        return this;
    }
}
