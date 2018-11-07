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

package com.klarna.rest;

import com.klarna.rest.api.checkout.CheckoutOrdersApi;
import com.klarna.rest.api.customer_token.TokensApi;
import com.klarna.rest.api.hosted_payment_page.HPPSessionsApi;
import com.klarna.rest.api.merchant_card_service.VirtualCreditCardApi;
import com.klarna.rest.api.order_management.OrderManagementCapturesApi;
import com.klarna.rest.api.order_management.OrderManagementOrdersApi;
import com.klarna.rest.api.order_management.OrderManagementRefundsApi;
import com.klarna.rest.api.payments.PaymentsOrdersApi;
import com.klarna.rest.api.payments.PaymentsSessionsApi;
import com.klarna.rest.api.settlements.SettlementsPayoutsApi;
import com.klarna.rest.api.settlements.SettlementsReportsApi;
import com.klarna.rest.api.settlements.SettlementsTransactionsApi;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.http_transport.HttpUrlConnectionTransport;

import java.net.URI;

public class Client {
    protected final HttpTransport transport;

    public Client(final String merchantId,
                  final String sharedSecret,
                  final URI baseUri) {

        this.transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, baseUri);
    }

    public Client(final HttpTransport transport) {
        this.transport = transport;
    }

    public CheckoutOrdersApi newCheckoutOrderApi() {
        return new CheckoutOrdersApi(transport);
    }

    public TokensApi newTokenApi(final String customerToken) {
        return new TokensApi(transport, customerToken);
    }

    public HPPSessionsApi newHPPSessionsApi() {
        return new HPPSessionsApi(transport);
    }

    public VirtualCreditCardApi newVirtualCreditCardApi() {
        return new VirtualCreditCardApi(transport);
    }

    public OrderManagementCapturesApi newOrderManagementCapturesApi(final String orderId) {
        return new OrderManagementCapturesApi(transport, orderId);
    }

    public OrderManagementOrdersApi newOrderManagementOrdersApi() {
        return new OrderManagementOrdersApi(transport);
    }

    public OrderManagementRefundsApi newOrderManagementRefundsApi(final String orderId) {
        return new OrderManagementRefundsApi(transport, orderId);
    }

    public PaymentsOrdersApi newPaymentsOrdersApi() {
        return new PaymentsOrdersApi(transport);
    }

    public PaymentsSessionsApi newPaymentsSessionsApi() {
        return new PaymentsSessionsApi(transport);
    }

    public SettlementsPayoutsApi newSettlementsPayoutsApi() {
        return new SettlementsPayoutsApi(transport);
    }

    public SettlementsTransactionsApi newSettlementsTransactionsApi() {
        return new SettlementsTransactionsApi(transport);
    }

    public SettlementsReportsApi newSettlementsReportsApi() {
        return new SettlementsReportsApi(transport);
    }
}
