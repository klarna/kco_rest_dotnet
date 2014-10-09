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
import com.sun.jersey.api.client.ClientResponse;
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;

import static com.sun.jersey.api.client.ClientResponse.Status.BAD_REQUEST;
import static com.sun.jersey.api.client.ClientResponse.Status.CREATED;
import static com.sun.jersey.api.client.ClientResponse.Status.NO_CONTENT;
import static org.mockito.Mockito.when;

/**
 * Test cases for the ApiResponse class.
 */
@RunWith(MockitoJUnitRunner.class)
public class ApiResponseTest extends TestCase {

    @Rule
    public ExpectedException thrown = ExpectedException.none();

    @Mock private ClientResponse response;

    @Mock private ErrorMessage message;

    private BaseResource.ApiResponse helper;

    @Before
    public void setUp() {
         helper = new BaseResource.ApiResponse(response);
    }

    @Test
    public void testCheckStatus() {
        when(response.getStatusInfo())
                .thenReturn(BAD_REQUEST);
        when(response.getStatus())
                .thenReturn(BAD_REQUEST.getStatusCode());
        when(response.getEntity(ErrorMessage.class))
                .thenReturn(message);

        thrown.expect(ApiException.class);

        try {
            helper.checkStatus();
        } catch (ApiException ex) {
            assertSame(message, ex.getErrorMessage());
            assertEquals(BAD_REQUEST.getStatusCode(), ex.getHttpStatus());

            throw ex; // rethrow to check thrown exception
        }
    }

    @Test
    public void testAndExpect() {
        thrown.expect(ProtocolException.class);

        when(response.getStatus())
                .thenReturn(NO_CONTENT.getStatusCode());

        try {
            helper.andExpect(CREATED);
        } catch (ProtocolException ex) {
            assertEquals("Unexpected response status code: 204",
                    ex.getMessage());

            throw ex; // rethrow to check thrown exception
        }
    }
}
