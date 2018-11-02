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

import com.klarna.rest.*;
import com.klarna.rest.api.payments.OrdersApi;
import com.klarna.rest.api.payments.SessionsApi;
import com.klarna.rest.api.payments.model.*;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * Payments resource examples.
 */
public class PaymentsExample {
    /**
     * Creates new Credit Session.
     */
    public static class CreateNewCreditSessionExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            SessionsApi sessionsApi = new SessionsApi(transport);

            try {
                final List<PaymentsOrderLine> lines = Arrays.asList(
                    new PaymentsOrderLine()
                        .type("physical")
                        .reference("123050")
                        .name("Tomatoes")
                        .quantity(10L)
                        .quantityUnit("kg")
                        .unitPrice(600L)
                        .taxRate(2500L)
                        .totalAmount(6000L)
                        .totalTaxAmount(1200L),

                    new PaymentsOrderLine()
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

                PaymentsSession sessionRequest = new PaymentsSession()
                    .purchaseCountry("gb")
                    .purchaseCurrency("gbp")
                    .locale("en-gb")
                    .orderAmount(10000L)
                    .orderTaxAmount(2000L)
                    .orderLines(lines);

                PaymentsMerchantSession session = sessionsApi.create(sessionRequest);
                System.out.println(session);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Reads an existing Credit Session.
     */
    public static class ReadCreditSessionExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String sessionId = "sessionId";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            SessionsApi sessionsApi = new SessionsApi(transport);

            try {
                PaymentsSession session = sessionsApi.fetch(sessionId);
                System.out.println(session);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Updates an existing Credit Session.
     */
    public static class UpdateExistingCreditSessionExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String sessionId = "sessionId";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            SessionsApi sessionsApi = new SessionsApi(transport);

            try {
                final List<PaymentsOrderLine> lines = Arrays.asList(
                    new PaymentsOrderLine()
                        .type("physical")
                        .reference("543670")
                        .name("New updated bananas")
                        .quantity(1L)
                        .quantityUnit("bag")
                        .unitPrice(5000L)
                        .taxRate(2500L)
                        .totalAmount(4000L)
                        .totalDiscountAmount(1000L)
                        .totalTaxAmount(800L)
                );

                PaymentsSession sessionRequest = new PaymentsSession()
                    .purchaseCountry("gb")
                    .purchaseCurrency("gbp")
                    .locale("en-gb")
                    .orderAmount(4000L)
                    .orderTaxAmount(800L)
                    .orderLines(lines);

                sessionsApi.update(sessionId, sessionRequest);
                System.out.println("Order has been updated");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Creates a new Order.
     */
    public static class CreateOrderExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String authorizationToken = "authToken";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                final PaymentsAddress address = new PaymentsAddress()
                    .givenName("John")
                    .familyName("Doe")
                    .email("johndoe@example.com")
                    .title("Mr")
                    .streetAddress("13 New Burlington St")
                    .streetAddress2("Apt 214")
                    .postalCode("W13 3BG")
                    .city("London")
                    .phone("01895808221")
                    .country("GB");

                final List<PaymentsOrderLine> lines = Arrays.asList(
                    new PaymentsOrderLine()
                        .type("physical")
                        .reference("123050")
                        .name("Tomatoes")
                        .quantity(10L)
                        .quantityUnit("kg")
                        .unitPrice(600L)
                        .taxRate(2500L)
                        .totalAmount(6000L)
                        .totalTaxAmount(1200L),

                    new PaymentsOrderLine()
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

                PaymentsCreateOrderRequest request = new PaymentsCreateOrderRequest()
                    .billingAddress(address)
                    .shippingAddress(address)
                    .purchaseCountry("GB")
                    .purchaseCurrency("GBP")
                    .locale("en-GB")
                    .orderAmount(10000L)
                    .orderTaxAmount(2000L)
                    .orderLines(lines);

                PaymentsOrder order = ordersApi.create(authorizationToken, request);
                System.out.println(order);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Generates a new Customer Token.
     */
    public static class GenerateCustomerTokenExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String authorizationToken = "authToken";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                final PaymentsAddress address = new PaymentsAddress()
                    .givenName("John")
                    .familyName("Doe")
                    .email("johndoe@example.com")
                    .title("Mr")
                    .streetAddress("13 New Burlington St")
                    .streetAddress2("Apt 214")
                    .postalCode("W13 3BG")
                    .city("London")
                    .phone("01895808221")
                    .country("GB");

                PaymentsCustomerTokenCreationRequest request = new PaymentsCustomerTokenCreationRequest()
                    .purchaseCountry("GB")
                    .purchaseCurrency("GBP")
                    .locale("en-GB")
                    .billingAddress(address)
                    .customer(new PaymentsCustomer()
                        .dateOfBirth("1970-01-01")
                        .gender("male")
                    )
                    .description("For testing purposes")
                    .intendedUse(PaymentsCustomerTokenCreationRequest.IntendedUseEnum.SUBSCRIPTION);

                PaymentsCustomerTokenCreationResponse response = ordersApi.generateToken(authorizationToken, request);
                System.out.println(response);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Cancels an existing authorization.
     */
    public static class CancelExistingAuthorizationExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String authorizationToken = "authToken";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                ordersApi.cancelAuthorization(authorizationToken);
                System.out.println("Authorization has been cancelled");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
