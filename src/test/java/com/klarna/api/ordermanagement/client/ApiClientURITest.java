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
 * File containing the ApiClientURITest class
 */

package com.klarna.api.ordermanagement.client;

import com.klarna.api.ordermanagement.client.model.request.*;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.WebResource;
import org.apache.commons.httpclient.HttpStatus;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.ArgumentCaptor;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;

import java.net.URI;

import static org.hamcrest.core.Is.is;
import static org.junit.Assert.assertThat;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class ApiClientURITest {

    public static final String API_BASE_URL = "https://api.playground.klarna.com";

    @Mock
    private UpdateAuthorization updateAuthorization;

    @Mock
    private UpdateMerchantReferences updateMerchantReferences;

    @Mock
    private UpdateCustomerDetails updateCustomerDetails;

    @Mock
    private Capture capture;

    @Mock
    private AddShippingInfo addShippingInfo;

    @Mock
    private Refund refund;

    @Test
    public void verifyGetOrderURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(HttpStatus.SC_OK, uriCaptor).getOrder("123");
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123");
    }

    @Test
    public void verifyAcknowledgeOrderURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).acknowledgeOrder("123");
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/acknowledge");
    }

    @Test
    public void verifyUpdateAuthorizationURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).updateAuthorization("123", updateAuthorization);
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/authorization");
    }

    @Test
    public void verifyExtendAuthorizationTimeURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).extendAuthorizationTime("123");
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/extend-authorization-time");
    }

    @Test
    public void verifyUpdateMerchantReferencesURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).updateMerchantReferences("123", updateMerchantReferences);
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/merchant-references");
    }

    @Test
    public void verifyUpdateCustomerDetailsURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).updateCustomerDetails("123", updateCustomerDetails);
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/customer-details");
    }

    @Test
    public void verifyCancelURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).cancelOrder("123");
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/cancel");
    }

    @Test
    public void verifyCaptureURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(HttpStatus.SC_CREATED, uriCaptor).captureOrder("123", capture);
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/captures");
    }

    @Test
    public void verifyGetCaptureURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(HttpStatus.SC_OK, uriCaptor).getCapture("123", "78");
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/captures/78");
    }

    @Test
    public void verifyAddShippingInfoToCaptureURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).addShippingInfo("123", "78", addShippingInfo);
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/captures/78/shipping-info");
    }

    @Test
    public void verifyUpdateCustomerDetailsOnCaptureURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).updateCustomerDetails("123", "78", updateCustomerDetails);
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/captures/78/customer-details");
    }

    @Test
    public void verifyTriggerSendOutURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).triggerSendOut("123", "78");
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/captures/78/trigger-send-out");
    }

    @Test
    public void verifyRefundURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).refundOrder("123", refund);
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/refunds");
    }

    @Test
    public void verifyReleaseRemainingAuthorizationURI() {
        ArgumentCaptor<URI> uriCaptor = getUriArgumentCaptor();
        prepApiClientWith(uriCaptor).releaseRemainingAuthorization("123");
        assertAgainstRelativeURI(uriCaptor, "/ordermanagement/v1/orders/123/release-remaining-authorization");
    }

    private ApiClient prepApiClientWith(ArgumentCaptor<URI> uriCaptor) {
        return prepApiClientWith(HttpStatus.SC_NO_CONTENT, uriCaptor);
    }

    private ApiClient prepApiClientWith(int status, ArgumentCaptor<URI> uriCaptor) {
        Client jerseyClient = builderWithURICaptor(uriCaptor).setStatus(status).build();
        return new ApiClient(jerseyClient, API_BASE_URL);
    }

    private void assertAgainstRelativeURI(ArgumentCaptor<URI> uriCaptor, String expectedRelativeUri) {
        assertThat(uriCaptor.getValue().toString(), is(API_BASE_URL + expectedRelativeUri));
    }

    private ArgumentCaptor<URI> getUriArgumentCaptor() {
        return ArgumentCaptor.forClass(URI.class);
    }

    private MockClientBuilder builderWithURICaptor(final ArgumentCaptor<URI> uriCaptor) {
        return new MockClientBuilder() {
            @Override
            protected void buildClient(Client client, WebResource webResource) {
                when(client.resource(uriCaptor.capture())).thenReturn(webResource);
            }
        };
    }

}
