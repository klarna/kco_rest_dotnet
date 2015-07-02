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
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.ArrayList;
import java.util.List;

/**
 * Test cases for the HotelReservationDetails class.
 */
@RunWith(MockitoJUnitRunner.class)
public class HotelReservationDetailsTest extends TestCase {

    HotelReservationDetails object;

    @Before
    public void setUp() {
        this.object = new HotelReservationDetails();
    }

    @Test
    public void testPnr() {
        assertNull(this.object.getPnr());

        String expected = "PNR";
        this.object.setPnr(expected);

        assertSame(expected, this.object.getPnr());
    }

    @Test
    public void testCarRentalItinerary() {
        assertNull(this.object.getHotelItinerary());

        List<HotelItinerary> expected = new ArrayList<>();
        this.object.setHotelItinerary(expected);

        assertSame(expected, this.object.getHotelItinerary());
    }

    @Test
    public void testInsurance() {
        assertNull(this.object.getInsurance());

        List<Insurance> expected = new ArrayList<>();
        this.object.setInsurance(expected);

        assertSame(expected, this.object.getInsurance());
    }

    @Test
    public void testDrivers() {
        assertNull(this.object.getPassengers());

        List<Person> expected = new ArrayList<>();
        this.object.setPassengers(expected);

        assertSame(expected, this.object.getPassengers());
    }

    @Test
    public void testAffiliateName() {
        assertNull(this.object.getAffiliateName());

        String expected = "Name";
        this.object.setAffiliateName(expected);

        assertSame(expected, this.object.getAffiliateName());
    }
}
