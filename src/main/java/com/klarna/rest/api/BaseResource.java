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

import com.klarna.rest.api.model.ErrorMessage;
import com.sun.jersey.api.client.ClientHandlerException;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.ClientResponse.Status;
import com.sun.jersey.api.client.UniformInterfaceException;
import com.sun.jersey.api.client.WebResource;

import javax.ws.rs.core.Response.Status.Family;
import java.net.URI;
import java.util.Arrays;
import java.util.List;

import static javax.ws.rs.core.MediaType.APPLICATION_JSON_TYPE;
import static javax.ws.rs.core.Response.Status.Family.SUCCESSFUL;

/**
 * Base resource class.
 */
/* package */ abstract class BaseResource implements Resource {

    /**
     * Web API resource.
     */
    private WebResource resource;

    /**
     * Gets the URL for this resource.
     *
     * @return Absolute URL to the resource
     */
    public URI getLocation() {
        return this.getWebResource().getURI();
    }

    /**
     * Sets the URL to this resource.
     *
     * @param location Absolute URL to the resource
     */
    public void setLocation(final URI location) {
        this.resource = this.getWebResource().uri(location);
    }

    /**
     * Sets the URL to this resource.
     *
     * @param location Resource location
     */
    /* package */ void setWebResource(final WebResource location) {
        this.resource = location;
    }

    /**
     * Gets the resource.
     *
     * @return Internal resource
     */
    /* package */ WebResource getWebResource() {
        return this.resource;
    }

    /**
     * Performs a HTTP GET.
     *
     * @return Response helper
     */
    protected ApiResponse get() {
        ClientResponse response = this.getWebResource()
                .getRequestBuilder()
                .accept(APPLICATION_JSON_TYPE)
                .get(ClientResponse.class);

        return new ApiResponse(response).checkStatus();
    }

    /**
     * Performs a HTTP POST to the specified path.
     *
     * @param path Sub path
     * @param data Post data
     * @param <T> Data type
     * @return Response helper
     */
    protected <T> ApiResponse post(final String path, final T data) {
        ClientResponse response = this.getWebResource()
                .path(path)
                .getRequestBuilder()
                .type(APPLICATION_JSON_TYPE)
                .post(ClientResponse.class, data);

        return new ApiResponse(response).checkStatus();
    }

    /**
     * Performs a HTTP POST.
     *
     * @param data Post data
     * @param <T> Data type
     * @return Response helper
     */
    protected <T> ApiResponse post(final T data) {
        ClientResponse response = this.getWebResource()
                .getRequestBuilder()
                .type(APPLICATION_JSON_TYPE)
                .post(ClientResponse.class, data);

        return new ApiResponse(response).checkStatus();
    }

    /**
     * Performs a HTTP PATCH to the specified path.
     *
     * @param path Sub path
     * @param data Patch data
     * @param <T> Data type
     * @return Response helper
     */
    protected <T> ApiResponse patch(final String path, final T data) {
        ClientResponse response = this.getWebResource()
                .path(path)
                .getRequestBuilder()
                .type(APPLICATION_JSON_TYPE)
                .method("PATCH", ClientResponse.class, data);

        return new ApiResponse(response).checkStatus();
    }

    /**
     * HTTP response helper class.
     */
    /* package */ static class ApiResponse {

        /**
         * HTTP response object.
         */
        private final ClientResponse response;

        /**
         * Constructs a ApiResponse instance.
         *
         * @param response The HTTP response object.
         */
        protected ApiResponse(final ClientResponse response) {
            this.response = response;
        }

        /**
         * Checks the HTTP response status code.
         *
         * @return Same instance
         * @throws ApiException If the status is not successful
         */
        protected ApiResponse checkStatus() throws ApiException {
            Family family = this.response.getStatusInfo().getFamily();

            if (family.equals(SUCCESSFUL)) {
                return this;
            }

            ErrorMessage message;
            try {
                message = this.response.getEntity(ErrorMessage.class);
            } catch (ClientHandlerException e) {
                message = null;
            } catch (UniformInterfaceException e) {
                message = null;
            }

            throw new ApiException(this.response.getStatus(), message);
        }

        /**
         * Asserts if the status code of the response is the expected.
         *
         * @param status The expected HTTP status code.
         * @return Same instance.
         * @throws ProtocolException If the response status code is not expected
         */
        protected ClientResponse andExpect(final Status status) throws
                ProtocolException {
            if (status.getStatusCode() == this.response.getStatus()) {
                return this.response;
            }

            this.close();

            throw ProtocolException.unexpectedStatus(
                    this.response.getStatus());
        }

        /**
         * Asserts if the status code of the response is the expected.
         *
         * @param expected The expected HTTP status codes.
         * @return Same instance.
         * @throws ProtocolException If the response status code is not expected
         */
        protected ClientResponse andExpect(final Status... expected) throws
                ProtocolException {
            List<Status> statuses = Arrays.asList(expected);
            Status status = Status.fromStatusCode(this.response.getStatus());

            if (statuses.contains(status)) {
                return this.response;
            }

            this.close();

            throw ProtocolException.unexpectedStatus(
                    this.response.getStatus());
        }

        /**
         * Closes the response.
         *
         * @throws ClientHandlerException If there is an error closing the
         * response.
         */
        protected void close() throws ClientHandlerException {
            this.response.close();
        }
    }
}
