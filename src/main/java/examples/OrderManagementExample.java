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

import com.klarna.rest.HttpUrlConnectionTransport;
import com.klarna.rest.Transport;

import com.klarna.rest.ApiException;
import com.klarna.rest.ContentTypeException;
import com.klarna.rest.ProtocolException;
import com.klarna.rest.api.order_management.OrdersApi;
import com.klarna.rest.api.order_management.RefundsApi;
import com.klarna.rest.api.order_management.model.*;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Checkout resource examples.
 */
public class OrderManagementExample {

    /**
     * Fetches a checkout order.
     */
    public static class FetchOrderExample {

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
                OrderManagementOrder order = ordersApi.fetch(orderId);
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
                final OrderManagementAddress address = new OrderManagementAddress()
                    .email("user@example.com")
                    .phone("57-3895734")
                    .givenName("John")
                    .familyName("Smith");

                ordersApi.updateCustomerAddresses(orderId, new OrderManagementUpdateConsumer()
                    .billingAddress(address)
                    .shippingAddress(address)
                );

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
    public static class UpdateMerchantReferencesExample {

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
                ordersApi.updateMerchantReferences(orderId, new OrderManagementUpdateMerchantReferences()
                    .merchantReference1("15632423")
                    .merchantReference2("special order")
                );

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
    public static class AcknowledgeOrderExample {

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
                final List<OrderManagementOrderLine> lines = Arrays.asList(
                    new OrderManagementOrderLine()
                        .type("physical")
                        .reference("123050")
                        .name("Tomatoes")
                        .quantity(10L)
                        .quantityUnit("kg")
                        .unitPrice(600L)
                        .taxRate(2500)
                        .totalAmount(6000L)
                        .totalTaxAmount(1200L)
                );

                final OrderManagementUpdateAuthorization orderData = new OrderManagementUpdateAuthorization()
                    .description("Removed bad bananas")
                    .orderAmount(6000L)
                    .orderLines(lines);

                ordersApi.setOrderAmountAndOrderLines(orderId, orderData);
                System.out.println("New order amount and order lines have been set");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    /**
     * Create a new order refund.
     */
    public static class CreateRefundExample {

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
            RefundsApi refundsApi = new RefundsApi(transport, orderId);

            try {
                final List<OrderManagementOrderLine> lines = Arrays.asList(
                    new OrderManagementOrderLine()
                        .type("physical")
                        .reference("123050")
                        .name("Tomatoes")
                        .quantity(5L)
                        .quantityUnit("kg")
                        .unitPrice(600L)
                        .taxRate(2500)
                        .totalAmount(3000L)
                        .totalTaxAmount(750L)
                );

                final OrderManagementRefundObject refund = new OrderManagementRefundObject()
                    .refundedAmount(3000L)
                    .description("Refunding half the tomatoes")
                    .orderLines(lines);

                refundsApi.create(refund);
                System.out.println("Refund has been created");

                // The refund ID will be sent back in the Header.
                String refundId = refundsApi.getLastResponse().getHeader("Refund-Id").get(0);
                System.out.println("Refund ID: " + refundId);

                // Also we got back a new Location header, so we can just use it by calling fetch method
                OrderManagementRefund createdRefund = refundsApi.fetch();
                System.out.println(createdRefund);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class FetchRefundExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String orderId = "12345";
            String refundId = "34567";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            RefundsApi refundsApi = new RefundsApi(transport, orderId);

            try {
                OrderManagementRefund refund = refundsApi.fetch(refundId);
                System.out.println(refund);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
