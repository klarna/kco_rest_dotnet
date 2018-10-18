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

package com.klarna.rest;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import javax.ws.rs.core.Response;
import java.util.LinkedList;

@RunWith(MockitoJUnitRunner.class)
public class ApiResponseTest extends TestCase {

    private ApiResponse response;

    @Before
    public void setUp() {
        response = new ApiResponse();
        response.setStatus(200);
        response.setBody("hello".getBytes());

        LinkedList<String> contentType = new LinkedList<>();
        contentType.add("application/json;utf8");

        LinkedList<String> contentLength = new LinkedList<>();
        contentLength .add("application/json;utf8");

        response.setHeader("Content-Type", contentType)
                .setHeader("Content-Length", contentLength );
    }

    @Test
    public void testEmptyResponse() {
        ApiResponse response = new ApiResponse();
        assertEquals(0, response.getStatus());
        assertNull(response.getBody());
        assertNull(response.getHeaders());
        assertNull(response.getHeader(""));
    }

    @Test
    public void testGetters() {
        assertEquals(200, response.getStatus());
        assertEquals("hello", new String(response.getBody()));
        assertNotNull(response.getHeaders());

        LinkedList<String> type = new LinkedList<>();
        type.add("application/json;utf8");
        assertEquals(type, response.getHeader("Content-Type"));
        assertNull(response.getHeader("Wrong-Header"));
    }

    @Test
    public void testIsSuccessfull() {
        assertTrue(response.isSuccessful());

        response.setStatus(500);
        assertFalse(response.isSuccessful());
    }

    @Test
    public void testExpectedStatusCode() {
        assertSame(response, response.expectStatusCode(Response.Status.fromStatusCode(200)));
    }

    @Test
    public void testExpectedMultipleStatusCodes() {
        assertSame(response, response.expectStatusCode(
                Response.Status.fromStatusCode(100),
                Response.Status.fromStatusCode(200),
                Response.Status.fromStatusCode(300)
        ));
    }

    @Test(expected = ProtocolException.class)
    public void testUnexpectedStatusCode() {
        response.expectStatusCode(Response.Status.fromStatusCode(404));
    }

    @Test
    public void testExpectedContentType() {
        assertSame(response, response.expectContentType("application/json;utf8"));
        assertSame(response, response.expectContentType("application/json"));
    }

    @Test(expected = ContentTypeException.class)
    public void testUnexpectedContentType() {
        assertSame(response, response.expectContentType("application/octet-stream"));
    }

    @Test(expected = ContentTypeException.class)
    public void testMissingContentTypeHeader() {
        response.setHeaders(null);
        assertSame(response, response.expectContentType("application/octet-stream"));
    }

    @Test
    public void testValidator() {
        assertSame(response, response.expectSuccessful());
    }

    @Test(expected = ApiException.class)
    public void testValidatorBadResponse() {
        response.setStatus(404);
        response.expectSuccessful();
    }

    @Test
    public void testValidatorErrorMessage() {
        try {
            response.setStatus(401);
            response.setBody("{ \"error_code\" : \"111\", \"error_messages\" : [\"Wrong order_total\"], \"correlation_id\" : \"123-123-123\" }".getBytes());
            response.expectSuccessful();
            fail();
        } catch (ApiException e) {
            assertEquals("111: Wrong order_total (#123-123-123)", e.getMessage());
        }
    }
}
