package examples;

import com.klarna.rest.*;
import com.klarna.rest.api.customer_token.TokensApi;
import com.klarna.rest.api.customer_token.model.*;


import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class CustomerTokenExample {
    public static class ReadTokenDetailsExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String customerToken = "customerToken";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            TokensApi tokensApi = new TokensApi(transport, customerToken);

            try {
                TokenCustomerTokenV1 token = tokensApi.fetchDetails();
                System.out.println(token);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class CreateOrderExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String customerToken = "customerToken";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            TokensApi tokensApi = new TokensApi(transport, customerToken);

            try {
                final TokenAddress address = new TokenAddress()
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

                final List<TokenOrderLine> lines = Arrays.asList(
                    new TokenOrderLine()
                        .type("physical")
                        .reference("123050")
                        .name("Tomatoes")
                        .quantity(10L)
                        .quantityUnit("kg")
                        .unitPrice(600L)
                        .taxRate(2500L)
                        .totalAmount(6000L)
                        .totalTaxAmount(1200L),
                    new TokenOrderLine()
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

                TokenCustomerTokenOrder request = new TokenCustomerTokenOrder()
                    .shippingAddress(address)
                    .purchaseCurrency("gbp")
                    .orderAmount(10000L)
                    .orderTaxAmount(2000L)
                    .orderLines(lines);

                TokenOrder order = tokensApi.createOrder(request);
                System.out.println(order);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
