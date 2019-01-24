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

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.DeserializationContext;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.JsonDeserializer;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.module.SimpleModule;
import com.klarna.rest.Client;
import com.klarna.rest.api.checkout.CheckoutOrdersApi;
import com.klarna.rest.api.checkout.model.CheckoutMerchantUrls;
import com.klarna.rest.api.checkout.model.CheckoutOrder;
import com.klarna.rest.api.checkout.model.CheckoutOrderLine;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.model.ApiException;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * Checkout resource examples.
 */
public class ObjectMapperExample {
    /**
     * Fetches a checkout order.
     */
    public static class CustomMapperExample {
        /**
         * Creates a checkout order with a Custom Mapper.
         */
        public static class CustomObjectMapperExample {

            /**
             * Runs the example code.
             *
             * @param args Command line arguments
             */
            public static void main(final String[] args) {
                // Custom Json Parser implementation
                class CheckoutOrderJsonDeserializer extends JsonDeserializer<CheckoutOrder> {
                    @Override
                    public CheckoutOrder deserialize(JsonParser jp, DeserializationContext ctxt) throws IOException, JsonProcessingException {
                        System.out.println("Hello from Custom Parser");
                        System.out.println(jp.readValueAsTree().toString());

                        return new CheckoutOrder();
                    }
                }
                SimpleModule module = new SimpleModule();
                module.addDeserializer(CheckoutOrder.class, new CheckoutOrderJsonDeserializer());

                class CustomMapper extends ObjectMapper {
                    CustomMapper() {
                        this.findAndRegisterModules();
                        this.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
                        this.setSerializationInclusion(JsonInclude.Include.NON_NULL);
                    }
                }
                // /Custom Json Parser implementation

                String username = "K123456_abcd12345";
                String password = "sharedSecret";

                Client client = new Client(username, password, HttpTransport.EU_TEST_BASE_URL);
                CheckoutOrdersApi checkoutOrdersApi = client.newCheckoutOrdersApi();

                // Use our custom Object Mapper
                CustomMapper mapper = new CustomMapper();
                mapper.registerModule(module);
                checkoutOrdersApi.setObjectMapper(mapper);

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
    }
}
