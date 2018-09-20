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
 * The model for events.
 */
public class Event extends Model {
    /**
     * Event name.
     */
    private String eventName;

    /**
     * Event company.
     */
    private String eventCompany;

    /**
     * Event genre.
     */
    private String genreOfEvent;

    /**
     * Arena name.
     */
    private String arenaName;

    /**
     * Arena location.
     */
    private Location arenaLocation;

    /**
     * Start time.
     */
    private DateTime startTime;

    /**
     * End time.
     */
    private DateTime endTime;

    /**
     * Access controlled venue.
     */
    private Boolean accessControlledVenue;

    /**
     * Ticket delivery method.
     */
    private String ticketDeliveryMethod;

    /**
     * Ticket delivery recipient.
     */
    private String ticketDeliveryRecipient;

    /**
     * Affiliate name.
     */
    private String affiliateName;

    /**
     * Get event name.
     *
     * @return Event name.
     */
    public String getEventName() {
        return this.eventName;
    }

    /**
     * Set event name.
     *
     * @param eventName Event name.
     * @return Same instance.
     */
    public Event setEventName(final String eventName) {
        this.eventName = eventName;

        return this;
    }

    /**
     * Get the event company name.
     *
     * @return Event company name.
     */
    public String getEventCompany() {
        return this.eventCompany;
    }

    /**
     * Set the event company name.
     *
     * @param eventCompany Event company name.
     * @return Same instance.
     */
    public Event setEventCompany(final String eventCompany) {
        this.eventCompany = eventCompany;

        return this;
    }

    /**
     * Get the event genre.
     *
     * @return Event genre.
     */
    public String getGenreOfEvent() {
        return this.genreOfEvent;
    }

    /**
     * Set the event genre.
     *
     * @param genreOfEvent Event genre.
     * @return Same instance.
     */
    public Event setGenreOfEvent(final String genreOfEvent) {
        this.genreOfEvent = genreOfEvent;

        return this;
    }

    /**
     * Get the arena name.
     *
     * @return Arena name.
     */
    public String getArenaName() {
        return this.arenaName;
    }

    /**
     * Set the arena name.
     *
     * @param arenaName Arena name
     * @return Same instance.
     */
    public Event setArenaName(final String arenaName) {
        this.arenaName = arenaName;

        return this;
    }

    /**
     * Get the arena location.
     *
     * @return Arena location.
     */
    public Location getArenaLocation() {
        return this.arenaLocation;
    }

    /**
     * Set the arena location.
     *
     * @param arenaLocation Arena location.
     * @return Same instance.
     */
    public Event setArenaLocation(final Location arenaLocation) {
        this.arenaLocation = arenaLocation;

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
    public Event setStartTime(final DateTime startTime) {
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
    public Event setEndTime(final DateTime endTime) {
        this.endTime = endTime;

        return this;
    }

    /**
     * Is event a access controlled venue.
     *
     * @return True if event is access controlled.
     */
    public Boolean isAccessControlledVenue() {
        return this.accessControlledVenue;
    }

    /**
     * Set whether the event is a access controlled venue.
     *
     * @param accessControlledVenue If event is a access controlled venue.
     * @return Same instance.
     */
    public Event setAccessControlledVenue(final Boolean accessControlledVenue) {
        this.accessControlledVenue = accessControlledVenue;

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
     *
     * @param ticketDeliveryMethod Ticket delivery method.
     * @return Same instance.
     */
    public Event setTicketDeliveryMethod(final String ticketDeliveryMethod) {
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
     * @param ticketDeliveryRecipient Ticket delivery recipient
     * @return Same instance.
     */
    public Event setTicketDeliveryRecipient(
            final String ticketDeliveryRecipient) {
        this.ticketDeliveryRecipient = ticketDeliveryRecipient;

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
     * @return Same instance
     */
    public Event setAffiliateName(final String affiliateName) {
        this.affiliateName = affiliateName;

        return this;
    }
}
