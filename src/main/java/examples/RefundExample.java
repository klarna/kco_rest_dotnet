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

import com.klarna.rest.api.Client;
import com.klarna.rest.api.DefaultClient;
import com.klarna.rest.api.model.OrderLine;
import com.klarna.rest.api.model.Refund;

import java.net.URI;
import java.util.ArrayList;
import java.util.List;

/**
 * Refund resource examples.
 */
public class RefundExample {

    /**
     * Creates a refund.
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
            String orderId = "12345";

            Client client = DefaultClient.newInstance(merchantId, sharedSecret, baseUrl);

            com.klarna.rest.api.Refund refund = client.newRefund(orderId);

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
                }
            };

            Refund data = new Refund() {
                {
                    setRefundedAmount(3000L);
                    setDescription("Refunding half the tomatoes");
                    setOrderLines(lines);
                }
            };

            refund.create(data);
        }
    }

    /**
     * Fetches a refund.
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
            String orderId = "12345";
            String refundId = "54321";

            Client client = DefaultClient.newInstance(merchantId, sharedSecret, baseUrl);

            com.klarna.rest.api.Refund refund = client.newRefund(orderId, refundId);

            Refund data = refund.fetch();
        }
    }
}
