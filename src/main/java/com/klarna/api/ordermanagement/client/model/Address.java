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
 * File containing the Address class
 */

package com.klarna.api.ordermanagement.client.model;

/**
 * Customer address.
 */
public class Address extends TransportObject {

    /**
     * Required. Max length is 255 characters.
     */
    public String given_name;

    /**
     * Required. Max length is 255 characters.
     */
    public String family_name;

    /**
     * Optional. Possible values: Mr, Ms, Mrs and Miss.
     */
    public String title;

    /**
     * Required street address, first line. Max length is 255 characters.
     */
    public String street_address;

    /**
     * Optional street address, second line. Max length is 255 characters.
     */
    public String street_address2;

    /**
     * Required. Max length is 255 characters.
     */
    public String postal_code;

    /**
     * Required. Max length is 255 characters.
     */
    public String city;

    /**
     * Required. ISO 3166 alpha-2, e.g. "GB".
     */
    public String country;

    /**
     * Required. Max length is 255 characters.
     */
    public String email;

    /**
     * Required. Max length is 255 characters.
     */
    public String phone;

}