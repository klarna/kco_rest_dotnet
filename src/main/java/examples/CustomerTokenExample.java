package examples;

import com.klarna.rest.*;
import com.klarna.rest.api.customer_token.TokensApi;
import com.klarna.rest.model.customer_token.*;

import java.io.IOException;
import java.util.ArrayList;
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
                CustomerTokenV1 token = tokensApi.fetchDetails();
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

                CustomerTokenOrder request = new CustomerTokenOrder(){
                    {
                        setBillingAddress(address);
                        setShippingAddress(address);
                        setPurchaseCurrency("gbp");
                        setOrderAmount(10000L);
                        setOrderTaxAmount(2000L);
                        setOrderLines(lines);
                    }
                };
                Order order = tokensApi.createOrder(request);
                System.out.println(order);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
