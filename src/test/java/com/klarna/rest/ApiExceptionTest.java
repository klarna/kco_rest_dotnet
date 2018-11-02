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

import com.klarna.rest.model.ApiException;
import com.klarna.rest.model.ErrorMessage;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.ArrayList;
import java.util.List;

import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class ApiExceptionTest extends TestCase {

    private static final int STATUS = 500;

    private ApiException exception;

    @Mock
    private ErrorMessage message;

    @Before
    public void setUp() {
        when(message.getCorrelationId())
                .thenReturn("corr-id");

        when(message.getErrorCode())
                .thenReturn("err-code");

        List<String> messages = new ArrayList<String>();
        messages.add("err-msg-1");
        messages.add("err-msg-2");

        when(message.getErrorMessages())
                .thenReturn(messages);

        exception = new ApiException(STATUS, message);
    }

    @Test
    public void testGetMessage() {
        assertEquals("err-code: err-msg-1, err-msg-2 (#corr-id)",
                exception.getMessage());
    }

    @Test
    public void testGetMessageReason() {
        exception = new ApiException(500, "Hello");

        assertEquals("Hello", exception.getMessage());
        assertEquals(500, exception.getHttpStatus());
    }

    @Test
    public void testGetMessageUnknown() {
        exception = new ApiException(599, "");
        assertEquals(599, exception.getHttpStatus());


        assertEquals("", exception.getMessage());
    }

    @Test
    public void testGetErrorMessage() {
        assertSame(message, exception.getErrorMessage());
    }

    @Test
    public void testGetHttpStatus() {
        assertEquals(STATUS, exception.getHttpStatus());
    }
}
