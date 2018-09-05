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

package com.klarna.rest.api.model;

public class MerchantRequestedCheckbox extends Model {
    private String id;

    private Boolean checked;

    /**
     * Get id
     *
     * @return id
     **/
    public String getId() {
        return id;
    }

    public MerchantRequestedCheckbox setId(String id) {
        this.id = id;

        return this;
    }

    /**
     * Get checked status
     *
     * @return checked
     **/
    public Boolean getChecked() {
        return checked;
    }

    public MerchantRequestedCheckbox setChecked(Boolean checked) {
        this.checked = checked;
        return this;
    }
}