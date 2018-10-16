package examples;

import com.klarna.rest.*;
import com.klarna.rest.api.merchant_card_service.VirtualCreditCardApi;
import com.klarna.rest.model.merchant_card_service.SettlementRequest;
import com.klarna.rest.model.merchant_card_service.SettlementResponse;

import java.io.IOException;

public class MerchantCardServiceExample {
    public static class RetrieveExistingSettlementExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            final String merchantId = "0";
            final String sharedSecret = "sharedSecret";
            final String settlementId = "12345";
            final String keyId = "abcde";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            VirtualCreditCardApi vccApi = new VirtualCreditCardApi(transport);

            try {
                SettlementResponse settlement = vccApi.retrieveExistingSettlement(settlementId, keyId);
                System.out.println(settlement);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class RetriveOrdersSettlementsExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            final String merchantId = "0";
            final String sharedSecret = "sharedSecret";
            final String orderId = "12345";
            final String keyId = "abcde";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            VirtualCreditCardApi vccApi = new VirtualCreditCardApi(transport);

            try {
                SettlementResponse settlement = vccApi.retrieveSettledOrderSettlement(orderId, keyId);
                System.out.println(settlement);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class CreateSettlementExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            final String merchantId = "0";
            final String sharedSecret = "sharedSecret";
            final String orderId = "12345";
            final String keyId = "abcde";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            VirtualCreditCardApi vccApi = new VirtualCreditCardApi(transport);

            try {
                SettlementRequest request = new SettlementRequest(){
                    {
                        setKeyId(keyId);
                        setOrderId(orderId);
                    }
                };
                SettlementResponse settlement = vccApi.createSettlement(request);
                System.out.println(settlement);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
