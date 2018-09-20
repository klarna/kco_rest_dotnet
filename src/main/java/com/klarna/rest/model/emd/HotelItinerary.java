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

import com.fasterxml.jackson.annotation.JsonProperty;
import org.joda.time.DateTime;

import java.util.List;

/**
 * The model for hotel itineraries.
 */
public class HotelItinerary extends Model {
    /**
     * Hotel name.
     */
    private String hotelName;

    /**
     * Hotel address.
     */
    private Location address;

    /**
     * Start time.
     */
    private DateTime startTime;

    /**
     * End time.
     */
    private DateTime endTime;

    /**
     * Number of rooms.
     */
    private Integer numberOfRooms;

    /**
     * List passenger IDs.
     */
    private List<Integer> passengerID;

    /**
     * Ticket delivery method.
     */
    private String ticketDeliveryMethod;

    /**
     * Ticket delivery recipient.
     */
    private String ticketDeliveryRecipient;

    /**
     * Hotel price.
     */
    private Long hotelPrice;

    /**
     * Hotel class.
     */
    private String cls;

    /**
     * Get the hotel name.
     *
     * @return Hotel name.
     */
    public String getHotelName() {
        return this.hotelName;
    }

    /**
     * Set the hotel name.
     *
     * @param hotelName The hotel name.
     * @return Same instance.
     */
    public HotelItinerary setHotelName(final String hotelName) {
        this.hotelName = hotelName;

        return this;
    }

    /**
     * Get the hotel address.
     *
     * @return Hotel address.
     */
    public Location getAddress() {
        return this.address;
    }

    /**
     * Set the hotel address.
     *
     * @param address Hotel address.
     * @return Same instance.
     */
    public HotelItinerary setAddress(final Location address) {
        this.address = address;

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
    public HotelItinerary setStartTime(final DateTime startTime) {
        this.startTime = startTime;

        return this;
    }

    /**
     * Get the end time.
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
    public HotelItinerary setEndTime(final DateTime endTime) {
        this.endTime = endTime;

        return this;
    }

    /**
     * Get the number of rooms.
     *
     * @return Number of rooms.
     */
    public Integer getNumberOfRooms() {
        return this.numberOfRooms;
    }

    /**
     * Set the number of rooms.
     *
     * @param numberOfRooms Number of rooms.
     * @return Same instance.
     */
    public HotelItinerary setNumberOfRooms(final Integer numberOfRooms) {
        this.numberOfRooms = numberOfRooms;

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
    public HotelItinerary setPassengerID(final List<Integer> passengerID) {
        this.passengerID = passengerID;

        return this;
    }

    /**
     * Set the ticket delivery method.
     *
     * @return Ticket delivery method.
     */
    public String getTicketDeliveryMethod() {
        return this.ticketDeliveryMethod;
    }

    /**
     * Set the ticket delivery method.
     *
     * @param ticketDeliveryMethod Ticket delivery method.
     * @return Same instance.
     */
    public HotelItinerary setTicketDeliveryMethod(
            final String ticketDeliveryMethod) {
        this.ticketDeliveryMethod = ticketDeliveryMethod;

        return this;
    }

    /**
     * Get the ticket delivery recipient.
     * <p>
     * Allowed values are "pick_up", "email", "post" or "phone".
     * </p>
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
    public HotelItinerary setTicketDeliveryRecipient(
            final String ticketDeliveryRecipient) {
        this.ticketDeliveryRecipient = ticketDeliveryRecipient;

        return this;
    }

    /**
     * Get the hotel price.
     *
     * @return Hotel price.
     */
    public Long getHotelPrice() {
        return this.hotelPrice;
    }

    /**
     * Set the hotel price.
     *
     * @param hotelPrice Hotel price.
     * @return Same instance.
     */
    public HotelItinerary setHotelPrice(final Long hotelPrice) {
        this.hotelPrice = hotelPrice;

        return this;
    }

    /**
     * Get the hotel class.
     *
     * @return Hotel class.
     */
    @JsonProperty("class")
    public String getCls() {
        return this.cls;
    }

    /**
     * Set the hotel class.
     *
     * @param cls Hotel class.
     * @return Same instance.
     */
    @JsonProperty("class")
    public HotelItinerary setCls(final String cls) {
        this.cls = cls;

        return this;
    }
}
