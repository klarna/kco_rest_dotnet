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

import com.klarna.rest.HttpUrlConnectionTransport;
import com.klarna.rest.Transport;

import com.klarna.rest.ApiException;
import com.klarna.rest.ContentTypeException;
import com.klarna.rest.ProtocolException;
import com.klarna.rest.api.ordermanagement.OrdersApi;
import com.klarna.rest.model.order_management.*;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * Checkout resource examples.
 */
public class OrderManagementExample {

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
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                Order order = ordersApi.get(orderId);
                System.out.println(order);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Releases remaining authorization example.
     */
    public static class ReleaseRemainingAuthorizationExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                ordersApi.releaseRemainingAuthorization(orderId);
                System.out.println("Remaining authorised amount has been released");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Extend authorization time example.
     */
    public static class ExtendAuthorizationTimeExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                ordersApi.extendAuthorizationTime(orderId);
                System.out.println("The expiry time of an order has been extend");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Update customer addresses.
     */
    public static class UpdateCustomerAddressesExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                final Address address = new Address(){
                    {
                        setEmail("user@example.com");
                        setPhone("57-3895734");
                        setGivenName("John");
                        setFamilyName("Smith");
                    }
                };
                ordersApi.updateCustomerAddresses(orderId, new UpdateConsumer(){
                    {
                        setBillingAddress(address);
                        setShippingAddress(address);
                    }
                });
                System.out.println("Customer details have been updated");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Cancel order.
     */
    public static class CancelOrderExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                ordersApi.cancelOrder(orderId);
                System.out.println("Order has been cancelled");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Update merchant references.
     */
    public static class updateMerchantReferencesExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                ordersApi.updateMerchantReferences(orderId, new UpdateMerchantReferences(){
                    {
                        setMerchantReference1("15632423");
                        setMerchantReference2("special order");
                    }
                });
                System.out.println("Merchant references have been updated");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Acknowledge order.
     */
    public static class acknowledgeOrderExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

            try {
                ordersApi.acknowledgeOrder(orderId);
                System.out.println("Order has been acknowledged");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Set new order amount and order lines.
     */
    public static class setOrderAmountAndOrderLines {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            OrdersApi ordersApi = new OrdersApi(transport);

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
                                setTaxRate(2500);
                                setTotalAmount(6000L);
                                setTotalTaxAmount(1200L);
                            }
                        });
                    }};
                final UpdateAuthorization orderData = new UpdateAuthorization(){
                    {
                        setDescription("Removed bad bananas");
                        setOrderAmount(6000L);
                        setOrderLines(lines);
                    }
                };
                ordersApi.setOrderAmountAndOrderLines(orderId, orderData);
                System.out.println("New order amount and order lines have been set");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
