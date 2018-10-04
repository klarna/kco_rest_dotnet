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
 */

package com.klarna.rest.api;

import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.ClientResponse.Status;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InOrder;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.MediaType;
import java.net.URI;

import static javax.ws.rs.core.HttpHeaders.LOCATION;
import static javax.ws.rs.core.MediaType.APPLICATION_JSON_TYPE;
import static org.mockito.Mockito.*;

/**
 * Test cases for the Capture resource.
 */
@RunWith(MockitoJUnitRunner.class)
public class DefaultRefundTest extends ResourceTestCase {

    private static final String REFUND_ID = "23456";

    private DefaultRefund refund;

    @Test
    public void testCreate() {
        URI orderUrl = Client.EU_TEST_BASE_URL.resolve(DefaultOrder.PATH + "/12345");
        URI location = orderUrl.resolve(DefaultRefund.PATH + "/" + REFUND_ID);

        // Constructor
        when(root.path(DefaultRefund.PATH))
                .thenReturn(root);

        // BaseResource.post
        com.klarna.rest.api.model.Refund data = new com.klarna.rest.api.model.Refund();
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.post(ClientResponse.class, data))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.CREATED);

        // DefaultCheckoutOrder.create
        when(response.getStatus())
                .thenReturn(Status.CREATED.getStatusCode());
        when(response.getHeaders())
                .thenReturn(headers);
        when(headers.getFirst(LOCATION))
                .thenReturn(location.toString());
        when(root.uri(location))
                .thenReturn(root);

        // BaseResource.getLocation
        when(root.getURI())
                .thenReturn(location);

        refund = new DefaultRefund(root);
        refund.create(data);

        assertEquals(location, refund.getLocation());

        // Verify that the right URL was used
        verify(root).path(DefaultRefund.PATH);

        // Verify that the header response was set
        verify(root).uri(location);

        // Verify data sent
        verify(builder).post(ClientResponse.class, data);
    }

    @Test
    public void testFetch() {
        // Constructor
        when(root.path(DefaultRefund.PATH))
                .thenReturn(root);

        // BaseResource.setWebResource
        when(root.path(LOCATION))
                .thenReturn(root);

        // BaseResource.get
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.accept(APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.get(ClientResponse.class))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.OK);

        // DefaultCheckoutOrder.fetch
        com.klarna.rest.api.model.Refund responseData = new com.klarna.rest.api.model.Refund();
        when(response.getStatus())
                .thenReturn(Status.OK.getStatusCode());
        when(response.getEntity(com.klarna.rest.api.model.Refund.class))
                .thenReturn(responseData);

        refund = new DefaultRefund(root);
        refund.setWebResource(refund.getWebResource().path(LOCATION));

        com.klarna.rest.api.model.Refund data = refund.fetch();

        assertSame(responseData, data);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultRefund.PATH);
        ordered.verify(root).path(LOCATION);
    }
}
