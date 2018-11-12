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

package com.klarna.rest.model;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

/**
 * An error message received through the Klarna API.
 *
 * In the event of an error the message contains a {@link #getCorrelationId()}
 * identifying this particular transaction in Klarna's systems.
 *
 * The correlation id may be requested by merchant support to
 * facilitate support inquiries.
 */
public class ErrorMessage {

    /**
     * The error code.
     */
    @JsonProperty("error_code")
    private String errorCode;

    /**
     * List of error messages.
     */
    @JsonProperty("error_messages")
    private List<String> errorMessages;

    /**
     * Correlation id.
     *
     * The correlation id may be requested by merchant support
     * to facilitate support inquiries.
     */
    @JsonProperty("correlation_id")
    private String correlationId;

    /**
     * Service version.
     *
     * The correlation id may be requested by merchant support
     * to facilitate support inquiries.
     */
    @JsonProperty("service_version")
    private String serviceVersion;

    /**
     * Gets the error code.
     *
     * @return Error code
     */
    public String getErrorCode() {
        return this.errorCode;
    }

    /**
     * Gets the error messages.
     *
     * @return Error messages
     */
    public List<String> getErrorMessages() {
        return this.errorMessages;
    }

    /**
     * Gets the correlation id.
     *
     * @return Correlation id
     */
    public String getCorrelationId() {
        return this.correlationId;
    }

    /**
     * Gets the service version.
     *
     * @return Service version
     */
    public String getServiceVersion() {
        return this.serviceVersion;
    }
}