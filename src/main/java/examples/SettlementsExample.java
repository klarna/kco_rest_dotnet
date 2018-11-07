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

import com.klarna.rest.Client;
import com.klarna.rest.api.settlements.SettlementsPayoutsApi;
import com.klarna.rest.api.settlements.SettlementsReportsApi;
import com.klarna.rest.api.settlements.SettlementsTransactionsApi;
import com.klarna.rest.api.settlements.model.SettlementsPayout;
import com.klarna.rest.api.settlements.model.SettlementsPayoutCollection;
import com.klarna.rest.api.settlements.model.SettlementsPayoutSummary;
import com.klarna.rest.api.settlements.model.SettlementsTransactionCollection;
import com.klarna.rest.http_transport.HttpTransport;
import com.klarna.rest.http_transport.HttpUrlConnectionTransport;
import com.klarna.rest.model.ApiException;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.*;

/**
 * Settlements resource examples.
 */
public class SettlementsExample {
    static void writeToFile(String filename, byte[] data) throws FileNotFoundException, IOException {
        FileOutputStream file = new FileOutputStream(filename);
        file.write(data);
        file.close();
    }

    public static class PayoutFetchExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String paymentReference = "12345";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsPayoutsApi settlementsPayoutsApi = client.newSettlementsPayoutsApi();

            try {
                SettlementsPayout payout = settlementsPayoutsApi.getPayout(paymentReference);
                System.out.println(payout);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class PayoutFetchAllExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsPayoutsApi settlementsPayoutsApi = client.newSettlementsPayoutsApi();

            try {
                SettlementsPayoutCollection payouts = settlementsPayoutsApi.getAllPayouts();
                System.out.println(payouts);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class PayoutGetSummaryExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsPayoutsApi settlementsPayoutsApi = client.newSettlementsPayoutsApi();

            try {
                TimeZone tz = TimeZone.getTimeZone("UTC");
                DateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm'Z'");
                df.setTimeZone(tz);
                String startDate = df.format(new GregorianCalendar(2017, Calendar.JANUARY, 1).getTime());
                String endDate = df.format(new Date());

                HashMap<String, String> params = new HashMap<>();
                params.put("start_date", startDate);
                params.put("end_date", endDate);

                SettlementsPayoutSummary[] summary = settlementsPayoutsApi.getSummary(params);
                System.out.println(Arrays.toString(summary));

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class GetTransactionsExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsTransactionsApi transactionsApi = client.newSettlementsTransactionsApi();

            try {
                SettlementsTransactionCollection transactions = transactionsApi.getTransactions();
                System.out.println(transactions);

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class GetCSVSummaryExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsReportsApi settlementsReportsApi = client.newSettlementsReportsApi();

            try {
                TimeZone tz = TimeZone.getTimeZone("UTC");
                DateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm'Z'");
                df.setTimeZone(tz);
                String startDate = df.format(new GregorianCalendar(2017, Calendar.JANUARY, 1).getTime());
                String endDate = df.format(new Date());

                HashMap<String, String> params = new HashMap<>();
                params.put("start_date", startDate);
                params.put("end_date", endDate);

                byte[] csvReport = settlementsReportsApi.getCSVSummary(params);
                SettlementsExample.writeToFile("summary_report.csv", csvReport);
                System.out.println("Saved to summary_report.csv");

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class GetCSVPayoutReportExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String paymentReference = "12345";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsReportsApi settlementsReportsApi = client.newSettlementsReportsApi();

            try {
                HashMap<String, String> params = new HashMap<>();
                params.put("payment_reference", paymentReference);

                byte[] csvReport = settlementsReportsApi.getCSVPayoutReport(params);
                SettlementsExample.writeToFile("payout_report.csv", csvReport);
                System.out.println("Saved to payout_report.csv");

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class GetPDFSummaryExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsReportsApi settlementsReportsApi = client.newSettlementsReportsApi();

            try {
                TimeZone tz = TimeZone.getTimeZone("UTC");
                DateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm'Z'");
                df.setTimeZone(tz);
                String startDate = df.format(new GregorianCalendar(2017, Calendar.JANUARY, 1).getTime());
                String endDate = df.format(new Date());

                HashMap<String, String> params = new HashMap<>();
                params.put("start_date", startDate);
                params.put("end_date", endDate);

                byte[] csvReport = settlementsReportsApi.getPDFSummary(params);
                SettlementsExample.writeToFile("summary_report.pdf", csvReport);
                System.out.println("Saved to summary_report.pdf");

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }

    public static class GetPDFPayoutReportExample {
        /**
         * Runs the example code.
         *
         * @param args Command line arguments
         */
        public static void main(final String[] args) {
            String merchantId = "0";
            String sharedSecret = "sharedSecret";
            String paymentReference = "12345";

            Client client = new Client(merchantId, sharedSecret, HttpTransport.EU_TEST_BASE_URL);
            SettlementsReportsApi settlementsReportsApi = client.newSettlementsReportsApi();

            try {
                HashMap<String, String> params = new HashMap<>();
                params.put("payment_reference", paymentReference);

                byte[] csvReport = settlementsReportsApi.getPDFPayoutsSummaryReport(params);
                SettlementsExample.writeToFile("payout_summary_report.pdf", csvReport);
                System.out.println("Saved to payout_summary_report.pdf");

            } catch (IOException e) {
                System.out.println("Connection problem: " + e.getMessage());
            } catch (ApiException e) {
                System.out.println("API issue: " + e.getMessage());
            }
        }
    }
}
