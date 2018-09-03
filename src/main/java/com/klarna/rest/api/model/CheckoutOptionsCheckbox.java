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

public class CheckoutOptionsCheckbox extends Model {
    /**
     * Identifier used when presenting data back to merchant.
     */
    private String id = null;

    /**
     * Text that will be displayed to the consumer aside the checkbox.
     * Links and formatting can be added using Markdown.
     */
    private String text = null;

    /**
     * Default state of the additional checkbox. It will use this value when loaded for the first time.
     */
    private Boolean checked = false;

    /**
     * Whether it is required for the consumer to check the additional checkbox box or not in order
     * to complete the purchase.
     */
    private Boolean required = false;


    /**
     * Gets the checkbox ID.
     *
     * @return ID
     */
    public String getId() {
        return this.id;
    }

    /**
     * Sets the checkbox ID.
     *
     * @param id Checkbox ID
     * @return Same instance
     */
    public CheckoutOptionsCheckbox setId(final String id) {
        this.id = id;

        return this;
    }

    /**
     * Gets the checkbox text.
     *
     * @return Text
     */
    public String getText() {
        return this.text;
    }

    /**
     * Sets the checkbox text.
     *
     * @param text Checkbox text
     * @return Same instance
     */
    public CheckoutOptionsCheckbox setText(final String text) {
        this.text = text;

        return this;
    }

    /**
     * Gets whether the checkbox default state is checked.
     *
     * @return If it is checked
     */
    public Boolean getChecked() {
        return this.checked;
    }

    /**
     * Sets whether the checkbox is checked by default
     *
     * @param checked If checkbox should be checked by default
     * @return Same instance
     */
    public CheckoutOptionsCheckbox setChecked(final Boolean checked) {
        this.checked = checked;

        return this;
    }

    /**
     * Gets whether the checkbox is required.
     *
     * @return If it is required
     */
    public Boolean getRequired() {
        return this.required;
    }

    /**
     * Sets whether the checkbox is required.
     *
     * @param required If checkbox is required
     * @return Same instance
     */
    public CheckoutOptionsCheckbox setRequired(final Boolean required) {
        this.required = required;

        return this;
    }
}
