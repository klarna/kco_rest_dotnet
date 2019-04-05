/*
 * Copyright 2019 Klarna AB
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
import com.klarna.rest.api.checkout.model.CheckoutOrderLine;
import com.klarna.rest.api.hosted_payment_page.HPPSessionsApi;
import com.klarna.rest.api.hosted_payment_page.model.*;
import com.klarna.rest.api.instant_shopping.InstantShoppingButtonKeysApi;
import com.klarna.rest.api.instant_shopping.model.*;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.model.ApiException;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * Instant Shopping resource examples.
 */
public class InstantShoppingExample {
    /**
     * Creates new Instant Shopping Button.
     */
    public static class CreateButtonKeyExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String username = "K123456_abcd12345";
            String password = "sharedSecret";

            Client client = new Client(username, password, HttpTransport.EU_TEST_BASE_URL);
            InstantShoppingButtonKeysApi api = client.newInstantShoppingButtonKeysApi();

            try {
                final List<InstantShoppingOrderLineV1> lines = Arrays.asList(
                    new InstantShoppingOrderLineV1()
                            .type(InstantShoppingOrderLineV1.TypeEnum.PHYSICAL)
                            .reference("123050")
                            .name("Tomatoes")
                            .quantity(10L)
                            .quantityUnit("kg")
                            .unitPrice(600L)
                            .taxRate(0L)
                            .totalAmount(6000L)
                            .totalTaxAmount(0L)
                    );

                InstantShoppingButtonSetupOptionsV1 options = new InstantShoppingButtonSetupOptionsV1()
                        .merchantUrls(new InstantShoppingButtonSetupOptionsV1MerchantUrls()
                                .placeOrder("https://example.com/place")
                                .push("https://example.com/push")
                                .confirmation("https://example.com/confirm")
                                .terms("https://example.com/terms")
                                .notification("https://example.com/notification")
                                .update("https://example.com/update"))
                        .purchaseCountry("DE")
                        .purchaseCurrency("EUR")
                        .locale("de-DE")
                        .orderAmount(6000L)
                        .orderTaxAmount(0L)
                        .orderLines(lines)
                        .shippingOptions(Arrays.asList(new InstantShoppingShippingOptionV1()
                                .id("dhl")
                                .name("DHL Express")
                                .price(10L)
                                .taxAmount(0L)
                                .taxRate(0L)
                                .shippingMethod(InstantShoppingShippingOptionV1.ShippingMethodEnum.DHL_PACKSTATION)
                        ));
                InstantShoppingButtonSetupOptionsV1 button = api.createButtonKey(options);

                System.out.println("Button key: " + button.getButtonKey());

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class UpdateButtonKeyExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String username = "K123456_abcd12345";
            String password = "sharedSecret";
            String buttonKey = "button-key-123";

            Client client = new Client(username, password, HttpTransport.EU_TEST_BASE_URL);
            InstantShoppingButtonKeysApi api = client.newInstantShoppingButtonKeysApi();

            try {
                final List<InstantShoppingOrderLineV1> lines = Arrays.asList(
                        new InstantShoppingOrderLineV1()
                                .type(InstantShoppingOrderLineV1.TypeEnum.PHYSICAL)
                                .reference("123050")
                                .name("Tomatoes")
                                .quantity(10L)
                                .quantityUnit("kg")
                                .unitPrice(600L)
                                .taxRate(0L)
                                .totalAmount(6000L)
                                .totalTaxAmount(0L)
                );

                InstantShoppingButtonSetupOptionsV1 options = new InstantShoppingButtonSetupOptionsV1()
                        .merchantUrls(new InstantShoppingButtonSetupOptionsV1MerchantUrls()
                                .placeOrder("https://example.com/place")
                                .push("https://example.com/push")
                                .confirmation("https://example.com/confirm")
                                .terms("https://example.com/terms")
                                .notification("https://example.com/notification")
                                .update("https://example.com/update"))
                        .purchaseCountry("DE")
                        .purchaseCurrency("EUR")
                        .locale("de-DE")
                        .orderAmount(6000L)
                        .orderTaxAmount(0L)
                        .orderLines(lines)
                        .shippingOptions(Arrays.asList(new InstantShoppingShippingOptionV1()
                                .id("dhl")
                                .name("DHL Express")
                                .price(10L)
                                .taxAmount(0L)
                                .taxRate(0L)
                                .shippingMethod(InstantShoppingShippingOptionV1.ShippingMethodEnum.DHL_PACKSTATION)
                        ));
                InstantShoppingButtonSetupOptionsV1 button = api.updateButtonKey(buttonKey, options);
                System.out.println(button);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class FetchButtonKeyExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String username = "K123456_abcd12345";
            String password = "sharedSecret";
            String buttonKey = "button-key-123";

            Client client = new Client(username, password, HttpTransport.EU_TEST_BASE_URL);
            InstantShoppingButtonKeysApi api = client.newInstantShoppingButtonKeysApi();

            try {
                InstantShoppingButtonSetupOptionsV1 button = api.fetchButtonKeyOptions(buttonKey);
                System.out.println(button);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
