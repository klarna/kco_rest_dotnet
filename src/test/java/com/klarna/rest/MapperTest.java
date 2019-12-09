/*
 * Copyright 2018 Klarna AB
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

package com.klarna.rest;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.klarna.rest.api.DefaultMapper;
import com.klarna.rest.api.checkout.model.CheckoutOrder;
import com.klarna.rest.api.checkout.model.emd.Subscription;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;
import org.threeten.bp.LocalDate;
import org.threeten.bp.LocalTime;
import org.threeten.bp.OffsetDateTime;
import org.threeten.bp.ZoneOffset;

import java.io.IOException;


@RunWith(MockitoJUnitRunner.class)
public class MapperTest extends TestCase {
    @Test
    public void testCreateOrder() throws IOException {
        Subscription subscription = new Subscription();
        subscription.setStartTime(OffsetDateTime.parse("2018-08-08T08:37:22Z"));

        ObjectMapper mapper = new DefaultMapper();
        assertEquals("{\"startTime\":\"2018-08-08T08:37:22Z\"}", mapper.writeValueAsString(subscription));

        OffsetDateTime localTime = OffsetDateTime.of(
                LocalDate.of(2008, 6, 30),
                LocalTime.of(12, 30, 40, 987654321),
                ZoneOffset.UTC);
        subscription.setStartTime(localTime);
        assertEquals("{\"startTime\":\"2008-06-30T12:30:40.987654321Z\"}", mapper.writeValueAsString(subscription));

    }

    /**
     * Tests datetime conversion from string to OffsetDateTime and vice versa
     *
     * @throws IOException
     */
    @Test
    public void testDateTimeMapping() throws IOException {
        ObjectMapper mapper = new DefaultMapper();

        String data = "{\"started_at\": \"2008-06-30T12:30:40.987654321Z\", " +
                "\"completed_at\": \"2018-08-08T08:37:22Z\", \"order_amount\": 12345}";
        CheckoutOrder order = mapper.readValue(data, CheckoutOrder.class);

        assertEquals(12345L, order.getOrderAmount().longValue());

        OffsetDateTime startedAt = OffsetDateTime.of(
                LocalDate.of(2008, 6, 30),
                LocalTime.of(12, 30, 40, 987654321),
                ZoneOffset.UTC);
        assertEquals(order.getStartedAt(), startedAt);

        OffsetDateTime completedAt = OffsetDateTime.of(
                LocalDate.of(2018, 8, 8),
                LocalTime.of(8, 37, 22),
                ZoneOffset.UTC);
        assertEquals(order.getCompletedAt(), completedAt);
    }
}