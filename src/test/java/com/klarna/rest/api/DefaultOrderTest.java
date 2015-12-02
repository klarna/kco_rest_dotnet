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

import com.klarna.rest.api.model.OrderData;
import com.klarna.rest.api.model.Refund;
import com.klarna.rest.api.model.request.UpdateAuthorization;
import com.klarna.rest.api.model.request.UpdateCustomerDetails;
import com.klarna.rest.api.model.request.UpdateMerchantReferences;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.ClientResponse.Status;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InOrder;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.MediaType;

import static javax.ws.rs.core.MediaType.APPLICATION_JSON_TYPE;
import static org.mockito.Mockito.*;

/**
 * Test cases for the Order resource class.
 */
@RunWith(MockitoJUnitRunner.class)
public class DefaultOrderTest extends ResourceTestCase {

    private static final String ORDER_ID = "12345";

    private DefaultOrder order;

    @Test
    public void testFetch() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
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

        // DefaultOrder.fetch
        OrderData responseData = new OrderData();
        when(response.getStatus())
                .thenReturn(Status.OK.getStatusCode());
        when(response.getEntity(OrderData.class))
                .thenReturn(responseData);

        order = new DefaultOrder(root, ORDER_ID);

        OrderData data = order.fetch();

        assertSame(responseData, data);

        // Verify request method
        verify(builder).get(ClientResponse.class);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
    }

    @Test
    public void testAcknowledge() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.post
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.post(ClientResponse.class, null))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.acknowledge
        when(root.path("acknowledge"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.acknowledge();

        // Verify request method
        verify(builder).post(ClientResponse.class, null);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("acknowledge");
    }

    @Test
    public void testCancel() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.post
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.post(ClientResponse.class, null))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.cancel
        when(root.path("cancel"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.cancel();

        // Verify request method
        verify(builder).post(ClientResponse.class, null);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("cancel");
    }

    @Test
    public void testExtendAuthorizationTime() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.post
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.post(ClientResponse.class, null))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.extendAuthorizationTime
        when(root.path("extend-authorization-time"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.extendAuthorizationTime();

        // Verify request method
        verify(builder).post(ClientResponse.class, null);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("extend-authorization-time");
    }

    @Test
    public void testReleaseRemainingAuthorization() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.post
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.post(ClientResponse.class, null))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.releaseRemainingAuthorization
        when(root.path("release-remaining-authorization"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.releaseRemainingAuthorization();

        // Verify request method
        verify(builder).post(ClientResponse.class, null);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("release-remaining-authorization");
    }

    @Test
    public void testRefund() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.post
        Refund data = new Refund();
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.post(ClientResponse.class, data))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.refund
        when(root.path("refunds"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.refund(data);

        // Verify request method
        verify(builder).post(ClientResponse.class, data);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("refunds");
    }

    @Test
    public void testRefund201() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.post
        Refund data = new Refund();
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.post(ClientResponse.class, data))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.CREATED);

        // DefaultOrder.refund
        when(root.path("refunds"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.CREATED.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.refund(data);

        // Verify request method
        verify(builder).post(ClientResponse.class, data);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("refunds");
    }

    @Test
    public void testUpdateCustomerDetails() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.post
        UpdateCustomerDetails data = new UpdateCustomerDetails();
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.method("PATCH", ClientResponse.class, data))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.updateCustomerDetails
        when(root.path("customer-details"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.updateCustomerDetails(data);

        // Verify request method
        verify(builder).method("PATCH", ClientResponse.class, data);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("customer-details");
    }

    @Test
    public void testUpdateMerchantReferences() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.patch
        UpdateMerchantReferences data = new UpdateMerchantReferences();
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.method("PATCH", ClientResponse.class, data))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.updateMerchantReferences
        when(root.path("merchant-references"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.updateMerchantReferences(data);

        // Verify request method
        verify(builder).method("PATCH", ClientResponse.class, data);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("merchant-references");
    }

    @Test
    public void testUpdateAuthorization() {
        // Constructor
        when(root.path(DefaultOrder.PATH))
                .thenReturn(root);
        when(root.path(ORDER_ID))
                .thenReturn(root);

        // BaseResource.patch
        UpdateAuthorization data = new UpdateAuthorization();
        when(root.getRequestBuilder())
                .thenReturn(builder);
        when(builder.type(MediaType.APPLICATION_JSON_TYPE))
                .thenReturn(builder);
        when(builder.method("PATCH", ClientResponse.class, data))
                .thenReturn(response);
        when(response.getStatusInfo())
                .thenReturn(Status.NO_CONTENT);

        // DefaultOrder.updateMerchantReferences
        when(root.path("authorization"))
                .thenReturn(root);
        when(response.getStatus())
                .thenReturn(Status.NO_CONTENT.getStatusCode());

        order = new DefaultOrder(root, ORDER_ID);
        order.updateAuthorization(data);

        // Verify request method
        verify(builder).method("PATCH", ClientResponse.class, data);

        // Verify that the right URL was used
        InOrder ordered = inOrder(root);
        ordered.verify(root).path(DefaultOrder.PATH);
        ordered.verify(root).path(ORDER_ID);
        ordered.verify(root).path("authorization");
    }
}
