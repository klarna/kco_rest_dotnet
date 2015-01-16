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

package com.klarna.rest.api.model.request;

import com.klarna.rest.api.TestCase;
import com.klarna.rest.api.model.ShippingInfo;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.ArrayList;
import java.util.List;

/**
 * Test cases for the AddShippingInfo class.
 */
@RunWith(MockitoJUnitRunner.class)
public class AddShippingInfoTest extends TestCase {

    private AddShippingInfo append;

    @Before
    public void setUp() {
        append = new AddShippingInfo();
    }

    @Test
    public void testGetShippingInfo() {
        assertNull(append.getShippingInfo());

        List<ShippingInfo> info = new ArrayList<ShippingInfo>();

        append.setShippingInfo(info);

        assertSame(info, append.getShippingInfo());
    }
}
