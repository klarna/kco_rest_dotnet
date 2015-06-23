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
import com.sun.jersey.api.client.WebResource;
import com.sun.jersey.client.apache4.ApacheHttpClient4;
import org.mockito.Mock;

import javax.ws.rs.core.MultivaluedMap;

/**
 * Base resource test class.
 */
public abstract class ResourceTestCase extends TestCase {

    @Mock protected WebResource root;

    @Mock protected WebResource.Builder builder;

    @Mock protected ClientResponse response;

    @Mock protected MultivaluedMap<String, String> headers;

    @Mock protected ApacheHttpClient4 client;
}
