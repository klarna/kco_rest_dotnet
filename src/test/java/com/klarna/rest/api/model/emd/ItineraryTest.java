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

import com.klarna.rest.api.TestCase;
import org.joda.time.DateTime;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.ArrayList;
import java.util.List;

/**
 * Test cases for the Itinerary class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ItineraryTest extends TestCase {

    Itinerary object;

    @Before
    public void setUp() {
        this.object = new Itinerary();
    }

    @Test
    public void testGetDeparture() {
        assertNull(this.object.getDeparture());

        String expected = "wherever";
        this.object.setDeparture(expected);

        assertSame(expected, this.object.getDeparture());
    }

    @Test
    public void testGetDepartureCity() {
        assertNull(this.object.getDepartureCity());

        String expected = "Nowhere";
        this.object.setDepartureCity(expected);

        assertSame(expected, this.object.getDepartureCity());
    }

    @Test
    public void testGetArrival() {
        assertNull(this.object.getArrival());

        String expected = "Whatever";
        this.object.setArrival(expected);

        assertSame(expected, this.object.getArrival());
    }

    @Test
    public void testGetArrivalCity() {
        assertNull(this.object.getArrivalCity());

        String expected = "Somewhere";
        this.object.setArrivalCity(expected);

        assertSame(expected, this.object.getArrivalCity());
    }

    @Test
    public void testGetCarrier() {
        assertNull(this.object.getCarrier());

        String expected = "carrier";
        this.object.setCarrier(expected);

        assertSame(expected, this.object.getCarrier());
    }

    @Test
    public void testGetSegmentPrice() {
        assertNull(this.object.getSegmentPrice());

        Long expected = 2000L;
        this.object.setSegmentPrice(expected);

        assertSame(expected, this.object.getSegmentPrice());
    }

    @Test
    public void testGetDepartureDate() {
        assertNull(this.object.getDepartureDate());

        DateTime expected = new DateTime();
        this.object.setDepartureDate(expected);

        assertSame(expected, this.object.getDepartureDate());
    }

    @Test
    public void testGetTicketDeliveryMethod() {
        assertNull(this.object.getTicketDeliveryMethod());

        String expected = "email";
        this.object.setTicketDeliveryMethod(expected);

        assertSame(expected, this.object.getTicketDeliveryMethod());
    }

    @Test
    public void testGetTicketDeliveryRecipient() {
        assertNull(this.object.getTicketDeliveryRecipient());

        String expected = "test@klarna.com";
        this.object.setTicketDeliveryRecipient(expected);

        assertSame(expected, this.object.getTicketDeliveryRecipient());
    }

    @Test
    public void testGetPassengerID() {
        assertNull(this.object.getPassengerID());

        List<Integer> expected = new ArrayList<>();
        this.object.setPassengerID(expected);

        assertSame(expected, this.object.getPassengerID());
    }

    @Test
    public void testGetCls() {
        assertNull(this.object.getCls());

        String expected = "0 star";
        this.object.setCls(expected);

        assertSame(expected, this.object.getCls());
    }
}
