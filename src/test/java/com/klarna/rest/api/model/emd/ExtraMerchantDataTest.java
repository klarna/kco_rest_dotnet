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
import com.klarna.rest.api.model.Attachment;
import org.joda.time.DateTime;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * Test cases for the ExtraMerchantData class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ExtraMerchantDataTest extends TestCase {

    ExtraMerchantData object;

    @Before
    public void setUp() {
        this.object = new ExtraMerchantData();
    }

    @Test
    public void testFromAttachment() throws IOException {
        Attachment attachment = new Attachment()
                .setContentType(this.object.getContentType())
                .setBody(
                        "{\"payment_history_full\":[{\"unique_account_identifier\":\"bla\",\"date_of_first_paid_purchase\":\"2015-06-29T16:31:17Z\"}]}");

        ExtraMerchantData actual = ExtraMerchantData.fromAttachment(attachment);

        List<PaymentHistoryFull> list = actual.getBody()
                .getPaymentHistoryFull();

        assertNotNull(list);
        assertTrue("Not enough full purchase histories", list.size() > 0);

        PaymentHistoryFull history = list.get(0);

        assertEquals("bla", history.getUniqueAccountIdentifier());
        assertEquals(
                "2015-06-29T16:31:17.000Z",
                history.getDateOfFirstPaidPurchase().toString());
    }

    @Test(expected=IOException.class)
    public void testFromAttachmentContentTypeNull() throws IOException {
        Attachment attachment = new Attachment();

        ExtraMerchantData.fromAttachment(attachment);
    }

    @Test(expected=IOException.class)
    public void testFromAttachmentContentTypeEmpty() throws IOException {
        Attachment attachment = new Attachment().setContentType("");

        ExtraMerchantData.fromAttachment(attachment);
    }

    @Test(expected=IOException.class)
    public void testFromAttachmentContentTypeInvalid() throws IOException {
        Attachment attachment = new Attachment().setContentType("application/stuff");

        ExtraMerchantData.fromAttachment(attachment);
    }

    @Test
    public void testGetContentType() {
        assertNotNull(this.object.getContentType());
    }

    @Test
    public void testGetBody() {
        assertNull(this.object.getBody());

        ExtraMerchantDataBody expected = new ExtraMerchantDataBody();
        this.object.setBody(expected);

        assertSame(expected, this.object.getBody());
    }

    @Test
    public void testToAttachment() throws IOException {
        final PaymentHistoryFull history = new PaymentHistoryFull()
                .setUniqueAccountIdentifier("bla")
                .setDateOfFirstPaidPurchase(
                        DateTime.parse("2015-06-29T16:31:17.528+02:00"));

        ExtraMerchantDataBody body = new ExtraMerchantDataBody()
            .setPaymentHistoryFull(new ArrayList<PaymentHistoryFull>() {
                {
                    add(history);
                }
            });

        this.object.setBody(body);

        Attachment attachment = this.object.toAttachment();

        assertEquals(this.object.getContentType(), attachment.getContentType());
        assertEquals(
                "{\"payment_history_full\":[{\"unique_account_identifier\":\"bla\",\"date_of_first_paid_purchase\":\"2015-06-29T16:31:17Z\"}]}",
                attachment.getBody());
    }
}
