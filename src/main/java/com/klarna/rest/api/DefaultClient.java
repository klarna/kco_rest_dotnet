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

import com.sun.jersey.api.client.WebResource;
import com.sun.jersey.client.apache.ApacheHttpClient;
import com.sun.jersey.client.apache.config.ApacheHttpClientConfig;
import com.sun.jersey.client.apache.config.DefaultApacheHttpClientConfig;
import org.apache.commons.httpclient.HttpState;
import org.apache.commons.httpclient.UsernamePasswordCredentials;
import org.apache.commons.httpclient.auth.AuthScope;

import java.net.URI;

import static com.sun.jersey.api.json.JSONConfiguration.FEATURE_POJO_MAPPING;
import static com.sun.jersey.client.apache.config.ApacheHttpClientConfig
        .PROPERTY_PREEMPTIVE_AUTHENTICATION;
import static org.apache.commons.httpclient.params.HttpClientParams.USER_AGENT;

/**
 * Client facade.
 */
public final class DefaultClient implements Client {

    /**
     * Base URL for the client.
     */
    private final WebResource root;

    /**
     * HTTP client instance.
     */
    private final ApacheHttpClient client;

    /**
     * Constructs a client instance.
     *
     * @param client HTTP transport client
     * @param baseUrl Base URL of the API
     */
    /* package */ DefaultClient(final ApacheHttpClient client,
                                final URI baseUrl
    ) {
        this.client = client;
        this.root = this.client.resource(baseUrl);
    }

    @Override
    public CheckoutOrder newCheckoutOrder() {
        return new DefaultCheckoutOrder(root);
    }

    @Override
    public CheckoutOrder newCheckoutOrder(final String checkoutOrderID) {
        return new DefaultCheckoutOrder(root, checkoutOrderID);
    }

    @Override
    public Order newOrder(final String orderId) {
        return new DefaultOrder(root, orderId);
    }

    @Override
    public Capture newCapture(final String orderId) {
        DefaultOrder order = (DefaultOrder) this.newOrder(orderId);

        return new DefaultCapture(order.getWebResource());
    }

    @Override
    public Capture newCapture(final String orderId,
                              final String captureId
    ) {
        DefaultCapture capture = (DefaultCapture) this.newCapture(orderId);
        capture.setWebResource(capture.getWebResource().path(captureId));

        return capture;
    }

    @Override
    public void setConnectTimeout(final Integer timeout) {
        this.client.setConnectTimeout(timeout);
    }

    @Override
    public void setReadTimeout(final Integer timeout) {
        this.client.setReadTimeout(timeout);
    }

    @Override
    public void setProxy(final String scheme,
                         final String host,
                         final int port
    ) {
        String uri = scheme + "://" + host + ":" + port;

        client.getProperties()
                .put(ApacheHttpClientConfig.PROPERTY_PROXY_URI, uri);
    }

    @Override
    public void setProxy(final String scheme,
                         final String host,
                         final int port,
                         final String username,
                         final String password
    ) {
        this.setProxy(scheme, host, port);

        client.getClientHandler().getHttpClient().getState()
                .setProxyCredentials(
                        new AuthScope(host, port),
                        new UsernamePasswordCredentials(username, password));
    }

    /**
     * Constructs a client instance.
     *
     * @param merchantId Merchant Id
     * @param sharedSecret Shared secret
     * @param baseUrl Base URL of the API
     * @param agent User agent
     * @return Client instance
     */
    public static Client newInstance(final String merchantId,
                                     final String sharedSecret,
                                     final URI baseUrl,
                                     final UserAgent agent
    ) {
        ApacheHttpClientConfig clientConfig =
                new DefaultApacheHttpClientConfig();

        clientConfig.getFeatures()
                .put(FEATURE_POJO_MAPPING, Boolean.TRUE);

        clientConfig.getClasses()
                .add(ObjectMapperProvider.class);

        HttpState state = clientConfig.getState().getHttpState();
        state.setCredentials(
                new AuthScope(baseUrl.getHost(), baseUrl.getPort()),
                new UsernamePasswordCredentials(merchantId, sharedSecret)
        );

        clientConfig.getProperties()
                .put(PROPERTY_PREEMPTIVE_AUTHENTICATION, Boolean.TRUE);

        ApacheHttpClient client = ApacheHttpClient.create(clientConfig);

        client.getClientHandler()
                .getHttpClient()
                .getParams()
                .setParameter(USER_AGENT, agent.toString());

        return new DefaultClient(client, baseUrl);
    }

    /**
     * Constructs a client instance with the default user agent.
     *
     * @param merchantId Merchant Id
     * @param sharedSecret Shared secret
     * @param baseUrl Base URL of the API
     * @return Client instance
     */
    public static Client newInstance(final String merchantId,
                                     final String sharedSecret,
                                     final URI baseUrl
    ) {
        return newInstance(
                merchantId,
                sharedSecret,
                baseUrl,
                new KlarnaUserAgent());
    }
}
