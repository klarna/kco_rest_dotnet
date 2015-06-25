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

package com.klarna.rest.api.model;

/**
 * Checkout attachment model.
 */
public class Attachment {

    /**
     * Content-Type.
     */
    private String contentType;

    /**
     * JSON serialised body model.
     */
    private String body;

    /**
     * Get the content type.
     *
     * @return Content type.
     */
    public String getContentType() {
        return contentType;
    }

    /**
     * Set the content type.
     *
     * @param contentType Content type.
     * @return Same instance.
     */
    public Attachment setContentType(final String contentType) {
        this.contentType = contentType;

        return this;
    }

    /**
     * Get the JSON serialized body string.
     *
     * @return JSON serialized body string.
     */
    public String getBody() {
        return body;
    }

    /**
     * Set the JSON serialized body string.
     *
     * @param body JSON serialized body string.
     * @return Same instance.
     */
    public Attachment setBody(final String body) {
        this.body = body;

        return this;
    }
}
