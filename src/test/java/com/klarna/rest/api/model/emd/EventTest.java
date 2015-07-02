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

/**
 * Test cases for the Event class.
 */
@RunWith(MockitoJUnitRunner.class)
public class EventTest extends TestCase {

    Event object;

    @Before
    public void setUp() {
        this.object = new Event();
    }

    @Test
    public void testGetEventName() {
        assertNull(this.object.getEventName());

        String expected = "name";
        this.object.setEventName(expected);

        assertSame(expected, this.object.getEventName());
    }

    @Test
    public void testGetEventCompany() {
        assertNull(this.object.getEventCompany());

        String expected = "company";
        this.object.setEventCompany(expected);

        assertSame(expected, this.object.getEventCompany());
    }

    @Test
    public void testGetGenreOfEvent() {
        assertNull(this.object.getGenreOfEvent());

        String expected = "genre";
        this.object.setGenreOfEvent(expected);

        assertSame(expected, this.object.getGenreOfEvent());
    }

    @Test
    public void testGetArenaName() {
        assertNull(this.object.getArenaName());

        String expected = "name";
        this.object.setArenaName(expected);

        assertSame(expected, this.object.getArenaName());
    }

    @Test
    public void testGetArenaLocation() {
        assertNull(this.object.getArenaLocation());

        Location expected = new Location();
        this.object.setArenaLocation(expected);

        assertSame(expected, this.object.getArenaLocation());
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
    public void testIsAccessControlledVenue() {
        assertNull(this.object.isAccessControlledVenue());

        Boolean expected = false;
        this.object.setAccessControlledVenue(expected);

        assertSame(expected, this.object.isAccessControlledVenue());
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
    public void testGetAffiliateName() {
        assertNull(this.object.getAffiliateName());

        String expected = "name";
        this.object.setAffiliateName(expected);

        assertSame(expected, this.object.getAffiliateName());
    }
}
