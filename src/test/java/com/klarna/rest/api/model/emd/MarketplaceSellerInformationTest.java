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
 * Test cases for the MarketplaceSellerInformation class.
 */
@RunWith(MockitoJUnitRunner.class)
public class MarketplaceSellerInformationTest extends TestCase {

    MarketplaceSellerInformation object;

    @Before
    public void setUp() {
        this.object = new MarketplaceSellerInformation();
    }

    @Test
    public void testGetUniqueAccountIdentifierSeller() {
        assertNull(this.object.getUniqueAccountIdentifierSeller());

        UniqueAccountIdentifier expected = new UniqueAccountIdentifier();
        this.object.setUniqueAccountIdentifierSeller(expected);

        assertSame(expected, this.object.getUniqueAccountIdentifierSeller());
    }

    @Test
    public void testGetSubMerchantID() {
        assertNull(this.object.getSubMerchantID());

        String expected = "subMerchantID";
        this.object.setSubMerchantID(expected);

        assertSame(expected, this.object.getSubMerchantID());
    }

    @Test
    public void testGetProductCategory() {
        assertNull(this.object.getProductCategory());

        String expected = "productCategory";
        this.object.setProductCategory(expected);

        assertSame(expected, this.object.getProductCategory());
    }

    @Test
    public void testGetProductName() {
        assertNull(this.object.getProductName());

        String expected = "productName";
        this.object.setProductName(expected);

        assertSame(expected, this.object.getProductName());
    }

    @Test
    public void testGetAccountRegistrationDate() {
        assertNull(this.object.getAccountRegistrationDate());

        DateTime expected = new DateTime();
        this.object.setAccountRegistrationDate(expected);

        assertSame(expected, this.object.getAccountRegistrationDate());
    }

    @Test
    public void testGetAccountLastModified() {
        assertNull(this.object.getAccountLastModified());

        LastModified expected = new LastModified();
        this.object.setAccountLastModified(expected);

        assertSame(expected, this.object.getAccountLastModified());
    }

    @Test
    public void testGetSellerRating() {
        assertNull(this.object.getSellerRating());

        Long expected = 45000L;
        this.object.setSellerRating(expected);

        assertSame(expected, this.object.getSellerRating());
    }

    @Test
    public void testGetNumberOfTrades() {
        assertNull(this.object.getNumberOfTrades());

        Integer expected = 55;
        this.object.setNumberOfTrades(expected);

        assertSame(expected, this.object.getNumberOfTrades());
    }

    @Test
    public void testGetVolumeOfTrades() {
        assertNull(this.object.getVolumeOfTrades());

        Integer expected = 44;
        this.object.setVolumeOfTrades(expected);

        assertSame(expected, this.object.getVolumeOfTrades());
    }
}
