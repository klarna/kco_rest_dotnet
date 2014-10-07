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
 *
 * File containing the CaptureURI class
 */

package com.klarna.api.ordermanagement.client;

import org.apache.commons.lang3.Validate;

import java.net.URI;
import java.net.URISyntaxException;

/**
 * Capture resource URI.
 */
public class CaptureURI {
    private final URI uri;

    /**
     * Create a capture URI from string.
     * @param uri the URI string
     * @throws URISyntaxException if string is not a valid URI
     * @throws NullPointerException if the URI string is null
     * @throws IllegalArgumentException if the URI string is blank
     */
    public CaptureURI(String uri) throws URISyntaxException {
        Validate.notBlank(uri, "Capture URI may not be blank!");
        this.uri = new URI(uri);
    }

    /**
     * Create a capture URI from a URI.
     * @param uri the capture URI
     * @throws NullPointerException if the uri is null

     */
    public CaptureURI(URI uri) {
        Validate.notNull(uri, "Capture URI may not be null!");
        this.uri = uri;
    }

    /**
     * The capture resource URI.
     * @return a URI to a capture, never null or empty.
     */
    public URI getUri() {
        return uri;
    }

    @Override
    public String toString() {
        return uri.toString();
    }
}
