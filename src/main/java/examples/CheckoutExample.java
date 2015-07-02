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

import com.klarna.rest.api.CheckoutOrder;
import com.klarna.rest.api.Client;
import com.klarna.rest.api.DefaultClient;
import com.klarna.rest.api.model.CheckoutOrderData;
import com.klarna.rest.api.model.MerchantUrls;
import com.klarna.rest.api.model.OrderLine;
import com.klarna.rest.api.model.emd.ExtraMerchantData;
import com.klarna.rest.api.model.emd.ExtraMerchantDataBody;
import com.klarna.rest.api.model.emd.PaymentHistoryFull;
import org.joda.time.DateTime;

import java.io.IOException;
import java.net.URI;
import java.util.ArrayList;
import java.util.List;

/**
 * Checkout resource examples.
 */
public class CheckoutExample {

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
            URI baseUrl = Client.EU_TEST_BASE_URL;

            Client client = DefaultClient.newInstance(merchantId, sharedSecret, baseUrl);

            CheckoutOrder checkout = client.newCheckoutOrder();

            final List<OrderLine> lines = new ArrayList<OrderLine>() {
                {
                    add(new OrderLine()
                            .setType("physical")
                            .setReference("123050")
                            .setName("Tomatoes")
                            .setQuantity(10L)
                            .setQuantityUnit("kg")
                            .setUnitPrice(600L)
                            .setTaxRate(2500)
                            .setTotalAmount(6000L)
                            .setTotalTaxAmount(1200L));
                    add(new OrderLine()
                            .setType("physical")
                            .setReference("543670")
                            .setName("Bananas")
                            .setQuantity(1L)
                            .setQuantityUnit("bag")
                            .setUnitPrice(5000L)
                            .setTaxRate(2500)
                            .setTotalAmount(4000L)
                            .setTotalDiscountAmount(1000L)
                            .setTotalTaxAmount(800L));
                }
            };

            final MerchantUrls urls = new MerchantUrls() {
                {
                    setTerms("http://www.merchant.com/toc");
                    setCheckout("http://www.merchant.com/checkout?klarna_order_id={checkout.order.id}");
                    setConfirmation("http://www.merchant.com/thank-you?klarna_order_id={checkout.order.id}");
                    setPush("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}");
                }
            };

            CheckoutOrderData data = new CheckoutOrderData() {
                {
                    setPurchaseCountry("gb");
                    setPurchaseCurrency("gbp");
                    setLocale("en-gb");
                    setOrderAmount(10000L);
                    setOrderTaxAmount(2000L);
                    setOrderLines(lines);
                    setMerchantUrls(urls);
                }
            };

            checkout.create(data);
            data = checkout.fetch();

            // Store checkout order id
            String orderID = data.getOrderId();
        }
    }

    /**
     * An example with an optional extra merchant data attachment.
     */
    public static class AttachmentExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         * @throws IOException If ExtraMerchantData could not be converted to
         *                     or created from an Attachment.
         */
        public static void main(final String[] args) throws IOException {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            URI baseUrl = Client.EU_TEST_BASE_URL;

            Client client = DefaultClient.newInstance(merchantId, sharedSecret, baseUrl);

            CheckoutOrder checkout = client.newCheckoutOrder();

            final List<OrderLine> lines = new ArrayList<OrderLine>() {
                {
                    add(new OrderLine()
                            .setType("physical")
                            .setReference("123050")
                            .setName("Tomatoes")
                            .setQuantity(10L)
                            .setQuantityUnit("kg")
                            .setUnitPrice(600L)
                            .setTaxRate(2500)
                            .setTotalAmount(6000L)
                            .setTotalTaxAmount(1200L));
                    add(new OrderLine()
                            .setType("physical")
                            .setReference("543670")
                            .setName("Bananas")
                            .setQuantity(1L)
                            .setQuantityUnit("bag")
                            .setUnitPrice(5000L)
                            .setTaxRate(2500)
                            .setTotalAmount(4000L)
                            .setTotalDiscountAmount(1000L)
                            .setTotalTaxAmount(800L));
                }
            };

            final MerchantUrls urls = new MerchantUrls() {
                {
                    setTerms("http://www.merchant.com/toc");
                    setCheckout("http://www.merchant.com/checkout?klarna_order_id={checkout.order.id}");
                    setConfirmation("http://www.merchant.com/thank-you?klarna_order_id={checkout.order.id}");
                    setPush("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}");
                }
            };

            final List<PaymentHistoryFull> paymentHistoryFulls = new ArrayList<PaymentHistoryFull>() {
                {
                    add(new PaymentHistoryFull()
                            .setUniqueAccountIdentifier("Test Testperson")
                            .setPaymentOption("card")
                            .setNumberPaidPurchases(1)
                            .setTotalAmountPaidPurchases(10000L)
                            .setDateOfLastPaidPurchase(new DateTime())
                            .setDateOfFirstPaidPurchase(new DateTime()));
                }
            };

            final ExtraMerchantDataBody extraMerchantDataBody = new ExtraMerchantDataBody()
                    .setPaymentHistoryFull(paymentHistoryFulls);

            final ExtraMerchantData extraMerchantData = new ExtraMerchantData()
                    .setBody(extraMerchantDataBody);

            CheckoutOrderData data = new CheckoutOrderData() {
                {
                    setPurchaseCountry("gb");
                    setPurchaseCurrency("gbp");
                    setLocale("en-gb");
                    setOrderAmount(10000L);
                    setOrderTaxAmount(2000L);
                    setOrderLines(lines);
                    setMerchantUrls(urls);
                    setAttachment(extraMerchantData.toAttachment());
                }
            };

            checkout.create(data);
            data = checkout.fetch();

            // Store checkout order id
            String orderID = data.getOrderId();
            ExtraMerchantData emd = ExtraMerchantData.fromAttachment(data.getAttachment());
        }
    }

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
            URI baseUrl = Client.EU_TEST_BASE_URL;
            String checkoutOrderID = "12345";

            Client client = DefaultClient.newInstance(merchantId, sharedSecret, baseUrl);

            CheckoutOrder checkout = client.newCheckoutOrder(checkoutOrderID);

            CheckoutOrderData data = checkout.fetch();
        }
    }

    /**
     * Updates a checkout order.
     */
    public static class UpdateExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            URI baseUrl = Client.EU_TEST_BASE_URL;
            String checkoutOrderID = "12345";

            Client client = DefaultClient.newInstance(merchantId, sharedSecret, baseUrl);

            CheckoutOrder checkout = client.newCheckoutOrder(checkoutOrderID);

            final List<OrderLine> lines = new ArrayList<OrderLine>() {
                {
                    add(new OrderLine()
                            .setType("physical")
                            .setReference("123050")
                            .setName("Tomatoes")
                            .setQuantity(10L)
                            .setQuantityUnit("kg")
                            .setUnitPrice(600L)
                            .setTaxRate(2500)
                            .setTotalAmount(6000L)
                            .setTotalTaxAmount(1200L));
                    add(new OrderLine()
                            .setType("physical")
                            .setReference("543670")
                            .setName("Bananas")
                            .setQuantity(1L)
                            .setQuantityUnit("bag")
                            .setUnitPrice(5000L)
                            .setTaxRate(2500)
                            .setTotalAmount(4000L)
                            .setTotalDiscountAmount(1000L)
                            .setTotalTaxAmount(800L));
                    add(new OrderLine()
                            .setType("shipping_fee")
                            .setName("Express delivery")
                            .setQuantity(1L)
                            .setUnitPrice(1000L)
                            .setTaxRate(2500)
                            .setTotalAmount(1000L)
                            .setTotalTaxAmount(200L));
                }
            };

            CheckoutOrderData data = new CheckoutOrderData() {
                {
                    setOrderLines(lines);
                    setOrderAmount(11000L);
                    setOrderTaxAmount(2200L);
                }
            };


            data = checkout.update(data);
        }
    }
}
