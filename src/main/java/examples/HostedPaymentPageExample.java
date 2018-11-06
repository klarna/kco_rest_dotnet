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

import com.klarna.rest.http_transport.HttpUrlConnectionTransport;
import com.klarna.rest.http_transport.Transport;

import com.klarna.rest.model.ApiException;

import com.klarna.rest.api.hosted_payment_page.HPPSessionsApi;
import com.klarna.rest.api.hosted_payment_page.model.*;

import java.io.IOException;

/**
 * Hosted Payment Page resource examples.
 */
public class HostedPaymentPageExample {
    /**
     * Creates new HPP Session.
     */
    public static class CreateHPPSessionExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String sessionId = "sessionId";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            HPPSessionsApi HPPSessionsApi = new HPPSessionsApi(transport);

            try {
                HPPSessionCreationRequestV1 request = new HPPSessionCreationRequestV1()
                    .merchantUrls(new HPPMerchantUrlsV1()
                        .cancel("https://example.com/cancel")
                        .failure("https://example.com/fail")
                        .privacyPolicy("https://example.com/privacy_policy")
                        .success("https://example.com/success?token={{authorization_token}}")
                        .terms("https://example.com/terms"))
                    .options(new HPPOptionsV1()
                        .logoUrl("https://example.com/logo.jpg")
                        .pageTitle("Complete your purchase")
                        .paymentMethodCategory(HPPOptionsV1.PaymentMethodCategoryEnum.PAY_LATER)
                        .purchaseType(HPPOptionsV1.PurchaseTypeEnum.BUY))
                    .paymentSessionUrl("https://api.klarna.com/payments/v1/sessions/" + sessionId);

                HPPSessionCreationResponseV1 session = HPPSessionsApi.create(request);
                System.out.println(session);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class DistributeLinkToHPPSessionExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String sessionId = "sessionId";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            HPPSessionsApi HPPSessionsApi = new HPPSessionsApi(transport);

            try {
                HPPDistributionRequestV1 request = new HPPDistributionRequestV1()
                    .contactInformation(new HPPDistributionContactV1()
                        .email("test@example.com")
                        .phone("07000212345")
                        .phoneCountry("SE"))
                    .method(HPPDistributionRequestV1.MethodEnum.SMS)
                    .template(HPPDistributionRequestV1.TemplateEnum.INSTORE_PURCHASE);

                HPPSessionsApi.distributeLink(sessionId, request);
                System.out.println("The session link has been distributed");

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class GetHPPSessionExample {

        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String sessionId = "sessionId";

            Transport transport = new HttpUrlConnectionTransport(merchantId, sharedSecret, Transport.EU_TEST_BASE_URL);
            HPPSessionsApi HPPSessionsApi = new HPPSessionsApi(transport);

            try {
                HPPSessionResponseV1 session = HPPSessionsApi.fetch(sessionId);
                System.out.println(session);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
