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
 * File containing the ErrorMessage class
 */

package com.klarna.api.ordermanagement.client.model;

import java.util.List;

/**
 * An error message received through the order management api.
 * <p/>
 * In the event of an error the message contains a {@link #correlation_id} identifying
 * this particular transaction in Klarna's systems. The correlation id may be requested by merchant support to
 * facilitate support inquiries.
 */
public class ErrorMessage extends TransportObject {

    /**
     * The error code.
     */
    public String error_code;

    /**
     * List of error messages.
     */
    public List<String> error_messages;

    /**
     * Correlation id. The correlation id may be requested by merchant support to facilitate support inquiries.
     */
    public String correlation_id;

}
