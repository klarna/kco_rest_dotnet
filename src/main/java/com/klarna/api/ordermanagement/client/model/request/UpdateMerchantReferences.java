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
 * File containing the UpdateMerchantReferences class
 */

package com.klarna.api.ordermanagement.client.model.request;

/**
 * Update one or both merchant references. To clear a reference, set its value to "" (empty string).
 */
public class UpdateMerchantReferences extends Request {

    /**
     * Optional merchant reference 1. Max 255 characters.
     */
    public final String merchant_reference1;

    /**
     * Optional merchant reference 2. Max 255 characters.
     */
    public final String merchant_reference2;

    /**
     * Update one or both merchant references. To clear a
     * reference, set its value to "" (empty string).
     *
     * @param merchant_reference1 Merchant reference 1
     * @param merchant_reference2 Merchant reference 2
     */
    public UpdateMerchantReferences(String merchant_reference1, String merchant_reference2) {
        this.merchant_reference1 = merchant_reference1;
        this.merchant_reference2 = merchant_reference2;
    }

}
