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
 * File containing the ApiException class
 */

package com.klarna.api.ordermanagement.client;

import com.klarna.api.ordermanagement.client.model.ErrorMessage;

import static java.lang.String.format;

/**
 * Generic API exception with the underlying http status and messages.
 */
public class ApiException extends RuntimeException {

    /**
     * The returned HTTP status code for this error.
     */
    public final int httpStatus;

    /**
     * The expected HTTP status, for example 200.
     */
    public final int expectedHttpStatus;

    /**
     * An error message received through the order management api.
     * <p/>
     * In the event of an error the message contains a {@link com.klarna.api.ordermanagement.client.model.ErrorMessage#correlation_id} identifying
     * this particular transaction in Klarna's systems. The correlation id may be requested by merchant support to
     * facilitate support inquiries.
     */
    public final ErrorMessage errorMessage;

    public ApiException(int receivedStatus, int expectedResponseStatus, ErrorMessage errorMessage) {
        super(format("Klarna API error! Received HTTP response status [%s] when expecting [%s], message=%s",
                receivedStatus, expectedResponseStatus, errorMessage));

        this.httpStatus = receivedStatus;
        this.expectedHttpStatus = expectedResponseStatus;
        this.errorMessage = errorMessage;
    }

}
