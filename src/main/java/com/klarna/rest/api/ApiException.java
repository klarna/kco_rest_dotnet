package com.klarna.rest.api;

import com.klarna.rest.model.ErrorMessage;
import org.apache.commons.lang3.StringUtils;

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
     * {@link com.klarna.rest.model.ErrorMessage#getCorrelationId()}
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
        return String.format(
                "%s: %s (#%s)",
                errorMessage.getErrorCode(),
                StringUtils.join(errorMessage.getErrorMessages(), ", "),
                errorMessage.getCorrelationId());
    }
}
