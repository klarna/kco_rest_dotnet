package com.klarna.rest.api.checkout;

import com.klarna.rest.Transport;
import com.klarna.rest.api.ApiResponse;
import com.klarna.rest.model.checkout.Order;

public class Orders {
    String PATH = "/checkout/v3/orders";

    protected Transport transport;

    Orders(final Transport transport) {
        this.transport = transport;
    }

    public Order create(Order order) {
        ApiResponse response = transport.post(PATH, order);

        response.
    }

}
