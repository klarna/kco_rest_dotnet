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
 * Test cases for the ExtraMerchantDataBody class:
 */
@RunWith(MockitoJUnitRunner.class)
public class ExtraMerchantDataBodyTest extends TestCase {

    ExtraMerchantDataBody object;

    @Before
    public void setUp() {
        this.object = new ExtraMerchantDataBody();
    }

    @Test
    public void testGetAirReservationDetails() {
        assertNull(this.object.getAirReservationDetails());

        List<AirReservationDetails> expected = new ArrayList<>();
        this.object.setAirReservationDetails(expected);

        assertSame(expected, this.object.getAirReservationDetails());
    }

    @Test
    public void testGetBusReservationDetails() {
        assertNull(this.object.getBusReservationDetails());

        List<BusReservationDetails> expected = new ArrayList<>();
        this.object.setBusReservationDetails(expected);

        assertSame(expected, this.object.getBusReservationDetails());
    }

    @Test
    public void testGetTrainReservationDetails() {
        assertNull(this.object.getTrainReservationDetails());

        List<TrainReservationDetails> expected = new ArrayList<>();
        this.object.setTrainReservationDetails(expected);

        assertSame(expected, this.object.getTrainReservationDetails());
    }

    @Test
    public void testGetFerryReservationDetails() {
        assertNull(this.object.getFerryReservationDetails());

        List<FerryReservationDetails> expected = new ArrayList<>();
        this.object.setFerryReservationDetails(expected);

        assertSame(expected, this.object.getFerryReservationDetails());
    }

    @Test
    public void testGetHotelReservationDetails() {
        assertNull(this.object.getHotelReservationDetails());

        List<HotelReservationDetails> expected = new ArrayList<>();
        this.object.setHotelReservationDetails(expected);

        assertSame(expected, this.object.getHotelReservationDetails());
    }

    @Test
    public void testGetCarRentalReservationDetails() {
        assertNull(this.object.getCarRentalReservationDetails());

        List<CarRentalReservationDetails> expected = new ArrayList<>();
        this.object.setCarRentalReservationDetails(expected);

        assertSame(expected, this.object.getCarRentalReservationDetails());
    }

    @Test
    public void testGetEvent() {
        assertNull(this.object.getEvent());

        List<Event> expected = new ArrayList<>();
        this.object.setEvent(expected);

        assertSame(expected, this.object.getEvent());
    }

    @Test
    public void testGetVoucher() {
        assertNull(this.object.getVoucher());

        List<Voucher> expected = new ArrayList<>();
        this.object.setVoucher(expected);

        assertSame(expected, this.object.getVoucher());
    }

    @Test
    public void testGetSubscription() {
        assertNull(this.object.getSubscription());

        List<Subscription> expected = new ArrayList<>();
        this.object.setSubscription(expected);

        assertSame(expected, this.object.getSubscription());
    }

    @Test
    public void testGetCustomerAccountInfo() {
        assertNull(this.object.getCustomerAccountInfo());

        List<CustomerAccountInformation> expected = new ArrayList<>();
        this.object.setCustomerAccountInfo(expected);

        assertSame(expected, this.object.getCustomerAccountInfo());
    }

    @Test
    public void testGetMarketplaceSellerInfo() {
        assertNull(this.object.getMarketplaceSellerInfo());

        List<MarketplaceSellerInformation> expected = new ArrayList<>();
        this.object.setMarketplaceSellerInfo(expected);

        assertSame(expected, this.object.getMarketplaceSellerInfo());
    }

    @Test
    public void testGetMarketplaceWinnerInfo() {
        assertNull(this.object.getMarketplaceWinnerInfo());

        List<MarketplaceWinnerInformation> expected = new ArrayList<>();
        this.object.setMarketplaceWinnerInfo(expected);

        assertSame(expected, this.object.getMarketplaceWinnerInfo());
    }

    @Test
    public void testGetPurchaseHistoryFull() {
        assertNull(this.object.getPaymentHistoryFull());

        List<PaymentHistoryFull> expected = new ArrayList<>();
        this.object.setPaymentHistoryFull(expected);

        assertSame(expected, this.object.getPaymentHistoryFull());
    }

    @Test
    public void testGetPurchaseHistorySimple() {
        assertNull(this.object.getPaymentHistorySimple());

        List<PaymentHistorySimple> expected = new ArrayList<>();
        this.object.setPaymentHistorySimple(expected);

        assertSame(expected, this.object.getPaymentHistorySimple());
    }

    @Test
    public void testGetOtherDeliveryAddress() {
        assertNull(this.object.getOtherDeliveryAddress());

        List<OtherDeliveryAddress> expected = new ArrayList<>();
        this.object.setOtherDeliveryAddress(expected);

        assertSame(expected, this.object.getOtherDeliveryAddress());
    }
}
