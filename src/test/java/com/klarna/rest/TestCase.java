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
import org.mockito.MockitoAnnotations;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;

import static org.mockito.Mockito.when;

/**
 * Base test class.
 */
public abstract class TestCase extends junit.framework.TestCase {

    @Before
    public void initMocks() {
        MockitoAnnotations.initMocks(this.getClass());
    }

    public InputStream makeInputStream(String payload) throws IOException {
        ByteArrayOutputStream out = new ByteArrayOutputStream();
        out.write(payload.getBytes());
        return new ByteArrayInputStream(out.toByteArray());
    }
}
