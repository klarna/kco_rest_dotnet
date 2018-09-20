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

import com.klarna.rest.api.ApiException;
import com.klarna.rest.api.ProtocolException;
import com.klarna.rest.api.checkout.OrdersApi;

import com.klarna.rest.model.checkout.MerchantUrls;
import com.klarna.rest.model.checkout.Order;
import com.klarna.rest.model.checkout.OrderLine;

import java.io.IOException;
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

            Transport transport = new HttpUrlConnectionTransport();
            OrdersApi ordersApi = new OrdersApi(transport);

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

            final MerchantUrls urls = new MerchantUrls() {
                {
                    setTerms("http://www.merchant.com/toc");
                    setCheckout("http://www.merchant.com/checkout?klarna_order_id={checkout.order.id}");
                    setConfirmation("http://www.merchant.com/thank-you?klarna_order_id={checkout.order.id}");
                    setPush("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}");
                }
            };

            Order data = new Order() {
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

            try {
                Order order = ordersApi.create(data);
                System.out.println("ID: " + order.getOrderId());
                System.out.println("Status: " + order.getStatus());
                System.out.println("HTML Snippet: " + order.getHtmlSnippet());
            } catch (IOException | ProtocolException | ApiException e) {
                System.out.println(e.getMessage());
            }
        }
    }
}