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

import com.fasterxml.jackson.annotation.JsonProperty;
import com.klarna.rest.Client;
import com.klarna.rest.api.checkout.CheckoutOrdersApi;
import com.klarna.rest.api.checkout.model.*;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.http_transport.HttpUrlConnectionTransport;
import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ApiResponse;
import io.swagger.annotations.ApiModelProperty;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * New Checkout resource with a custom Options examples.
 */

// Create our new Options model
class CustomCheckoutOptions extends CheckoutOptions {
    // Let's add a new Boolean field
    @JsonProperty("new_custom_option")
    private Boolean newCustomOption = false;

    // Some getter/setters
    public CustomCheckoutOptions newCustomOption(Boolean newCustomOption) {
        this.newCustomOption = newCustomOption;
        return this;
    }

    public Boolean isNewCustomOption() {
        return newCustomOption;
    }

    public void setNewCustomOption(Boolean newCustomOption) {
        this.newCustomOption = newCustomOption;
    }
}

// We need to create a new Checkout Order with our new custom options, setters and getters
class CustomCheckoutOrder extends CheckoutOrder {
    @JsonProperty("options") // IT MUST BE HERE with the property name you want to override.
    private CustomCheckoutOptions CustomCheckoutOptions;

    // Override the methods for getting/setting a new Custom options
    public CustomCheckoutOrder options(CustomCheckoutOptions options) {
        this.CustomCheckoutOptions = options;
        return this;
    }

    @ApiModelProperty(value = "Options for this purchase.")
    @Override
    public CustomCheckoutOptions getOptions() {
        return CustomCheckoutOptions;
    }

    public void setOptions(CustomCheckoutOptions options) {
        this.CustomCheckoutOptions = options;
    }
}

// The last step: Create an API resource, that will use our Custom Models
class CustomCheckoutOrdersApi extends CheckoutOrdersApi {
    public CustomCheckoutOrdersApi(final HttpTransport transport) {
        super(transport);
    }

    public CustomCheckoutOrder create(final CustomCheckoutOrder order) throws ApiException, IOException {
        final byte[] data = objectMapper.writeValueAsBytes(order);
        System.out.println(new String(data));  // Let's check if our new field was sent to the server

        final ApiResponse response = this.post(PATH, data);

        response.expectSuccessful()
                .expectStatusCode(Response.Status.CREATED)
                .expectContentType(MediaType.APPLICATION_JSON);

        return fromJson(response.getBody(), CustomCheckoutOrder.class);
    }
}

public class CustomOptionsExample {
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
            String username = "K123456_abcd12345";
            String password = "sharedSecret";
            String checkoutOrderID = "12345";

            HttpUrlConnectionTransport transport = new HttpUrlConnectionTransport(username, password, HttpTransport.EU_TEST_BASE_URL);
            CustomCheckoutOrdersApi checkoutOrdersApi = new CustomCheckoutOrdersApi(transport);

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

            CustomCheckoutOptions options = new CustomCheckoutOptions();
            options.setNewCustomOption(true); // Our new option
            options.setColorButton("#FF0000"); // General Checkout option

            CustomCheckoutOrder data = new CustomCheckoutOrder();
            data.purchaseCountry("GB");
            data.purchaseCurrency("GBP");
            data.locale("EN-GB");
            data.orderAmount(10000L);
            data.orderTaxAmount(2000L);
            data.orderLines(lines);
            data.merchantUrls(urls);
            data.options(options);    // Set our custom options

            try {
                CustomCheckoutOrder order = checkoutOrdersApi.create(data);
                System.out.println(order);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
