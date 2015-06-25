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
 * Test cases for the HotelItinerary class.
 */
@RunWith(MockitoJUnitRunner.class)
public class HotelItineraryTest extends TestCase {

    HotelItinerary object;

    @Before
    public void setUp() {
        this.object = new HotelItinerary();
    }

    @Test
    public void testGetHotelName() {
        assertNull(this.object.getHotelName());

        String expected = "name";
        this.object.setHotelName(expected);

        assertSame(expected, this.object.getHotelName());
    }

    @Test
    public void testGetAddress() {
        assertNull(this.object.getAddress());

        Location expected = new Location();
        this.object.setAddress(expected);

        assertSame(expected, this.object.getAddress());
    }

    @Test
    public void testGetStartTime() {
        assertNull(this.object.getStartTime());

        DateTime expected = new DateTime();
        this.object.setStartTime(expected);

        assertSame(expected, this.object.getStartTime());
    }

    @Test
    public void testGetEndTime() {
        assertNull(this.object.getEndTime());

        DateTime expected = new DateTime();
        this.object.setEndTime(expected);

        assertSame(expected, this.object.getEndTime());
    }

    @Test
    public void testGetNumberOfRooms() {
        assertNull(this.object.getNumberOfRooms());

        Integer expected = 4;
        this.object.setNumberOfRooms(expected);

        assertSame(expected, this.object.getNumberOfRooms());
    }

    @Test
    public void testGetPassengerID() {
        assertNull(this.object.getPassengerID());

        List<Integer> expected = new ArrayList<>();
        this.object.setPassengerID(expected);

        assertSame(expected, this.object.getPassengerID());
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
    public void testGetHotelPrice() {
        assertNull(this.object.getHotelPrice());

        Long expected = 50000L;
        this.object.setHotelPrice(expected);

        assertSame(expected, this.object.getHotelPrice());
    }

    @Test
    public void testGetCls() {
        assertNull(this.object.getCls());

        String expected = "5 stars";
        this.object.setCls(expected);

        assertSame(expected, this.object.getCls());
    }
}
