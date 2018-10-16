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

import com.klarna.rest.HttpUrlConnectionTransport;
import com.klarna.rest.Transport;

import com.klarna.rest.ApiException;
import com.klarna.rest.ContentTypeException;
import com.klarna.rest.ProtocolException;

import com.klarna.rest.api.hosted_payment_page.SessionsApi;
import com.klarna.rest.model.hosted_payment_page.*;

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
            SessionsApi sessionsApi = new SessionsApi(transport);

            try {
                SessionRequestV1 request = new SessionRequestV1();
                request.setMerchantUrls(new MerchantUrlsV1() {
                    {
                        setCancel("https://example.com/cancel");
                        setFailure("https://example.com/fail");
                        setPrivacyPolicy("https://example.com/privacy_policy");
                        setSuccess("https://example.com/success?token={{authorization_token}}");
                        setTerms("https://example.com/terms");
                    }
                });
                request.setOptions(new OptionsV1() {
                    {
                        setLogoUrl("https://example.com/logo.jpg");
                        setPageTitle("Complete your purchase");
                        setPaymentMethodCategory(PaymentMethodCategoryEnum.PAY_LATER);
                        setPurchaseType(PurchaseTypeEnum.BUY);
                    }
                });
                request.setPaymentSessionUrl("https://api.klarna.com/payments/v1/sessions/" + sessionId);

                SessionResponseV1 session = sessionsApi.create(request);
                System.out.println(session);

            } catch (IOException | ProtocolException | ContentTypeException e) {
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
            SessionsApi sessionsApi = new SessionsApi(transport);

            try {
                DistributionRequestV1 request = new DistributionRequestV1(){
                    {
                        setContactInformation(new DistributionContactV1(){
                            {
                                setEmail("test@example.com");
                                setPhone("07000212345");
                                setPhoneCountry("SE");
                            }
                        });
                        setMethod(MethodEnum.SMS);
                        setTemplate(TemplateEnum.INSTORE_PURCHASE);
                    }
                };
                sessionsApi.distributeLink(sessionId, request);
                System.out.println("The session link has been distributed");

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class GetHPPSessionStatusExample {

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
            SessionsApi sessionsApi = new SessionsApi(transport);

            try {
                SessionStatusResponseV1 status = sessionsApi.getStatus(sessionId);
                System.out.println(status);

            } catch (IOException | ProtocolException | ContentTypeException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
