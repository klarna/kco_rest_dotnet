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

package com.klarna.rest.api;

import com.klarna.rest.api.model.ErrorMessage;
import org.apache.commons.lang3.StringUtils;
import org.apache.http.ReasonPhraseCatalog;
import org.apache.http.impl.EnglishReasonPhraseCatalog;

/**
 * Generic API exception with the underlying HTTP status and messages.
 */
public class ApiException extends RuntimeException {

    /**
     * The returned HTTP status code for this error.
     */
    private final int httpStatus;

    /**
     * An error message received through the Klarna API.
     *
     * In the event of an error the message contains a
     * {@link com.klarna.rest.api.model.ErrorMessage#getCorrelationId()}
     * identifying this particular transaction in Klarna's systems.
     *
     * The correlation id may be requested by merchant support to
     * facilitate support inquiries.
     */
    private final ErrorMessage errorMessage;

    /**
     * Constructs a ApiException instance.
     *
     * @param status HTTP status code
     * @param errorMessage Error message
     */
    public ApiException(final int status, final ErrorMessage errorMessage) {
        super(formatError(errorMessage, status));

        this.httpStatus = status;
        this.errorMessage = errorMessage;
    }

    /**
     * Gets the error message.
     *
     * @return Error message
     */
    public ErrorMessage getErrorMessage() {
        return this.errorMessage;
    }

    /**
     * Gets the HTTP status code.
     *
     * @return Status code
     */
    public int getHttpStatus() {
        return this.httpStatus;
    }

    /**
     * Formats the exception message.
     *
     * @param errorMessage Error data
     * @param httpStatus HTTP status code
     * @return Exception message
     */
    private static String formatError(final ErrorMessage errorMessage,
                                      final int httpStatus
    ) {
        ReasonPhraseCatalog catalog = EnglishReasonPhraseCatalog.INSTANCE;

        if (errorMessage == null && catalog.getReason(httpStatus, null) == null) {
            return String.format("HTTP status code: %s", httpStatus);
        } else if (errorMessage == null) {
            return catalog.getReason(httpStatus, null);
        }

        return String.format(
                "%s: %s (#%s)",
                errorMessage.getErrorCode(),
                StringUtils.join(errorMessage.getErrorMessages(), ", "),
                errorMessage.getCorrelationId());
    }
}
