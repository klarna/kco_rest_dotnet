/*
 * Copyright 2014 Klarna AB
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

package com.klarna.rest.api.model;

import com.klarna.rest.api.TestCase;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

/**
 * Test cases for the Address class.
 */
@RunWith(MockitoJUnitRunner.class)
public class AddressTest extends TestCase {

    private Address address;

    @Before
    public void setUp() {
        address = new Address();
    }

    @Test
    public void testGetTitle() {
        assertNull(address.getTitle());

        address.setTitle("Mr");
        assertEquals("Mr", address.getTitle());
    }

    @Test
    public void testGetGivenName() {
        assertNull(address.getGivenName());

        address.setGivenName("Name");
        assertEquals("Name", address.getGivenName());
    }

    @Test
    public void testGetFamilyName() {
        assertNull(address.getFamilyName());

        address.setFamilyName("Last");
        assertEquals("Last", address.getFamilyName());
    }

    @Test
    public void testGetStreetAddress() {
        assertNull(address.getStreetAddress());

        address.setStreetAddress("Street");
        assertEquals("Street", address.getStreetAddress());
    }

    @Test
    public void testGetStreetAddress2() {
        assertNull(address.getStreetAddress2());

        address.setStreetAddress2("Street2");
        assertEquals("Street2", address.getStreetAddress2());
    }

    @Test
    public void testGetStreetName() {
        assertNull(address.getStreetName());

        address.setStreetName("streetName");
        assertEquals("streetName", address.getStreetName());
    }

    @Test
    public void testGetStreetNumber() {
        assertNull(address.getStreetNumber());

        address.setStreetNumber("streetNumber");
        assertEquals("streetNumber", address.getStreetNumber());
    }

    @Test
    public void testGetHouseExtension() {
        assertNull(address.getHouseExtension());

        address.setHouseExtension("houseExtension");
        assertEquals("houseExtension", address.getHouseExtension());
    }

    @Test
    public void testGetPostalCode() {
        assertNull(address.getPostalCode());

        address.setPostalCode("Zip");
        assertEquals("Zip", address.getPostalCode());
    }

    @Test
    public void testGetCity() {
        assertNull(address.getCity());

        address.setCity("City");
        assertEquals("City", address.getCity());
    }

    @Test
    public void testGetCountry() {
        assertNull(address.getCountry());

        address.setCountry("Country");
        assertEquals("Country", address.getCountry());
    }

    @Test
    public void testGetEmail() {
        assertNull(address.getEmail());

        address.setEmail("Email");
        assertEquals("Email", address.getEmail());
    }

    @Test
    public void testGetPhone() {
        assertNull(address.getPhone());

        address.setPhone("Phone");
        assertEquals("Phone", address.getPhone());
    }

    @Test
    public void testGetRegion() {
        assertNull(address.getRegion());

        address.setRegion("Region");
        assertEquals("Region", address.getRegion());
    }

    @Test
    public void testGetOrganizationName() {
        assertNull(address.getOrganizationName());

        address.setOrganizationName("OrgName");
        assertEquals("OrgName", address.getOrganizationName());
    }

    @Test
    public void testGetReference() {
        assertNull(address.getReference());

        address.setReference("#ref");
        assertEquals("#ref", address.getReference());
    }

    @Test
    public void testGetAttention() {
        assertNull(address.getAttention());

        address.setAttention("watt");
        assertEquals("watt", address.getAttention());
    }

    @Test
    public void testGetCareOf() {
        assertNull(address.getCareOf());

        address.setCareOf("C/O Box 41");
        assertEquals("C/O Box 41", address.getCareOf());
    }
}
