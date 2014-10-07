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
 * File containing the ApiClient class
 */

package com.klarna.api.ordermanagement.client;

import com.klarna.api.ordermanagement.client.model.CapturedOrder;
import com.klarna.api.ordermanagement.client.model.ErrorMessage;
import com.klarna.api.ordermanagement.client.model.Order;
import com.klarna.api.ordermanagement.client.model.request.*;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;
import org.apache.commons.lang3.Validate;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.UriBuilder;
import java.net.URI;

import static java.lang.String.format;
import static javax.ws.rs.core.HttpHeaders.USER_AGENT;
import static javax.ws.rs.core.MediaType.APPLICATION_JSON;
import static javax.ws.rs.core.Response.Status.*;

/**
 * Client for using the Order Management API.
 *
 * <p/>In the event of an exception {@link ApiException} the error message
 * ({@link com.klarna.api.ordermanagement.client.model.ErrorMessage}) contains
 * a correlation_id identifying this particular transaction in Klarna's systems.
 * The correlation id may be requested by merchant support to facilitate support inquiries.
 *
 * <p/>All amounts and prices have an absolute maximum of 100 million in the minor currency unit,
 * in other words 1 million in the major unit. The real limit is likely to be lower on a case-by-case basis.
 */
public class ApiClient {

    public static final String VERSION = "1.0.0";
    public static final String BASE_URL_SUFFIX = "ordermanagement/v1/orders";

    private final UserAgent userAgent = UserAgent.withDefaultFields();

    private final Client client;
    private final String apiBaseUrl;

    /**
     * Create an API client for using the Order Management API.
     * @param jerseyClient the client for HTTP requests.
     * @param apiBaseUrl The API base URL (https://api.playground.klarna.com or https://api.klarna.com).
     */
    public ApiClient(Client jerseyClient, String apiBaseUrl) {
        Validate.notNull(jerseyClient, "Jersey client may not be null!");
        Validate.notBlank(apiBaseUrl, "Api base url may not be empty!");
        this.client = jerseyClient;
        this.apiBaseUrl = apiBaseUrl.endsWith("/") ? apiBaseUrl : apiBaseUrl + "/";
    }

    /**
     * Get the UserAgent for adding additional user agent fields
     * (see {@link UserAgent#add(com.klarna.api.ordermanagement.client.UserAgent.Field)}).
     */
    public UserAgent getUserAgent() {
        return userAgent;
    }

    /**
     * Acknowledge authorized order. Merchants will receive the order confirmation push until the order
     * has been acknowledged.
     *
     * @param orderId The order id.
     */
    public void acknowledgeOrder(String orderId) {
        post(uri(format("/%s/acknowledge", orderId))).andExpect(NO_CONTENT);
    }

    /**
     * Get the current state of an order.
     *
     * @return The {@link com.klarna.api.ordermanagement.client.model.Order}.
     */
    public Order getOrder(String orderId) {
        return get(uri(format("/%s", orderId))).andExpect(OK).getEntity(Order.class);
    }

    /**
     * Update the total order amount of an order, subject to a new customer credit check.
     * The updated amount can optionally be accompanied by a descriptive text and new order lines.
     * Supplied order lines will replace the existing order lines.
     * <p/>
     * If no order lines are supplied in the call, the existing order lines will be deleted.
     * The updated 'order_amount' must not be negative, nor less than current 'captured_amount'.
     * Currency is inferred from the original order.
     *
     * @param orderId       The order id.
     * @param authorization The update request.
     */
    public void updateAuthorization(String orderId, UpdateAuthorization authorization) {
        patch(uri(format("/%s/authorization", orderId)), authorization).andExpect(NO_CONTENT);
    }

    /**
     * Extend the order's authorization by default period according to merchant contract.
     *
     * @param orderId The order id.
     */
    public void extendAuthorizationTime(String orderId) {
        post(uri(format("/%s/extend-authorization-time", orderId))).andExpect(NO_CONTENT);
    }

    /**
     * Update one or both merchant references. Only the provided reference(s) in will be updated. To clear a
     * reference, set its value to "" (empty string).
     *
     * @param orderId                  The order id.
     * @param updateMerchantReferences The merchant references update.
     */
    public void updateMerchantReferences(String orderId, UpdateMerchantReferences updateMerchantReferences) {
        patch(uri(format("/%s/merchant-references", orderId)), updateMerchantReferences).andExpect(NO_CONTENT);
    }

    /**
     * Update billing and/or shipping address for an order, subject to customer credit check.
     * Fields can be updated independently. To clear a newField, set its value to "" (empty string).
     *
     * @param update  The consumer detail update.
     *                Mandatory fields can not be cleared,
     *                see {@link com.klarna.api.ordermanagement.client.model.Address}.
     * @param orderId The order id.
     */
    public void updateCustomerDetails(String orderId, UpdateCustomerDetails update) {
        patch(uri(format("/%s/customer-details", orderId)), update).andExpect(NO_CONTENT);
    }

    /**
     * Cancel an authorized order. For a cancellation to be successful, there must be no captures on the order.
     * The authorized amount will be released and no further updates to the order will be allowed.
     *
     * @param orderId The order id.
     */
    public void cancelOrder(String orderId) {
        post(uri(format("/%s/cancel", orderId))).andExpect(NO_CONTENT);
    }

    /**
     * Capture the supplied amount. Use this call when fulfillment is completed,
     * e.g. physical goods are being shipped to the customer. Shipping address is inherited from the order.
     * <p/>
     * Use
     * {@link #updateCustomerDetails(String, String, com.klarna.api.ordermanagement.client.model.request.UpdateCustomerDetails)}
     * below to update the shipping address of an individual capture.
     * <p/>
     * The capture amount can optionally be accompanied by a descriptive text and order lines for the captured items.
     *
     * @param orderId The order id.
     * @param capture The capture.
     * @return The URI of the created captured resource.
     */
    public CaptureURI captureOrder(String orderId, Capture capture) {
        return new CaptureURI(post(uri(format("/%s/captures", orderId)), capture).andExpect(CREATED).getLocation());
    }

    /**
     * Retrieve a capture of an order.
     *
     * @param orderId   The order id.
     * @param captureId The capture id.
     * @return The capture.
     */
    public CapturedOrder getCapture(String orderId, String captureId) {
        return get(uri(format("/%s/captures/%s", orderId, captureId))).andExpect(OK).getEntity(CapturedOrder.class);
    }

    /**
     * Retrieve a capture of an order.
     *
     * @param captureURI The capture resource uri.
     * @return The capture.
     */
    public CapturedOrder getCapture(CaptureURI captureURI) {
        return get(captureURI.getUri()).andExpect(OK).getEntity(CapturedOrder.class);
    }

    /**
     * Add new shipping info to a capture.
     *
     * @param orderId   The order id.
     * @param captureId The capture id.
     * @param update    The shipping information update.
     */
    public void addShippingInfo(String orderId, String captureId, AddShippingInfo update) {
        post(uri(format("/%s/captures/%s/shipping-info", orderId, captureId)), update).andExpect(NO_CONTENT);
    }

    /**
     * Add new shipping info to a capture.
     *
     * @param captureURI The capture resource uri.
     * @param update     The shipping information update.
     */
    public void addShippingInfo(CaptureURI captureURI, AddShippingInfo update) {
        post(captureURI.getUri(), update).andExpect(NO_CONTENT);
    }

    /**
     * Update the billing address for a capture. Shipping address can not be updated.
     * Fields can be updated independently. To clear a newField, set its value to "" (empty string). Mandatory fields
     * can not be cleared, see {@link com.klarna.api.ordermanagement.client.model.Address}.
     *
     * @param orderId   The order id.
     * @param captureId The capture id.
     * @param update    The consumer details update.
     */
    public void updateCustomerDetails(String orderId, String captureId, UpdateCustomerDetails update) {
        patch(uri(format("/%s/captures/%s/customer-details", orderId, captureId)), update).andExpect(NO_CONTENT);
    }

    /**
     * Update the billing address for a capture. Shipping address can not be updated.
     * Fields can be updated independently. To clear a newField, set its value to "" (empty string). Mandatory fields
     * can not be cleared, see {@link com.klarna.api.ordermanagement.client.model.Address}.
     *
     * @param captureURI The capture resource uri.
     * @param update     The consumer details update.
     */
    public void updateCustomerDetails(CaptureURI captureURI, UpdateCustomerDetails update) {
        patch(captureURI.getUri(), update).andExpect(NO_CONTENT);
    }

    /**
     * Trigger a new send out of customer communication. Typically a new invoice, for a capture.
     *
     * @param orderId   The order id.
     * @param captureId The capture id.
     */
    public void triggerSendOut(String orderId, String captureId) {
        post(uri(format("/%s/captures/%s/trigger-send-out", orderId, captureId))).andExpect(NO_CONTENT);
    }

    /**
     * Trigger a new send out of customer communication. Typically a new invoice, for a capture.
     *
     * @param captureURI The capture resource uri.
     */
    public void triggerSendOut(CaptureURI captureURI) {
        post(captureURI.getUri()).andExpect(NO_CONTENT);
    }

    /**
     * Refund an amount of a captured order. The refunded amount will be credited to the customer.
     * The refunded amount must not be higher than 'captured_amount'. The refunded amount can optionally be
     * accompanied by a descriptive text and order lines.
     *
     * @param orderId The order id.
     * @param refund  The refund request.
     */
    public void refundOrder(String orderId, Refund refund) {
        post(uri(format("/%s/refunds", orderId)), refund).andExpect(NO_CONTENT);
    }

    /**
     * Release the remaining authorization for an order.
     *
     * @param orderId The order id.
     */
    public void releaseRemainingAuthorization(String orderId) {
        post(uri(format("/%s/release-remaining-authorization", orderId))).andExpect(NO_CONTENT);
    }

    private ApiResponse get(URI uri) {
        return new ApiResponse(execute(uri).get(ClientResponse.class));
    }

    private ApiResponse post(URI uri) {
        return post(uri, null);
    }

    private ApiResponse post(URI uri, Object requestEntity) {
        return new ApiResponse(execute(uri).post(ClientResponse.class, requestEntity));
    }

    private ApiResponse patch(URI uri, Object requestEntity) {
        return new ApiResponse(execute(uri).method("PATCH", ClientResponse.class, requestEntity));
    }

    private WebResource.Builder execute(URI uri) {
        return client.resource(uri).type(APPLICATION_JSON).header(USER_AGENT, userAgent.toString());
    }

    private URI uri(String path) {
        return UriBuilder.fromUri(apiBaseUrl).path(BASE_URL_SUFFIX + path).build();
    }

    private static class ApiResponse {

        private final ClientResponse clientResponse;

        private ApiResponse(ClientResponse clientResponse) {
            this.clientResponse = clientResponse;
        }

        private ClientResponse andExpect(Response.Status expectedResponseStatus) {
            if (expectedResponseStatus.getStatusCode() != clientResponse.getStatus()) {
                throw new ApiException(
                        clientResponse.getStatus(),
                        expectedResponseStatus.getStatusCode(),
                        clientResponse.getEntity(ErrorMessage.class));
            }
            return clientResponse;
        }
    }

}
