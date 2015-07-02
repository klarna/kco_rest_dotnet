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
 * Test cases for the CarRentalItinerary class.
 */
@RunWith(MockitoJUnitRunner.class)
public class CarRentalItineraryTest extends TestCase {

    CarRentalItinerary object;

    @Before
    public void setUp() {
        this.object = new CarRentalItinerary();
    }

    @Test
    public void testRentalCompany() {
        assertNull(this.object.getRentalCompany());

        String expected = "Company name";
        this.object.setRentalCompany(expected);

        assertSame(expected, this.object.getRentalCompany());
    }

    @Test
    public void testDriversID() {
        assertNull(this.object.getDriversID());

        List<Integer> expected = new ArrayList<>();
        this.object.setDriversID(expected);

        assertSame(expected, this.object.getDriversID());
    }

    @Test
    public void testPickUpLocation() {
        assertNull(this.object.getPickUpLocation());

        Location expected = new Location();
        this.object.setPickUpLocation(expected);

        assertSame(expected, this.object.getPickUpLocation());
    }

    @Test
    public void testDropOffLocation() {
        assertNull(this.object.getDropOffLocation());

        Location expected = new Location();
        this.object.setDropOffLocation(expected);

        assertSame(expected, this.object.getDropOffLocation());
    }

    @Test
    public void testStartTime() {
        assertNull(this.object.getStartTime());

        DateTime expected = new DateTime();
        this.object.setStartTime(expected);

        assertSame(expected, this.object.getStartTime());
    }

    @Test
    public void testEndTime() {
        assertNull(this.object.getEndTime());

        DateTime expected = new DateTime();
        this.object.setEndTime(expected);

        assertSame(expected, this.object.getEndTime());
    }

    @Test
    public void testCarPrice() {
        assertNull(this.object.getCarPrice());

        Long expected = 100000L;
        this.object.setCarPrice(expected);

        assertSame(expected, this.object.getCarPrice());
    }

    @Test
    public void testCls() {
        assertNull(this.object.getCls());

        String expected = "super class";
        this.object.setCls(expected);

        assertSame(expected, this.object.getCls());
    }
}
