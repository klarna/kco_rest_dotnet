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
 * File containing the MockClientBuilder class
 */

package com.klarna.api.ordermanagement.client;

import com.klarna.api.ordermanagement.client.model.ErrorMessage;
import com.klarna.api.ordermanagement.client.model.Order;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;
import org.apache.commons.httpclient.HttpStatus;

import javax.ws.rs.core.MediaType;
import java.net.URI;

import static org.mockito.Matchers.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

/**
 * Jersey client mock builder. Can be used for mocking client
 * responses, statuses and errors.
 */
public class MockClientBuilder {

    private URI location = URI.create("");
    private Order order = mock(Order.class);
    private ErrorMessage errorMessage = mock(ErrorMessage.class);
    private int status = HttpStatus.SC_OK;

    public MockClientBuilder setOrderResponse(Order order) {
        this.order = order;
        return this;
    }

    public MockClientBuilder setLocation(URI location) {
        this.location = location;
        return this;
    }

    public MockClientBuilder setErrorMessageResponse(ErrorMessage errorMessage) {
        this.errorMessage = errorMessage;
        return this;
    }

    public MockClientBuilder setStatus(int status) {
        this.status = status;
        return this;
    }

    protected void buildClient(Client client, WebResource webResource) {
        when(client.resource(any(URI.class))).thenReturn(webResource);
    }

    protected void buildWebResource(WebResource webResource, WebResource.Builder builder) {
        when(webResource.type(MediaType.APPLICATION_JSON)).thenReturn(builder);
    }

    protected void buildBuilder(WebResource.Builder builder, ClientResponse clientResponse) {
        when(builder.method(eq("PATCH"), eq(ClientResponse.class), anyObject())).thenReturn(clientResponse);
        when(builder.post(eq(ClientResponse.class), anyObject())).thenReturn(clientResponse);
        when(builder.get(eq(ClientResponse.class))).thenReturn(clientResponse);
        when(builder.header(anyString(), anyObject())).thenReturn(builder);
    }

    protected void buildClientResponse(ClientResponse clientResponse) {
        when(clientResponse.getEntity(ErrorMessage.class)).thenReturn(errorMessage);
        when(clientResponse.getEntity(Order.class)).thenReturn(order);
        when(clientResponse.getStatus()).thenReturn(status);
        when(clientResponse.getLocation()).thenReturn(location);
    }

    public Client build() {
        Client client = mock(Client.class);
        ClientResponse clientResponse = mock(ClientResponse.class);
        WebResource.Builder builder = mock(WebResource.Builder.class);
        WebResource webResource = mock(WebResource.class);

        buildClient(client, webResource);
        buildWebResource(webResource, builder);
        buildBuilder(builder, clientResponse);
        buildClientResponse(clientResponse);

        return client;
    }

}
