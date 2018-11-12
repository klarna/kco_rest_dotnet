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

package com.klarna.rest.api.checkout.model.emd;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.klarna.rest.api.DefaultMapper;
import com.klarna.rest.api.checkout.model.CheckoutAttachment;

import java.io.IOException;

/**
 * The model for the EMD attachment.
 */
public class ExtraMerchantData extends Model {
    /**
     * Extra merchant data content type.
     */
    private static String contentType =
            "application/vnd.klarna.internal.emd-v2+json";

    /**
     * Extra merchant data body model.
     */
    private ExtraMerchantDataBody body;

    /**
     * Create a ExtraMerchantData instance from an Attachment.
     *
     * @param attachment Attachment to convert.
     * @return Parsed ExtraMerchantData instance.
     * @throws IOException For invalid content type or invalid body string.
     */
    public static ExtraMerchantData fromAttachment(
            final CheckoutAttachment attachment) throws IOException {
        if (attachment.getContentType() == null
                || !attachment.getContentType().equals(contentType)) {
            throw new IOException("Incorrect content type");
        }

        ObjectMapper om = new DefaultMapper();
        ExtraMerchantDataBody body = om.readValue(attachment.getBody(), ExtraMerchantDataBody.class);

        return new ExtraMerchantData().setBody(body);
    }

    /**
     * Get the content type.
     *
     * @return Content type.
     */
    public String getContentType() {
        return contentType;
    }

    /**
     * Get the extra merchant data body model.
     *
     * @return Extra merchant data body model.
     */
    public ExtraMerchantDataBody getBody() {
        return this.body;
    }

    /**
     * Set the extra merchant data body model.
     *
     * @param body Extra merchant data body model.
     * @return Same instance.
     */
    public ExtraMerchantData setBody(final ExtraMerchantDataBody body) {
        this.body = body;

        return this;
    }

    /**
     * Convert this instance to an attachment.
     *
     * @return Attachment.
     * @throws IOException If the body could not be serialized.
     */
    public CheckoutAttachment toAttachment() throws IOException {
        ObjectMapper om = new DefaultMapper();

        CheckoutAttachment attachment = new CheckoutAttachment();
        attachment.setContentType(this.getContentType());
        attachment.setBody(om.writeValueAsString(this.getBody()));

        return attachment;
    }
}
