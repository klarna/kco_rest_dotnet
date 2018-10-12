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

package com.klarna.rest.api.checkout;

import com.klarna.rest.Transport;
import com.klarna.rest.ApiException;
import com.klarna.rest.ApiResponse;
import com.klarna.rest.ContentTypeException;
import com.klarna.rest.ProtocolException;
import com.klarna.rest.api.BaseApi;

import com.klarna.rest.model.checkout.Order;

import javax.ws.rs.core.Response.Status;
import javax.ws.rs.core.MediaType;

import java.io.IOException;

/**
 * Checkout API: Orders resource.
 * The checkout API is used to create a checkout with Klarna and update the checkout order during the purchase.
 *
 * As soon as the purchase is completed the order should be read and handled using the
 * {@link com.klarna.rest.api.order_management.OrdersApi Order Management API}
 */
public class OrdersApi extends BaseApi {
    protected String PATH = "/checkout/v3/orders";

    public OrdersApi(final Transport transport) {
        super(transport);
    }

    /**
     * Use this API call to create a new order.
     * The response body will contain the full order object and the location header will contain the
     * URL at which the newly created order can be found.
     *
     * @see examples.CheckoutExample.CreateExample
     *
     * @param order Order data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Order create(Order order) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = this.post(PATH, data);

        response.validator()
                .expectStatusCode(Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    /**
     * Use this API call to read an order from Klarna.
     *
     * <p>
     *  Note that orders should only be read from the checkout API until the order is completed.
     *  Completed orders should be read using the order management API
     * </p>
     *
     * @see examples.CheckoutExample.FetchExample
     *
     * @param orderId Order ID
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Order fetch(String orderId) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + '/' + orderId);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    /**
     * Use this API call to read an order from Klarna using Location header got from the API server.
     *
     * @see examples.CheckoutExample.FetchExample
     *
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Order fetch() throws ApiException, ProtocolException, ContentTypeException, IOException {
        if (this.location == null) {
            throw new IOException("Unknown location");
        }
        final ApiResponse response = this.get(this.location);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }

    /**
     * To update an order simply provide an object with the properties you want to update.
     * Properties not provided in the request will stay the same.
     *
     * <p>
     *  Please note: an order can only be updated when the status is <b>checkout_incomplete</b>
     * </p>
     *
     * @see examples.CheckoutExample.UpdateExample
     *
     * @param orderId Order ID
     * @param order Order data
     * @return server response
     * @throws ApiException if API server returned non-20x HTTP CODE and response contains
     *                      a <a href="https://developers.klarna.com/api/#errors">Error</a>
     * @throws ProtocolException if HTTP status code was non-20x or did not match expected code.
     * @throws ContentTypeException if content type does not match the expectation
     * @throws IOException if an error occurred connecting to the server
     */
    public Order update(String orderId, Order order) throws ApiException, ProtocolException, ContentTypeException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        final ApiResponse response = this.post(PATH + '/' + orderId, data);

        response.validator()
                .expectStatusCode(Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), Order.class);
    }
}
