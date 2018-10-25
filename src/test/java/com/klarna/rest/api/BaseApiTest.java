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

package com.klarna.rest.api;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.core.JsonParseException;
import com.klarna.rest.FakeHttpUrlConnectionTransport;
import com.klarna.rest.TestCase;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.io.IOException;
import java.util.HashMap;

@RunWith(MockitoJUnitRunner.class)
public class BaseApiTest extends TestCase {

    class BaseApiImpl extends BaseApi {
        BaseApiImpl(FakeHttpUrlConnectionTransport transport) {
            super(transport);
        }
    }

    static class Hello {
        @JsonProperty("hello")
        public String hello;


    }

    @Test
    public void testBuildQueryStringNull() {
        assertEquals("", BaseApi.buildQueryString(null));
    }

    @Test
    public void testBuildQueryStringWithParams() {
        HashMap<String, String> params = new HashMap<>();
        params.put("hello", "world");
        params.put("page", "1");
        assertTrue(BaseApi.buildQueryString(params).contains("page=1"));
        assertTrue(BaseApi.buildQueryString(params).contains("hello=world"));
        assertTrue(BaseApi.buildQueryString(params).contains("&"));
    }

    @Test
    public void testBuildQueryStringWithIllegalParams() {
        HashMap<String, String> params = new HashMap<>();
        params.put("hello", "a&b");
        params.put("page", "1 2");
        params.put("limit", "a=b");

        assertTrue(BaseApi.buildQueryString(params).contains("limit=a%3Db"));
        assertTrue(BaseApi.buildQueryString(params).contains("hello=a%26b"));
        assertTrue(BaseApi.buildQueryString(params).contains("page=1+2"));
        assertTrue(BaseApi.buildQueryString(params).indexOf("&") != BaseApi.buildQueryString(params).lastIndexOf("&"));
    }

    @Test
    public void testFromJson() throws IOException {
        FakeHttpUrlConnectionTransport transport = new FakeHttpUrlConnectionTransport();
        BaseApiImpl api = new BaseApiImpl(transport);

        byte[] json = "{\"hello\": \"world\"}".getBytes();
        api.fromJson(json, Hello.class);
    }

    @Test(expected = JsonParseException.class)
    public void testInvalidJson() throws IOException {
        FakeHttpUrlConnectionTransport transport = new FakeHttpUrlConnectionTransport();
        BaseApiImpl api = new BaseApiImpl(transport);

        byte[] json = "{\"hello\": \"world\" 123".getBytes();
        api.fromJson(json, Hello.class);
    }
}
