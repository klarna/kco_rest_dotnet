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
 *
 * File containing the ApiClientErrorTest class
 */

package com.klarna.api.ordermanagement.client;

import com.klarna.api.ordermanagement.client.model.request.UpdateCustomerDetails;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientHandlerException;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;
import org.apache.commons.httpclient.HttpStatus;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;

import static org.mockito.Matchers.eq;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class ApiClientErrorsTest {

    public static final String API_BASE_URL = "https://api.playground.klarna.com";

    @Mock
    private UpdateCustomerDetails updateCustomerDetails;

    @Test(expected = ApiException.class)
    public void noSuchOrderShouldRaiseException() {
        prepApiClientWith(HttpStatus.SC_NOT_FOUND).getOrder("44");
    }

    @Test(expected = ApiException.class)
    public void updateNotAllowedShouldRaiseException() {
        prepApiClientWith(HttpStatus.SC_FORBIDDEN).updateCustomerDetails("44", updateCustomerDetails);
    }

    @Test(expected = ApiException.class)
    public void httpErrorStatusShouldRaiseException() {
        prepApiClientWith(HttpStatus.SC_INTERNAL_SERVER_ERROR).getOrder("44");
    }

    @Test(expected = ClientHandlerException.class)
    public void unexpectedErrorShouldRaiseException() {
        prepApiClientWith(new ClientHandlerException()).getOrder("123");
    }

    private ApiClient prepApiClientWith(int status) {
        Client jerseyClient = new MockClientBuilder().setStatus(status).build();
        return new ApiClient(jerseyClient, API_BASE_URL);
    }

    private ApiClient prepApiClientWith(final Throwable throwable) {
        Client jerseyClient =
                new MockClientBuilder() {
                    @Override
                    protected void buildBuilder(WebResource.Builder builder, ClientResponse clientResponse) {
                        super.buildBuilder(builder, clientResponse);
                        when(builder.get(eq(ClientResponse.class))).thenThrow(throwable);
                    }
                }.build();
        return new ApiClient(jerseyClient, API_BASE_URL);
    }

}
