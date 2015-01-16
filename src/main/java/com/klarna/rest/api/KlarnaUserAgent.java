/*
 * Copyright 2015 Klarna AB
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

import static java.lang.System.getProperty;

/**
 * User agent class for providing environmental information
 * through a user agent header.
 */
public final class KlarnaUserAgent extends DefaultUserAgent {

    /**
     * Constructs a user agent instance.
     */
    public KlarnaUserAgent() {
        this.add(this.newField()
                .setKey(LIBRARY)
                .setName("Klarna.kco_rest_java")
                .setVersion(Client.VERSION));

        this.add(this.newField()
                .setKey(OS)
                .setName(getProperty("os.name"))
                .setVersion(getProperty("os.version")));

        this.add(this.newField()
                .setKey(LANGUAGE)
                .setName("Java")
                .setVersion(getProperty("java.version"))
                .setOptions(
                        "Vendor/" + getProperty("java.vendor"),
                        "VM/" + getProperty("java.vm.name")
                ));
    }
}
