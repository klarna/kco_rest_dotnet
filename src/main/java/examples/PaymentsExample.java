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

package examples;

import com.klarna.rest.*;
import com.klarna.rest.api.payments.OrdersApi;
import com.klarna.rest.api.payments.SessionsApi;
import com.klarna.rest.model.payments.*;

import java.io.IOException;
import java.util.ArrayList;
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
                final List<OrderLine> lines = new ArrayList<OrderLine>() {
                    {
                        add(new OrderLine() {
                            {
                                setType("physical");
                                setReference("123050");
                                setName("Tomatoes");
                                setQuantity(10L);
                                setQuantityUnit("kg");
                                setUnitPrice(600L);
                                setTaxRate(2500L);
                                setTotalAmount(6000L);
                                setTotalTaxAmount(1200L);
                            }
                        });
                        add(new OrderLine() {
                            {
                                setType("physical");
                                setReference("543670");
                                setName("Bananas");
                                setQuantity(1L);
                                setQuantityUnit("bag");
                                setUnitPrice(5000L);
                                setTaxRate(2500L);
                                setTotalAmount(4000L);
                                setTotalDiscountAmount(1000L);
                                setTotalTaxAmount(800L);
                            }
                        });

                    }
                };

                Session sessionRequest = new Session(){
                    {
                        setPurchaseCountry("gb");
                        setPurchaseCurrency("gbp");
                        setLocale("en-gb");
                        setOrderAmount(10000L);
                        setOrderTaxAmount(2000L);
                        setOrderLines(lines);
                    }
                };
                MerchantSession session = sessionsApi.create(sessionRequest);
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
                Session session = sessionsApi.fetch(sessionId);
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
                final List<OrderLine> lines = new ArrayList<OrderLine>() {
                    {
                        add(new OrderLine() {
                            {
                                setType("physical");
                                setReference("543670");
                                setName("New updated bananas");
                                setQuantity(1L);
                                setQuantityUnit("bag");
                                setUnitPrice(5000L);
                                setTaxRate(2500L);
                                setTotalAmount(4000L);
                                setTotalDiscountAmount(1000L);
                                setTotalTaxAmount(800L);
                            }
                        });

                    }
                };

                Session sessionRequest = new Session(){
                    {
                        setPurchaseCountry("gb");
                        setPurchaseCurrency("gbp");
                        setLocale("en-gb");
                        setOrderAmount(4000L);
                        setOrderTaxAmount(800L);
                        setOrderLines(lines);
                    }
                };
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
                final Address address = new Address(){
                    {
                        setGivenName("John");
                        setFamilyName("Doe");
                        setEmail("johndoe@example.com");
                        setTitle("Mr");
                        setStreetAddress("13 New Burlington St");
                        setStreetAddress2("Apt 214");
                        setPostalCode("W13 3BG");
                        setCity("London");
                        setPhone("01895808221");
                        setCountry("GB");
                    }
                };

                final List<OrderLine> lines = new ArrayList<OrderLine>() {
                    {
                        add(new OrderLine() {
                            {
                                setType("physical");
                                setReference("123050");
                                setName("Tomatoes");
                                setQuantity(10L);
                                setQuantityUnit("kg");
                                setUnitPrice(600L);
                                setTaxRate(2500L);
                                setTotalAmount(6000L);
                                setTotalTaxAmount(1200L);
                            }
                        });
                        add(new OrderLine() {
                            {
                                setType("physical");
                                setReference("543670");
                                setName("Bananas");
                                setQuantity(1L);
                                setQuantityUnit("bag");
                                setUnitPrice(5000L);
                                setTaxRate(2500L);
                                setTotalAmount(4000L);
                                setTotalDiscountAmount(1000L);
                                setTotalTaxAmount(800L);
                            }
                        });

                    }
                };

                CreateOrderRequest request = new CreateOrderRequest(){
                    {
                        setBillingAddress(address);
                        setShippingAddress(address);
                        setPurchaseCountry("GB");
                        setPurchaseCurrency("GBP");
                        setLocale("en-GB");
                        setOrderAmount(10000L);
                        setOrderTaxAmount(2000L);
                        setOrderLines(lines);
                    }
                };

                Order order = ordersApi.create(authorizationToken, request);
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
                final Address address = new Address(){
                    {
                        setGivenName("John");
                        setFamilyName("Doe");
                        setEmail("johndoe@example.com");
                        setTitle("Mr");
                        setStreetAddress("13 New Burlington St");
                        setStreetAddress2("Apt 214");
                        setPostalCode("W13 3BG");
                        setCity("London");
                        setPhone("01895808221");
                        setCountry("GB");
                    }
                };
                CustomerTokenCreationRequest request = new CustomerTokenCreationRequest(){
                    {
                        setPurchaseCountry("GB");
                        setPurchaseCurrency("GBP");
                        setLocale("en-GB");
                        setBillingAddress(address);
                        setCustomer(new Customer(){
                            {
                                setDateOfBirth("1970-01-01");
                                setGender("male");
                            }
                        });
                        setDescription("For testing purposes");
                        setIntendedUse(IntendedUseEnum.SUBSCRIPTION);
                    }
                };

                CustomerTokenCreationResponse response = ordersApi.generateToken(authorizationToken, request);
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
