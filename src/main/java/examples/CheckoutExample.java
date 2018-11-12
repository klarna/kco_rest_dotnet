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

package examples;

import com.klarna.rest.Client;
import com.klarna.rest.api.checkout.CheckoutOrdersApi;
import com.klarna.rest.http_transport.HttpTransport;

import com.klarna.rest.model.ApiException;

import com.klarna.rest.api.checkout.model.CheckoutAddress;
import com.klarna.rest.api.checkout.model.CheckoutMerchantUrls;
import com.klarna.rest.api.checkout.model.CheckoutOrder;
import com.klarna.rest.api.checkout.model.CheckoutOrderLine;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * Checkout resource examples.
 */
public class CheckoutExample {

    /**
     * Fetches a checkout order.
     */
    public static class FetchExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String checkoutOrderID = "12345";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            CheckoutOrdersApi checkoutOrdersApi = client.newCheckoutOrdersApi();

            try {
                CheckoutOrder order = checkoutOrdersApi.fetch(checkoutOrderID);
                System.out.println(order);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Creates a checkout order.
     */
    public static class CreateExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            CheckoutOrdersApi checkoutOrdersApi = client.newCheckoutOrdersApi();

            final List<CheckoutOrderLine> lines = Arrays.asList(
                new CheckoutOrderLine()
                    .type("physical")
                    .reference("123050")
                    .name("Tomatoes")
                    .quantity(10L)
                    .quantityUnit("kg")
                    .unitPrice(600L)
                    .taxRate(2500L)
                    .totalAmount(6000L)
                    .totalTaxAmount(1200L),

                new CheckoutOrderLine()
                    .type("physical")
                    .reference("543670")
                    .name("Bananas")
                    .quantity(1L)
                    .quantityUnit("bag")
                    .unitPrice(5000L)
                    .taxRate(2500L)
                    .totalAmount(4000L)
                    .totalDiscountAmount(1000L)
                    .totalTaxAmount(800L)
            );

            final CheckoutMerchantUrls urls = new CheckoutMerchantUrls()
                .terms("http://www.example.com/toc")
                .checkout("http://www.example.com/checkout?klarna_order_id={checkout.order.id}")
                .confirmation("http://www.example.com/thank-you?klarna_order_id={checkout.order.id}")
                .push("http://www.example.com/create_order?klarna_order_id={checkout.order.id}");

            CheckoutOrder data = new CheckoutOrder()
                .purchaseCountry("GB")
                .purchaseCurrency("GBP")
                .locale("EN-GB")
                .orderAmount(10000L)
                .orderTaxAmount(2000L)
                .orderLines(lines)
                .merchantUrls(urls);

            try {
                CheckoutOrder order = checkoutOrdersApi.create(data);
                System.out.println(order);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println(e.getMessage());
            }
        }
    }

    /**
     * Update a checkout order.
     */
    public static class UpdateExample {

        /**
         * Runs the example code. .s new address.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String checkoutOrderID = "12345";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            CheckoutOrdersApi checkoutOrdersApi = client.newCheckoutOrdersApi();

            final CheckoutAddress address = new CheckoutAddress()
                .title("Mr")
                .country("GB")
                .city("London")
                .givenName("John")
                .familyName("Smith")
                .streetAddress("1st Avenue");

            final List<CheckoutOrderLine> lines = Arrays.asList(
                new CheckoutOrderLine()
                    .type("physical")
                    .reference("123050")
                    .name("Tomatoes")
                    .quantity(10L)
                    .quantityUnit("kg")
                    .unitPrice(600L)
                    .taxRate(2500L)
                    .totalAmount(6000L)
                    .totalTaxAmount(1200L),

                new CheckoutOrderLine()
                    .type("physical")
                    .reference("543670")
                    .name("Bananas")
                    .quantity(1L)
                    .quantityUnit("bag")
                    .unitPrice(5000L)
                    .taxRate(2500L)
                    .totalAmount(4000L)
                    .totalDiscountAmount(1000L)
                    .totalTaxAmount(800L)
            );
            CheckoutOrder data = new CheckoutOrder()
                .billingAddress(address)
                .shippingAddress(address)
                .orderAmount(10000L)
                .orderTaxAmount(2000L)
                .orderLines(lines);

            try {
                CheckoutOrder order = checkoutOrdersApi.update(checkoutOrderID, data);
                System.out.println(order);
            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
