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
 * File containing the UpdateShippingInfo class
 */

package com.klarna.api.ordermanagement.client.model.request;

import com.klarna.api.ordermanagement.client.model.ShippingInfo;

import java.util.Collections;
import java.util.List;

/**
 * Append new shipping info to a capture.
 */
public class AddShippingInfo extends Request {

    /**
     * Required list of shipping info.
     */
    public List<ShippingInfo> shipping_info;

    /**
     * Append new shipping info.
     *
     * @param shipping_info List of shipping info.
     */
    public AddShippingInfo(List<ShippingInfo> shipping_info) {
        this.shipping_info = Collections.unmodifiableList(shipping_info);
    }

}
